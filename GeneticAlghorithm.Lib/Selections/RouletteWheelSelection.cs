using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlghorithm.Lib.Chromosomes;
using GeneticAlghorithm.Lib.Populations;

namespace GeneticAlghorithm.Lib.Selections
{
    public class RouletteWheelSelection<T> : SelectionBase<T>
    {
        private readonly Random _random = new Random();

        public RouletteWheelSelection() : base(2)
        {    
        }

        public override IEnumerable<IChromosome<T>> PerformSelection(int populationSize, IPopulation<T> population)
        {
            IList<IChromosome<T>> chromosomes = population.Generation;                
            IList<double> probabilities = CalculateProbabilities(chromosomes);           
            IList<double> cumulativeProbabilities = CalculateCumulativeProbabilities(populationSize + 1, probabilities);

            return RouletteSelection(populationSize, chromosomes, cumulativeProbabilities);          
        }

        private IEnumerable<IChromosome<T>> RouletteSelection(int populationSize, IList<IChromosome<T>> chromosomes, IList<double> cumulativeProbabilities)
        {
            var selected = new List<IChromosome<T>>(populationSize);

            for (int i = 0; i < populationSize; i++)
            {
                selected.Add(SpinRouletteWheel(populationSize,chromosomes,cumulativeProbabilities, _random.NextDouble));
            }

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


        private IList<double> CalculateCumulativeProbabilities(int size ,IList<double> probabilities)
        {
            var cumulativePercent = 0.0d;
            var rouletteWheel = new List<double>(size){cumulativePercent};
            foreach (var probability in probabilities)
            {
                cumulativePercent += probability;
                rouletteWheel.Add(cumulativePercent);
            }

            return rouletteWheel;
        }

        private IList<double> CalculateProbabilities(IList<IChromosome<T>> chromosomes)
        {
            var valuesTable = chromosomes.Select(c => c.Fitness).ToList();
            Validate(valuesTable);
            double total = valuesTable.Sum();
            
            return chromosomes.Select(c => c.Fitness / total).ToList();
        }

        private static void Validate(IList<double> valuesTable)
        {
            var min = valuesTable.Min();
            if (min < 0)
                valuesTable.ToList().ForEach(f => f += Math.Abs(min));
        }
    }
}