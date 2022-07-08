using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blmk.Domain.Exceptions
{
    public class ClientExampleException : Exception
    {
        public ClientExampleException(string client)
       : base($"Client {client} has an exception for some reason")
        {
        }
    }
}
