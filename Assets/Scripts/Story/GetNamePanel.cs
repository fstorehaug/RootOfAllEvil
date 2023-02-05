using UnityEngine;

public class GetNamePanel : StoryPanel
{
    [SerializeField]
    TMPro.TMP_Text TMPName;
    
    [SerializeField]
    TMPro.TMP_InputField InputField;

    private void OnEnable()
    {
        FocusField();
    }

    public void FocusField()
    {
        InputField.Select();
        InputField.ActivateInputField();
    }

    public override bool ProgressStorry()
    {
        string name = TMPName.text.Trim((char)8203);
   
        if (string.IsNullOrWhiteSpace(name))
        {
            name = "carl";
        }
        GameState.GameStateInstance.SetPlayerName(name);
        base.ProgressStorry();
        return true;
    }

    public override void StartStory()
    {
        base.StartStory();
        InputField.Select();
    }
}
