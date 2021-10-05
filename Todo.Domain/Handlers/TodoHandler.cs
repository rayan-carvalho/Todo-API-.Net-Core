using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : 
        Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkAsUnDoneCommand>
    {
        private readonly ITodoRepository _repository;
        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GeneicCommandResult(false,"Ops, parece que sua tarefa está errada.",command.Notifications);

            var todo = new TodoItem(command.Title, command.User, command.Date);

            _repository.Create(todo);


            return new GeneicCommandResult(true, "tarefa Salva", todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GeneicCommandResult(false, "Ops, parece que sua tarefa está errada.", command.Notifications);
          
            var todo = _repository.GetById(command.Id, command.User);

            todo.UpdateTitle(command.Title);

            _repository.Update(todo);


            return new GeneicCommandResult(true, "tarefa Salva", todo);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GeneicCommandResult(false, "Ops, parece que sua tarefa está errada.", command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            todo.MarkAsDone();

            _repository.Update(todo);


            return new GeneicCommandResult(true, "tarefa Salva", todo);
        }

        public ICommandResult Handle(MarkAsUnDoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GeneicCommandResult(false, "Ops, parece que sua tarefa está errada.", command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            todo.MarkAsUnDone();

            _repository.Update(todo);


            return new GeneicCommandResult(true, "tarefa Salva", todo);
        }
    }
}
