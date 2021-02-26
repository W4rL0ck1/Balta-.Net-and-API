using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateTodoCommand command)
        {
            //Criar um todo
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            //Gera o TodoItem
            var todo = new TodoItem(command.Title, command.User, command.Date);

            //Salvar um todo no banco
            _repository.Create(todo);

            //Notificar o usuario


            //Retorna o Resultado
            return new GenericCommandResult(true, "Tarefa Salva", todo);           
        }
        public ICommandResult Handle(UpdateTodoCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            // Recupera o TodoItem (Rehidratação)
            var todo = _repository.GetById(command.Id, command.User);

            //Salvar um todo no banco
            _repository.Update(todo);

            //Retorna o Resultado
            return new GenericCommandResult(true, "Tarefa Salva", todo);
        }
        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            // Recupera o TodoItem (Rehidratação)
            var todo = _repository.GetById(command.Id, command.User);

            //Altera o Estado
            todo.MarkAsDone();

            //Salvar um todo no banco
            _repository.Update(todo);

            //Retorna o Resultado
            return new GenericCommandResult(true, "Tarefa Salva", todo);
        }
        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            // Recupera o TodoItem (Rehidratação)
            var todo = _repository.GetById(command.Id, command.User);

            //Altera o Estado
            todo.MarkAsUndone();

            //Salvar um todo no banco
            _repository.Update(todo);

            //Retorna o Resultado
            return new GenericCommandResult(true, "Tarefa Salva", todo);
        }
    }
}
