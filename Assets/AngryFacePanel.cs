using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryFacePanel : StoryPanel
{
    [SerializeField] private TMPro.TMP_Text wrongNameText;

    public override void StartStory()
    {
        wrongNameText.text = DefaultNamespace.GameEngine.WrongName;
        base.StartStory();
    }
}
