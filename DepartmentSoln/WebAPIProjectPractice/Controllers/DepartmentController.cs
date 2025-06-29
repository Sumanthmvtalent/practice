using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIProjectPractice.DataAccess.IRepository;
using WebAPIProjectPractice.Models;

namespace WebAPIProjectPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        public IDeptRepo depcon;

        public DepartmentController(IDeptRepo _depcon) 
        {

            depcon = _depcon;


        }

        [HttpPost]
        [Route("InsertDepartment")]
        public async Task<IActionResult> InsertDepartment(Department department) 
        {
            try
            {
              var count= await depcon.InsertDepartment(department);
                if (count > 0)
                {
                    return Ok(count);
                }
                else {
                 return NotFound("Records not available");
                }
            }

            catch (Exception e) 
            {
              return BadRequest("Something went wrong "+e.Message+"Will resolve soon");
            }
        
        
        }



        [HttpGet]
        [Route("GetAllDepartments")]
        public async Task<IActionResult> GetAllDepartments() 
        {
            try
            {
               var DeptList=await depcon.GetAllDepartments();
                if (DeptList.Count>0)
                {
                    return Ok(DeptList);
                }
                else 
                
                {
                    return NotFound("Records not Found");
                }

            }
            catch (Exception e) 
            {
                return BadRequest("Something went wrong" + e.Message + "will resolve soon");
            }
        
        
        }


        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment(Department department)
        {
            try
            {
                var count=await depcon.UpdateDepartment(department);
                if (count > 0)
                {
                    return Ok(count);

                }
                else
                {
                    return NotFound();
                }
                
            }

            catch (Exception e)
            {
                return BadRequest("Something went wrong " + e.Message + "Will resolve soon");
            }


        }

        [HttpDelete]
        [Route("DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(int DeptId)
        {
            try
            {
               var count=await depcon.DeleteDepartment(DeptId);
                if (count > 0)
                {
                    return Ok(count);
                }
                else {
                    return NotFound("Records Not Delted");
                }

            }

            catch (Exception e)
            {
                return BadRequest("Something went wrong " + e.Message + "Will resolve soon");
            }


        }




    }
}
