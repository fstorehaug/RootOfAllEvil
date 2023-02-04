using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoryCanvas : MonoBehaviour
{
    [SerializeField]
    StoryPanel[] _storyPanels;
    private int _storyIndex = 0;

    public UnityAction OnStorryCompleete;
    private StoryPanel _activeStoryPanel;

    public void ProgresStory()
    {
        if (_storyIndex >= _storyPanels.Length)
        {
            OnStorryEnd();
            return;
        }

        _activeStoryPanel = _storyPanels[_storyIndex];
        bool panelFinished = _activeStoryPanel.ProgressStorry();

        if (panelFinished)
        {
            RunStory(_storyIndex);
        }

        _storyIndex++;
    }

    public void RunStory(int index)
    {
        this.gameObject.SetActive(true);
        _storyPanels[_storyIndex].StartStory();
    }
    private void OnStorryEnd()
    {
        OnStorryCompleete?.Invoke();
        _storyIndex = 0;
        this.gameObject.SetActive(false);
    }


}
