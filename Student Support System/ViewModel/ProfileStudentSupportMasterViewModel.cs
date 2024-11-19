using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using StudentSupportSystem.Model;
using StudentSupportSystem.Service.Implement;
using StudentSupportSystem.Service.Interface;

namespace StudentSupportSystem.ViewModel
{
    public class ProfileStudentSupportMasterViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly IStudentSupportMasterService _supportMasterService;
        private readonly ILoadingService _loadingService;
        private readonly IJSRuntime _jSRuntime;
        public ProfileStudentSupportMasterViewModel(IDialogService dialogService, IStudentSupportMasterService supportMasterService, ILoadingService loadingService, IJSRuntime jSRuntime)
        {
            _dialogService = dialogService;
            _supportMasterService = supportMasterService;
            _loadingService = loadingService;
            _jSRuntime = jSRuntime;
        }

        private StudentModel? _studentProfile = new StudentModel();
        public StudentModel? StudentProfile
        {
            get => _studentProfile;
            set
            {
                _studentProfile = value;
                OnPropertyChanged();
            }
        }

        private int? _selectTypeSearch;
        public int? SelectTypeSearch
        {
            get => _selectTypeSearch;
            set
            {
                _selectTypeSearch = value;
                OnPropertyChanged();
            }
        }

        private string? _zipCode;
        public string? ZipCode
        {
            get => _zipCode;
            set
            {
                _zipCode = value;
                OnPropertyChanged();
            }
        }

        private bool _isSearchStd;
        public bool IsSearchStd
        {
            get => _isSearchStd;
            set
            {
                _isSearchStd = value;
                OnPropertyChanged();
            }
        }

        private string? _IdStd;
        public string? IdStd
        {
            get => _IdStd;
            set
            {
                _IdStd = value;
                OnPropertyChanged();
            }
        }

        private bool _isCurrentlyLivingWithOther;
        public bool IsCurrentlyLivingWithOther
        {
            get => _isCurrentlyLivingWithOther;
            set
            {
                _isCurrentlyLivingWithOther = value;
                OnPropertyChanged();
            }
        }

        private string? _nickNameStd;
        public string? NickNameStd
        {
            get => _nickNameStd;
            set
            {
                _nickNameStd = value;
                OnPropertyChanged();
            }
        }

