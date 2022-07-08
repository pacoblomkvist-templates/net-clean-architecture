using Blmk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blmk.Application.Common.Interfaces
{
    public interface IAlephDbContext
    {
        DbSet<ClientExample> Clients { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
