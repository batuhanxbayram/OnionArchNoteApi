using Microsoft.EntityFrameworkCore;
using NoteApi.Application.Interfaces.Repositories;
using NoteApi.Domain.Common;
using NoteApi.Persistence.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApi.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T>
        where T : class,IEntityBase, new()
    {
        private readonly AppDbContext context;
        private DbSet<T> Table { get => context.Set<T>(); }

        public WriteRepository(AppDbContext context)
        {
            this.context = context;
        }
        public WriteRepository() { }

        public async Task AddAsync(T entity)
        {
           await Table.AddAsync(entity);
           
        }

        public async Task AddRangeAsync(IList<T> entity)
        {
            await Table.AddRangeAsync(entity);
        }

        public async Task HardDeleteAsync(T entity)
        {
            await Task.Run(()=> Table.Remove(entity));
        }
        public async Task<T> UpdateAsync(T entity)
        {
           await Task.Run(() => Table.Update(entity));

            return entity;
        }
    }
}
