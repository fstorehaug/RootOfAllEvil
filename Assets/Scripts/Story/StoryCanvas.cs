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
        _activeStoryPanel = _storyPanels[_storyIndex];
        bool panelFinished = _activeStoryPanel.ProgressStorry();

        if (panelFinished)
        {
            _storyIndex++;

            if (_storyIndex >= _storyPanels.Length)
            {
                OnStorryEnd();
            }

            RunStoryPanel(_storyIndex);
        }
    }

    public void RunStoryPanel(int index)
    {
        foreach(StoryPanel panel in _storyPanels)
        {
            panel.gameObject.SetActive(false);
        }
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
