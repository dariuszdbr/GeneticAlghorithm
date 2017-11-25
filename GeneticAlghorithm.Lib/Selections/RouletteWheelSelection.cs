using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlghorithm.Lib.Chromosomes;
using GeneticAlghorithm.Lib.Populations;

namespace GeneticAlghorithm.Lib.Selections
{
    public class RouletteWheelSelection<T> : SelectionBase<T>
    {
        public RouletteWheelSelection() : base(2)
        {    
        }

        public override IPopulation<T> PerformSelection(int populationSize, IPopulation<T> population)
        {
            IList<IChromosome<T>> chromosomes = population.Generation;                
            IList<double> probabilities = CalculateProbabilities(chromosomes);           
            IList<double> cumulativeProbabilities = CalculateCumulativeProbabilities(populationSize + 1, probabilities);

            var newGeneration = RouletteSelection(populationSize, chromosomes, cumulativeProbabilities);            
            population.ReplaceGeneration(newGeneration);

            return population;
        }

        private IList<IChromosome<T>> RouletteSelection(int populationSize, IList<IChromosome<T>> chromosomes, IList<double> cumulativeProbabilities)
        {
            var selected = new List<IChromosome<T>>(populationSize);

            for (int i = 0; i < populationSize; i++)
                selected.Add(SpinRouletteWheel(populationSize,chromosomes,cumulativeProbabilities, RandomizerProvider.Current.GetDouble));

            return selected;
        }

        private IChromosome<T> SpinRouletteWheel(int populationSize, IList<IChromosome<T>> chromosomes, IList<double> cumulativeProbabilities, Func<double> selector)
        {
            var randomNumber = selector();
            for (int index = 0; index < populationSize; index++)
                if (randomNumber >= cumulativeProbabilities.ElementAt(index) && randomNumber <= cumulativeProbabilities.ElementAt(index + 1))
                    return chromosomes[index];
            
            throw new ArgumentOutOfRangeException(nameof(SpinRouletteWheel), "Failure to return valid population.");
        }


        private IList<double> CalculateCumulativeProbabilities(int size, IList<double> probabilities)
        {
            double cumulativePercent = 0.0d;
            var rouletteWheel = new List<double>(size){cumulativePercent};

            foreach (var probability in probabilities)
            {
                cumulativePercent += probability;
                rouletteWheel.Add(cumulativePercent);
            }

            rouletteWheel[rouletteWheel.Count - 1] = 1.0;
            
            return rouletteWheel;
        }

        private IList<double> CalculateProbabilities(IList<IChromosome<T>> chromosomes)
        {
            var valuesTable = chromosomes.Select(c => c.Fitness);
            valuesTable = Validate(valuesTable);
            double total = valuesTable.Sum();
            
            return valuesTable.Select(fitness => fitness / total).ToList();
        }

        private IList<double> Validate(IEnumerable<double> valuesTable)
        {
            var min = valuesTable.Min();
            
            if (min < 0)
              valuesTable = valuesTable.Select(f => f += Math.Abs(2*min));
            
            return valuesTable.ToList();
        }
    }
}