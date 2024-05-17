using ApplicationFormTask.Core.Application.Dto;
using ApplicationFormTask.Core.Application.Interface.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationFormTask.Controllers
{
    [Route("api/questionTypes")]
    [ApiController]
    public class QuestionTypesController : ControllerBase
    {
        private readonly IQuestionTypesService _questionTypesService;

        public QuestionTypesController(IQuestionTypesService questionTypesService)
        {
            _questionTypesService = questionTypesService;
        }

        [HttpPost("date")]
        public async Task<IActionResult> CreateDateQuestion(DateQuestionRequest model)
        {
            var response = await _questionTypesService.CreateDateQuestion(model);
            return StatusCode(response.Status ? 201 : 400, response);
        }

        [HttpPost("dropdown")]
        public async Task<IActionResult> CreateDropdownQuestion(DropdownQuestionRequestModel model)
        {
            var response = await _questionTypesService.CreateDropdownQuestion(model);
            return StatusCode(response.Status ? 201 : 400, response);
        }

        [HttpPost("multiple")]
        public async Task<IActionResult> CreateMultipleQuestion(MultipleQuestionRequestModel model)
        {
            var response = await _questionTypesService.CreateMultipleQuestion(model);
            return StatusCode(response.Status ? 201 : 400, response);
        }

        [HttpPost("numeric")]
        public async Task<IActionResult> CreateNumericQuestion(NumericQuestionRequestModel model)
        {
            var response = await _questionTypesService.CreateNumericQuestion(model);
            return StatusCode(response.Status ? 201 : 400, response);
        }

        [HttpPost("paragraph")]
        public async Task<IActionResult> CreateParagraphQuestion(ParagraphQuestionRequestModel model)
        {
            var response = await _questionTypesService.CreateParagraphQuestion(model);
            return StatusCode(response.Status ? 201 : 400, response);
        }

        [HttpPost("yesorno")]
        public async Task<IActionResult> CreateYesOrNoQuestion(YesOrNoQuestionRequestModel model)
        {
            var response = await _questionTypesService.CreateYesOrNoQuestion(model);
            return StatusCode(response.Status ? 201 : 400, response);
        }
    }
}

