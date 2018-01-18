namespace TBG_InventorySys
{
    public partial class Game
    {
        protected Room[,] rooms;
        protected Player player;
        protected XY Dimension;

        public Game(int x, int y)
        {
			Dimension.X = x;
            Dimension.Y = y;
			player = new Player(0,0);
            rooms = new Room[x,y];

            for (int i = 0; i < x; i++) {
                for (int j = 0; j < y; j++) {
                    rooms[i,j] = new Room(j,i);
                }
            }

            PopulateItems();
        }

        public void StartGame() {
            // Welcome and name picking phase
            Phase1();

			// Weapon choosing phase
			Phase2();

            // Begin
            Phase3();

        }
    }

	public struct XY {
		public int X { get; set; }
		public int Y { get; set; }
	}
}
