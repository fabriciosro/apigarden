using Garden.Domain.Entities;
using System.Collections.Generic;

namespace Garden.Domain.Interfaces
{
    public interface IRepositoryTree
    {
        void Save(Tree obj);
        void Remove(Tree obj);
        Tree GetById(int id);
        IList<Tree> GetAll();
    }
}
