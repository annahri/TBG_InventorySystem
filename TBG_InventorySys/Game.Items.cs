using System.Collections.Generic;
namespace TBG_InventorySys {
    public partial class Game {
        private List<Item> items = new List<Item>();

        private void PopulateItems() {
            items.Add(new Axe());
            items.Add(new Axe());
            items.Add(new Sword());
            items.Add(new Sword());

            int i = 0;
            items[i].SetName("Skysteel Axe");
			(items[i] as Weapon).ModifyPrice = 1;
			(items[i] as Weapon).ModifyAttackspeed = -1;
			(items[i] as Weapon).ModifyDamageModifier = 3;

            items[++i].SetName("Rueful Axe");
			(items[i] as Weapon).ModifyPrice = -1;
			(items[i] as Weapon).ModifyAttackspeed = 1.1;
			(items[i] as Weapon).ModifyDamageModifier = 2;

			items[++i].SetName("Skysteel Sword");
			(items[i] as Weapon).ModifyPrice = 1.5;
			(items[i] as Weapon).ModifyAttackspeed = 2.3;
			(items[i] as Weapon).ModifyDamageModifier = 1;
			
            items[++i].SetName("Knight Sword");
			(items[i] as Weapon).ModifyPrice = -0.4;
			(items[i] as Weapon).ModifyAttackspeed = 1.7;
			(items[i] as Weapon).ModifyDamageModifier = 1.8;
		}
    }
}
