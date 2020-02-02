using Products.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Domain.Base
{
    public abstract class DomainBase : Entity
    {
        public DomainBase(string name, int? id = null)
        {
            if (id.HasValue)
                Id = (int)id;

            Name = name;
        }

        //Props
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
