using System.Collections.Generic;
using System.Linq;
using GeneticAlghorithm.Lib.Chromosomes;
using GeneticAlghorithm.Lib.Problems;

namespace GeneticAlghorithm.Lib.Populations
{
    public class Population<T> : IPopulation<T>
    {
        public int PopulationSize { get; }
        public IList<IChromosome<T>> Generation { get; private set;}
        public IChromosome<T> BestChromosome => GetBest();

        private readonly IProblem<T> _problem;

        public Population(int populationSize, IProblem<T> problem)
        {
            this.PopulationSize = populationSize;
            this._problem = problem;
            this.Generation = CreateChromosomes(populationSize);
        }

        public void InitializePopulation()
        {
            Generation = Generation
                .Select(chromosome => chromosome.CreateNew(this._problem).SetRandomValues())
                .ToList();
        }

        private static List<IChromosome<T>> CreateChromosomes(int populationSize)
        {
            return new List<IChromosome<T>>(populationSize);
        }

        private IChromosome<T> GetBest()
        {
            return Generation.OrderByDescending(chr => chr.Fitness).FirstOrDefault();
        }
    }
}