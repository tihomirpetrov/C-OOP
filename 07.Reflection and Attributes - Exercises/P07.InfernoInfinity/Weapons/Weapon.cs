namespace P07.InfernoInfinity.Weapons
{
    public abstract class Weapon
    {
        int minDamage { get; }
        int maxDamage { get; }
        int numberOfSockets { get; }

        public Weapon(int minDamage, int maxDamage, int numberOfSockets)
        {
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
            this.numberOfSockets = numberOfSockets;
        }
    }
}
