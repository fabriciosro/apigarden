using Flunt.Validations;
using Garden.Domain.ValueTypes;
using System;
using System.Collections.Generic;

namespace Garden.Domain.Entities
{
    public class Harvest : BaseEntity<int>
    {
        public Harvest(int id, Information information, DateTime harvestDate, int grossWeight, int treeId) : base(id)
        {
            AddNotifications(
                information.contract);

            if (Valid)
            {
                Information = information;
                HarvestDate = harvestDate;
                GrossWeight = grossWeight;
                TreeId = treeId;
            }
        }

        protected Harvest() { }
        public Information Information { get; }
        public DateTime HarvestDate { get; }
        public int? GrossWeight { get; }
        public int TreeId { get; }
        public Tree Tree { get; set; }
    }
}
