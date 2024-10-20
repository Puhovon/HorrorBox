using System;
using System.Collections.Generic;
using Items.Abstract;
using UnityEngine;
using Zenject;

namespace Player
{
    public class Inventory : MonoBehaviour
    {
        private ArmControllerConfig _config;
        private List<IItem> _items;

        [Inject]
        private void Construct(ArmControllerConfig config)
        {
            _config = config;
            _items = new List<IItem>();
            Debug.Log(_items is null);
        }

        public bool CanPullItem()
        {
            
            Debug.Log("items in inventory: " + _items.Count);
            return _items.Count < _config.MaxItems;
        }

        public void PullItem(IItem item)
        {
            if (!CanPullItem())
                throw new ArgumentOutOfRangeException("Maaaan, inventory is full...");
            _items.Add(item);
        }

        public bool DropItem(IItem item)
        {
            return _items.Remove(item);
        }

        public void GetNextItem()
        {
            
        }

        public void GetPreviusItem()
        {
            
        }
    }
}