        private StudentSupportMasterModel? _studentSupportMst = new StudentSupportMasterModel();
        public StudentSupportMasterModel? studentSupportMst
        {
            get => _studentSupportMst;
            set
            {
                _studentSupportMst = value;
                OnPropertyChanged();
            }
        }
        private StdDateOfBirthModel? _stdDateOfBirth = new StdDateOfBirthModel();
        public StdDateOfBirthModel? StdDateOfBirth
        {
            get => _stdDateOfBirth;
            set
            {
                _stdDateOfBirth = value;
                OnPropertyChanged();
            }
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

        private List<StudentSupportBreachDisciplineChecklist> _lstBreachDisciplineMstId = new List<StudentSupportBreachDisciplineChecklist>();
        public List<StudentSupportBreachDisciplineChecklist> lstBreachDisciplineMstId
        {
            get => _lstBreachDisciplineMstId;
            set
            {
                _lstBreachDisciplineMstId = value;
                OnPropertyChanged();
            }
        }

        private TeacherModel? _teacherProfile = new TeacherModel();
        public TeacherModel? TeacherProfile
        {
            get => _teacherProfile;
            set
            {
                _teacherProfile = value;
                _teacherProfile?.SetNameTeacher();
                OnPropertyChanged();
            }
        }

        private int? _provinceId;
        public int? ProvinceId
        {
            get => _provinceId;
            set
            {
                _provinceId = value;
                if (_provinceId != null)
                    ResetPovince();
                GetDistrict();
                OnPropertyChanged();
            }
        }

        private List<PovinceModel> _lstPovince = new List<PovinceModel>();
        public List<PovinceModel> LstPovince
        {
            get => _lstPovince;
            set
            {
                _lstPovince = value;
                OnPropertyChanged();
            }
        }

        private int? _districtId;
        public int? DistrictId
        {
            get => _districtId;
            set
            {
                _districtId = value;
                if (_districtId != null)
                {
                    ResetSubDistrict();
                    GetSubDistrict();
                }
                OnPropertyChanged();
            }
        }

        private List<DistrictModel> _lstDistrict = new List<DistrictModel>();
        public List<DistrictModel> LstDistrict
        {
            get => _lstDistrict;
            set
            {
                _lstDistrict = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsDistrict));
            }
        }
        public bool IsDistrict { get => _lstDistrict.Count <= 0; }

        private int? _subDistrictId;

        public int? SubDistrictId
        {
            get => _subDistrictId;
            set
            {
                _subDistrictId = value;
                if (_subDistrictId != null)
                    ZipCode = _lstSubDistrict.Find(d => d.Id == _subDistrictId)?.ZipCode.ToString();
                OnPropertyChanged();
            }
        }

        private StudentSupportAddressModel _studentSupportAddress = new StudentSupportAddressModel();

        public StudentSupportAddressModel StudentSupportAddress
        {
            get => _studentSupportAddress;
            set
            {
                _studentSupportAddress = value;
                OnPropertyChanged();
            }
        }

        private FileCenterModel? _fileCenter;

        public FileCenterModel? FileCenter
        {
            get => _fileCenter;
            set
            {
                _fileCenter = value;
                OnPropertyChanged();
            }
        }

        private string? _imageDataUrl;
        public string? ImageDataUrl
        {
            get => _imageDataUrl;
            set
            {
                _imageDataUrl = value;
                OnPropertyChanged();
            }
        }

        private IBrowserFile? _fileImageStd;
        public IBrowserFile? FileImageStd
        {
            get => _fileImageStd;
            set
            {
                _fileImageStd = value;
                OnPropertyChanged();
            }
        }
        public void RemoveFileCenter()
        {
            FileCenter = null;
        }

        public void SetFileCenter(IBrowserFile? FileImageStd)
        {
            if (FileImageStd != null)
            {
                FileCenter = new FileCenterModel
                {
                    NameFile = FileImageStd.Name,
                    ContentType = FileImageStd.ContentType
                };
            }
        }

        public bool IsSubDistrict { get => _lstSubDistrict.Count <= 0; }

        private List<SubDistrictModel> _lstSubDistrict = new List<SubDistrictModel>();

        public List<SubDistrictModel> LstSubDistrict
        {
            get => _lstSubDistrict;
            set
            {
                _lstSubDistrict = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsSubDistrict));
            }
        }

        public bool IsModeEdit { get; private set; }

        private StateData _modeEdit;
        public StateData ModeEdit
        {
            get => _modeEdit;
            set
            {
                _modeEdit = value;
                IsModeEdit = _modeEdit == StateData.Edit;
                _jSRuntime.InvokeVoidAsync("SetSearchTeacherDisabled", IsModeEdit);
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsModeEdit));
            }
        }

        public async Task GetPovince()
        {
            try
            {
                LstPovince = await _supportMasterService.GetPovince();
            }
            catch (Exception ex)
            {
                await _dialogService.DialogErrorAsync(ex);
            }
        }

        public async Task GetDistrict()
        {
            try
            {
                DistrictId = null;
                LstSubDistrict = new List<SubDistrictModel>();
                LstDistrict = await _supportMasterService.GetDistrict(ProvinceId ?? 0);
            }
            catch (Exception ex)
            {
                await _dialogService.DialogErrorAsync(ex);
            }
        }

        public async Task GetSubDistrict()
        {
            try
            {
                SubDistrictId = null;
                LstSubDistrict = await _supportMasterService.GetSubDistrict(DistrictId ?? 0);
            }
            catch (Exception ex)
            {
                await _dialogService.DialogErrorAsync(ex);
            }
        }

        public async Task GetBreachDisciplineMst()
        {
            try
            {
                LstBreachDisciplineMst = await _supportMasterService.GetBreachDisciplineMaster();
                Console.WriteLine(LstBreachDisciplineMst.Count > 0);
            }
            catch (Exception ex)
            {
                await _dialogService.DialogErrorAsync(ex);
            }
        }

        private void ResetPovince()
        {
            ResetDistrict();
            ResetSubDistrict();
        }

        private void ResetDistrict()
        {
            DistrictId = null;
            LstDistrict = new List<DistrictModel>();
        }

        private void ResetSubDistrict()
        {
            SubDistrictId = null;
            LstSubDistrict = new List<SubDistrictModel>();
            ZipCode = null;
        }

        public Task OnClearFrom()
        {
            StudentSupportAddress = new StudentSupportAddressModel();
            StudentProfile = new StudentModel();
            return Task.FromResult(true);
        }

        public void SetCurrentlyLivingWith(int data)
        {
            studentSupportMst.CurrentlyLivingWith = data;
            IsCurrentlyLivingWithOther = (data == 4);
        }

        public async Task OnSaveData()
        {
            try
            {
                UploadFileResponseModel UploadFile;
                if (FileImageStd != null)
                {
                    UploadFile = await _supportMasterService.UploadFile(FileImageStd);
                    if (UploadFile != null)
                    {
                        FileCenter.NameFile = UploadFile!.Data[0].FileName;
                        FileCenter.PathFile = UploadFile!.Data[0].PathFile;
                        _studentSupportMst.Std_FileCenter = FileCenter;
                    }
                }

                StudentSupportAddress.IdProvinces = ProvinceId ?? 0;
                StudentSupportAddress.IdDistricts = DistrictId ?? 0;
                StudentSupportAddress.IdSubdistricts = SubDistrictId ?? 0;
                StudentSupportAddress.ZipCode = ZipCode;
                try
                {
                    _studentSupportMst.StdAddress = StudentSupportAddress;
                    var _textStdDateOfBirth = string.Format("{0:0000}-{1:00}-{2:00}", (StdDateOfBirth?.Year), StdDateOfBirth?.Month, StdDateOfBirth?.Day);
                    DateTime _stdDateOfBirth = DateTime.ParseExact(_textStdDateOfBirth, "yyyy-MM-dd", new CultureInfo("th-TH"));
                    _studentSupportMst.StdDateOfBirth = _stdDateOfBirth;
                }
                catch
                {
                    _dialogService.DialogWarning("กรอกวันเกิด ไม่ถูกต้อง");
                }
                _studentSupportMst.StdDateOfBirthSeparate = StdDateOfBirth;
                //_studentSupportMst.LstBreachDisciplineMaster = _lstBreachDisciplineMstId;
                _studentSupportMst.IdStd = StudentProfile.Id;
                _studentSupportMst.CreateBy = 102;
                _studentSupportMst.CreateDate = DateTime.Now;
                var state = await _supportMasterService.CreateStudentSupportMaster(_studentSupportMst);
                if (state)
                {
                    _dialogService.DialogSuccess(ResourceSystemMessenger.Successful);
                }
                else
                {
                    _dialogService.DialogWarning(ResourceSystemMessenger.TransactionFailed);
                }
            }
            catch (Exception ex)
            {
                if (_studentSupportMst?.Std_FileCenter != null)
                {
                    try
                    {
                        await _supportMasterService.RemoveFile(FileImageStd.Name, DateTime.Now.ToString("yyyy-MM-dd", new CultureInfo("en-US")));
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err);
                    }
                }
                await _dialogService.DialogErrorAsync(ex);
            }
        }

        public async Task LoadDataEdit(int Id)
        {
            try
            {
                await _loadingService.LoadingShow();
                studentSupportMst = await _supportMasterService.GetStudentSupportMaster(Id);
                if (studentSupportMst?.StudentProfile != null)
                {
                    StudentProfile = studentSupportMst?.StudentProfile ?? new StudentModel();
                    TeacherProfile = await _supportMasterService.GetTeachertById(studentSupportMst?.IdTeacher ?? 0) ?? new TeacherModel();
                    if (studentSupportMst?.StdAddress != null)
                    {
                        StudentSupportAddress = studentSupportMst?.StdAddress;
                        ProvinceId = StudentSupportAddress.IdProvinces;
                        DistrictId = StudentSupportAddress.IdDistricts;
                        SubDistrictId = StudentSupportAddress.IdSubdistricts;
                        ZipCode = StudentSupportAddress.ZipCode;
                    }

                    if (studentSupportMst.StdDateOfBirthSeparate != null)
                    {
                        StdDateOfBirth = studentSupportMst.StdDateOfBirthSeparate;
                    }

                    if (studentSupportMst.CurrentlyLivingWith != null)
                    {
                        await _jSRuntime.InvokeVoidAsync("SetCheckedCurrentlyLivingWith", studentSupportMst.CurrentlyLivingWith);
                        SetCurrentlyLivingWith(studentSupportMst.CurrentlyLivingWith ?? 0);
                    }

                    if (studentSupportMst.Id_File_Cener != null)
                    {
                        FileCenter = await _supportMasterService.GetFileCenter(studentSupportMst.Id_File_Cener ?? 0);
                        ImageDataUrl = FileCenter?.UrlPath;
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

        public async Task RemoveStudentSupportMaster(int Id)
        {
            try
            {
                var _state = await _dialogService.DialogYesOrNo(ResourceHelper.GetString("Are you sure you want to delete the item"));
                if (_state)
                {
                    var _result = await _loadingService.LoadingAsync(_supportMasterService.RemoveStudentSupportMaster(Id));
                    if (_result)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                await _dialogService.DialogErrorAsync(ex);
            }
        }
    }
}
