using UnityEngine;
using UnityEngine.InputSystem;

public class StoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameCanvas;

    [SerializeField]
    private StoryCanvas[] _storyCanvases;

    [SerializeField]
    public InputAction _progressStorryAction;

    [SerializeField] 
    private GameObject shopUI;
    
    private StoryCanvas _activeStory;

    public static StoryManager Instance;

    private void Start()
    {
        Instance = this;

        _progressStorryAction.Enable();
        _progressStorryAction.performed += ProgressStorry;

        RunNextStorry();
    }

    private void SetActivatated(bool isActive)
    {
        _gameCanvas.SetActive(isActive);
        shopUI.SetActive(isActive);
    }

    public void RunNextStorry()
    {
        SetActivatated(false);
        if (GameState.GameStateInstance.StoryIndex >= _storyCanvases.Length)
        {
            return;
        }
        
        _activeStory = _storyCanvases[GameState.GameStateInstance.StoryIndex];
        _activeStory.RunStoryPanel(0);
        _activeStory.OnStorryCompleete += OnStoryComplete;
    }

    public void ProgressStorry(InputAction.CallbackContext context)
    {
        _activeStory.ProgresStory();
    }

    public void OnStoryComplete()
    {
        this.gameObject.SetActive(false);
        _progressStorryAction.performed -= ProgressStorry;
        SetActivatated(true);
    }

    private void OnDestroy()
    {
        _progressStorryAction.performed -= ProgressStorry;
    }

}
