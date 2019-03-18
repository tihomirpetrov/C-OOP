namespace MilitaryElite.Main
{
    using MilitaryElite.Enums;
    using MilitaryElite.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private List<ISoldier> soldiers;
        private ISoldier soldier;

        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }

                var type = input[0];
                var id = int.Parse(input[1]);
                var firstName = input[2];
                var lastName = input[3];

                switch (type)
                {
                    case "Private":
                        var salary = decimal.Parse(input[4]);
                        soldier = GetPrivateSoldier(id, firstName, lastName, salary);
                        break;

                    case "LieutenantGeneral":
                        salary = decimal.Parse(input[4]);
                        soldier = GetLieutenantGeneral(id, firstName, lastName, salary, input);
                        break;

                    case "Engineer":
                        salary = decimal.Parse(input[4]);
                        soldier = GetEngineer(id, firstName, lastName, salary, input);
                        break;

                    case "Commando":
                        salary = decimal.Parse(input[4]);
                        soldier = GetCommando(id, firstName, lastName, salary, input);
                        break;

                    case "Spy":
                        var codeNumber = int.Parse(input[4]);
                        soldier = GetSpy(id, firstName, lastName, codeNumber);
                        break;
                }

                if (soldier != null)
                {
                    this.soldiers.Add(soldier);
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private ISoldier GetSpy(int id, string firstName, string lastName, int codeNumber)
        {
            ISpy spy = new Spy(id, firstName, lastName, codeNumber);

            return spy;
        }

        private ISoldier GetCommando(int id, string firstName, string lastName, decimal salary, string[] input)
        {
            var corpsParse = input[5];

            if (!Enum.TryParse(corpsParse, out Corps corps))
            {
                return null;
            }

            Commando commando = new Commando(id, firstName, lastName, salary, corps);

            for (int i = 6; i < input.Length; i += 2)
            {
                var codeName = input[i];
                var stateParse = input[i + 1];

                if (!Enum.TryParse(stateParse, out State state))
                {
                    continue;
                }

                IMission mission = new Mission(codeName, state);
                commando.Missions.Add(mission);
            }

            return commando;
        }

        private ISoldier GetEngineer(int id, string firstName, string lastName, decimal salary, string[] input)
        {
            var corpsParse = input[5];

            if (!Enum.TryParse(corpsParse, out Corps corps))
            {
                return null;
            }

            Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);

            for (int i = 6; i < input.Length; i += 2)
            {
                var repairPart = input[i];
                var repairHours = int.Parse(input[i + 1]);

                IRepair repair = new Repair(repairPart, repairHours);
                engineer.Repairs.Add(repair);
            }

            return engineer;

        }

        private ISoldier GetLieutenantGeneral(int id, string firstName, string lastName, decimal salary, string[] input)
        {
            ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

            for (int i = 5; i < input.Length; i++)
            {
                var privateId = int.Parse(input[i]);

                IPrivate privateSoldier = (IPrivate)this.soldiers.FirstOrDefault(x => x.Id == privateId);

                lieutenantGeneral.Privates.Add(privateSoldier);
            }

            return lieutenantGeneral;
        }

        private ISoldier GetPrivateSoldier(int id, string firstName, string lastName, decimal salary)
        {
            IPrivate privateSoldier = new Private(id, firstName, lastName, salary);

            return privateSoldier;
        }
    }
}