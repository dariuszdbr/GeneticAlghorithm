using System;
using System.Collections.Generic;
using GeneticAlghorithm.Lib.Chromosomes;
using GeneticAlghorithm.Lib.Populations;

namespace GeneticAlghorithm.Lib.Selections
{
    public abstract class SelectionBase<T> : ISelection<T>
    {
        private readonly int _minimumSize;

        protected SelectionBase(int minimumSize)
        {
            _minimumSize = minimumSize;
        }

        public IPopulation<T> SelectChromosomes(IPopulation<T> population)
        {
            if (population == null)
                throw new ArgumentNullException(nameof(population));
            
            if (population.PopulationSize < _minimumSize)
                throw new ArgumentOutOfRangeException(nameof(population.PopulationSize), population.PopulationSize,
                    "Minimum size of population is greater or equal two");

            return PerformSelection(population.PopulationSize, population);
        }

        public abstract IPopulation<T> PerformSelection(int populationSize, IPopulation<T> population);

    }
}