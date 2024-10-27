using Microsoft.JSInterop;
using StudentSupportSystem.Model;
using StudentSupportSystem.Service.Interface;

namespace StudentSupportSystem.Service.Implement
{
    public class DialogService : IDialogService
    {
        private readonly IJSRuntime _jSRuntime;

        public DialogService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }
        public async void DialogError(string msg)
        {
            await _jSRuntime.InvokeVoidAsync(Dialog.DialogError, msg);
        }

        public async void DialogInfo(string msg)
        {
            await _jSRuntime.InvokeVoidAsync(Dialog.DialogInfo, msg);
        }

        public async void DialogSuccess(string msg)
        {
            await _jSRuntime.InvokeVoidAsync(Dialog.DialogSuccess, msg);
        }

        public async void DialogWarning(string msg)
        {
            await _jSRuntime.InvokeVoidAsync(Dialog.DialogWarning, msg);
        }

        public async Task<bool> DialogYesOrNo(string msg)
        {
            return await _jSRuntime.InvokeAsync<bool>(Dialog.DialogYesOrNo, msg);
        }
    }
}
