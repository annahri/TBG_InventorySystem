using System;
namespace TBG_InventorySys
{
    public abstract class Item
    {
        protected string name;
        public string GetName {
            get { return name; }
        }

        public void SetName(string name) {
            this.name = name;
        }
    }
}
