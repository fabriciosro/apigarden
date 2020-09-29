using Flunt.Validations;
using Garden.Domain.ValueTypes;
using System;
using System.Collections.Generic;

namespace Garden.Domain.Entities
{
    public class Tree : BaseEntity<int>
    {
        public Tree(int id, Information information, DateTime treeAge, Specie specie) : base(id)
        {
            AddNotifications(
                information.contract,
                ValidateTreeAge(treeAge));

            if (Valid)
            {
                Information = information;
                TreeAge = treeAge;
                Specie = specie;
            }
        }

        public Tree(int id, Information information, DateTime treeAge) : base(id)
        {
            AddNotifications(
                information.contract,
                ValidateTreeAge(treeAge));

            if (Valid)
            {
                Information = information;
                TreeAge = treeAge;
            }
        }

        protected Tree() { }
        public Information Information { get; }
        public DateTime TreeAge { get; }
        public int? SpecieId { get; }
        public Specie Specie { get; }
        public virtual IEnumerable<Harvest> Harvests { get; }
        private Contract ValidateTreeAge(DateTime treeAge) =>
            new Contract()
                .IsLowerThan(new DateTime(1500, 12, 1), treeAge, nameof(treeAge), "very old.")
                .IsGreaterThan(DateTime.Now.AddYears(-8), treeAge, nameof(treeAge), "very young.");
    }
}
