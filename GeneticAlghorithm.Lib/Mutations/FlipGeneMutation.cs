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
            foreach (var chromosome in population.Generation)
            {
                if (RandomizerProvider.Current.GetDouble() > mutationChance) continue;

                var flipIndex = RandomizerProvider.Current.GetInt(0, chromosome.Genes.Length);
                FlipGene(flipIndex, chromosome);
            }

            return population;
        }
        private void FlipGene(int index, IChromosome<T> chromosome)
        {
            var value = (int) chromosome.Genes.ElementAt(index).Value;

            chromosome.ReplaceGene(index, new Gene(value == 0 ? 1 : 0));
        }
    }
}