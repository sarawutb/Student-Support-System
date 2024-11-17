using StudentSupportSystem.Model;
using StudentSupportSystem.Service.Interface;

namespace StudentSupportSystem.ViewModel
{
    public class StudentSupportMasterViewModel : BaseViewModel
    {
        private readonly IStudentSupportMasterService _supportMasterService;
        private readonly ILoadingService _loadingService;
        private readonly IDialogService _dialogService;
        public StudentSupportMasterViewModel(IStudentSupportMasterService supportMasterService, ILoadingService loadingService, IDialogService dialogService)
        {
            _supportMasterService = supportMasterService;
            _loadingService = loadingService;
            _dialogService = dialogService;
        }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }

        private bool _isSsearchText = true;
        public bool IsSearchText
        {
            get => _isSsearchText;
            set
            {
                _isSsearchText = value;
                OnPropertyChanged();
            }
        }

        private int? _searchType;
        public int? SearchType
        {
            get => _searchType;
            set
            {
                _searchType = value;
                if (_searchType != null)
                {
                    IsSearchText = (_searchType == 0);
                }
                else
                {
                    IsSearchText = true;
                    SearchText = string.Empty;
                }
                OnPropertyChanged();
            }
        }

        private List<StudentSupportMasterModel> _lstStudentSupportMaster = new List<StudentSupportMasterModel>();
        public List<StudentSupportMasterModel> LstStudentSupportMaster
        {
            get => _lstStudentSupportMaster;
            set
            {
                _lstStudentSupportMaster = value;
                OnPropertyChanged();
            }
        }

        public async Task RemoveStudentSupportMaster(int Id)
        {
            try
            {
                var _state = await _dialogService.DialogYesOrNo(ResourceSystemMessenger.AreYouSureYouWantToDeleteTheItem);
                if (_state)
                {
                    var _result = await _loadingService.LoadingAsync(_supportMasterService.RemoveStudentSupportMaster(Id));
                    if (_result)
                    {
                        var _indexData = LstStudentSupportMaster.Where(d => d.Id == Id).SingleOrDefault();
                        _lstStudentSupportMaster.Remove(_indexData!);
                        LstStudentSupportMaster = _lstStudentSupportMaster;
                        _dialogService.DialogSuccess(ResourceSystemMessenger.Successful);
                    }
                    else
                    {
                        _dialogService.DialogWarning(ResourceSystemMessenger.TransactionFailed);
                    }
                }
            }
            catch (Exception ex)
            {
                await _dialogService.DialogErrorAsync(ex);
            }
        }

        public async Task GetStudentSupportMasterAll()
        {
            try
            {
                if (!IsSearchText)
                {
                    if (string.IsNullOrEmpty(_searchText))
                    {
                        _dialogService.DialogInfo(ResourceSystemMessenger.PleaseFillInTheInformationToSearch);
                    }
                    else
                    {
                        LstStudentSupportMaster = await _loadingService.LoadingAsync(_supportMasterService.GetStudentSupportMasterAll(_searchType, _searchText));
                    }
                }
                else
                {
                    LstStudentSupportMaster = await _loadingService.LoadingAsync(_supportMasterService.GetStudentSupportMasterAll());
                }
                if (!string.IsNullOrEmpty(_searchText) && (_searchType != 0 || _searchType != null) && LstStudentSupportMaster.Count < 1)
                {
                    _dialogService.DialogInfo(ResourceSystemMessenger.SearchItemNotFound);
                }
            }
            catch (Exception ex)
            {
                await _dialogService.DialogErrorAsync(ex);
            }
        }
    }
}
