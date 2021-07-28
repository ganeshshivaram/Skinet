using System;
using System.Collections.Generic;

namespace Core.Entities.OrderAggregate
{
    public class Order : BaseEntity
    {
        public Order()
        {
        }

        public Order(string buyerEmail,
        Address shippingAddress,
        DeliveryMethod deliveryMethod,
        IReadOnlyList<OrderItem> orderItem,
        decimal subtotal,
        string paymentIntentId)
        {
            BuyerEmail = buyerEmail;
            ShippingAddress = shippingAddress;
            DeliveryMethod = deliveryMethod;
            OrderItem = orderItem;
            Subtotal = subtotal;
            PaymentIntentId = paymentIntentId;
        }

        public string BuyerEmail { get; set; }

        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;

        public Address ShippingAddress { get; set; }

        public DeliveryMethod DeliveryMethod { get; set; }

        public IReadOnlyList<OrderItem> OrderItem { get; set; }

        public decimal Subtotal { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public string PaymentIntentId { get; set; }

        public decimal GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }
    }
}