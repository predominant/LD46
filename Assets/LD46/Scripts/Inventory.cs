using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace LD46.Scripts
{
    public class Inventory : MonoBehaviour
    {
        private int _maxItems = 5;

        public List<InventoryItem> Items = new List<InventoryItem>();

        public bool Has<T>()
        {
            foreach (var i in this.Items)
            {
                if (i.GetType() == typeof(T))
                    return true;
            }

            return false;
        }

        public bool Full => this.Items.Count >= this._maxItems;
        public int Count => this.Items.Count;

        public bool Add(InventoryItem item)
        {
            if (this.Full)
                return false;
            
            this.Items.Add(item);
            return true;
        }
    }
}