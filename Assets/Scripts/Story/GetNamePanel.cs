using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNamePanel : StoryPanel
{
    private string _nameString = "Carl";

    public override bool ProgressStorry()
    {
        DefaultNamespace.GameEngine.SetName(_nameString == ""? "Carl" : _nameString);
        base.ProgressStorry();
        return true;
    }

    public void UpdateName(string name) 
    {
        _nameString = name;    
    }

}
