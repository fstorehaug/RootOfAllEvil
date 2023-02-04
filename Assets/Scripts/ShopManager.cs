using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class ShopManager : MonoBehaviour
    {
        private GameEngine gameEngine;
        
        private void Start()
        {
            gameEngine = FindObjectOfType<GameEngine>();
            DontDestroyOnLoad(this);
            
            shopItems.ForEach(si => si.SetShopManager(this));
        }

        [SerializeField]
        private List<ShopItem> shopItems;
        
        public ShopItem[] ShopItems => shopItems.ToArray();

        public void IncreaseSoulRate(int multipler)
        {
            gameEngine.SetSoulMultiplier(multipler);
        }

        public void SetMinigunMode() => gameEngine.SetMinigunMode();
        
        public void SetShotgunMode() => gameEngine.SetShotgunMode();

        public bool TryBuyItem(ShopItem item) => gameEngine.TrySpend(item.Cost);

        public bool CheckAvalability(ShopItem item) => gameEngine.Score >= item.Cost;
    }
}