using Blmk.Application.Common.Interfaces;
using Blmk.Application.Common.Models;
using Blmk.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blmk.Application.Features.Client.Commands
{
    public class CreateClientCommand : IRequest<ResponseModel>
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, ResponseModel>
    {
        private readonly IAlephDbContext _context;
        public CreateClientCommandHandler(IAlephDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = ClientExample.Create(request.Name, request.Street, request.City, request.ZipCode);
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync(cancellationToken);

            return ResponseModel.Success();

        }

        public class CreateTodoItemCommandValidator : AbstractValidator<CreateClientCommand>
        {
            public CreateTodoItemCommandValidator()
            {
                RuleFor(v => v.Name)
                    .MaximumLength(200)
                    .NotEmpty();

            }
        }
    }
}
