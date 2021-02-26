using PaymentContext.Shared.ValueObjects;
using Flunt.Validations;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract()
            .Requires()
            .IsEmail(address,"Email.Addres","E-mail Inválido")
            );

        }

        public string Address { get;private set; }       
    }
}