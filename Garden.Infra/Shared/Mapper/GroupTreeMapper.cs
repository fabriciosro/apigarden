using Garden.Domain.Entities;
using Garden.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Garden.Infra.Shared.Mapper
{
    public static class GroupTreeMapper
    {
        public static GroupTree ConvertToGroupTreeEntity(this CreateGroupTreeModel GroupTreeModel) =>
            new GroupTree(
                0, 
                GroupTreeModel.Name, 
                GroupTreeModel.Information);

        public static GroupTree ConvertToGroupTreeEntity(this UpdateGroupTreeModel GroupTreeModel) =>
            new GroupTree(
                GroupTreeModel.Id, 
                GroupTreeModel.Name, 
                GroupTreeModel.Information);

        public static IEnumerable<GroupTreeModel> ConvertToGroupTrees(this IList<GroupTree> GroupTrees) =>
            new List<GroupTreeModel>(
                GroupTrees.Select(s => new GroupTreeModel(
                    s.Id, 
                    s.Name, 
                    s.Information)));

        public static GroupTreeModel ConvertToGroupTree(this GroupTree GroupTree) =>
            new GroupTreeModel(
                GroupTree.Id, 
                GroupTree.Name,  
                GroupTree.Information);
    }
}
