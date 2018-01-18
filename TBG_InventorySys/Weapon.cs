using System;
namespace TBG_InventorySys {
    
    public abstract class Weapon : Item {
        protected double damage = 5;
        protected double price = 5;
        protected double baseAtkSpd = 5;
        protected double damageModifier = 0;

		public double Damage {
			get { return damage; }
		}

		public double Price {
			get { return price; }
		}

		public double AttackSpeed {
			get { return baseAtkSpd; }
		}

        public double DamageModifier {
            get { return damageModifier * 0.8; }
        }

        public double TotalDamage {
            get { return DamageModifier + Damage; }
        }

        public double ModifyDamageModifier {
			set { damageModifier += value; }
		}

        public double ModifyPrice {
            set { price += value; }
        }

        public double ModifyAttackspeed {
            set { baseAtkSpd += value; }
        }
	}

    public class Axe : Weapon {
        public Axe() {
            damage = 10;
            price = 8;
            baseAtkSpd = 6;
        }

    }

	public class Sword : Weapon {
        public Sword() {
            damage = 8;
            price = 7;
            baseAtkSpd = 7.2;
        }
	}
}
