namespace P07.InfernoInfinity.Weapons
{
    public class Knife : Weapon
    {
        public Knife(int minDamage, int maxDamage, int numberOfSockets) : base(minDamage, maxDamage, numberOfSockets)
        {
            minDamage = 3;
            maxDamage = 4;
            numberOfSockets = 2;
        }
    }
}