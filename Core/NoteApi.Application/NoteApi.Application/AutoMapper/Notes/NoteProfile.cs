using AutoMapper;
using NoteApi.Application.Features.Notes.Queries.GetAllNotes;
using NoteApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApi.Application.AutoMapper.Notes
{
    public class NoteProfile:Profile
    {
        public NoteProfile()
        {
            CreateMap<Note, GetAllNotesQueryResponse>().ReverseMap();
        }

    }
}
