﻿namespace Stoqui.Kernel.Domain.Objects
{
    public abstract class Entity
    {

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; protected set; }
        public DateTime RegistrationDate { get; protected set; }


        protected abstract void Validate();


    }
}
