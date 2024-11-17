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
       
        public async Task DialogErrorAsync(string msg)
        {
            await _jSRuntime.InvokeVoidAsync(Dialog.DialogError, msg);
        }
        
        public async Task DialogErrorAsync(Exception err)
        {
            await _jSRuntime.InvokeVoidAsync(Dialog.DialogError, err.ToString());
        }

        public void DialogInfo(string msg)
        {
            _jSRuntime.InvokeVoidAsync(Dialog.DialogInfo, msg);
        }

        public async Task DialogInfoAsync(string msg)
        {
            await _jSRuntime.InvokeVoidAsync(Dialog.DialogInfoAsync, msg);
        }

        public void DialogSuccess(string msg)
        {
            _jSRuntime.InvokeVoidAsync(Dialog.DialogSuccess, msg);
        }

        public async Task DialogSuccessAsync(string msg)
        {
            await _jSRuntime.InvokeVoidAsync(Dialog.DialogSuccessAsync, msg);
        }

        public void DialogWarning(string msg)
        {
            _jSRuntime.InvokeVoidAsync(Dialog.DialogWarning, msg);
        }

        public async Task DialogWarningAsync(string msg)
        {
            await _jSRuntime.InvokeVoidAsync(Dialog.DialogWarningAsync, msg);
        }

        public async Task<bool> DialogYesOrNo(string msg)
        {
            return await _jSRuntime.InvokeAsync<bool>(Dialog.DialogYesOrNo, msg);
        }
    }
}
