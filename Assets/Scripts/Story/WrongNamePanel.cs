using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongNamePanel : StoryPanel
{

    private Dictionary<char, string> replacements = new Dictionary<char, string>();
    [SerializeField]
    private TMPro.TMP_Text text;
    
    private void OnEnable()
    {
        text.text = MessupName(DefaultNamespace.GameEngine.Name);
    }

    private string MessupName(string originalName) 
    {
        string wrongName = "";
        
        for (int i = 0; i < originalName.Length; i++)
        {
            if (replacements.ContainsKey(originalName[i]))
            {
                wrongName = originalName;
                string tochange = wrongName.Remove(i, 1);
                wrongName.Insert(i, replacements[tochange[0]]);
                return wrongName;  
            }
        }

        if (name.Length == 1) 
        {
            return originalName + "-ito";
        }

        bool onlyOneChar = true;
        for (int i = 0; i<name.Length; i++)
        {
            if (originalName[i] != originalName[i + 1])
            {
                onlyOneChar = false;
            }
        }

        if (onlyOneChar)
        {
            return originalName[0].ToString();
        }

        int swappos = (int)(Random.Range(0, originalName.Length - 1));

        string removedLetter = originalName.Remove(swappos, 1);
        wrongName = originalName;
        wrongName.Insert(swappos + 1, removedLetter);

        return wrongName;

    }


    private void PopulateStringDict() 
    {
        replacements.Add('c', "k");
        replacements.Add('k', "c");
        replacements.Add('H', "");
        replacements.Add('w', "wh");
        replacements.Add('i', "ee");
        replacements.Add('e', "a");
        replacements.Add('s', "z");
        replacements.Add('z', "s");
        replacements.Add('a', "e");
    }




}
