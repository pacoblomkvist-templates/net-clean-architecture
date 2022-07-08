using Blmk.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blmk.Application.Features.Client.EventHandlers
{
    public class ClientCreatedEventHandler : INotificationHandler<ClientCreatedEvent>
    {
        private readonly ILogger<ClientCreatedEvent> _logger;

        public ClientCreatedEventHandler(ILogger<ClientCreatedEvent> logger)
        {
            _logger = logger;
        }

        public Task Handle(ClientCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("TEst Event Handler: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
