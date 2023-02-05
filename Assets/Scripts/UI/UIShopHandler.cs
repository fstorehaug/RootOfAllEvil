using UnityEngine;

namespace DefaultNamespace
{
    public class UIShopHandler : MonoBehaviour
    {
        private ShopManager shopManager;
        
        [SerializeField]
        private GameObject itemTemplate;

        [SerializeField]
        private GameObject container;
        
        private void Start()
        {
            shopManager = FindObjectOfType<ShopManager>();
            CreateUI();
        }

        private void CreateUI()
        {
            foreach (var shopManagerShopItem in shopManager.ShopItems)
            {
                var uiItem = Instantiate(itemTemplate, container.transform);
                uiItem.GetComponent<UIShopItem>().SetDataContext(shopManagerShopItem);
            }
        }
    }
}