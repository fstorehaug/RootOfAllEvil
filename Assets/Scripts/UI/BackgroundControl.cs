using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class BackgroundControl : MonoBehaviour
    {
        [SerializeField] private Image backgroundImage;

        [SerializeField] private Sprite[] backgrounds;

        private int lastStoryIndex = -1;

        private void Update()
        {
            if (lastStoryIndex != GameState.GameStateInstance.StoryIndex)
            {
                lastStoryIndex = GameState.GameStateInstance.StoryIndex;
                backgroundImage.sprite = backgrounds.ElementAtOrDefault(lastStoryIndex);
            }
        }
    }
}