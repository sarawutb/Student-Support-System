using System.Reflection.Emit;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using StudentSupportSystem.Model;
using StudentSupportSystem.Service.Interface;

namespace StudentSupportSystem.ViewModel
{
    public class CreareStudentSupportMasterViewModel : BaseViewModel
    {
        private readonly IHttpClientService _httpClient;
        private readonly IDialogService _dialogService;
        public CreareStudentSupportMasterViewModel(IHttpClientService httpClient, IDialogService dialogService)
        {
            _httpClient = httpClient;
            _dialogService = dialogService;
        }

        private StudentModel? _studentProfile = new StudentModel();
        public StudentModel? StudentProfile
        {
            get => _studentProfile;
            set
            {
                _studentProfile = value;
                _studentProfile?.SetNameStd();
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
                if(_provinceId != null)
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
                if(_districtId != null)
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
                if(_subDistrictId != null)
                    ZipCode = _lstSubDistrict.Find(d => d.Id == _subDistrictId)?.ZipCode.ToString();
                OnPropertyChanged();
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

        public async Task GetPovince()
        {
            try
            {
                LstPovince = await _httpClient.Get<List<PovinceModel>>("api/GetProvince");
            }
            catch(Exception ex)
            {
                _dialogService.DialogError(ex.ToString());
            }
        }

        public async Task GetDistrict()
        {
            try
            {
                DistrictId = null;
                LstSubDistrict = new List<SubDistrictModel>();
                LstDistrict = await _httpClient.Get<List<DistrictModel>>($"api/GetDistrict?provinceId={ProvinceId}");
            }
            catch(Exception ex)
            {
                _dialogService.DialogError(ex.ToString());
            }
        }

        public async Task GetSubDistrict()
        {
            try
            {
                SubDistrictId = null;
                LstSubDistrict = await _httpClient.Get<List<SubDistrictModel>>($"api/GetSubDistrict?districtId={DistrictId}");
            }
            catch(Exception ex)
            {
                _dialogService.DialogError(ex.ToString());
            }
        }

        public async Task GetBreachDisciplineMst()
        {
            try
            {
                LstBreachDisciplineMst = await _httpClient.Get<List<BreachDisciplineMasterModel>>("api/GetBreachDisciplineMaster");
                Console.WriteLine(LstBreachDisciplineMst.Count > 0);
            }
            catch(Exception ex)
            {
                _dialogService.DialogError(ex.ToString());
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
    }
}
