using System.Collections.Generic;
using GeneticAlghorithm.Lib.Chromosomes;

namespace GeneticAlghorithm.Lib.Crossovers
{
    public interface ICrossover<T>
    {
        IEnumerable<IChromosome<T>> Cross(double crossoverChance, IList<IChromosome<T>> population);
    }
}