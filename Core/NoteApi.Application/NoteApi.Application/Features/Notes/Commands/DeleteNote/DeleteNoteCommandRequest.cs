using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApi.Application.Features.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandRequest:IRequest
    {
        public Guid Id { get; set; }
    }
}
