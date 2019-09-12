using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.App.Services;
using CJGLXT.App.Services.DataServiceFactory;
using CJGLXT.ViewModels.Services;
using CJGLXT.ViewModels.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CJGLXT.App.Configuration
{
    public class ServiceLocator : IDisposable
    {
        private static readonly ConcurrentDictionary<int, ServiceLocator> _serviceLocators = new ConcurrentDictionary<int, ServiceLocator>();

        private static ServiceProvider _rootServiceProvider = null;

        public static void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IDataServiceFactory, DataServiceFactory>();
            serviceCollection.AddSingleton<IStudentService, StudentService>();
            serviceCollection.AddSingleton<IDialogService, DialogService>();

            serviceCollection.AddTransient<StudentDetailsViewModel>();

            _rootServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public static ServiceLocator Current(int id = 0)
        {
            return _serviceLocators.GetOrAdd(id, key => new ServiceLocator());
        }

        public static void DisposeCurrent(int id = 0)
        {
            if (_serviceLocators.TryRemove(id, out ServiceLocator current))
            {
                current.Dispose();
            }
        }

        private IServiceScope _serviceScope = null;

        private ServiceLocator()
        {
            _serviceScope = _rootServiceProvider.CreateScope();
        }

        public T GetService<T>()
        {
            return GetService<T>(true);
        }

        public T GetService<T>(bool isRequired)
        {
            if (isRequired)
            {
                return _serviceScope.ServiceProvider.GetRequiredService<T>();
            }
            return _serviceScope.ServiceProvider.GetService<T>();
        }

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _serviceScope?.Dispose();
            }
        }
        #endregion
    }
}
