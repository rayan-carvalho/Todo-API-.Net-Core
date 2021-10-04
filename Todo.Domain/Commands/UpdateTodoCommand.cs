using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class UpdateTodoCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string User { get; set; }

        public UpdateTodoCommand() { }

        public UpdateTodoCommand(string title, string user, Guid id)
        {
            Title = title;
            Id = id;
            User = user;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Title, 3, "Title", "Por favor, descreva melhor estatarefa!")
                    .HasMinLen(User, 6, "User", "Usuário Inválido")
            );

        }
    }
}
