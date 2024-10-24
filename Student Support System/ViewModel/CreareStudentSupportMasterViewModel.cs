using Student_Support_System.Model;

namespace Student_Support_System.ViewModel
{
    public class CreareStudentSupportMasterViewModel : BaseViewModel
    {
        public CreareStudentSupportMasterViewModel()
        {

        }

        private StudentModel _studentProfile = new StudentModel();
        public StudentModel studentProfile
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

        private StudentSupportMasterModel _studentSupportMst = new StudentSupportMasterModel();
        public StudentSupportMasterModel studentSupportMst
        {
            get => _studentSupportMst;
            set
            {
                _studentSupportMst = value;
                OnPropertyChanged();
            }
        }
    }
}
