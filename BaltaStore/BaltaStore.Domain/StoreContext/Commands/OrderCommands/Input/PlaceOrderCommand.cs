using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaStore.Domain.StoreContext.Commands.OrderCommands.Input
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }
        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasLen(Customer.ToString(), 36, "Customer", "Identificador do cliente inválido")
                .IsGreaterThan(OrderItems.Count, 40, "Items", "Nenhum item do pedido foi encontrado")
                );
            return Valid();
        }
    }

    public class OrderItemCommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}
