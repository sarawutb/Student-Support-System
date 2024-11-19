using Microsoft.AspNetCore.Components.Forms;
using StudentSupportSystem.Model;
using StudentSupportSystem.Pages;

namespace StudentSupportSystem.Service.Interface
{
    public interface IStudentSupportMasterService
    {
        Task<List<PovinceModel>> GetPovince();
        Task<List<BreachDisciplineMasterModel>> GetBreachDisciplineMaster();
        Task<List<DistrictModel>> GetDistrict(int ProvinceId);
        Task<List<SubDistrictModel>> GetSubDistrict(int DistrictId);
        Task<UploadFileResponseModel> UploadFile(IBrowserFile browserFile);
        Task<bool> RemoveFile(string fileName, string fileDate);
        Task<bool> CreateStudentSupportMaster(StudentSupportMasterModel obj);
        Task<bool> UpdateStudentSupportMaster(StudentSupportMasterModel obj);
        Task<bool> RemoveStudentSupportMaster(int Id);
        Task<List<StudentSupportMasterModel>> GetStudentSupportMasterAll(int? SearchType = null, string? SearchText = null);
        Task<StudentSupportMasterModel> GetStudentSupportMaster(int Id);
        Task<TeacherModel> GetTeachertById(int Id);
        Task<FileCenterModel> GetFileCenter(int Id);
        Task<bool> CreateSupportBreachDiscipline(BreachDisciplineMasterCheckListModel checkListModel);
        Task<bool> RemoveSupportBreachDisciplineById(int Id);
        Task<bool> RemoveSupportBreachDisciplineByMasterId(int Id);
    }
}
