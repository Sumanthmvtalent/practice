using WebAPIProjectPractice.Models;

namespace WebAPIProjectPractice.DataAccess.IRepository
{
    public interface IEmpRepo
    {
        public Task<List<Employee>> GetAllEMPLOYEE();

        public Task<Employee> GetEmpId(int EmpId);

        public Task<Employee> GetEName(string EName);

        public Task<Employee> GetEmail(string Email);
        public Task<int> InsertEmployee(Employee employee);
        public Task<int> UpdateEmployee(Employee employee);

        public Task<int> DeleteEmployee(int EmpId);
    }
}

