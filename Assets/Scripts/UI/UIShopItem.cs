using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class UIShopItem : MonoBehaviour
    {
        private ShopItem dataContext;
        
        [SerializeField]
        private TextMeshProUGUI nameText;
        
        [SerializeField]
        private TextMeshProUGUI descriptionText;
        
        [SerializeField]
        private TextMeshProUGUI costText;
        
        [SerializeField]
        private Image itemPicture;

        [SerializeField]
        private Color availableColor;
        
        [SerializeField]
        private Color unavailableMaterial;

        private bool isAvailbale = true;
        
        public void SetDataContext(ShopItem shopItem)
        {
            this.dataContext = shopItem;
            UpdateUIInfo();
        }

        public bool IsAvailable
        {
            get => isAvailbale;
            set
            {
                if (isAvailbale == value)
                {
                    return;
                }

                costText.color = dataContext.IsAvailable ? availableColor : unavailableMaterial;
                isAvailbale = value;
            }
        }

        private void Update()
        {
            IsAvailable = dataContext.IsAvailable;
            costText.SetText(dataContext.Cost.ToString());
            
            if (dataContext.IsBought)
            {
                gameObject.SetActive(false);
            }
        }

        private void UpdateUIInfo()
        {
            nameText.SetText(dataContext.Name);
            descriptionText.SetText(dataContext.Description);
            costText.SetText(dataContext.Cost.ToString());
            itemPicture.sprite = dataContext.Image;
        }
        
        public void OnClick() => dataContext.TryBuy();
    }
}