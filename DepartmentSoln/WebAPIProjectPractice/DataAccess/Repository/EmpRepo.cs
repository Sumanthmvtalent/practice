using Microsoft.EntityFrameworkCore;
using WebAPIProjectPractice.DataAccess.IRepository;
using WebAPIProjectPractice.DataBaseAccess;
using WebAPIProjectPractice.Models;

namespace WebAPIProjectPractice.DataAccess.Repository
{
    public class EmpRepo:IEmpRepo
    {
        public DatabaseContext Emptrep;

        public EmpRepo(DatabaseContext _Emptrep)
        {

            Emptrep = _Emptrep;


        }

      

        public async Task<List<Employee>> GetAllEMPLOYEE()
        {
            return await Emptrep.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmail(string Email)
        {
            //return await deptrep.Departments.FindAsync(DeptId);
            return await Emptrep.Employees.Where(x => x.Email == Email).SingleOrDefaultAsync();
               

        }

        public async Task<Employee> GetEmpId(int EmpId)
        {
            return await Emptrep.Employees.FindAsync(EmpId);
        }

        public async Task<Employee> GetEName(string EName)
        {
            return await Emptrep.Employees
               .Where(x => x.EName == EName)
               .SingleOrDefaultAsync();
        }

        public async Task<int> InsertEmployee(Employee employee)
        {
            await Emptrep.Employees.AddAsync(employee);
            return await Emptrep.SaveChangesAsync();
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            Emptrep.Employees.Update(employee);
            return await Emptrep.SaveChangesAsync();
        }
        public async Task<int> DeleteEmployee (int EmpId)
        {
            var empdel = Emptrep.Employees.Find(EmpId);
            Emptrep.Employees.Remove(empdel);
            return await Emptrep.SaveChangesAsync ();

        }
    }
}


    