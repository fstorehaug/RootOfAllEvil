using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class AngryFacePanel : StoryPanel
{
    [SerializeField] private TMPro.TMP_Text wrongNameText;
    private UnityAction _onCrashDone;

    public override void StartStory()
    {
        _onCrashDone += OnCrashEnd;
        SoundManager.Instance.PlayCrashSound(_onCrashDone);
        wrongNameText.text = DefaultNamespace.GameEngine.WrongName;
        base.StartStory();
    }

    public void OnCrashEnd()
    {
        StoryManager.Instance.ProgressStorry(new InputAction.CallbackContext());
    }
}
