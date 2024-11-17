using Microsoft.JSInterop;
using StudentSupportSystem.Model;
using StudentSupportSystem.Service.Interface;

namespace StudentSupportSystem.ViewModel
{
    public class ModalAddCommitCrimeStdViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly IStudentSupportMasterService _supportMasterService;
        private readonly ILoadingService _loadingService;
        private readonly IJSRuntime _jSRuntime;

        public ModalAddCommitCrimeStdViewModel(IDialogService dialogService, IStudentSupportMasterService supportMasterService, ILoadingService loadingService, IJSRuntime jSRuntime)
        {
            _dialogService = dialogService;
            _supportMasterService = supportMasterService;
            _loadingService = loadingService;
            _jSRuntime = jSRuntime;
        }
        private List<BreachDisciplineMasterModel> _lstBreachDisciplineMst = new List<BreachDisciplineMasterModel>();
        public List<BreachDisciplineMasterModel> LstBreachDisciplineMst
        {
            get => _lstBreachDisciplineMst;
            set
            {
                _lstBreachDisciplineMst = value;
                OnPropertyChanged();
            }
        }

        private List<int> _lstBreachDisciplineMstId = new List<int>();
        public List<int> lstBreachDisciplineMstId
        {
            get => _lstBreachDisciplineMstId;
            set
            {
                _lstBreachDisciplineMstId = value;
                OnPropertyChanged();
            }
        }

        public async Task GetBreachDisciplineMst()
        {
            try
            {
                LstBreachDisciplineMst = await _loadingService.LoadingAsync(_supportMasterService.GetBreachDisciplineMaster());
            }
            catch (Exception ex)
            {
                await _dialogService.DialogErrorAsync(ex);
            }
        }
    }
}
