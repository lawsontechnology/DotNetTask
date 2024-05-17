using ApplicationFormTask.Core.Application.Dto;
using ApplicationFormTask.Core.Application.Interface.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationFormTask.Controllers
{
    [Route("api/programEntity")]
    [ApiController]
    public class ProgramEntityController : ControllerBase
    {
        private readonly IProgramEntityService _programEntityService;

        public ProgramEntityController(IProgramEntityService programEntityService)
        {
            _programEntityService = programEntityService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProgramEntityRequestModel model)
        {
            var response = await _programEntityService.Create(model);
            return StatusCode(response.Status ? 201 : 400, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await _programEntityService.Get(id);
            return StatusCode(response.Status ? 200 : 404, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _programEntityService.GetAll();
            return StatusCode(response.Status ? 200 : 404, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _programEntityService.Delete(id);
            return StatusCode(response.Status ? 200 : 404, response);
        }
    }
}

