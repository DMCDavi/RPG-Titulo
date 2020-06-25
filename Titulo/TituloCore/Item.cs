using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TituloCore
{
    [DataContract(Name = "Item", Namespace = "http://www.contoso.com")]
    public class Item
    {
        public Character Owner;
        public string Name;
        public int posX;
        public int posY;
        public void PickUp(Character player)
        {
            player.Inventory.Add(this);
            this.Owner = player;
        }

        public void Drop()
        {
            this.Owner.Inventory.Remove(this);
            this.Owner = null;
        }
        
    }
}
