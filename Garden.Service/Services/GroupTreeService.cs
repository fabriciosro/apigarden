using Flunt.Validations;
using Garden.Domain.Interfaces;
using Garden.Domain.Models;
using Garden.Infra.Shared.Contexts;
using Garden.Infra.Shared.Mapper;
using System.Collections.Generic;

namespace Garden.Service.Services
{
    public class GroupTreeService : IServiceGroupTree
    {
        private readonly IRepositoryGroupTree _repositoryGroupTree;
        private readonly NotificationContext _notificationContext;

        public GroupTreeService(IRepositoryGroupTree repositoryGroupTree, NotificationContext notificationContext)
        {
            _repositoryGroupTree = repositoryGroupTree;
            _notificationContext = notificationContext;
        }
        public IEnumerable<GroupTreeModel> RecoverAll()
        {
            var GroupTrees = _repositoryGroupTree.GetAll();
            return GroupTrees.ConvertToGroupTrees();
        }

        public GroupTreeModel RecoverById(int id)
        {
            var GroupTree = _repositoryGroupTree.GetById(id);
            return GroupTree.ConvertToGroupTree();
        }

        public void Delete(int id)
        {
            var GroupTree = _repositoryGroupTree.GetById(id);
            _repositoryGroupTree.Remove(GroupTree);
        }

        public GroupTreeModel Insert(CreateGroupTreeModel GroupTreeModel)
        {
            var GroupTree = GroupTreeModel.ConvertToGroupTreeEntity();
            _notificationContext.AddNotifications(GroupTree.Notifications);

            if (_notificationContext.Invalid)
                return default;

            _repositoryGroupTree.Save(GroupTree);

            return GroupTree.ConvertToGroupTree();
        }

        public GroupTreeModel Update(int id, UpdateGroupTreeModel GroupTreeModel)
        {
            if (id != GroupTreeModel.Id)
            {
                _notificationContext.AddNotifications(new Contract().AreNotEquals(id, GroupTreeModel.Id, nameof(id), "GroupTree not found."));

                return default;
            }

            var GroupTree = GroupTreeModel.ConvertToGroupTreeEntity();

            _notificationContext.AddNotifications(GroupTree.Notifications);

            if (_notificationContext.Invalid)
                return default;

            _repositoryGroupTree.Save(GroupTree);
            return GroupTree.ConvertToGroupTree();
        }
    }
}
