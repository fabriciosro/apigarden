using Garden.Domain.ValueTypes;
using System.Collections.Generic;

namespace Garden.Domain.Entities
{
    public class Specie : BaseEntity<int>
    {
        public Specie(int id, string information) : base(id)
        {

            if (Valid)
            {
                Information = information;
            }
        }

        protected Specie() { }
        public string Information { get; }
        public virtual IEnumerable<Tree> Trees { get; }
    }
}
