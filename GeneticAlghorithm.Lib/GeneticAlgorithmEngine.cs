﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlghorithm.Lib.Chromosomes;
using GeneticAlghorithm.Lib.Crossovers;
using GeneticAlghorithm.Lib.Mutations;
using GeneticAlghorithm.Lib.Populations;
using GeneticAlghorithm.Lib.Problems;
using GeneticAlghorithm.Lib.Selections;

namespace GeneticAlghorithm.Lib
{
    public class GeneticAlgorithmEngine<T> : IGAEngine<T>
    {
        private readonly int _populationSize;
        private readonly double _crossoverChance;
        private readonly double _mutationChance;

	    private int GenerationNumber { get; set; } = 0;
	    private IProblem<T> Problem { get; set; }
	    private IMutation<T> Mutation { get; set; }
	    private ICrossover<T> Crossover { get; set; }
	    private ISelection<T> Selection { get; set; }
	    private IPopulation<T> Population { get; set; }

	    private IEnumerable<double> _fittness;


	    public GeneticAlgorithmEngine(int populationSize, double crossoverChence, double mutationChence, IProblem<T> problem, IMutation<T> mutation, ICrossover<T> crossover, ISelection<T> selection)
        {
            this._populationSize = populationSize;
            this._crossoverChance = crossoverChence;
            this._mutationChance = mutationChence;
            this.Problem = problem ?? throw new ArgumentNullException(nameof(problem));
            this.Mutation = mutation ?? throw new ArgumentNullException(nameof(mutation));
            this.Crossover = crossover ?? throw new ArgumentNullException(nameof(crossover));
            this.Selection = selection ?? throw new ArgumentNullException(nameof(selection));
            this.Population = new Population<T>(_populationSize, problem);
        }

	    private void InitializePopulation()
        {
            Population.InitializePopulation();
        }

	    public void GenerateNextGeneration()
        {
            this.Population = Select();
            this.Population = Cross();
            this.Population = Mutate();
        }

	    public IChromosome<T> BestChromosome => Population.BestChromosome;

        private IPopulation<T> Mutate()
        {
            return this.Mutation.Mutate(this._mutationChance, this.Population);
        }

        private IPopulation<T> Cross()
        {
            return this.Crossover.Cross(this._crossoverChance, this.Population);
        }
        
        private IPopulation<T> Select()
        {
            return Selection.SelectChromosomes(this.Population);
        }

        public void Run(Func<bool> predicate, bool writeDetails = false)
        {
            this.InitializePopulation();
            if (writeDetails) WritePopulationDetails();
	        Console.WriteLine(LabelForBestChromosome());

			while (predicate())
            {
                this.GenerateNextGeneration();
	            if (writeDetails) WritePopulationDetails();
	            Console.WriteLine(LabelForBestChromosome());
			}
        }

		private void WritePopulationDetails()
		{
			Console.WriteLine($"Generation: {++GenerationNumber}" +
			                  $"{Environment.NewLine}" +
			                  LabelForChromosomes() +
			                  $"{Environment.NewLine}");
		}

	    private string LabelForBestChromosome()
	    {
		    return $"Best: {BestChromosome} {Environment.NewLine}";
	    }

	    private string LabelForChromosomes()
		{
			var label = new StringBuilder();
			foreach (var chromosome in Population.Generation)
				label.Append(chromosome + Environment.NewLine);

			return label.ToString();
		}
	}
}
