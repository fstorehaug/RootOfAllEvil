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

    [SerializeField]
    private HatHandler hatHandler;

    [SerializeField]
    private Sprite[] dollImages;

    [SerializeField] private GameObject politicianParts;
    
    private GameEngine gameEngine;
    private Image buttonImage;

    private int lastSceneIndex = -1;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        gameEngine = FindObjectOfType<GameEngine>();
    }

    private void Update()
    {
        if (GameState.GameStateInstance.StoryIndex != lastSceneIndex)
        {
            lastSceneIndex = GameState.GameStateInstance.StoryIndex;
            SceneChange();
        }
        
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

    public void SceneChange(int? specScene = null)
    {
        buttonImage.sprite = dollImages[specScene ?? lastSceneIndex];
        
        switch (lastSceneIndex)
        {
            case 0:
                politicianParts.gameObject.SetActive(false);
                hatHandler.gameObject.SetActive(true);
                break;
            case 1:
                politicianParts.gameObject.SetActive(true);
                hatHandler.gameObject.SetActive(false);
                break;
            default:
                politicianParts.gameObject.SetActive(false);
                hatHandler.gameObject.SetActive(false);
                break;
        }
    }
}
