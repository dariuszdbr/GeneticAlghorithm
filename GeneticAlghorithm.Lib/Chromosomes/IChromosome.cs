using System.Collections.Generic;
using GeneticAlghorithm.Lib.Chromosomes.Genes;
using GeneticAlghorithm.Lib.Problems;

namespace GeneticAlghorithm.Lib.Chromosomes
{
    public interface IChromosome<T>
    {
        double Fitness { get; }
        Gene[] Genes { get; }
        IChromosome<T> Clone();
        IChromosome<T> CreateNew(IProblem<T> problem);
        IChromosome<T> SetRandomValues();
        void ReplaceGenes(int startIndex, Gene[] genes);
        void ReplaceGene(int index, Gene gene);
    }
}