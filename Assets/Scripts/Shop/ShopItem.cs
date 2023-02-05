using System;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    [Serializable]
    public class ShopItem
    {
        private ShopManager shopManager;
        private int puchaseCounter = 1;
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

        public int PurchaseCounter => puchaseCounter;
        
        public bool IsBought { get; private set; }

        public int Cost => (shopManager?.IsCheatMode ?? false) ? 0 : cost;

        public string Name => name;

        public string Description => description;

        public bool IsAvailable => shopManager?.CheckAvalability(this) ?? true;
        
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