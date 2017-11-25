using System.Collections.Generic;
using GeneticAlghorithm.Lib.Chromosomes;
using GeneticAlghorithm.Lib.Populations;

namespace GeneticAlghorithm.Lib.Crossovers
{
    public class OnePointCrossover<T> : CrossoverBase<T>
    {
        public OnePointCrossover() : base(2)
        {
        }

        public override IPopulation<T> PerformCrossover(double crossoverChance, IPopulation<T> population)
        {
            var childrens = new List<IChromosome<T>>(population.PopulationSize);
            for (int index = 0; index < population.PopulationSize; index += 2)
            {
                if (RandomizerProvider.Current.GetDouble() > crossoverChance)
                {
                    childrens.AddRange(new[] {population.Generation[index], population.Generation[index+1]});
                    continue;
                }
                
                childrens.AddRange(CreateChildren(population.Generation[index], population.Generation[index + 1]));
            }
            population.ReplaceGeneration(childrens);
            
            return population;
        }

        private IEnumerable<IChromosome<T>> CreateChildren(IChromosome<T> firstParent, IChromosome<T> secondParent)
        {
            IChromosome<T> firstChild = CreateChild(firstParent, secondParent);
            IChromosome<T> secondChild = CreateChild(secondParent, firstParent);

            return new List<IChromosome<T>> {firstChild, secondChild};
        }

        private IChromosome<T> CreateChild(IChromosome<T> leftParent, IChromosome<T> rightParent)
        {
            var child = leftParent.Clone();
            var swapIndex = RandomizerProvider.Current.GetInt(1, child.Genes.Length - 2);
            child.ReplaceGenes(swapIndex, rightParent.Genes);
            return child;
        }
    }
}