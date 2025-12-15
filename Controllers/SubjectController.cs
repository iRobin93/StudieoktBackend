using Microsoft.AspNetCore.Mvc;
using StudieøktBackend.Model.Entities;
using StudieøktBackend.Services.Interfaces;

namespace StudieøktBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        // GET /subject
        [HttpGet]
        public async Task<ActionResult<List<Subject>>> GetSubjects()
        {
            var subjects = await _subjectService.GetAllSubjectsAsync();
            return Ok(subjects);
        }

        // POST /subject
        [HttpPost]
        public async Task<ActionResult<Subject>> AddSubject([FromBody] Subject subject)
        {
            var created = await _subjectService.CreateSubjectAsync(subject);
            if (created == null)
                return BadRequest("Name is required.");

            return CreatedAtAction(nameof(GetSubjects), new { id = created.Id }, created);
        }
    }
}
