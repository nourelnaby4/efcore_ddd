using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Customers
{
    public class Customer
    {
        public CustomerId Id { get; private set; }

        public string Email { get; private set; }

        public string Name { get; private set; }
    }

    public record CustomerId(Guid Value);
}
