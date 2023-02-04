using System;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    [Serializable]
    public class ShopItem
    {
        private int puchaseCounter = 1;
        
        private ShopManager shopManager;

        private int initialCost;
        
        [SerializeField]
        private int cost = 100;

        [SerializeField] 
        private string name;
        
        [SerializeField] 
        private string description;

        [SerializeField]
        private Sprite image;
        
        [SerializeField]
        private UnityEvent onBuy;

        [SerializeField]
        private bool isEnabled = true;
        
        [SerializeField] 
        private float priceMultiplier = 4;

        [SerializeField] private bool isOneTime = false;
        
        public bool IsBought { get; private set; }

        public int Cost => cost;

        public string Name => name;

        public string Description => description;

        public bool IsAvailable => shopManager.CheckAvalability(this);
        
        public bool IsEnabled => isEnabled;

        public Sprite Image => image;

        public void SetShopManager(ShopManager shopManager)
        {
            initialCost = cost;
            this.shopManager = shopManager;
        }

        public void TryBuy()
        {
            if (shopManager.TryBuyItem(this))
            {
                Buy();
            }
        }

        private void Buy()
        {
            onBuy?.Invoke();
            IncreasePrice();
            if (isOneTime)
            {
                IsBought = true;
            }
        }

        private void IncreasePrice()
        {
            cost = initialCost * (int)Math.Pow(priceMultiplier, puchaseCounter++);
        }
    }
}