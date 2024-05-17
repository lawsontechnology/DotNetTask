using ApplicationFormTask.Core.Application.Dto;
using ApplicationFormTask.Core.Application.Interface.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApplicationFormTask.Controllers
{
    [Route("api/personalInformation")]
    [ApiController]
    public class PersonalInformationController : ControllerBase
    {
        private readonly IPersonalInformationService _personalInformationService;

        public PersonalInformationController(IPersonalInformationService personalInformationService)
        {
            _personalInformationService = personalInformationService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonalInformationRequestModel model)
        {
            var response = await _personalInformationService.Create(model);
            return StatusCode(response.Status ? 201 : 400, response);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var response = await _personalInformationService.GetInformation(email);
            return StatusCode(response.Status ? 200 : 404, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _personalInformationService.GetAllInformation();
            return StatusCode(response.Status ? 200 : 404, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _personalInformationService.DeleteInformation(id);
            return StatusCode(response.Status ? 200 : 404, response);
        }
    }
}

