using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIProjectPractice.DataAccess.IRepository;
using WebAPIProjectPractice.Models;

namespace WebAPIProjectPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IEmpRepo Empcon;

        public EmployeeController(IEmpRepo _Empcon)
        {

            Empcon = _Empcon;

        }

        [HttpPost]
        [Route("InsertEmployee")]
        public async Task<IActionResult> InsertEmployee(Employee employee)
        {
            try
            {
                var count = await Empcon.InsertEmployee(employee);
                if (count > 0)
                    return Ok("Employee inserted successfully.");
                else
                    return NotFound("Insert failed.");
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong: " + e.Message);
            }
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var empList = await Empcon.GetAllEMPLOYEE();
                if (empList.Count > 0)
                    return Ok(empList);
                else
                    return NotFound("No employee records found.");
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong: " + e.Message);
            }
        }


        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var emp = await Empcon.GetEmpId(id);
                if (emp != null)
                    return Ok(emp);
                else
                    return NotFound("Employee not found.");
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong: " + e.Message);
            }
        }

        [HttpGet]
        [Route("GetEmployeeByEmail/{email}")]
        public async Task<IActionResult> GetEmployeeByEmail(string email)
        {
            try
            {
                var emp = await Empcon.GetEmail(email);
                if (emp != null)
                    return Ok(emp);
                else
                    return NotFound("Employee not found with the given email.");
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong: " + e.Message);
            }
        }

        [HttpGet]
        [Route("GetEmployeeByName/{name}")]
        public async Task<IActionResult> GetEmployeeByName(string name)
        {
            try
            {
                var emp = await Empcon.GetEName(name);
                if (emp != null)
                    return Ok(emp);
                else
                    return NotFound("Employee not found with the given name.");
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong: " + e.Message);
            }
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            try
            {
                var count = await Empcon.UpdateEmployee(employee);
                if (count > 0)
                    return Ok("Employee updated successfully.");
                else
                    return NotFound("Update failed.");
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong: " + e.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int EmpId)
        {
            try
            {
                var count = await Empcon.DeleteEmployee(EmpId);
                if (count > 0)
                    return Ok("Employee deleted successfully.");
                else
                    return NotFound("Delete failed.");
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong: " + e.Message);
            }
        }


    }
}

