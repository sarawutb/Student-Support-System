using Microsoft.JSInterop;
using StudentSupportSystem.Model;
using StudentSupportSystem.Pages;
using StudentSupportSystem.Service.Interface;

namespace StudentSupportSystem.ViewModel
{
    public class ModalAddCommitCrimeStdViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly IStudentSupportMasterService _supportMasterService;
        private readonly ILoadingService _loadingService;
        private readonly IJSRuntime _jSRuntime;
        private readonly StudentSupportMasterViewModel _studentSupportMasterViewModel;

        public ModalAddCommitCrimeStdViewModel(IDialogService dialogService, IStudentSupportMasterService supportMasterService, ILoadingService loadingService, IJSRuntime jSRuntime, StudentSupportMasterViewModel studentSupportMasterViewModel)
        {
            _dialogService = dialogService;
            _supportMasterService = supportMasterService;
            _loadingService = loadingService;
            _jSRuntime = jSRuntime;
            _studentSupportMasterViewModel = studentSupportMasterViewModel;
        }
        private List<BreachDisciplineMasterModel> _lstBreachDisciplineMst = new List<BreachDisciplineMasterModel>();
        public List<BreachDisciplineMasterModel> LstBreachDisciplineMst
        {
            get => _lstBreachDisciplineMst;
            set
            {
                _lstBreachDisciplineMst = value;
                if (_lstBreachDisciplineMst.Count > 0)
                {
                    ChecklistOtherId = _lstBreachDisciplineMst.Where(d => d.IsOther == true).Select(d => d.Id).FirstOrDefault();
                }
                else
                {
                    ChecklistOtherId = 0;
                }
                OnPropertyChanged();
            }
        }
        public int _idStudentSupportMaster;
        public int IdStudentSupportMaster
        {
            get => _idStudentSupportMaster;
            set
            {
                _idStudentSupportMaster = value;
                ModalIdOpen = "IdModalAddCommitCrimeStdOpen" + _idStudentSupportMaster;
                ModalIdClose = "IdModalAddCommitCrimeStdClose" + _idStudentSupportMaster;
            }
        }

        public string ModalIdOpen { get; set; }
        public string ModalIdClose { get; set; }

        public string UnCheckBoxModalAddCommitCrimeStd = "checklit-modal-add";

        private List<StudentSupportBreachDisciplineChecklist> _lstCheckListBreachDisciplineId = new List<StudentSupportBreachDisciplineChecklist>();
        public List<StudentSupportBreachDisciplineChecklist> LstCheckListBreachDisciplineId
        {
            get => _lstCheckListBreachDisciplineId;
            set
            {
                _lstCheckListBreachDisciplineId = value;
                OnPropertyChanged();
            }
        }

        public int ChecklistOtherId { get; set; }

        private string _checklistOther;
        public string ChecklistOther
        {
            get => _checklistOther;
            set
            {
                _checklistOther = value;
                OnPropertyChanged();
            }
        }

        private int _qty = 1;
        public int Qty
        {
            get => _qty;
            set
            {
                _qty = value;
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

        public void UpdateSelectedCheckListId(int id, object obj)
        {
            var isChecked = (bool)obj;
            var checkList = new StudentSupportBreachDisciplineChecklist
            {
                CheckLsitId = id,
                Other = id == ChecklistOtherId ? ChecklistOther : null
            };
            if (isChecked)
            {
                if (!LstCheckListBreachDisciplineId.Select(x => x.CheckLsitId).Contains(id))
                {
                    LstCheckListBreachDisciplineId.Add(checkList);
                }
            }
            else
            {
                var _remove = LstCheckListBreachDisciplineId.FirstOrDefault(d => d.CheckLsitId == checkList.CheckLsitId);
                if (_remove != null)
                    LstCheckListBreachDisciplineId.Remove(_remove);
            }
        }

        public async Task AddBreachDisciplineMasterCheckList(int IdStudentSupportMaster)
        {
            try
            {
                if (Qty <= 0)
                {
                    await _dialogService.DialogWarningAsync(ResourceSystemMessenger.PleaseEnterNumberOfTime);
                    return;
                }
                else if (LstCheckListBreachDisciplineId.Count <= 0)
                {
                    await _dialogService.DialogWarningAsync(ResourceSystemMessenger.PleaseSelectTopicBreakTheRules);
                    return;
                }
                else
                {
                    await _jSRuntime.InvokeVoidAsync("CloseModalById", ModalIdClose);
                }
                var chk = await _dialogService.DialogYesOrNo(ResourceSystemMessenger.AreYouSureYouWantToSave);
                if (chk)
                {
                    var CheckList = new BreachDisciplineMasterCheckListModel
                    {
                        IdStudentSupportMaster = IdStudentSupportMaster,
                        CreateBy = 102,
                        Qty = Qty,
                        StudentSupportBreachDisciplineChecklist = LstCheckListBreachDisciplineId,
                    };
                    var state = await _supportMasterService.CreateSupportBreachDiscipline(CheckList);
                    if (state)
                    {
                        await _dialogService.DialogSuccessAsync(ResourceSystemMessenger.Successful);
                        await ModelAddDefaultData();
                        await _studentSupportMasterViewModel.GetStudentSupportMasterAll();
                    }
                    else
                    {
                        await _dialogService.DialogSuccessAsync(ResourceSystemMessenger.TransactionFailed);
                    }
                }
            }
            catch (Exception ex)
            {
                await _dialogService.DialogErrorAsync(ex);
            }
        }

        private async Task ModelAddDefaultData()
        {
            LstCheckListBreachDisciplineId = new List<StudentSupportBreachDisciplineChecklist>();
            Qty = 1;
            await _jSRuntime.InvokeVoidAsync("UnCheckBoxModalAddCommitCrimeStd", UnCheckBoxModalAddCommitCrimeStd);
        }
    }
}
