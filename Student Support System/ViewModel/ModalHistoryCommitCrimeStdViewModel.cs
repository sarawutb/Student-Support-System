using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.JSInterop;
using StudentSupportSystem.Model;
using StudentSupportSystem.Service.Implement;
using StudentSupportSystem.Service.Interface;

namespace StudentSupportSystem.ViewModel
{
    public partial class ModalHistoryCommitCrimeStdViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly IStudentSupportMasterService _supportMasterService;
        private readonly ILoadingService _loadingService;
        private readonly IJSRuntime _jSRuntime;
        private readonly StudentSupportMasterViewModel _studentSupportMasterViewModel;
        public ModalHistoryCommitCrimeStdViewModel(IDialogService dialogService, IStudentSupportMasterService supportMasterService, ILoadingService loadingService, IJSRuntime jSRuntime, StudentSupportMasterViewModel studentSupportMasterViewModel)
        {
            _dialogService = dialogService;
            _supportMasterService = supportMasterService;
            _loadingService = loadingService;
            _jSRuntime = jSRuntime;
            _studentSupportMasterViewModel = studentSupportMasterViewModel;
        }

        private int ChecklistOtherId = 0;
        private List<BreachDisciplineMasterModel> _lstBreachDisciplineMst = new List<BreachDisciplineMasterModel>();
        public List<BreachDisciplineMasterModel> lstBreachDisciplineMst
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

        [ObservableProperty]
        public string checklistOther;

        [ObservableProperty]
        public List<BreachDisciplineMasterCheckListModelDetailsModel> lstBreachDisciplineDetails = new List<BreachDisciplineMasterCheckListModelDetailsModel>();

        [ObservableProperty]
        public List<BreachDisciplineModel> lstBreachDisciplineModel = new List<BreachDisciplineModel>();

        [ObservableProperty]
        public List<StudentSupportBreachDisciplineChecklist> lstCheckListBreachDisciplineId = new List<StudentSupportBreachDisciplineChecklist>();

        [ObservableProperty]
        public bool isEdit = false;

        public string btnViewHistory = "view-details";
        public string ModalHistoryCommitCrimeStdViewModelTable = "ModalHistoryCommitCrimeStdViewModel-table";

        public async Task OnViewDetail(bool state, BreachDisciplineModel obj)
        {
            try
            {
                lstBreachDisciplineModel.ForEach(e => e.IsEdit = false);
                lstBreachDisciplineModel.ForEach(e => e.IsDetail = false);
                obj.IsDetail = state;
                if (obj.IsDetail)
                {
                    await _loadingService.LoadingShow();
                    obj.lstBreachDisciplineMasters = await _supportMasterService.GetBreachDisciplineMaster();
                    obj.lstCheckListModelDetailsModels = await _supportMasterService.GetBreachDisciplineChecklistByBreachDisciplineId(obj.Id);
                }
            }
            catch (Exception ex)
            {
                await _loadingService.LoadingHide();
                await _dialogService.DialogErrorAsync(ex);
            }
            finally
            {
                await _loadingService.LoadingHide();
            }
        }

        public async Task OnEditMode(bool state, BreachDisciplineModel obj)
        {
            try
            {
                lstCheckListBreachDisciplineId.Clear();
                lstBreachDisciplineModel.ForEach(e => e.IsEdit = false);
                lstBreachDisciplineModel.ForEach(e => e.IsDetail = false);
                obj.IsEdit = state;
                if (obj.IsEdit)
                {
                    await _loadingService.LoadingShow();
                    obj.lstBreachDisciplineMasters = await _supportMasterService.GetBreachDisciplineMaster();
                    obj.lstCheckListModelDetailsModels = await _supportMasterService.GetBreachDisciplineChecklistByBreachDisciplineId(obj.Id);
                    if (obj.lstCheckListModelDetailsModels.Count > 0)
                    {
                        obj.lstCheckListModelDetailsModels.ForEach(e =>
                        {
                            lstCheckListBreachDisciplineId.Add(new StudentSupportBreachDisciplineChecklist
                            {
                                CheckLsitId = e.CheckListId,
                                Other = e.CheckListOther
                            });
                        });
                    }

                }
            }
            catch (Exception ex)
            {
                await _loadingService.LoadingHide();
                await _dialogService.DialogErrorAsync(ex);
            }
            finally
            {
                await _loadingService.LoadingHide();
            }
        }

        public async Task OnViewDetailsCheckList(BreachDisciplineModel obj)
        {
            try
            {
                obj.lstCheckListModelDetailsModels = await _loadingService.LoadingAsync(_supportMasterService.GetBreachDisciplineChecklistByBreachDisciplineId(obj.Id));
                Console.WriteLine(obj?.JsonlstCheckListModelDetailsModels);
            }
            catch (Exception ex)
            {
                await _dialogService.DialogErrorAsync(ex);
            }
        }

        public async Task OnGetSupportBreachDiscipline(int mstId)
        {
            try
            {
                lstBreachDisciplineModel = await _loadingService.LoadingAsync(_supportMasterService.GetSupportBreachDiscipline(mstId));
            }
            catch (Exception ex)
            {
                await _dialogService.DialogErrorAsync(ex);
            }
        }

        public async Task OnUpdateBreachDiscipline(BreachDisciplineModel obj)
        {
            try
            {
                bool state = await _dialogService.DialogYesOrNo(ResourceSystemMessenger.AreYouSureYouWantToUpdate);
                if (state)
                {
                    var _updata = new BreachDisciplineMasterCheckListModel()
                    {
                        Id = obj.Id,
                        Qty = obj.Qty,
                        CreateBy = 102,
                        IdStudentSupportMaster = obj.IdStudentSupportMaster,
                        StudentSupportBreachDisciplineChecklist = lstCheckListBreachDisciplineId
                    };
                    state = await _supportMasterService.UpdateSupportBreachDiscipline(_updata);
                    if (state)
                    {
                        await _dialogService.DialogSuccessAsync(ResourceSystemMessenger.Successful);
                        await OnGetSupportBreachDiscipline(obj.IdStudentSupportMaster);
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

        public async Task OnDeleteBreachDiscipline(BreachDisciplineModel obj)
        {
            try
            {
                var state = await _loadingService.LoadingAsync(_supportMasterService.RemoveSupportBreachDisciplineById(obj.Id));
                if (state)
                {
                    await OnGetSupportBreachDiscipline(obj.IdStudentSupportMaster);
                }
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
                Other = id == ChecklistOtherId ? checklistOther : null
            };
            if (isChecked)
            {
                if (!lstCheckListBreachDisciplineId.Select(x => x.CheckLsitId).Contains(id))
                {
                    lstCheckListBreachDisciplineId.Add(checkList);
                }
            }
            else
            {
                var _remove = lstCheckListBreachDisciplineId.FirstOrDefault(d => d.CheckLsitId == checkList.CheckLsitId);
                if (_remove != null)
                    lstCheckListBreachDisciplineId.Remove(_remove);
            }
        }

        public async Task GetReportStudentSupport(int id)
        {
            try
            {
                var fileReport = await _loadingService.LoadingAsync(_supportMasterService.ReportStudentSupport(id));
                string base64Pdf = Convert.ToBase64String(fileReport);
                await _jSRuntime.InvokeVoidAsync("showPdfInNewTab", base64Pdf, "test");
            }
            catch (Exception ex)
            {
                await _dialogService.DialogErrorAsync(ex);
            }
        }
    }
}
