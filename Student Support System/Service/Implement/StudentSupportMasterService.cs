using Microsoft.AspNetCore.Components.Forms;
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

        public async Task<bool> CreateStudentSupportMaster(StudentSupportMasterModel obj)
        {
            string url = "api/CreateStudentSupportMaster";
            var Data = await _httpClient.Post<StudentSupportMasterModel, bool>(url, obj);
            return Data;
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
            var ReqData = new Dictionary<string, dynamic>();
            ReqData.Add("fileName", fileName);
            ReqData.Add("fileDate", fileDate);
            string url = "RemoveFiles";
            var Data = await _httpClient.Post<dynamic, bool>(url, ReqData);
            return Data;
        }

        public async Task<bool> RemoveStudentSupportMaster(int Id)
        {
            string url = $"api/RemoveStudentSupportMaster?id={Id}";
            var Data = await _httpClient.Get<bool>(url);
            return Data;
        }

        public Task<bool> UpdateStudentSupportMaster(StudentSupportMasterModel obj)
        {
            throw new NotImplementedException();
        }

        public async Task<UploadFileResponseModel> UploadFile(IBrowserFile browserFile)
        {
            string url = "api/UploadFiles";

            using var content = new MultipartFormDataContent();
            var fileContent = new StreamContent(browserFile.OpenReadStream());
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(browserFile.ContentType);
            content.Add(fileContent, "files[]", browserFile.Name);
            var Data = await _httpClient.UploadFile<UploadFileResponseModel>(url, content);
            return Data;
        }
    }
}
