using System.Collections.Generic;
using System.Linq;
using GeneticAlghorithm.Lib.Chromosomes;
using GeneticAlghorithm.Lib.Chromosomes.Genes;
using GeneticAlghorithm.Lib.Populations;

namespace GeneticAlghorithm.Lib.Mutations
{
    public class FlipGeneMutation<T> : BaseMutation<T>
    {
        public FlipGeneMutation() : base(2)
        {
        }

        public override IPopulation<T> PerformMutate(double mutationChance, IPopulation<T> population)
        {         
			var newGeneration = new List<IChromosome<T>>();
            foreach (var chromosome in population.Generation)
            {
	            if (RandomizerProvider.Current.GetDouble() > mutationChance)
	            {
					newGeneration.Add(chromosome);
		            continue;
	            }

                var flipIndex = RandomizerProvider.Current.GetInt(0, chromosome.Genes.Length);
                FlipGene(flipIndex, chromosome);
				newGeneration.Add(chromosome);
            }

			population.ReplaceGeneration(newGeneration);

            return population;
        }

        private void FlipGene(int index, IChromosome<T> chromosome)
        {
            var value = (int) chromosome.Genes.ElementAt(index).Value;
            chromosome.ReplaceGene(index, new Gene(value == 0 ? 1 : 0));
        }
    }
}