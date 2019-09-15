using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.ViewModels.Models;
using CJGLXT.ViewModels.Services;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.ViewModels
{
    public class LoginViewModel:ObservableObject
    {
        public IDialogService DialogService { get; }
        public ILoginService LoginService { get; }

        public LoginViewModel(IDialogService dialogService, ILoginService loginService)
        {
            DialogService = dialogService;
            LoginService = loginService;
        }

        public async Task<bool> Login()
        {
            IsEnabled = false;

            bool result = true;
            if (String.IsNullOrWhiteSpace(User.UserId))
            {
                await DialogService.ShowAsync("验证未通过", "Property 'UserId' cannot be empty 请更正错误后重试！");
                result = false;
            }
            if (result)
            {
                try
                {
                    result = await LoginService.LoginAsync(User);
                    if (!result)
                        await DialogService.ShowAsync("登录失败", "账号不存或者密码错误");
                }
                catch (Exception e)
                {
                    await DialogService.ShowAsync("发生异常", e.Message);
                    result = false;
                }
            }
            IsEnabled = true;

            return result;
        }

        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get => _isEnabled;
            set => Set(ref _isEnabled, value);
        }

        private UserModel _user=new UserModel();
        public UserModel User
        {
            get => _user;
            set => Set(ref _user, value);
        }
    }
}
