using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI scoreText;

        [SerializeField] 
        private GameEngine gameEngine;
        
        private void Update()
        {
            scoreText.SetText($"Score {gameEngine.Score}");
        }
    }
}