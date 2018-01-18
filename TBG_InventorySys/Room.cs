using System;
using System.Collections.Generic;

namespace TBG_InventorySys {
	public class Room {
		public int X { get; set; }
		public int Y { get; set; }

        public List<Item> Items;

		public Room(int x,int y) {
			X = x;
			Y = y;

            Items = new List<Item>();
		}

	}
}
