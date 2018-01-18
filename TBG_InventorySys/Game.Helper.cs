using System;
using static HelperClass.Helper;
namespace TBG_InventorySys
{
    public partial class Game {
        #region CheckItem Stats
        protected bool CheckStatsFromPlayerInventory(int i) {
            try {
                double dmg = (player.inventory[i] as Weapon).Damage;
                double val = (player.inventory[i] as Weapon).Price;
                double atkspd = (player.inventory[i] as Weapon).AttackSpeed;
                double dmgmod = (player.inventory[i] as Weapon).DamageModifier;
                double total = (player.inventory[i] as Weapon).TotalDamage;

                Print("\t Base damage: ",dmg.ToString(),ConsoleColor.White,ConsoleColor.Magenta);
                Print("\t Damage modifier: ",dmgmod.ToString(),ConsoleColor.White,ConsoleColor.Magenta);
                Print("\n\t Total damage: ",total.ToString(),ConsoleColor.White,ConsoleColor.Magenta);
                Print("\t Attack speed: ",atkspd.ToString(),ConsoleColor.White,ConsoleColor.Magenta);
                Print("\n\t Value: ",val.ToString() + "G",ConsoleColor.White,ConsoleColor.Magenta);
				return true;
			} catch(ArgumentOutOfRangeException) {
                PrintLN("You have nothing in that slot.", ConsoleColor.Red);
                return false;
            }
		}

        protected void CheckStats(Item item) {
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
            } else {
                // implemented later
            }
        }

        #endregion
    }
}
