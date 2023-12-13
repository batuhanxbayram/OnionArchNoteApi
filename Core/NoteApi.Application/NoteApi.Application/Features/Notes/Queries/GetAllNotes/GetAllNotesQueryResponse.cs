using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApi.Application.Features.Notes.Queries.GetAllNotes
{
    public class GetAllNotesQueryResponse
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreatedDate { get; set; }

    }
}
