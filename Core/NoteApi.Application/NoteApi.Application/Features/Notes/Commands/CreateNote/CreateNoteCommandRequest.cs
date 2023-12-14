using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApi.Application.Features.Notes.Commands.CreateNote
{
    public class CreateNoteCommandRequest:IRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }

        public CreateNoteCommandRequest()
        {
        }

        public CreateNoteCommandRequest(string title, string content, Guid categoryId)
        {
            Title = title;
            Content = content;
            CategoryId = categoryId;
        }
    }
}
