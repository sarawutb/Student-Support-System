using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using StudentSupportSystem.Model;
using StudentSupportSystem.Service.Implement;
using StudentSupportSystem.Service.Interface;
using System.Net;

namespace StudentSupportSystem.ViewModel
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly IStudentSupportMasterService _supportMasterService;
        private readonly ILoadingService _loadingService;
        private readonly IJSRuntime _jSRuntime;
        private readonly AuthenticationService _authenticationService;
        private readonly NavigationManager _navigationManager;

        public LoginViewModel(IDialogService dialogService,
            IStudentSupportMasterService supportMasterService,
            ILoadingService loadingService,
            IJSRuntime jSRuntime,
            AuthenticationService authenticationService,
            NavigationManager navigation)
        {
            _dialogService = dialogService;
            _supportMasterService = supportMasterService;
            _loadingService = loadingService;
            _jSRuntime = jSRuntime;
            _authenticationService = authenticationService;
            _navigationManager = navigation;
        }

        [ObservableProperty]
        public string email;

        [ObservableProperty]
        public string password;

        public async Task OnLogin()
        {
            try
            {
                var chk = await ValidateLogin();
                if (!chk)
                {
                    var formLoginModel = new FormLoginModel
                    {
                        email = Email,
                        password = Password
                    };
                    await _loadingService.LoadingShow();
                    var obj = await _supportMasterService.Login(formLoginModel);
                    if (obj != null)
                    {
                        await _authenticationService.SignIn(obj.Token);
                        _navigationManager.NavigateTo("/");
                    }
                    else
                    {
                        await _dialogService.DialogWarningAsync("อีเมล หรือ รหัสผ่านไม่ถูกต้อง");
                    }
                }
            }
            catch (Exception ex)
            {
                await _loadingService.LoadingHide();
                await _dialogService.DialogWarningAsync("อีเมล หรือ รหัสผ่านไม่ถูกต้อง");
            }
            finally
            {
                await _loadingService.LoadingHide();
            }
        }

        public async Task<bool> ValidateLogin()
        {
            bool _state = true;
            if (string.IsNullOrEmpty(Email))
            {
                await _dialogService.DialogWarningAsync("กรุณากรอกอีเมล");
            }
            else if (string.IsNullOrEmpty(Password))
            {
                await _dialogService.DialogWarningAsync("กรุณากรอกรหัสผ่าน");
            }
            else
            {
                _state = false;
            }
            return _state;
        }

        public async Task IsSignIn()
        {
            var chkIsSignIn = await _authenticationService.IsSignIn();
            if (chkIsSignIn)
            {
                _navigationManager.NavigateTo("/");
            }
        }
    }
}
