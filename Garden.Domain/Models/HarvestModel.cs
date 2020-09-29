using Garden.Domain.Entities;
using System;

namespace Garden.Domain.Models
{
    public class HarvestModel
    {
        public HarvestModel(int id, string information, DateTime harvestDate, int? grossWeight, int treeId)
        {
            Id = id;
            Information = information;
            HarvestDate = harvestDate;
            GrossWeight = grossWeight;
            TreeId = treeId;
        }
        public HarvestModel(int id, string information, DateTime harvestDate, int? grossWeight, int treeId, TreeModel tree)
        {
            Id = id;
            Information = information;
            HarvestDate = harvestDate;
            GrossWeight = grossWeight;
            TreeId = treeId;
            Tree = tree;
        }

        public int Id { get; set; }
        public string Information { get; set; }
        public DateTime HarvestDate { get; set; }
        public int? GrossWeight { get; set; }
        public int TreeId { get; set; }
        public TreeModel Tree { get; set; }
    }
}
