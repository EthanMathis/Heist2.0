using System;
using System.Collections.Generic;

namespace Heist2
{
    class Program
    {
        static void Main(string[] args)
        {
            Hacker dell = new Hacker()
            {
                Name = "Dell",
                SkillLevel = 40,
                PercentageCut = 20
            };
            Hacker lenovo = new Hacker()
            {
                Name = "Lenovo",
                SkillLevel = 80,
                PercentageCut = 30
            };

            Muscle stipe = new Muscle()
            {
                Name = "Stipe",
                SkillLevel = 70,
                PercentageCut = 30
            };
            Muscle conor = new Muscle()
            {
                Name = "Conor",
                SkillLevel = 30,
                PercentageCut = 20
            };

            LockSpecialist stella = new LockSpecialist()
            {
                Name = "Stella",
                SkillLevel = 50,
                PercentageCut = 20
            };
            LockSpecialist john = new LockSpecialist()
            {
                Name = "John",
                SkillLevel = 90,
                PercentageCut = 30
            };

            List<IRobber> rolodex = new List<IRobber>()
            {
                dell, lenovo, stipe, conor, stella, john
            };

            //  Prompt the user for their name
            Console.WriteLine($"the rolodex currently has {rolodex.Count} operatives.");
            Console.WriteLine("Word on the street is there's a heist being planned. Big payout... You want in?");
            Console.WriteLine("What's your name?...");
            string UserName = Console.ReadLine();

            //  Prompt the user to pick a specialty
            Console.WriteLine($"Alright {UserName}... You must have some skills if you want this job... What do you specialize in?");
            Console.WriteLine(@"
            1) Hacker [ Disables alarms ]
            2) Muscle [ Takes care of the guards ]
            3) Lock Specialist [ cracks into the vault ]
            ");
            string Specialty = Console.ReadLine();
            int SpecialtyNum;
            while (!(int.TryParse(Specialty, out SpecialtyNum)) || SpecialtyNum < 1 || SpecialtyNum > 3)
            {
                Console.WriteLine(@"
            I didn't catch that... Try again. Pick a specialization from the list  [ 1-3 ]

            1) Hacker [ Disables alarms ]
            2) Muscle [ Takes care of the guards ]
            3) Lock Specialist [ cracks into the vault ]
                ");
                Specialty = Console.ReadLine();
            }
            if (SpecialtyNum == 1)
            {
                Hacker NewGuy = new Hacker();
                NewGuy.Name = UserName;
            }
            else if (SpecialtyNum == 2)
            {
                Muscle NewGuy = new Muscle();
                NewGuy.Name = UserName;
            }
            else
            {
                LockSpecialist NewGuy = new LockSpecialist();
                NewGuy.Name = UserName;
            }

            //  Prompt the user to enter their skill level
            Console.WriteLine($"Alright {UserName}, How good are you?...");
            Console.WriteLine("[ Enter a number between 0 and 100 ]");
            string Proficiency = Console.ReadLine();
            int ProficiencyNum;
            while (!(int.TryParse(Proficiency, out ProficiencyNum)) || ProficiencyNum < 0 || ProficiencyNum > 100)
            {
                Console.WriteLine("Stop wasting my time... Either give me your skill level or get outta here...");
                Console.WriteLine("[ Enter a number between 0 and 100 ]");
                Proficiency = Console.ReadLine();
            }
        }
    }
}
