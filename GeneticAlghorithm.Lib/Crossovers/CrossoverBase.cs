using System;
using System.Collections.Generic;
using GeneticAlghorithm.Lib.Chromosomes;
using GeneticAlghorithm.Lib.Populations;

namespace GeneticAlghorithm.Lib.Crossovers
{
    public abstract class CrossoverBase<T> : ICrossover<T>
    {
        private readonly int _minimumSize;

        protected CrossoverBase(int minimumSize)
        {
            this._minimumSize = minimumSize;
        }

        public IPopulation<T> Cross(double crossoverChance, IPopulation<T> population)
        {
            if (population == null) throw new ArgumentNullException(nameof(population));
            if (crossoverChance <= 0) throw new ArgumentOutOfRangeException(nameof(crossoverChance));
            if (population.PopulationSize < _minimumSize) throw new ArgumentOutOfRangeException(nameof(population.PopulationSize), population.PopulationSize,
                $"Minimum size of population must be greater or equal {_minimumSize}");

            return PerformCrossover(crossoverChance, population);
        }

        public abstract IPopulation<T> PerformCrossover(double crossoverChance, IPopulation<T> population);
    }
}