using Student_Support_System.Model;

namespace Student_Support_System.ViewModel
{
    public class CreareStudentSupportMasterViewModel : BaseViewModel
    {
        public CreareStudentSupportMasterViewModel()
        {

        }

        private StudentModel _studentProfile;
        public StudentModel studentProfile
        {
            get => _studentProfile;
            set
            {
                _studentProfile = value;
                OnPropertyChanged();
            }
        }

        private StudentSupportMasterModel _studentSupportMst;
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
