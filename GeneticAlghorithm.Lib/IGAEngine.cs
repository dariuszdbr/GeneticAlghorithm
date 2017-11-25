using System;
using GeneticAlghorithm.Lib.Chromosomes;

namespace GeneticAlghorithm.Lib
{
    public interface IGAEngine<T>
    {
        IChromosome<T> BestChromosome { get; }
        void Run(Func<bool> predicate, bool writeDetails);
    }
}