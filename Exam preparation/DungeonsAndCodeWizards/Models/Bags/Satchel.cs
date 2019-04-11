namespace DungeonsAndCodeWizards.Models.Bags
{
    public class Satchel : Bag
    {
        public const int SatchelCapacity = 20;
        public Satchel() 
            : base(SatchelCapacity)
        {
        }
    }
}