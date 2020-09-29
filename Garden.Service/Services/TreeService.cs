using Flunt.Validations;
using Garden.Domain.Interfaces;
using Garden.Domain.Models;
using Garden.Infra.Shared.Contexts;
using Garden.Infra.Shared.Mapper;
using System.Collections.Generic;

namespace Garden.Service.Services
{
    public class TreeService : IServiceTree
    {
        private readonly IRepositoryTree _repositoryTree;
        private readonly NotificationContext _notificationContext;

        public TreeService(IRepositoryTree repositoryTree, NotificationContext notificationContext)
        {
            _repositoryTree = repositoryTree;
            _notificationContext = notificationContext;
        }

        public IEnumerable<TreeModel> RecoverAll()
        {
            var trees = _repositoryTree.GetAll();
            return trees.ConvertToTrees();
        }

        public TreeModel RecoverById(int id)
        {
            var tree = _repositoryTree.GetById(id);
            return tree.ConvertToTree();
        }

        public void Delete(int id)
        {
            var tree = _repositoryTree.GetById(id);
            _repositoryTree.Remove(tree);
        }

        public TreeModel Insert(CreateTreeModel treeModel)
        {
            var tree = treeModel.ConvertToTreeEntity();
            _notificationContext.AddNotifications(tree.Notifications);

            if (_notificationContext.Invalid)
                return default;

            _repositoryTree.Save(tree);

            return tree.ConvertToTree();
        }

        public TreeModel Update(int id, UpdateTreeModel treeModel)
        {
            if (id != treeModel.Id)
            {
                _notificationContext.AddNotifications(new Contract().AreNotEquals(id, treeModel.Id, nameof(id), "Tree not found."));

                return default;
            }

            var tree = treeModel.ConvertToTreeEntity();

            _notificationContext.AddNotifications(tree.Notifications);

            if (_notificationContext.Invalid)
                return default;

            _repositoryTree.Save(tree);
            return tree.ConvertToTree();
        }
    }
}
