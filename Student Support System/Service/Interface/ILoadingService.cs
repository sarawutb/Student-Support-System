using StudentSupportSystem.Model;

namespace StudentSupportSystem.Service.Interface
{
    public interface ILoadingService
    {
        T Loading<T>(Func<T> actionEvent);
        Task<T> LoadingAsync<T>(Task<T> task);
        Task<T> LoadingAsync<T>(Func<Task<T>> task);
        Task LoadingShow();
        Task LoadingHide();
    }
}
