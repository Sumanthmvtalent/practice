using WebAPIProjectPractice.Models;

namespace WebAPIProjectPractice.DataAccess.IRepository
{
    public interface IDeptRepo
    {
        public Task<List<Department>> GetAllDepartments();

        public Task<Department> GetDeptName(string DName);

        public Task<Department> GetDeptId(int DeptId);

        public Task<Department> GetDeptLocation(string Location);
        public Task<int> InsertDepartment(Department department);
        public Task<int> UpdateDepartment(Department department);

        public Task<int> DeleteDepartment(int DeptId);
    }
}
