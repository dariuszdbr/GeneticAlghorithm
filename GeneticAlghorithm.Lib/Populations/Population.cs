using System;
using GeneticAlghorithm.Lib.Chromosomes;
using GeneticAlghorithm.Lib.Problems;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlghorithm.Lib.Populations
{
    public class Population<T> : IPopulation<T>
    {
        public int PopulationSize { get; }
        public IList<IChromosome<T>> Generation { get; private set; } = new List<IChromosome<T>>();
        public IChromosome<T> BestChromosome => GetBest();
        private readonly IProblem<T> _problem;
        
        public Population(int populationSize, IProblem<T> problem)
        {
            if (populationSize <= 2) throw new ArgumentOutOfRangeException(nameof(populationSize));
            if (problem == null)  throw new ArgumentNullException(nameof(problem));
            
            this.PopulationSize = populationSize;
            this._problem = problem;
        }

        public void InitializePopulation()
        {
            for (int i = 0; i < PopulationSize; i++)
            {
                Generation.Add(new Chromosome<T>(_problem)
                    .SetRandomValues());
            }
        }

        private IChromosome<T> GetBest()
        {
            return Generation.OrderByDescending(chr => chr.Fitness).FirstOrDefault();
        }

        public void ReplaceGeneration(IList<IChromosome<T>> newGeneration)
        {
            this.Generation = newGeneration ?? throw new ArgumentNullException(nameof(newGeneration));
        }
    }
}