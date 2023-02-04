using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class AngryFacePanel : StoryPanel
{
    [SerializeField] private TMPro.TMP_Text wrongNameText;
    private UnityAction _onCrashDone;
    private bool hasEnded;

    public override void StartStory()
    {
        _onCrashDone += OnCrashEnd;
        SoundManager.Instance.PlayCrashSound(_onCrashDone);
        wrongNameText.text = DefaultNamespace.GameEngine.WrongName;
        base.StartStory();
    }

    public override bool ProgressStorry()
    {
        _onCrashDone -= OnCrashEnd;
        hasEnded = true;
        return base.ProgressStorry();
    }

    public void OnCrashEnd()
    {
        if (hasEnded)
        {
            return;
        }

        StoryManager.Instance.ProgressStorry(new InputAction.CallbackContext());
    }
}
