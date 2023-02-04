using System.Collections;
using System.Collections.Generic;
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

    private StoryCanvas _activeStory;
    private int storyIndex = 0;

    public static StoryManager Instance;

    private void Start()
    {
        Instance = this;

        _progressStorryAction.Enable();
        _progressStorryAction.performed += ProgressStorry;

        RunNextStorry();
    }

    public void RunNextStorry()
    {
        _gameCanvas.SetActive(false);
        _activeStory = _storyCanvases[storyIndex++];
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
        _gameCanvas.SetActive(true);
    }

}
