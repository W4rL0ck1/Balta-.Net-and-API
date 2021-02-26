using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace baltastore.tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Renato", "Santos");
            var document = new Document("12345678911");
            var email = new Email("hello@balta.io");
            var costumer = new Customer(name, document, email, "13999944411");
            var mouse = new Product("Mouse", "Brabissiimo e só 10 conto", "image.png", 59.90M, 10);
            var teclado = new Product("Teclado", "faz tec tec", "image.png", 159.90M, 10);
            var impressora = new Product("Impressora", "Imprime as coisas", "image.png", 359.90M, 10);
            var cadeira = new Product("Cadeira", "Por esse preço aparentemente este item é banhado a ouro", "image.png", 559.90M, 10);

           /* var order = new Order(costumer);
            order.AddItem(new OrderItem(mouse, 5));
            order.AddItem(new OrderItem(teclado, 5));
            order.AddItem(new OrderItem(impressora, 5));
            order.AddItem(new OrderItem(cadeira, 5));

            order.PlaceOrder();
            order.PayOrder();
            order.Ship();
            order.CancelOrder();*/


            //var order = new Order(c);
        }
    }
}
