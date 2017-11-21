namespace GeneticAlghorithm.Lib.Chromosomes.Genes
{
    public class Gene<T>
    {
        public T Value { get; private set; }

        public Gene(T value)
        {
            Value = value;
        }
        
       public Gene<T> CreateNew(T value) => new Gene<T>(value);
    }
}