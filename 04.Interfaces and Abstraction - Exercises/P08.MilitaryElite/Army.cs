using System.Collections.Generic;
using System.Linq;

namespace P08.MilitaryElite
{
    public class Army
    {
        private HashSet<ISoldier> soldiers;

        public Army()
        {
            this.soldiers = new HashSet<ISoldier>();
        }

        public void AddSoldier(ISoldier soldier)
        {
            this.soldiers.Add(soldier);
        }

        public HashSet<Private> GetPrivates(int[] ids)
        {
            HashSet<Private> privates = new HashSet<Private>();
            for (int i = 0; i < ids.Length; i++)
            {
                ISoldier currentPrivate = this.soldiers.FirstOrDefault(x => x.Id == ids[i]);

                privates.Add((Private)currentPrivate);
            }

            return privates;
        }
    }
}
