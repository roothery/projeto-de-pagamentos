using Flunt.Notifications;

namespace ContextoContextoDePagamento.Shared.Entidades
{
    public abstract class Entidade : Notifiable
    {
        protected Entidade()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}