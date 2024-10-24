using Student_Support_System.Service.Interface;

namespace Student_Support_System.ViewModel
{
    public class StudentSupportMasterViewModel : BaseViewModel
    {
        IHttpClientService _httpClient;
        public StudentSupportMasterViewModel(IHttpClientService httpClientService)
        {
            _httpClient = httpClientService;
        }

        private string _test = "12345";
        public string Test
        {
            get => _test;
            set
            {
                _test = value;
                OnPropertyChanged();
            }
        }
    }
}
