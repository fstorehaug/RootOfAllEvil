using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class WrongNamePanel : StoryPanel
{

    private Dictionary<char, string> replacements = new Dictionary<char, string>();
    [SerializeField]
    private TMPro.TMP_Text text;

    public override void StartStory()
    {
        PopulateStringDict();
        string wrongName = MessupName(GameState.GameStateInstance.PlayerName.ToLower()).ToUpper();
        text.text = wrongName;
        GameState.GameStateInstance.SetPlayerName(wrongName);
        base.StartStory();
    }
    private string MessupName(string originalName) 
    {
        string wrongName = "";
        
        for (int i = 0; i < originalName.Length; i++)
        {
            if (replacements.ContainsKey(originalName[i]))
            {
                wrongName = originalName;
                string toChange = wrongName[i].ToString();
                Regex reg = new Regex(Regex.Escape(toChange));
                return reg.Replace(wrongName, replacements[toChange[0]], 1);
            }
        }

        if (originalName.Length == 1) 
        {
            return originalName + "-ito";
        }

        bool onlyOneChar = true;
        for (int i = 0; i < originalName.Length-1; i++)
        {
            if (originalName[i] != originalName[i + 1])
            {
                onlyOneChar = false;
                break;
            }
        }

        if (onlyOneChar)
        {
            return originalName[0].ToString();
        }

        int swappos = (int)(Random.Range(0, originalName.Length - 1));

        char removedLetter = originalName[swappos];
        if (removedLetter == originalName[swappos + 1])
        {
            return "RootMan";
        }
        originalName.Remove(swappos, swappos + 1);
        wrongName = originalName;
        wrongName.Insert(swappos + 1, removedLetter.ToString());

        return wrongName;

    }


    private void PopulateStringDict() 
    {
        replacements.Add('c', "k");
        replacements.Add('k', "c");
        replacements.Add('H', " ");
        replacements.Add('w', "wh");
        replacements.Add('i', "ee");
        replacements.Add('e', "a");
        replacements.Add('s', "z");
        replacements.Add('z', "s");
        replacements.Add('a', "e");
    }




}
