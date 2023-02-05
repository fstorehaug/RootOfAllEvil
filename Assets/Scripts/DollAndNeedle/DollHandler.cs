using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DollHandler : MonoBehaviour
{
    [SerializeField]
    private float hitTestAlphaTreshold;

    [SerializeField]
    private NeedleSpawner needleSpawner;
    
    private GameEngine gameEngine;
    private Image buttonImage;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        gameEngine = FindObjectOfType<GameEngine>();
    }

    private void Update()
    {
        buttonImage.alphaHitTestMinimumThreshold = hitTestAlphaTreshold;
    }
    
    public void OnClick()
    {
        if (gameEngine.IsMinigunMode)
        {
            needleSpawner.MinigunNeedles();
            return;
        }

        if (gameEngine.IsShotgunMode)
        {
            needleSpawner.ShotgunNeedles();
            return;
        }
        
        needleSpawner.SpawnNeedle();
    }
}
