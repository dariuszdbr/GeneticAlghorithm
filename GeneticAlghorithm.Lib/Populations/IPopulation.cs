using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GeneticAlghorithm.Lib.Chromosomes;

namespace GeneticAlghorithm.Lib.Populations
{
    public interface IPopulation<T>
    {
        void InitializePopulation();
        void ReplaceGeneration(IList<IChromosome<T>> newGeneration);
        int PopulationSize { get; }
        IList<IChromosome<T>> Generation { get;  }
        IChromosome<T> BestChromosome { get; }
        
    }
}
