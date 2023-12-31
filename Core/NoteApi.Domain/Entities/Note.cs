﻿using NoteApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApi.Domain.Entities
{
    public class Note: EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Note()
        {
        }
        public Note(string? title,string? content,Guid categoryId)
        {
            Title=title;
            Content=content;
            CategoryId = categoryId;
        }
    }
}
