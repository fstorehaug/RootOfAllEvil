using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNamePanel : StoryPanel
{
    [SerializeField]
    TMPro.TMP_Text TMPName;
    [SerializeField]
    TMPro.TMP_InputField InputField;

    private void Awake()
    {
        InputField.Select();
    }

    public override bool ProgressStorry()
    {
        string name = TMPName.text.Trim((char)8203);
   
        if (string.IsNullOrWhiteSpace(name))
        {
            name = "carl";
        }
        DefaultNamespace.GameEngine.SetName(name);
        base.ProgressStorry();
        return true;
    }

    public override void StartStory()
    {
        base.StartStory();
        InputField.Select();
    }





}
