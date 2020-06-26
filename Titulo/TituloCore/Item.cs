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
