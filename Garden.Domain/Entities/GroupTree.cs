using System.Collections.Generic;

namespace Garden.Domain.Entities
{
    public class GroupTree : BaseEntity<int>
    {
        public GroupTree(int id, string name, string information) : base(id)
        {
            if (Valid)
            {
                Name = name;
                Information = information;
            }
        }

        protected GroupTree() { }
        public string Name { get; }
        public string Information { get;  }
        public virtual IEnumerable<Harvest> Harvests { get; }
    }
}
