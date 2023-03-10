using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class ShopManager : MonoBehaviour
    {
        private GameEngine gameEngine;

        [SerializeField]
        private bool cheatMode;
        
        private void Start()
        {
            gameEngine = FindObjectOfType<GameEngine>();
            shopItems.ForEach(si => si.SetShopManager(this));
        }

        [SerializeField]
        private List<ShopItem> shopItems;

        public bool IsCheatMode => cheatMode;
        
        public ShopItem[] ShopItems => shopItems.ToArray();

        public void IncreaseSoulRate(int multipler)
        {
            gameEngine.SetSoulMultiplier(multipler);
        }

        public void SpawnGhost() => gameEngine.SpawnGhost();

        public void UpgradeGhost() => gameEngine.UpgradeGhost();

        public void SetMinigunMode() => gameEngine.SetMinigunMode();
        
        public void SetShotgunMode() => gameEngine.SetShotgunMode();

        public bool TryBuyItem(ShopItem item) => gameEngine.TrySpend(item.Cost);

        public bool CheckAvalability(ShopItem item) => gameEngine.Score >= item.Cost;
    }
}