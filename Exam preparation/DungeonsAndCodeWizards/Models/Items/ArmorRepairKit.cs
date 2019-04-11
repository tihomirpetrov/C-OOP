namespace DungeonsAndCodeWizards.Models.Items
{
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

            //The character’s armor restored up to the base armor value.
            //Example: Armor: 10, Base Armor: 100  Armor: 100

        }
    }
}