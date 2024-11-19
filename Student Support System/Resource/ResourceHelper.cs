using System.Diagnostics.Metrics;
using System.Globalization;
using System.Resources;
using System.Xml.Linq;

public static class ResourceHelper
{
    private static readonly ResourceManager ResourceManager = new ResourceManager("StudentSupportSystem.Resource.ResourceSystemMessenger ", typeof(ResourceHelper).Assembly);

    public static string GetString(string key)
    {
        return ResourceManager.GetString(key, CultureInfo.CurrentUICulture) ?? string.Empty;
    }
}

public static class ResourceSystemMessenger
{
    public static string Successful => ResourceHelper.GetString("Successful");
    public static string TransactionFailed => ResourceHelper.GetString("Transaction Failed");
    public static string AreYouSureYouWantToDeleteTheItem => ResourceHelper.GetString("Are you sure you want to delete the item");
    public static string AreYouSureYouWantToSave => ResourceHelper.GetString("Are you sure you want to save");
    public static string AreYouSureYouWantToUpdate => ResourceHelper.GetString("Are you sure you want to update");
    public static string AreYouSureYouWantToClearYourData => ResourceHelper.GetString("Are you sure you want to clear your data");
    public static string Save => ResourceHelper.GetString("Save");
    public static string Edit => ResourceHelper.GetString("Edit");
    public static string Delete => ResourceHelper.GetString("Delete");
    public static string Cancel => ResourceHelper.GetString("Cancel");
    public static string ClearData => ResourceHelper.GetString("Clear data");
    public static string PleaseFillInTheInformationToSearch => ResourceHelper.GetString("Please Fill In The Information To Search");
    public static string SearchItemNotFound => ResourceHelper.GetString("Search Item Not Found");
    public static string AddCommitCrime => ResourceHelper.GetString("Add Commit A Crime");
    public static string CommitCrime => ResourceHelper.GetString("Commit A Crime");
    public static string Close => ResourceHelper.GetString("Close");
    public static string StudentsWhoViolateDisciplineBehaveImproperly => ResourceHelper.GetString("Students who violate discipline behave improperly");
    public static string Name => ResourceHelper.GetString("Name");
    public static string NameAndLastName => ResourceHelper.GetString("Name And LastName");
    public static string Level => ResourceHelper.GetString("Level");
    public static string NumberStudent => ResourceHelper.GetString("Number Student");
    public static string Number => ResourceHelper.GetString("Number");
    public static string Branch => ResourceHelper.GetString("Branch");
    public static string Year => ResourceHelper.GetString("Year");
    public static string Room => ResourceHelper.GetString("Room");
    public static string NumberOfOffenses => ResourceHelper.GetString("Number Of Offenses");
    public static string Qty => ResourceHelper.GetString("Qty");
    public static string ManagerData => ResourceHelper.GetString("Manager Data");
    public static string AddStudent => ResourceHelper.GetString("Add Student");
    public static string ListNameStudent => ResourceHelper.GetString("List Name Student");
    public static string All => ResourceHelper.GetString("All");
    public static string DataStudent => ResourceHelper.GetString("Data Student");
    public static string HistoryCommitCrime => ResourceHelper.GetString("History Commit A Crime");
    public static string ViewHistoryCommitCrime => ResourceHelper.GetString("View History Commit A Crime");
    public static string CreateDate => ResourceHelper.GetString("Create Date");
    public static string EditDate => ResourceHelper.GetString("Edit Date");
    public static string CreateBy => ResourceHelper.GetString("Create By");
    public static string EditBy => ResourceHelper.GetString("Edit By");
    public static string Title => ResourceHelper.GetString("Title");
    public static string ViewDetail => ResourceHelper.GetString("View Detail");
    public static string StudentSupportSystem => ResourceHelper.GetString("Student Support System");
    public static string Logout => ResourceHelper.GetString("Logout");
    public static string PleaseEnterNumberOfTime => ResourceHelper.GetString("Please enter number of times");
    public static string Test => ResourceHelper.GetString("");


}
