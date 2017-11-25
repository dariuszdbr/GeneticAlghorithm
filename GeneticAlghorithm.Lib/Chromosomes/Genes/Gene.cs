namespace GeneticAlghorithm.Lib.Chromosomes.Genes
{
    public class Gene
    {
        public object Value { get; private set; }

        public Gene(object value)
        {
            Value = value;
        }

        private Gene()
        {
            
        }
        
       public Gene CreateNew(object value) => new Gene(value);
    }
}