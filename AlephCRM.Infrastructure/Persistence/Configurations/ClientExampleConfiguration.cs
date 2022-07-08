using Blmk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blmk.Infrastructure.Persistence.Configurations
{
    public class ClientExampleConfiguration : IEntityTypeConfiguration<ClientExample>
    {
        public void Configure(EntityTypeBuilder<ClientExample> builder)
        {
            builder.OwnsOne(b => b.Address);
        }
    }
}
