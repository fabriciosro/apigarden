
namespace Garden.Domain.Models
{
    public class SpecieModel
    {
        public SpecieModel(int id, string information)
        {
            Id = id;
            Information = information;
        }

        public int Id { get; set; }
        public string Information { get; set; }
    }
}
