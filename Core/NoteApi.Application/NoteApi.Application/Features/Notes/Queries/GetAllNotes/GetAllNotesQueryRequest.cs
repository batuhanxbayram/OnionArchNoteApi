using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApi.Application.Features.Notes.Queries.GetAllNotes
{
    public class GetAllNotesQueryRequest:IRequest<IList<GetAllNotesQueryResponse>>
    {


    }
}
