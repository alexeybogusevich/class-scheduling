namespace KNU.IS.ClassScheduling.Logic.Configuration
{
    public class GeneticOptions
    {
        public int PopulationSize { get; set; }
        public double ElitismPercentage { get; set; }
        public double CrossoverProbability { get; set; }
        public double MutationCoefficient { get; set; }
        public double MutationProbability { get; set; }
        public double SatisfactoryFitnessValue { get; set; }
    }
}
