using Products.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Domain.Base
{
    public abstract class DomainBase : Entity
    {
        public DomainBase(string name, Guid? id = null)
        {
            if (id.HasValue)
                Id = (Guid)id;
            else
                Id = Guid.NewGuid();
            Name = name;
        }

        //Props
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
