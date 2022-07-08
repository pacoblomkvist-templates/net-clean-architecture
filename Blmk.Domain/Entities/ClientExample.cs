using Blmk.Domain.Common;
using Blmk.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blmk.Domain.Entities
{
    public class ClientExample : BaseEntity
    {
        public ClientExample() { } //needed by EF
        private ClientExample(string fullName, Address address)
        {
            FullName = fullName;
            Address = address;
        }

        public string FullName { get; set; }
        public Address Address { get; set; }

        public static ClientExample Create(string fullname, string street, string city, string zipcode)
        {
            var address = new Address(street, city, zipcode);
            var client = new ClientExample(fullname, address);

            client.AddDomainEvent(new ClientCreatedEvent(client));

            return client;
        }

    }

    public class ClientCreatedEvent : BaseEvent
    {
        public ClientCreatedEvent(ClientExample client)
        {
            Client = client;
        }

        public ClientExample Client { get; }

    }
}
