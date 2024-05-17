    using ApplicationFormTask.Core.Application.Dto;
    using ApplicationFormTask.Core.Application.Interface.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

namespace ApplicationFormTask.Controllers
{
        [Route("api/customQuestions")]
        [ApiController]
        public class CustomQuestionController : ControllerBase
        {
            private readonly ICustomQuestionService _customQuestionService;

            public CustomQuestionController(ICustomQuestionService customQuestionService)
            {
                _customQuestionService = customQuestionService;
            }

            [HttpPost]
            public async Task<IActionResult> CreateQuestion(CustomQuestionRequestModel model)
            {
                var response = await _customQuestionService.CreateQuestion(model);
                return StatusCode(response.Status ? 201 : 400, response);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetQuestion(string id)
            {
                var response = await _customQuestionService.GetQuestion(id);
                return StatusCode(response.Status ? 200 : 404, response);
            }

            [HttpGet]
            public async Task<IActionResult> GetAllQuestions()
            {
                var response = await _customQuestionService.GetAllQuestion();
                return StatusCode(response.Status ? 200 : 404, response);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateQuestion(string id, CustomQuestionUpdateModel model)
            {
                var response = await _customQuestionService.UpdateQuestion(model, id);
                return StatusCode(response.Status ? 200 : 404, response);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteQuestion(string id)
            {
                var response = await _customQuestionService.DeleteQuestion(id);
                return StatusCode(response.Status ? 200 : 404, response);
            }
        }
    }


