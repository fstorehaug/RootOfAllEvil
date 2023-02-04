using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryPanel : MonoBehaviour
{
    //returns true when the story is finished
    public virtual bool ProgressStorry()
    {
        this.gameObject.SetActive(false);
        return true;
    }

    public virtual void StartStory()
    {
        this.gameObject.SetActive(true);
    }
}
