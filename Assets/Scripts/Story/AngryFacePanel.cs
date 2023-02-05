using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class AngryFacePanel : StoryPanel
{
    [SerializeField] private TMPro.TMP_Text wrongNameText;
    [SerializeField] private RectTransform image;
    private UnityAction _onCrashDone;
    private bool hasEnded;

    [SerializeField] private float zoomSpeed;

    public override void StartStory()
    {
        _onCrashDone += OnCrashEnd;
        SoundManager.Instance.PlayCrashSound(_onCrashDone);
        wrongNameText.text = GameState.GameStateInstance.WrongPlayerName;
        base.StartStory();
    }

    public override bool ProgressStorry()
    {
        _onCrashDone -= OnCrashEnd;
        hasEnded = true;
        return base.ProgressStorry();
    }

    public void Update()
    {
        image.localScale *= 1+ ( Time.deltaTime * zoomSpeed);
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
