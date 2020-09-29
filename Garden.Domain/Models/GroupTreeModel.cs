
namespace Garden.Domain.Models
{
    public class GroupTreeModel
    {
        public GroupTreeModel(int id, string name, string information)
        {
            Id = id;
            Name = name;
            Information = information;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }
    }
}
