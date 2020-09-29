using System;

namespace Garden.Domain.Models
{
    public class CreateHarvestModel
    {
        public string Information { get; set; }

        public DateTime HarvestDate { get; set; }

        public int GrossWeight { get; set; }

        public int TreeId { get; set; }
    }
}
