using MediatR;
using NoteApi.Application.Interfaces.UnitOfWorks;
using NoteApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApi.Application.Features.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteNoteCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteNoteCommandRequest request, CancellationToken cancellationToken)
        {
          var note = await unitOfWork.GetReadRepository<Note>().GetAsync(x=> x.Id == request.Id && !x.IsDeleted);
            
            note.IsDeleted = true;
            await unitOfWork.GetWriteRepository<Note>().UpdateAsync(note);
            await unitOfWork.SaveAsync();

            
        }
    }
}
