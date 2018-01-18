using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using static HelperClass.Helper;

namespace TBG_InventorySys {
    public partial class Game {
        
        protected void Phase1() {
			Print("Welcome to the Oblivion!\n");
			Print("What is your name, adventurer? > ");

		TestName:

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			player.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().ToLower());
			Console.ResetColor();

			if (string.IsNullOrEmpty(player.Name)) {
				Print("You have a name, don't you? > ");
				goto TestName;
			}
        }

        protected void Phase2() {
			// Weapon choosing phase

			PrintInb("Hail, ",player.Name,". Please choose your weapon: \n",ConsoleColor.White,ConsoleColor.DarkCyan);

		TestInput:

			int i = 1;
			foreach (var item in items) {
				Print($"\t{i++}) ");
				Print($"{item.GetName} \n",ConsoleColor.Yellow);
			}

			Print("Which one? > ");

			string input = Console.ReadLine();
			if (int.TryParse(input,out int parsed)) {
				if (parsed > items.Count()) {
					Print($"Hmm, there are only {items.Count()} options, {player.Name}. \n");
					goto TestInput;
				}
			TestYN1:
				Console.Clear();
				Print("You picked ",$"{items[parsed - 1].GetName}",ConsoleColor.White,ConsoleColor.Yellow);
				Print("! Stats: \n");

				CheckStats(items[parsed - 1]);
				Print("\nIs it good for you? (y/n) > ");
				try {
					char yn = Char.Parse(Console.ReadLine().ToLower());
					if (yn == 'y' || yn == 'n') {
						if (yn == 'n') goto TestInput;
					} else {
						goto TestYN1;
					}
				} catch (FormatException) {
					goto TestYN1;
				}

				Print(items[parsed - 1].GetName," has been added to your inventory.",ConsoleColor.Yellow,ConsoleColor.White);
				player.AddItem(items[parsed - 1]);

			} else {
				Print($"Umm, {player.Name}, please pick your weapon. \n");
				goto TestInput;
			}

			PrintLN("Now you are ready to go!");
        }

        protected void Phase3() {
            string[] commands = {
                "check inventory",
                "inventory",
                "commands",
                "stats",
                "exit"
            };
            while (true) {
                Print("What are you gonna do? \n");
				PrintInb("[","IDLE","] > ",ConsoleColor.White,ConsoleColor.Blue);
				string input = Console.ReadLine();
                if(input == commands[0]) {
                    player.CheckInventory();
                } 
                else if (input == commands[1]) {
                    player.GotoInventory();
                }
				else if (input == commands[2]) {
					Print("Available commands: \n");
					foreach (var command in commands) {
						Print(command + ", ");
					}
					Print("\n");
                }
                else if (input == commands[3]) {
                    player.GetStats();
                }
                else if (input == commands[4]) {
                    break;
                } else {
					Print("Available commands: \n");
					foreach (var command in commands) {
						Print(command + ", ");
					}
					Print("\n");
                }
            }
        }


		public void CheckItemStats(Item item) {
			if (item is Weapon) {
				double dmg = (item as Weapon).Damage;
				double dmgmod = (item as Weapon).DamageModifier;
				double totdmg = (item as Weapon).TotalDamage;
				double atkspd = (item as Weapon).AttackSpeed;
				double val = (item as Weapon).Price;

				Print("\t Base damage: ",dmg.ToString(),ConsoleColor.White,ConsoleColor.Magenta);
				Print("\t Damage modifier: ",dmgmod.ToString(),ConsoleColor.White,ConsoleColor.Magenta);
				Print("\n\t Total damage: ",totdmg.ToString(),ConsoleColor.White,ConsoleColor.Magenta);
				Print("\t Attack speed: ",atkspd.ToString(),ConsoleColor.White,ConsoleColor.Magenta);
				Print("\n\t Value: ",val.ToString() + "G",ConsoleColor.White,ConsoleColor.Magenta);
			}
		}
	}
}
