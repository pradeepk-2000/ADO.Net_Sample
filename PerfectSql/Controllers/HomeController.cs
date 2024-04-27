using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PerfectSql.Helpers;
using PerfectSql.Interfaces;
using PerfectSql.Models;
using System.Net;
using System.Reflection;

namespace PerfectSql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        public HomeController(ILogger<HomeController> logger, IEmployeeRepository employeeRepository)
        {
                _employeeRepository = employeeRepository;
                _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return new JsonResult(true);
        }
        [HttpGet("GetEmployeeDetails")]
        public IActionResult GetEmployeeDetails([FromQuery] EmployeeDetailsRequestModel model)
        {
            ServiceResponse<EmployeeDetails> serviceResponse;
            try
            {
                if (ModelState.IsValid)
                {
                    var response =  _employeeRepository.GetEmployeeDetails(model);
                    if (response != null && !string.IsNullOrEmpty(response.EmpName))
                    {
                        serviceResponse = new ServiceResponse<EmployeeDetails>
                        {
                            IsSuccess = true,
                            StatusCode = HttpStatusCode.OK,
                            Result = response
                        };

                        _logger.LogInformation($"GetEmployeeDetails API is Successfull", serviceResponse.IsSuccess);
                        return Ok(serviceResponse);
                    }

                    serviceResponse = new ServiceResponse<EmployeeDetails>
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        IsSuccess = false,
                    };

                    _logger.LogInformation($"GetEmployeeDetails API is Notfound", serviceResponse.IsSuccess);
                    return NotFound(serviceResponse);
                }
                else
                {
                    serviceResponse = new ServiceResponse<EmployeeDetails>
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                    };

                    _logger.LogInformation("GetEmployeeDetails API model is Invalid", serviceResponse.IsSuccess);
                    return BadRequest(serviceResponse);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Internal Server error" + ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, model);
            }
        
    }


        [HttpPost("UpdateEmployeeDesignation")]
        public IActionResult UpdateEmployeeDesignation([FromBody] UpdateEmployeDesignationRequestModel model)
        {
            ServiceResponse<object> serviceResponse;
            try
            {
                if (ModelState.IsValid)
                {
                    var response = _employeeRepository.UpdateDesignation(model);
                    if (response)
                    {
                        serviceResponse = new ServiceResponse<object>
                        {
                            IsSuccess = true,
                            StatusCode = HttpStatusCode.OK,
                            Result = response
                        };

                        _logger.LogInformation($"UpdateEmployeeDesignation API is Successfull", serviceResponse.IsSuccess);
                        return Ok(serviceResponse);
                    }

                    serviceResponse = new ServiceResponse<object>
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        IsSuccess = false,
                    };

                    _logger.LogInformation($"UpdateEmployeeDesignation API is Notfound", serviceResponse.IsSuccess);
                    return NotFound(serviceResponse);
                }
                else
                {
                    serviceResponse = new ServiceResponse<object>
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                    };

                    _logger.LogInformation("UpdateEmployeeDesignation API model is Invalid", serviceResponse.IsSuccess);
                    return BadRequest(serviceResponse);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Internal Server error" + ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, model);
            }

        }


        [HttpGet("GetAllEmployeeDetails")]
        public IActionResult GetAllEmployeeDetails()
        {
            ServiceResponse<List<EmployeeDetails>> serviceResponse;
            try
            {
                if (ModelState.IsValid)
                {
                    var response = _employeeRepository.GetAllEmployeeDetails();
                    if (response != null)
                    {
                        serviceResponse = new ServiceResponse<List<EmployeeDetails>>
                        {
                            IsSuccess = true,
                            StatusCode = HttpStatusCode.OK,
                            Result = response
                        };

                        _logger.LogInformation($"GetAllEmployeeDetails API is Successfull", serviceResponse.IsSuccess);
                        return Ok(serviceResponse);
                    }

                    serviceResponse = new ServiceResponse<List<EmployeeDetails>>
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        IsSuccess = false,
                    };

                    _logger.LogInformation($"GetAllEmployeeDetails API is Notfound", serviceResponse.IsSuccess);
                    return NotFound(serviceResponse);
                }
                else
                {
                    serviceResponse = new ServiceResponse<List<EmployeeDetails>>
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                    };

                    _logger.LogInformation("GetAllEmployeeDetails API model is Invalid", serviceResponse.IsSuccess);
                    return BadRequest(serviceResponse);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Internal Server error" + ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPost("AddNewEmployee")]
        public IActionResult AddNewEmployee([FromBody] NewEmployeeDetailsRequestModel model)
        {
            ServiceResponse<object> serviceResponse;
            try
            {
                if(ModelState.IsValid)
                {
                    var response = _employeeRepository.AddNewEmployee(model);
                    if (response)
                    {
                        serviceResponse = new ServiceResponse<object>
                        {
                            IsSuccess = true,
                            StatusCode = HttpStatusCode.OK,
                            Result = response
                        };
                        _logger.LogInformation($"AddNewEmployee API is Successfull", serviceResponse.IsSuccess);
                        return Ok(serviceResponse);
                    }
                    serviceResponse = new ServiceResponse<object>
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        Result = response
                    };
                    _logger.LogInformation("AddNewEmployee API model is Invalid", serviceResponse.IsSuccess);
                    return BadRequest(serviceResponse);
                }
                serviceResponse = new ServiceResponse<object>
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                };

                _logger.LogInformation("AddNewEmployee API model is Invalid", serviceResponse.IsSuccess);
                return BadRequest(serviceResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Internal Server error" + ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
