using Microsoft.JSInterop;
using Newtonsoft.Json;
using StudentSupportSystem.Model;

namespace StudentSupportSystem.ViewModel
{
    public class CreareStudentSupportMasterViewModel : BaseViewModel
    {
        public CreareStudentSupportMasterViewModel()
        {
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
    }
}
