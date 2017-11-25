﻿using System;
using GeneticAlghorithm.Lib.Chromosomes;

namespace GeneticAlghorithm.Lib
{
    public interface IGAEngine<T>
    {
        void GenerateNextGeneration();
        int GenerationNumber { get; }
        IChromosome<T> BestChromosome { get; }

        void Run(Func<bool> predicate, bool writeDetails);
    }
}