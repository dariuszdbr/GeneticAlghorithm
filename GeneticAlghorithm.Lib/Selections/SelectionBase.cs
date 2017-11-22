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

        public IEnumerable<IChromosome<T>> SelectChromosomes(int populationSize, IPopulation<T> population)
        {
            if (population == null) throw new ArgumentNullException(nameof(population));
            if (populationSize < _minimumSize) throw new ArgumentOutOfRangeException(nameof(populationSize), populationSize, "Minimum size of population is greater or equal two");

            return PerformSelection(populationSize, population);
        }

        public abstract IEnumerable<IChromosome<T>> PerformSelection(int populationSize, IPopulation<T> population);

    }
}