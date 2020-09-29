using Garden.Domain.Entities;
using Garden.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Garden.Infra.Shared.Mapper
{
    public static class TreeMapper
    {
        public static Tree ConvertToTreeEntity(this CreateTreeModel TreeModel) =>
            new Tree(0, TreeModel.Information, TreeModel.TreeAge, TreeModel.Specie);

        public static Tree ConvertToTreeEntity(this UpdateTreeModel TreeModel) =>
            new Tree(TreeModel.Id, TreeModel.Information, TreeModel.TreeAge, TreeModel.Specie);

        public static IEnumerable<TreeModel> ConvertToTrees(this IList<Tree> Trees) =>
            new List<TreeModel>(Trees.Select(s => new TreeModel(s.Id, s.Information.ToString(), s.TreeAge, s.Specie)));

        public static TreeModel ConvertToTree(this Tree Tree) =>
            new TreeModel(Tree.Id, Tree.Information.ToString(), Tree.TreeAge, Tree.Specie);
    }
}
