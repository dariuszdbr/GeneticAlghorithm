using System.Collections.Generic;
using GeneticAlghorithm.Lib.Chromosomes.Genes;
using GeneticAlghorithm.Lib.Problems;

namespace GeneticAlghorithm.Lib.Chromosomes
{
    public interface IChromosome<T>
    {
        double Fitness { get; }
        IList<Gene<T>> Genes { get; }
        IChromosome<T> Clone();
        IChromosome<T> CreateNew(IProblem<T> problem);
        IChromosome<T> SetRandomValues();
    }
}