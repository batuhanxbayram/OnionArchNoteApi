using AutoMapper;
using MediatR;
using NoteApi.Application.Interfaces.UnitOfWorks;
using NoteApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApi.Application.Features.Notes.Queries.GetAllNotes
{
    public class GetAllNotesQueryHandler : IRequestHandler<GetAllNotesQueryRequest, IList<GetAllNotesQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllNotesQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        
        public async Task<IList<GetAllNotesQueryResponse>> Handle(GetAllNotesQueryRequest request, CancellationToken cancellationToken)
        {
            var notes = await unitOfWork.GetReadRepository<Note>().GetAllAsync();
            var map = mapper.Map<List<GetAllNotesQueryResponse>>(notes);
            return map;

        }
    }
}
