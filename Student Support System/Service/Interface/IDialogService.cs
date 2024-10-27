using Microsoft.VisualBasic;

namespace StudentSupportSystem.Service.Interface
{
    public interface IDialogService
    {
        void DialogSuccess(string msg);
        void DialogInfo(string msg);
        void DialogWarning(string msg);
        void DialogError(string msg);
        Task<bool> DialogYesOrNo(string msg);
    }
}
