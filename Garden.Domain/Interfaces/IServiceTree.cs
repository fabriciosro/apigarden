using Garden.Domain.Models;
using System.Collections.Generic;

namespace Garden.Domain.Interfaces
{
    public interface IServiceTree
    {
        TreeModel Insert(CreateTreeModel treeModel);
        TreeModel Update(int id, UpdateTreeModel treeModel);
        void Delete(int id);
        TreeModel RecoverById(int id);
        IEnumerable<TreeModel> RecoverAll();
    }
}
