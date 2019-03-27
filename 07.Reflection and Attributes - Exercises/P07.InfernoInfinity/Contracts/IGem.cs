namespace P07.InfernoInfinity.Contracts
{
    using P07.InfernoInfinity.Models.Enums;
    public interface IGem
    {
        int StreangthModifier { get; }
        int AgilityModifier { get; }
        int VitalityModifier { get; }
        GemQuality Quality { get; }
    }
}