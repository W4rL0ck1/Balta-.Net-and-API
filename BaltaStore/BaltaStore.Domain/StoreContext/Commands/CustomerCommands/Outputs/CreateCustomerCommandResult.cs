using BaltaStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs
{
    class CreateCustomerCommandResult : ICommandResult
    {
        public CreateCustomerCommandResult()
        {

        }

        public CreateCustomerCommandResult(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
