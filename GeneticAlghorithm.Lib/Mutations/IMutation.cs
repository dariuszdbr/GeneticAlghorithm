using System.Collections.Generic;
using GeneticAlghorithm.Lib.Populations;

namespace GeneticAlghorithm.Lib.Mutations
{
    public interface IMutation<T>
    {
        IPopulation<T> Mutate(double mutationChance, IPopulation<T> population);
    }
}