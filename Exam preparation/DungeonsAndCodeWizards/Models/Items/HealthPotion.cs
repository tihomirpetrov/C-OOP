namespace DungeonsAndCodeWizards.Models.Items
{
    public class HealthPotion : Item
    {
        private const int HealthPotionWeight = 5;
        public HealthPotion() 
            : base(HealthPotionWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            if(IsAlive)
            {
                //The character’s health gets increased by 20 points.
            }
        }
    }
}