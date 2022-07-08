using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blmk.Domain.ValueObjects
{
    public record class Address(string street, string city, string zipcode);
}
