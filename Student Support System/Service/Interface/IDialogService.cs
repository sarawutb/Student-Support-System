using Microsoft.VisualBasic;

namespace StudentSupportSystem.Service.Interface
{
    public interface IDialogService
    {
        void DialogSuccess(string msg);
        void DialogInfo(string msg);
        void DialogWarning(string msg);
        Task DialogSuccessAsync(string msg);
        Task DialogInfoAsync(string msg);
        Task DialogWarningAsync(string msg);
        Task DialogErrorAsync(string msg);
        Task DialogErrorAsync(Exception err);
        Task<bool> DialogYesOrNo(string msg);
    }
}
