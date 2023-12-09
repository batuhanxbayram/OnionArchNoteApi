using NoteApi.Application.Interfaces.Repositories;
using NoteApi.Application.Interfaces.UnitOfWorks;
using NoteApi.Persistence.context;
using NoteApi.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApi.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        public async ValueTask DisposeAsync() =>await context.DisposeAsync();
        public int Save()=>context.SaveChanges();
        public async Task<int> SaveAsync()=> await context.SaveChangesAsync();
        

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>()
        {
            return new ReadRepository<T>(context);
        }

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()
        {
            return new WriteRepository<T>(context);
        }
    }
}
