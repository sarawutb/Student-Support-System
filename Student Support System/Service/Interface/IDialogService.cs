using Microsoft.VisualBasic;

namespace StudentSupportSystem.Service.Interface
{
    public interface IDialogService
    {
        Task DialogSuccess(string msg);
        Task DialogInfo(string msg);
        Task DialogWarning(string msg);
        Task DialogError(string msg);
        Task DialogError(Exception err);
        Task<bool> DialogYesOrNo(string msg);
    }
}
