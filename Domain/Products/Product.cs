using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public class Product
    {
        public ProductId Id { get; private set; }

        public string Name { get; private set; }

        public Money Price { get; private set; }

        public Sku Sku { get; private set; }
    }

    public record ProductId(Guid Value);

    public record Money(string Currency, decimal Amount);

    public record Sku
    {
        private const int DefaultLength = 15;

        private Sku(string value) => Value = value;

        public string Value { get; init; }

        public static Sku? Create(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
                return null;

            if(value.Length !=  DefaultLength)
                return null;

            return new Sku(value);
        }
    }
}
