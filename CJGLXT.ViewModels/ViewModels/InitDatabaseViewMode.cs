using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CJGLXT.Data.Common;
using CJGLXT.Data.DataContexts;
using CJGLXT.ViewModels.Services;
using CJGLXT.ViewModels.ViewModels.Common;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CJGLXT.ViewModels.ViewModels
{
    public class InitDatabaseViewMode:ObservableObject
    {
        public IDialogService DialogService { get; }

        public InitDatabaseViewMode(IDialogService dialogService)
        {
            DialogService = dialogService;
        }

        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=CJGLXTContext;Trusted_Connection=True;MultipleActiveResultSets=true";
        public string ConnectionString
        {
            get => _connectionString;
            set => Set(ref _connectionString, value);
        }

        private double _progressValue=0;
        public double ProgressValue
        {
            get => _progressValue;
            set => Set(ref _progressValue, value);
        }

        private double _progressMaximum = 10;
        public double ProgressMaximum
        {
            get => _progressMaximum;
            set => Set(ref _progressMaximum, value);
        }

        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get => _isEnabled;
            set => Set(ref _isEnabled, value);
        }

        private bool _isLoading = false;
        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value);
        }

        private bool _isSuccess = false;
        public bool IsSuccess
        {
            get => _isSuccess;
            set => Set(ref _isSuccess, value);
        }

        private string _message;
        public string Message
        {
            get => _message;
            set => Set(ref _message, value);
        }

        public ICommand ValidateCommand => new RelayCommand(OnValidate);
        protected async void OnValidate()
        {
            IsEnabled = false;
            try
            {
                Message = "请稍后";
                SqlServeStrings.DefaultConnectionString = ConnectionString;
                using (var db = new SqlServerDb())
                {
                    var dbCreator = db.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                    if (await dbCreator.ExistsAsync())
                    {
                        Message = "数据库连接正常";
                        IsSuccess = true;
                    }
                    else
                    {
                        Message = "数据库连接失败,请先创建数据库";
                        IsSuccess = false;
                    }
                }
            }
            catch (Exception e)
            {
                _isSuccess = false;
                Message = $"初始化数据库失败";
                await DialogService.ShowAsync("数据库连接失败", e.InnerException?.Message ?? e.Message);
            }
            IsEnabled = true;
        }

        public ICommand CreateDatabaseCommand => new RelayCommand(OnCreateDatabase);
        protected async void OnCreateDatabase()
        {
            IsEnabled = false;
            IsLoading = true;
            try
            {
                ProgressMaximum = 10;
                ProgressValue = 1;
                Message = "正在连接数据库";
                SqlServeStrings.DefaultConnectionString = ConnectionString;
                using (var db = new SqlServerDb())
                {
                    var dbCreator = db.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                    if (!await dbCreator.ExistsAsync())
                    {
                        ProgressValue = 2;
                        Message = "创建数据库中";
                        await db.Database.EnsureCreatedAsync();
                        ProgressValue = 3;
                        Message = "初始化种子数据";
                        await CopyDataTables(db);
                        ProgressValue = 10;
                        Message = "数据库初始化成功";
                        IsSuccess = true;
                    }
                    else
                    {
                        ProgressValue = 10;
                        Message = $"数据库已经存在，请删除后重试";
                        IsSuccess = false;
                    }
                }
            }
            catch (Exception e)
            {
                Message = $"初始化数据库失败";
                await DialogService.ShowAsync("数据库连接失败", e.InnerException?.Message ?? e.Message);
                IsSuccess = false;
            }
            IsLoading = false;
            IsEnabled = true;
        }

        private async Task CopyDataTables(SqlServerDb db)
        {
            Message = "添加种子数据";
            ProgressValue = 4;
            await Task.Delay(1000);
            Message = "添加化学生数据";
            ProgressValue = 4;
            await db.Students.AddRangeAsync(SeedData.GetStudents());



            await db.SaveChangesAsync();
        }
    }
}
