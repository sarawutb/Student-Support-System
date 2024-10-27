namespace StudentSupportSystem.Service.Interface
{
    public interface IHttpClientService
    {
        Task<T> Get<T>(string Url);
        Task<TR> Post<T, TR>(string Url, T obj);
        Task<TR> Put<T, TR>(string Url, T obj);
        Task<T> Delete<T>(string Url, T obj);
    }
}
