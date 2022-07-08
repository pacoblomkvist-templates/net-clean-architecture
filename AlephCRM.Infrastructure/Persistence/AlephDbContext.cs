using Blmk.Application.Common.Interfaces;
using Blmk.Domain.Entities;
using Blmk.Infrastructure.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blmk.Infrastructure.Persistence
{
    public class AlephDbContext : DbContext, IAlephDbContext
    {
        private readonly IMediator _mediator;

        public AlephDbContext(IMediator mediator, DbContextOptions options) : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<ClientExample> Clients { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }



        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEvents(this);

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
