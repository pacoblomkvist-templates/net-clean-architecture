using Blmk.Application.Common.Interfaces;
using Blmk.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blmk.Application.Features.Client.Queries
{
    public class GetClientDto
    {
        public string FullName { get; set; }
    }
    public class GetAllClientsQuery : IRequest<ResponseModel<List<GetClientDto>>>
    {
    }
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, ResponseModel<List<GetClientDto>>>
    {
        private readonly IAlephDbContext _context;

        public GetAllClientsQueryHandler(IAlephDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<GetClientDto>>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var clients = await _context.Clients.Where(c => !c.IsDeleted).ToListAsync();
            if (clients == null) return null;

            var result = clients.Select(c => new GetClientDto { FullName = c.FullName }).ToList();

            return ResponseModel<List<GetClientDto>>.Success(result);
        }
    }
}
