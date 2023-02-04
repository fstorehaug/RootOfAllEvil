using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoryCanvas : MonoBehaviour
{
    [SerializeField]
    StoryPanel[] storyPanels;
    private int storyIndex = 0;

    public UnityAction OnStorryCompleete;
    private StoryPanel _activeStoryPanel;

    public void RunStory()
    {
        this.gameObject.SetActive(true);
    }

    public void ProgresStory()
    {
        if (storyIndex >= storyPanels.Length)
        {
            OnStorryEnd();
            return;
        }

        _activeStoryPanel = storyPanels[storyIndex++];
        _activeStoryPanel.ProgressStorry();
    }

    private void OnStorryEnd()
    {

        OnStorryCompleete?.Invoke();
        storyIndex = 0;
        this.gameObject.SetActive(false);
    }


}
