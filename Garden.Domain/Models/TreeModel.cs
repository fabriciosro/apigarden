using Garden.Domain.Entities;
using System;

namespace Garden.Domain.Models
{
    public class TreeModel
    {
        public TreeModel(int id, string information, DateTime treeAge, Specie specie)
        {
            Id = id;
            Information = information;
            TreeAge = treeAge;
            Specie = specie;
        }

        public int Id { get; set; }
        public string Information { get; set; }
        public DateTime TreeAge { get; set; }
        public Specie Specie { get; set; }
    }
}
