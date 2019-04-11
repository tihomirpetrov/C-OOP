namespace DungeonsAndCodeWizards.Models.Items
{
    public class PoisonPotion : Item
    {
        private const int PoisonPotionWeight = 5;
        public PoisonPotion() 
            : base(PoisonPotionWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            if (IsAlive)
            {
                //The character’s health gets decreased by 20 points. 
            }
            else if (value <= 0)
            {
                //If the character’s health drops to zero, the character dies 
                IsAlive == false;
            }
        }
    }
}
