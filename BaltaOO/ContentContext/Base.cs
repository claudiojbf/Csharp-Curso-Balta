using BaltaOO.NotificationContext;

namespace BaltaOO.ContentContext
{

    public abstract class Base : Notifiable
    {
        public Base()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}