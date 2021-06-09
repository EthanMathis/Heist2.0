using System;
using System.Collections.Generic;
using System.Linq;

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
            Questions(rolodex);
            Console.WriteLine(@"
    Would you like to add another operative?
    1) Yes
    2) No
    ");
            string AddAnother = Console.ReadLine();
            int AddAnotherNum;
            while (!(int.TryParse(AddAnother, out AddAnotherNum)) || AddAnotherNum < 1 || AddAnotherNum > 2)
            {
                Console.WriteLine("Please enter either 1 for yes or 2 for no");
            }

            if (AddAnotherNum == 1)
            {
                Questions(rolodex);
            }

            //  Initialize the target bank
            Bank Target = new Bank(RandomCash(), RandomNum(), RandomNum(), RandomNum());

            //  Scouting the target
            string Strength = MaxValue(Target);
            string Weakness = MinValue(Target);
            Console.WriteLine($"Alright, I've scouted the target and their most secure system is the {Strength} but their weakest system is definitely their {Weakness}.");

            // print off the rolodex
            for (int i = 0; i < rolodex.Count; i++)
            {
                Console.WriteLine($@"

-------------------------------------------------
|   Index: {i++}                                  
|   Name: {rolodex[i].Name}                     
|   Specialty: {rolodex[i].Specialty}           
|   Skill Level: {rolodex[i].SkillLevel}        
|   Cut Percentage: {rolodex[i].PercentageCut}  
-------------------------------------------------

                ");
            }



        }

        static IRobber CreateRobber(string UserName, int SpecialtyNum, int Skill, int Cut)
        {
            if (SpecialtyNum == 1)
            {
                Hacker NewGuy = new Hacker();
                NewGuy.Name = UserName;
                NewGuy.SkillLevel = Skill;
                NewGuy.PercentageCut = Cut;
                return NewGuy;
            }
            else if (SpecialtyNum == 2)
            {
                Muscle NewGuy = new Muscle();
                NewGuy.Name = UserName;
                NewGuy.SkillLevel = Skill;
                NewGuy.PercentageCut = Cut;
                return NewGuy;

            }
            else
            {
                LockSpecialist NewGuy = new LockSpecialist();
                NewGuy.Name = UserName;
                NewGuy.SkillLevel = Skill;
                NewGuy.PercentageCut = Cut;
                return NewGuy;

            }
        }

        static void Questions(List<IRobber> Rolo)
        {
            //  Prompt the user for their name
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

            //  Prompt the user to enter their PercentageCut
            Console.WriteLine("Last question... What percentage of the take do you want?");
            Console.WriteLine("[ Enter a number between 0 and 100 ]");
            string Percentage = Console.ReadLine();
            int PercentageNum;
            while (!(int.TryParse(Percentage, out PercentageNum)) || PercentageNum < 0 || PercentageNum > 100)
            {
                Console.WriteLine("Enter a number between 0 and 100...");
                Percentage = Console.ReadLine();
            }

            IRobber NewGuy = CreateRobber(UserName, SpecialtyNum, ProficiencyNum, PercentageNum);
            Rolo.Add(NewGuy);
        }

        static string MaxValue(Bank target)
        {
            string Result;
            int[] scores = { target.AlarmScore, target.SecurityGuardScore, target.VaultScore };
            int Value = scores.Max();
            if (Value == target.AlarmScore)
            {
                Result = "Alarm";
            }
            else if (Value == target.SecurityGuardScore)
            {
                Result = "Security";
            }
            else
            {
                Result = "Vault";
            }
            return Result;
        }

        static string MinValue(Bank target)
        {
            string Result;
            int[] scores = { target.AlarmScore, target.SecurityGuardScore, target.VaultScore };
            int Value = scores.Min();
            if (Value == target.AlarmScore)
            {
                Result = "Alarm";
            }
            else if (Value == target.SecurityGuardScore)
            {
                Result = "Security";
            }
            else
            {
                Result = "Vault";
            }
            return Result;
        }

        static int RandomNum()
        {
            return new Random().Next(0, 100);
        }

        static int RandomCash()
        {
            return new Random().Next(50000, 1000000);
        }

    }
}
