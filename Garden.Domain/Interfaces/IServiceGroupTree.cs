using Garden.Domain.Models;
using System.Collections.Generic;

namespace Garden.Domain.Interfaces
{
    public interface IServiceGroupTree
    {
        GroupTreeModel Insert(CreateGroupTreeModel GroupTreeModel);
        GroupTreeModel Update(int id, UpdateGroupTreeModel GroupTreeModel);
        void Delete(int id);
        GroupTreeModel RecoverById(int id);
        IEnumerable<GroupTreeModel> RecoverAll();
    }
}
