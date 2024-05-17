using ApplicationFormTask.Core.Application.Dto;
using ApplicationFormTask.Core.Application.Interface.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationFormTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditLogController : ControllerBase
    {
        private readonly IAuditLogService _auditLogService;

        public AuditLogController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }

        [HttpGet("{action}")]
        public async Task<ActionResult<BaseResponse<AuditLogDto>>> GetByAction(string action)
        {
            var response = await _auditLogService.Get(action);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("{timestamp}")]
        public async Task<ActionResult<BaseResponse<AuditLogDto>>> GetByTimestamp(DateTime timestamp)
        {
            var response = await _auditLogService.Get(timestamp);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<ICollection<AuditLogDto>>>> GetAll()
        {
            var response = await _auditLogService.GetAll();
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
