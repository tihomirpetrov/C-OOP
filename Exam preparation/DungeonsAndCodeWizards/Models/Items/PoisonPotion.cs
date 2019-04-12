namespace DungeonsAndCodeWizards.Models.Items
{
    using DungeonsAndCodeWizards.Models.Characters;
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

            if (character.IsAlive)
            {
                character.Health -= 20;
                //The character’s health gets decreased by 20 points. 
            }
            else if (character.Health <= 0)
            {
                //If the character’s health drops to zero, the character dies 
                character.IsAlive == false;
            }
        }
    }
}