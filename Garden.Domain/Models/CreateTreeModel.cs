using Garden.Domain.Entities;
using System;

namespace Garden.Domain.Models
{
    public class CreateTreeModel
    {
        public string Information { get; set; }
        public DateTime TreeAge { get; set; }
        public Specie Specie { get; set; }
    }
}
