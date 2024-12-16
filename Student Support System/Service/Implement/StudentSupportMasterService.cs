using Microsoft.AspNetCore.Components.Forms;
using StudentSupportSystem.Const;
using StudentSupportSystem.Model;
using StudentSupportSystem.Service.Interface;
using System.Collections.Generic;

namespace StudentSupportSystem.Service.Implement
{
    public class StudentSupportMasterService : IStudentSupportMasterService
    {
        private readonly IHttpClientService _httpClient;

        public StudentSupportMasterService(IHttpClientService httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> CreateStudentSupportMaster(StudentSupportMasterModel obj)
        {
            string url = "api/CreateStudentSupportMaster";
            var Data = await _httpClient.Post<StudentSupportMasterModel, int?>(url, obj);
            return Data ?? 0;
        }

        public async Task<List<BreachDisciplineMasterModel>> GetBreachDisciplineMaster()
        {
            string url = "api/GetBreachDisciplineMaster";
            var Data = await _httpClient.Get<List<BreachDisciplineMasterModel>>(url);
            return Data;
        }

        public async Task<List<DistrictModel>> GetDistrict(int ProvinceId)
        {
            string url = $"api/GetDistrict?provinceId={ProvinceId}";
            var Data = await _httpClient.Get<List<DistrictModel>>(url);
            return Data;
        }

        public async Task<List<PovinceModel>> GetPovince()
        {
            string url = "api/GetProvince";
            var Data = await _httpClient.Get<List<PovinceModel>>(url);
            return Data;
        }

        public async Task<StudentSupportMasterModel> GetStudentSupportMaster(int Id)
        {
            string url = $"api/GetStudentSupportMaster?id={Id}";
            var Data = await _httpClient.Get<StudentSupportMasterModel>(url);
            return Data;
        }

        public async Task<List<StudentSupportMasterModel>> GetStudentSupportMasterAll(int? SearchType = null, string? SearchText = null)
        {
            string url = $"api/GetStudentSupportMasterAll?searchType={SearchType}&searchText={SearchText}";
            var Data = await _httpClient.Get<List<StudentSupportMasterModel>>(url);
            return Data;
        }

        public async Task<TeacherModel> GetTeachertById(int Id)
        {
            string url = $"api/GetTeachertById?id={Id}";
            var Data = await _httpClient.Get<TeacherModel>(url);
            return Data;
        }

        public async Task<FileCenterModel> GetFileCenter(int Id)
        {
            string url = $"api/GetFileCenter?id={Id}";
            var Data = await _httpClient.Get<FileCenterModel>(url);
            return Data;
        }

        public async Task<List<SubDistrictModel>> GetSubDistrict(int DistrictId)
        {
            string url = $"api/GetSubDistrict?districtId={DistrictId}";
            var Data = await _httpClient.Get<List<SubDistrictModel>>(url);
            return Data;
        }

        public async Task<bool> RemoveFile(string fileName, string fileDate)
        {
            var ReqData = new RenoveFileModel
            {
                fileName = fileName,
                fileDate = fileDate
            };
            string url = "api/RemoveFiles";
            var Data = await _httpClient.Post<RenoveFileModel, bool>(url, ReqData);
            return Data;
        }

        public async Task<bool> RemoveStudentSupportMaster(int Id)
        {
            string url = $"api/RemoveStudentSupportMaster?id={Id}";
            var Data = await _httpClient.Get<bool?>(url);
            return Data ?? false;
        }

        public Task<bool> UpdateStudentSupportMaster(StudentSupportMasterModel obj)
        {
            throw new NotImplementedException();
        }

        public async Task<UploadFileResponseModel> UploadFile(IBrowserFile browserFile)
        {
            string url = "api/UploadFiles";
            using var content = new MultipartFormDataContent();
            var fileContent = new StreamContent(browserFile.OpenReadStream(ConfigConst.MAX_FILE_SIZE));
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(browserFile.ContentType);
            content.Add(fileContent, "files[]", browserFile.Name);
            var Data = await _httpClient.UploadFile<UploadFileResponseModel>(url, content);
            return Data;
        }

        public async Task<bool> CreateSupportBreachDiscipline(BreachDisciplineMasterCheckListModel checkListModel)
        {
            string url = $"api/CreateSupportBreachDiscipline";
            var Data = await _httpClient.Post<BreachDisciplineMasterCheckListModel, bool>(url, checkListModel);
            return Data;
        }

        public async Task<bool> UpdateSupportBreachDiscipline(BreachDisciplineMasterCheckListModel checkListModel)
        {
            string url = $"api/UpdateSupportBreachDiscipline";
            var Data = await _httpClient.Put<BreachDisciplineMasterCheckListModel, bool>(url, checkListModel);
            return Data;
        }

        public async Task<bool> RemoveSupportBreachDisciplineById(int Id)
        {
            string url = $"api/RemoveSupportBreachDisciplineById?id={Id}";
            var Data = await _httpClient.Get<bool>(url);
            return Data;
        }

        public async Task<bool> RemoveSupportBreachDisciplineByMasterId(int Id)
        {
            string url = $"api/RemoveSupportBreachDisciplineByMasterId?id={Id}";
            var Data = await _httpClient.Get<bool>(url);
            return Data;
        }

        public async Task<List<BreachDisciplineMasterCheckListModelDetailsModel>> GetBreachDisciplineChecklistByBreachDisciplineId(int Id)
        {
            string url = $"api/GetBreachDisciplineChecklistByBreachDisciplineId?id={Id}";
            var lstData = await _httpClient.Get<List<BreachDisciplineMasterCheckListModelDetailsModel>>(url);
            return lstData;
        }

        public async Task<List<BreachDisciplineModel>> GetSupportBreachDiscipline(int mstId)
        {
            string url = $"api/GetSupportBreachDiscipline?mstId={mstId}";
            var lstData = await _httpClient.Get<List<BreachDisciplineModel>>(url);
            return lstData;
        }

        public async Task<byte[]> ReportStudentSupport(int Id)
        {
            string url = $"api/ReportStudentSupport?Id={Id}";
            var filePdf = await _httpClient.GetFile(url);
            return filePdf;
        }

        public Task<LoginModel> Login(FormLoginModel formLogin)
        {
            string url = $"api/Login/Teacher";
            var Data = _httpClient.Post<FormLoginModel, LoginModel>(url, formLogin);
            return Data;
        }
    }
}
