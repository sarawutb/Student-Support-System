using Microsoft.JSInterop;
using StudentSupportSystem.Service.Interface;

namespace StudentSupportSystem.Service.Implement
{
    public class LoadingService : ILoadingService
    {
        private const string LoadingShowName = "LoadingShow";
        private const string LoadingHideName = "LoadingHide";
        private readonly IJSRuntime _jSRuntime;

        public LoadingService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }

        public T Loading<T>(Func<T> actionEvent)
        {
            T Result = default(T);
            _ = LoadingShow();
            Result = actionEvent();
            _ = LoadingHide();
            return Result;
        }


        public async Task<T> LoadingAsync<T>(Func<Task<T>> task)
        {
            T? Result = default(T);
            await LoadingShow();
            Result = await task.Invoke();
            await LoadingHide();
            return Result;
        }

        public async Task<T> LoadingAsync<T>(Task<T> task)
        {
            T? Result = default(T);
            await LoadingShow();
            Result = await task;
            await LoadingHide();
            return Result;
        }

        public async Task LoadingHide()
        {
            await _jSRuntime.InvokeVoidAsync(LoadingHideName);
        }

        public async Task LoadingShow()
        {
            await _jSRuntime.InvokeVoidAsync(LoadingShowName);
        }
    }
}
