using Garden.Domain.Entities;
using Garden.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Garden.Infra.Shared.Mapper
{
    public static class HarvestMapper
    {
        public static Harvest ConvertToHarvestEntity(this CreateHarvestModel harvestModel) =>
            new Harvest(
                0, 
                harvestModel.Information, 
                harvestModel.HarvestDate, 
                harvestModel.GrossWeight, 
                harvestModel.TreeId);

        public static Harvest ConvertToHarvestEntity(this UpdateHarvestModel harvestModel) =>
            new Harvest(
                harvestModel.Id, 
                harvestModel.Information, 
                harvestModel.HarvestDate, 
                harvestModel.GrossWeight, 
                harvestModel.TreeId);

        public static IEnumerable<HarvestModel> ConvertToHarvests(this IList<Harvest> harvests) =>
            new List<HarvestModel>(harvests.Select(
                s => new HarvestModel(
                    s.Id, 
                    s.Information.ToString(), 
                    s.HarvestDate, 
                    s.GrossWeight, 
                    s.TreeId,
                    new TreeModel(
                        s.Tree.Id,
                        s.Tree.Information.ToString(),
                        s.Tree.TreeAge,
                        null
                    ))));

        public static HarvestModel ConvertToHarvest(this Harvest harvest) =>
            new HarvestModel(
                    harvest.Id,
                    harvest.Information.ToString(),
                    harvest.HarvestDate,
                    harvest.GrossWeight,
                    harvest.TreeId,
                    new TreeModel(
                        harvest.Tree.Id,
                        harvest.Tree.Information.ToString(),
                        harvest.Tree.TreeAge,
                        null
                    ));
    }
}
