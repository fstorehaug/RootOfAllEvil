using System;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    [Serializable]
    public class ShopItem
    {
        [SerializeField]
        private int cost = 100;

        [SerializeField] 
        private string name;
        
        [SerializeField] 
        private string description;

        [SerializeField]
        private UnityEvent onBuy;

        [SerializeField]
        private bool isEnabled = true;

        public bool IsBought { get; private set; }

        public void Buy()
        {
            onBuy?.Invoke();
            IsBought = true;
        }
    }
}