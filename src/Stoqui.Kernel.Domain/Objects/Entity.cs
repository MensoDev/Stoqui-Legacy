using Stoqui.Kernel.Domain.Messages;

namespace Stoqui.Kernel.Domain.Objects
{
    public abstract class Entity
    {

        private List<Event> _events;

        protected Entity()
        {
            _events = new();
            Id = Guid.NewGuid();
        }



        public Guid Id { get; protected set; }
        public DateTime RegistrationDate { get; protected set; }


        protected abstract void Validate();

        public void AddEvent(Event eventItem)
        {
            _events ??= new();
            _events.Add(eventItem);
        }

        public void RemoveEvent(Event eventItem)
        {
            _events?.Remove(eventItem);
        }

        public void ClearEvents()
        {
            _events?.Clear();
        }


        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (compareTo is null) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity? a, Entity? b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

    }
}
