using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteApi.Application.Features.Notes.Queries.GetAllNotes;

namespace NoteApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IMediator mediatr;

        public NoteController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotesAsync()
        {
            var response = await mediatr.Send(new GetAllNotesQueryRequest());

            return Ok(response);
        }

    }
}
