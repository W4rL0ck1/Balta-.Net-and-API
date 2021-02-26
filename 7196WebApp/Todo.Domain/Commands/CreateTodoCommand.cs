using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class CreateTodoCommand : Notifiable, ICommand
    {
        public CreateTodoCommand() { }
        
        public CreateTodoCommand(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
            Date = date;
        }

        public string Title { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public List<string> Erros { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Title, 3, "Title", "Por favor, descreva melhor esta tarefa!")
                .HasMinLen(User, 6 , "User", "O Usuario deve ter mais de 6 caracteres!")
                );
        }
    }
}
