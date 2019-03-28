namespace P07.InfernoInfinity.Models.Gems
{
    using P07.InfernoInfinity.Contracts;
    using P07.InfernoInfinity.Models.Enums;

    public abstract class Gem : IGem
    {
        public Gem(GemQuality quality, int strengthModifier, int agilityModifier, int vitalityModifier)
        {
            this.Quality = quality;
            this.StrengthModifier = strengthModifier + (int)this.Quality;
            this.AgilityModifier = agilityModifier + (int)this.Quality;
            this.VitalityModifier = vitalityModifier + (int)this.Quality;
        }

        public int StrengthModifier { get; private set; }
        public int AgilityModifier { get; private set; }
        public int VitalityModifier { get; private set; }
        public GemQuality Quality { get; private set; }
    }
}