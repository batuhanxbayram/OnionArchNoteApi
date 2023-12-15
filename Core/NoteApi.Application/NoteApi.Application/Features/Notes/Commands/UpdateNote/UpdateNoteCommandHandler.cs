using AutoMapper;
using MediatR;
using NoteApi.Application.Interfaces.UnitOfWorks;
using NoteApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApi.Application.Features.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateNoteCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

       

        public  async Task Handle(UpdateNoteCommandRequest request, CancellationToken cancellationToken)
        {
            var note = await unitOfWork.GetReadRepository<Note>().GetAsync(x=> x.Id==request.Id && !x.IsDeleted);

            var mapped = mapper.Map<UpdateNoteCommandRequest>(request);

            await unitOfWork.GetWriteRepository<Note>().UpdateAsync(note);
            await unitOfWork.SaveAsync();

        }
    }
}
