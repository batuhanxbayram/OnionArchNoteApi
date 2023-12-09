
using NoteApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApi.Domain.Entities
{
    public class Category:EntityBase
    {
       
        public string Name { get; set; }
        public ICollection<Note> Notes { get; set; }

        public Category(){}
        public Category(string name)
        {
            Name = name;
        }

    }
}
