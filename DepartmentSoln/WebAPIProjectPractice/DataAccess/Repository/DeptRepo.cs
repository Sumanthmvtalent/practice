using Microsoft.EntityFrameworkCore;
using WebAPIProjectPractice.DataAccess.IRepository;
using WebAPIProjectPractice.DataBaseAccess;
using WebAPIProjectPractice.Models;

namespace WebAPIProjectPractice.DataAccess.Repository
{
    public class DeptRepo:IDeptRepo
    {

        public DatabaseContext deptrep;

        public DeptRepo(DatabaseContext _deptrep) {

            deptrep= _deptrep;


        }

        

        public async Task<List<Department>> GetAllDepartments()
        {
           return await deptrep.Departments.ToListAsync();
               
        }


        public async Task<Department> GetDeptId(int DeptId)
        {
          return await deptrep.Departments.FindAsync(DeptId);
        }


        public async Task<Department> GetDeptName(string DName)
        {
       return await deptrep.Departments.Where(x=>x.DName==DName).SingleOrDefaultAsync();
        }

        public async Task<int> InsertDepartment(Department department)
        {
           await deptrep.Departments.AddAsync(department);
          return await deptrep.SaveChangesAsync();
        }

        public async Task<int> UpdateDepartment(Department department)
        {
            deptrep.Departments.Update(department);
          return await deptrep.SaveChangesAsync();
        }

        public async Task<int> DeleteDepartment(int DeptId)
        {
            var dep = deptrep.Departments.Find(DeptId);
            deptrep.Departments.Remove(dep);
          return await deptrep.SaveChangesAsync();
        }

        public async Task<Department> GetDeptLocation(string Location)
        {
          return await deptrep.Departments.Where(x=>x.Location==Location).FirstOrDefaultAsync();
        }
    }
}
