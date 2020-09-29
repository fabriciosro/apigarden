using Garden.Domain.Entities;
using Garden.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Garden.Infra.Shared.Mapper
{
    public static class SpecieMapper
    {
        public static Specie ConvertToSpecieEntity(this CreateSpecieModel SpecieModel) =>
            new Specie(
                0, 
                SpecieModel.Information);

        public static Specie ConvertToSpecieEntity(this UpdateSpecieModel SpecieModel) =>
            new Specie(
                SpecieModel.Id, 
                SpecieModel.Information);

        public static IEnumerable<SpecieModel> ConvertToSpecies(this IList<Specie> Species) =>
            new List<SpecieModel>(
                Species.Select(
                    s => new SpecieModel(s.Id, s.Information.ToString())));

        public static SpecieModel ConvertToSpecie(this Specie Specie) =>
            new SpecieModel(
                Specie.Id, 
                Specie.Information.ToString());
    }
}
