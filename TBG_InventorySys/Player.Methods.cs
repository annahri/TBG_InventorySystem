using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using static HelperClass.Helper;

namespace TBG_InventorySys
{
	public partial class Player
	{

		public void AddItem(Item item) {
			if (inventory.Count <= inventorySize) {
				inventory.Add(item);
			}
		}

		public void EquipWeapon(int i) {
            if (inventory[i] != null) {
                if (inventory[i] is Weapon) {
                    Equip = (inventory[i] as Weapon);
					Print(Equip.GetName," has been equipped.\n",ConsoleColor.Yellow,ConsoleColor.White);
				} else {
                    Print(inventory[i].GetName, " is not a weapon.", ConsoleColor.Magenta, ConsoleColor.White);
                }
            } else {
                PrintLN("You have nothing in that slot!", ConsoleColor.Red);
            }
        }

        public void UnequipWeapon() {
            if (Equip == null) {
                PrintLN("You have nothing equipped!", ConsoleColor.Red);
            } else {
                Print(Equip.GetName, " has been unequipped.\n", ConsoleColor.Yellow, ConsoleColor.White);
                Equip = null;
            }
        }

        public void GetStats() {
            Print("\tHealth: ",this.Health.ToString(),ConsoleColor.White,ConsoleColor.Green);
            Print("\tGold: ",this.Gold.ToString(),ConsoleColor.White,ConsoleColor.Green);
			Print("\n\tBase Damage: ",this.BaseDamage.ToString(),ConsoleColor.White,ConsoleColor.Green);
			Print("\tBase Attack Speed: ",this.BaseAttackSpeed.ToString(),ConsoleColor.White,ConsoleColor.Green);
			Print("\n\tTotal Damage: ",this.TotalDamage.ToString(),ConsoleColor.White,ConsoleColor.Green);
			Print("\tTotal Attack Speed: ",this.TotalAttackSpeed.ToString(),ConsoleColor.White,ConsoleColor.Green);
            Print("\n\tEquipped Weapon: ", ( Equip!=null ? this.Equip.GetName : "none"),ConsoleColor.White,ConsoleColor.Yellow);
		    Print("\n");
        }

        public void ListInventory() {
			int i = 1;
			foreach (var item in inventory) {
				Print($"\t{i}) ");
				if (item is Weapon) {
					Print(item.GetName,ConsoleColor.Yellow);
					if (Equip == (inventory[i-1] as Weapon)) {
						Print(" (equipped)");
					}
				} else {
					Print(item.GetName,ConsoleColor.Magenta);
				}
			}
        }


		public void CheckInventory() {
			Print("Items in your inventory : \n");
			ListInventory();
			Print($"\nAnd you have {SlotsLeft} slots left.\n");
		}

		public void GotoInventory() {
			string[] commands = {
				"back",
				"equip",
				"commands",
                "list",
                "unequip",
                "check"
			};

			Print("Inventory: \n");
			ListInventory();
			Print($"\nSlot: {UsedSpace}/{inventorySize}\n");

			while (true) {
                PrintInb("[","INVENTORY","] > ",ConsoleColor.White,ConsoleColor.Blue);
                string input = Console.ReadLine();
				if (input == commands[0]) {
					break;
				}
                else if (input.Contains(commands[1]) && input != commands[4]){
                    if (input.Length > commands[1].Length) {
                        try {
                            var choice = int.Parse(Regex.Match(input,"\\d+").Value);
                            EquipWeapon(choice - 1);
                        } catch {
                            PrintLN("Which one??", ConsoleColor.Red);
                        }
                    } else {
                        Print("What do you want to equip? \n");
                    }
                }
				else if (input == commands[2]) {
					Print("Available commands: \n");
					foreach (var command in commands) {
						Print(command + ", ");
					}
					Print("\n");
                } 
                else if (input == commands[3]) {
                    ListInventory();
					Print($"\nSlot: {UsedSpace}/{inventorySize}\n");
				} 
                else if (input == commands[4]) {
                    UnequipWeapon();
                } 
                else if (input.Contains(commands[5])) {
					if (input.Length > commands[5].Length) {
						try {
							var choice = int.Parse(Regex.Match(input,"\\d+").Value);
							ItemStats(choice - 1);
						} catch {
							PrintLN("Nothing's there!",ConsoleColor.Red);
						}
					} else {
						Print("What do you want to examine? \n");
					} 
                } else {
					Print("Available commands: \n");
					foreach (var command in commands) {
						Print(command + ", ");
					}
					Print("\n");
				}
			}
		}

        public void ItemStats(int i) {
			if (inventory[i] != null) {
				if (inventory[i] is Weapon) {
					double dmg = (inventory[i] as Weapon).Damage;
					double dmgmod = (inventory[i] as Weapon).DamageModifier;
					double totdmg = (inventory[i] as Weapon).TotalDamage;
					double atkspd = (inventory[i] as Weapon).AttackSpeed;
					double val = (inventory[i] as Weapon).Price;

                    Print($"\t [{inventory[i].GetName}]",ConsoleColor.Yellow);
					Print("\n\t Base damage: ",dmg.ToString(),ConsoleColor.White,ConsoleColor.Magenta);
					Print("\t Damage modifier: ",dmgmod.ToString(),ConsoleColor.White,ConsoleColor.Magenta);
					Print("\n\t Total damage: ",totdmg.ToString(),ConsoleColor.White,ConsoleColor.Magenta);
					Print("\t Attack speed: ",atkspd.ToString(),ConsoleColor.White,ConsoleColor.Magenta);
					Print("\n\t Value: ",val.ToString() + "G",ConsoleColor.White,ConsoleColor.Magenta);
				} else {
					Print(inventory[i].GetName," is not a weapon.",ConsoleColor.Magenta,ConsoleColor.White);
				}
			} else {
				PrintLN("You have nothing in that slot!",ConsoleColor.Red);
			}
            NewLine();
        }
	}
}
