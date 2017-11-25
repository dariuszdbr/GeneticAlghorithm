using System;
using GeneticAlghorithm.Lib.Populations;

namespace GeneticAlghorithm.Lib.Mutations
{
    public abstract class BaseMutation<T> : IMutation<T>
    {
        private readonly int _minimumSize;

        protected BaseMutation(int minimumSize)
        {
            this._minimumSize = minimumSize;
        }

        public IPopulation<T> Mutate(double mutationChance, IPopulation<T> population)
        {
            if (population == null) throw new ArgumentNullException(nameof(population));
            if (mutationChance < 0) throw new ArgumentOutOfRangeException(nameof(mutationChance));
            if (population.PopulationSize < _minimumSize) throw new ArgumentOutOfRangeException(nameof(population.PopulationSize), population.PopulationSize,
                $"Minimum size of population must be greater or equal {_minimumSize}");

            return PerformMutate(mutationChance, population);
        }

        public abstract IPopulation<T> PerformMutate(double mutationChance, IPopulation<T> population);
    }
}