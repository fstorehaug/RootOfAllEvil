using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class UIScoreHandler : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI scoreText;
 
        private GameEngine gameEngine;

        private void Start()
        {
            gameEngine = FindObjectOfType<GameEngine>();
        }

        private void Update()
        {
            scoreText.SetText($"Soul Power : {gameEngine.Score}");
        }
    }
}