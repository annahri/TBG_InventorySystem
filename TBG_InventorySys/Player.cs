using System;
using System.Collections.Generic;
using static HelperClass.Helper;

namespace TBG_InventorySys {
    public partial class Player
    {
        public string Name;
        protected int inventorySize;

        protected double health = 100;
        protected double damage = 5;
        protected double attackspeed = 5;
        protected double gold = 1;

        public XY Pos;

        public List<Item> inventory;
        public Weapon Equip { get; set; }


        public Player(int x, int y)
        {
            Pos.X = x;
            Pos.Y = y;
            inventorySize = 5;
            inventory = new List<Item>();
        }

        public double Health {
            get { return health; }
        }

        public double BaseDamage {
            get { return damage; }
        }

        public double TotalDamage {
            get { return damage + (Equip != null ? Equip.TotalDamage : 0); }
        }

        public double Gold {
            get { return gold; }
        }

        public double BaseAttackSpeed {
            get { return attackspeed; }
        }

        public double TotalAttackSpeed {
            get { return attackspeed + (Equip != null ? Equip.AttackSpeed * 0.7 : 0); }
        }

        public int SlotsLeft {
            get { return inventorySize - inventory.Count; }
        }

        public int UsedSpace {
            get { return inventory.Count; }
        }


    }
}
