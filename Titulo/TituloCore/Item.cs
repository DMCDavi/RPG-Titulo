using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TituloCore
{
    [DataContract(Name = "Item", Namespace = "http://www.contoso.com")]
    public class Item
    {
        [DataMember]
        public Character Owner;
        [DataMember]
        public string Name;
        [DataMember]
        public int posX;
        [DataMember]
        public int posY;
        public void PickUp(Character player)
        {
            if (player.Inventory.Count < 25)
            {
                player.Inventory.Add(this);
                this.Owner = player;
            }
        }

        public void Drop(Character player)
        {
            player.Inventory.Remove(this);
            this.Owner = null;
        }
        
    }
}
