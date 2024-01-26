using MultiTenant.Domain.Common;
using MultiTenant.Domain.Common.ValueObjects;
using MultiTenant.Domain.Orders.ValueObjects;
using MultiTenant.Domain.Settings;

namespace MultiTenant.Domain.Orders;

public sealed class Order : Entity<Guid>, IAggregateRoot
{
    public decimal Discount { get; set; }
    public decimal DeliveryCharge { get; set; }
    public decimal TotalTax { get; set; }
    public decimal NetTotal { get; set; }
    
    // relationships
    public int ChannelId { get; set; }
    public OrderChannel Channel { get; set; } = null!;

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public Guid PaymentId { get; set; }
    public Payment Payment { get; set; } = null!;

    public int StatusId { get; set; }
    public OrderStatus OrderStatus { get; set; } = null!;
    
    // value objects
    public Address ShippingAddress { get; set; } = null!;
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public ICollection<AppliedTax> AppliedTaxes { get; set; } = new List<AppliedTax>();
}