using MediatR;
using NoteApi.Application.Interfaces.UnitOfWorks;
using NoteApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApi.Application.Features.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateNoteCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task Handle(CreateNoteCommandRequest request, CancellationToken cancellationToken)
        {
            Note note = new(request.Title,request.Content,request.CategoryId);

            await unitOfWork.GetWriteRepository<Note>().AddAsync(note);
            await unitOfWork.SaveAsync();
        }

        
    }
}
