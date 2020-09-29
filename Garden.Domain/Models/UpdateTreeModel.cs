using Garden.Domain.Entities;
using System;

namespace Garden.Domain.Models
{
    public class UpdateTreeModel
    {
        public int Id { get; set; }
        public string Information { get; set; }
        public DateTime TreeAge { get; set; }
        public Specie Specie { get; set; }
    }
}
