using System.Collections.Generic;
using GeneticAlghorithm.Lib.Chromosomes;

namespace GeneticAlghorithm.Lib.Mutations
{
    public interface IMutation<T>
    {
        IEnumerable<IChromosome<T>> Mutate(double mutationChance, IList<IChromosome<T>> population);
    }
}