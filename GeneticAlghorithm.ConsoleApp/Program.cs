using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GeneticAlghorithm.Lib;
using GeneticAlghorithm.Lib.Chromosomes;
using GeneticAlghorithm.Lib.Crossovers;
using GeneticAlghorithm.Lib.Mutations;
using GeneticAlghorithm.Lib.Populations;
using GeneticAlghorithm.Lib.Problems;
using GeneticAlghorithm.Lib.Selections;

namespace GeneticAlghorithm.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();         
        }

        public static void Run()
        {
	        int counter = 0;

			// Genetic Algorithm Settings 
			int populationSize = 10;
            double crossoverChance = 0.78;
            double mutationChance = 0.05;
	        int maxNumberOfNotChangedBestChromosome = 50;

			IProblem<int> problem = new MaximumOfQuadraticFuncionInRangeProblem();
            ISelection<int> selection = new RouletteWheelSelection<int>();
            ICrossover<int> crossover = new OnePointCrossover<int>();
            IMutation<int> mutation = new FlipGeneMutation<int>();
            IGAEngine<int> algorithm = new GeneticAlgorithmEngine<int>(populationSize, crossoverChance, mutationChance, problem, mutation, crossover, selection);

			var bestChromosome = algorithm.BestChromosome;  // null 
			algorithm.Run(() =>
			{	
				counter++;
				if (bestChromosome == null || !bestChromosome.Fitness.Equals(algorithm.BestChromosome.Fitness))
				{
					bestChromosome = algorithm.BestChromosome;
					counter = 0;
				}
				
				return counter < maxNumberOfNotChangedBestChromosome;

			}, writeDetails: true);

			Console.ReadKey();
        }
    }
}
