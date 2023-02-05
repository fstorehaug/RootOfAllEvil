using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class HatHandler : MonoBehaviour
    {
        [SerializeField]
        private Sprite hatSprite;

        [SerializeField]
        private Image hatImage;
        
        private void Start()
        {
            SetHatSprite(hatSprite);
        }

        public void SetHatSprite(Sprite newHat)
        {
            hatImage.sprite = newHat;
        }
    }
}