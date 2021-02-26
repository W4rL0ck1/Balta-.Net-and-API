using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string city, string neighborhood, string state, string country, string zipCodet)
        {
            Street = street;
            Number = number;
            City = city;
            Neighborhood = neighborhood;
            State = state;
            Country = country;
            ZipCodet = zipCodet;

            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(Street, 3 , "Address.Street","Nome deve conter pelo menos 3 caracteres")
            );
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string City { get; private set; }
        public string Neighborhood { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCodet { get; private set; }

    }
}