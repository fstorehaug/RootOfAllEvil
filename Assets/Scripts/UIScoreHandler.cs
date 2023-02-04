using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class UIScoreHandler : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI scoreText;

        [SerializeField] 
        private GameEngine gameEngine;
        
        private void Update()
        {
            scoreText.SetText($"Soul Energy : {gameEngine.Score}");
        }
    }
}