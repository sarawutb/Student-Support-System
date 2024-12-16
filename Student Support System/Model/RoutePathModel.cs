namespace StudentSupportSystem.Model
{
    public class RoutePathModel
    {
        public const string PageStudentSupportMaster = "/";
        public static string PageProfileStudentSupportMaster(int MasterId) => $"/ProfileStudent/{MasterId}";
        public const string PageCreareStudentSupportMaster = "/CreareStudent";

    }
}
