using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Shared.Entities;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Order : Entity
    {
        #region readonly's
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;
        #endregion

        #region Construtores
        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }
        #endregion

        #region Atributos
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items { get { return _items.ToArray(); } }
        public IReadOnlyCollection<Delivery> Deliveries { get { return _deliveries.ToArray(); } }
        #endregion

        #region Metodos
        public void AddItem(Product product, decimal quantity)
        {
            if (quantity > product.QuatityOnHand)
                AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} em estoque.");
            var item = new OrderItem(product, quantity);
            _items.Add(item);
        }
        //Criar um pedido
        public void PlaceOrder()
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            if (_items.Count == 0)
            {
                AddNotification("Order", "Este pedido não possui itens");
            }
        }

        //Pagar um pedido
        public void PayOrder()
        {
            Status = EOrderStatus.Paid;

        }

        //Enviar um pedido
        public void Ship()
        {
            //A cada 5 produtos é uma entrega separada
            var deliveries = new List<Delivery>();
            deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
            var count = 1;

            //Quebra as Entregas
            foreach (var item in _items)
            {
                if (count <= 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }
            //Envia todas as entregas
            deliveries.ForEach(x => x.Ship());
            //Adiciona as entregas ao pedido 
            deliveries.ForEach(x => _deliveries.Add(x));
        }

        //Cancelar um pedido 
        public void CancelOrder()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.CancelOrder());
        }
        #endregion
    }
}