using Domain.Customers;
using Domain.Products;
using StrongTypedId.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    public class Order
    {
        private Order()
        {
        }

        private readonly HashSet<LineItem> _lineItems = new();

        public OrderId Id { get; private set; }

        public CustomerId CustomerId { get; private set; }

        public IReadOnlyList<LineItem> LineItems => _lineItems.ToList();

        public static Order Create(CustomerId customerId)
        {
            var order = new Order()
            {
                Id = new OrderId(Guid.NewGuid()),
                CustomerId = customerId,
            };

            return order;
        }

        public void Add(ProductId productId, Money price)
        {
            var lineItem = new LineItem(
                new LineItemId(Guid.NewGuid()),
                Id,
                productId,
                price);

            _lineItems.Add(lineItem);
        }
    }

    public class LineItem
    {
        private LineItem() { }
        internal LineItem(LineItemId id,
            OrderId orderId,
            ProductId productId,
            Money price)
        {
            Id = id;
            OrderId = orderId;
            ProductId = productId;
            Price = price;
        }

        public LineItemId Id { get; private set; }

        public OrderId OrderId { get; private set; }

        public ProductId ProductId { get; private set; }

        public Money Price { get; private set; }
    }

    public record LineItemId(Guid Value);

    public record OrderId(Guid Value);
}
