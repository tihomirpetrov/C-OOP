namespace DungeonsAndCodeWizards.Models.Items
{
    using DungeonsAndCodeWizards.Models.Characters;
    public class ArmorRepairKit : Item
    {
        private const int ArmorRepairKitWeight = 10;
        public ArmorRepairKit()
            : base(ArmorRepairKitWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Armor = character.BaseArmor;
        }
    }
}