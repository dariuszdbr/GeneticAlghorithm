using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using GeneticAlghorithm.Lib.Chromosomes;
using GeneticAlghorithm.Lib.Populations;

namespace GeneticAlghorithm.Lib.Selections
{
    public interface ISelection<T>
    {
        IEnumerable<IChromosome<T>> SelectChromosomes(int populationSize, IPopulation<T> population);
    }

    public abstract class SelectionBase<T> : ISelection<T>
    {
        public IEnumerable<IChromosome<T>> SelectChromosomes(int populationSize, IPopulation<T> population)
        {
            if (population == null) throw new ArgumentNullException(nameof(population));
            if (populationSize <= 1) throw new ArgumentOutOfRangeException(nameof(populationSize), populationSize, "Minimum size of population is greater or equal two");

            return PerformSelection(populationSize, population);
        }

        public abstract IEnumerable<IChromosome<T>> PerformSelection(int populationSize, IPopulation<T> population);

    }

    class RouletteWheelSelection<T> : SelectionBase<T>
    {
        private Random _random = new Random();
        
        
        public override IEnumerable<IChromosome<T>> PerformSelection(int populationSize, IPopulation<T> population)
        {
            IList<IChromosome<T>> chromosomes = population.Generation;                
            IList<double> probabilities = CalculateProbabilities(chromosomes);           
            IList<double> _cumulativeProbabilities = CalculateCumulativeProbabilities(populationSize + 1, probabilities);

            //TODO SelectChromosomes();
            return null;
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
            var fitnessTable = chromosomes.Select(c => c.Fitness).ToList();
            Validate(fitnessTable);
            double total = fitnessTable.Sum();
            
            return chromosomes.Select(c => c.Fitness / total).ToList();
        }

        private void Validate(IList<double> fitnessTable)
        {
            var min = fitnessTable.Min();
            if (min < 0)
                fitnessTable.ToList().ForEach(f => f += Math.Abs(min));
        }
    }
}