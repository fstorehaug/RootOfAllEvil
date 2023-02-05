using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{

    private static GameState _state;
    public static GameState GameStateInstance = _state ??= new GameState();

    public int StoryIndex { private set; get; }
    public string PlayerName { private set; get; }
    public string WrongPlayerName { private set; get; }

    public void ProgressStoryIndex()
    {
        StoryIndex++;
    }

    public void SetPlayerName(string name)
    {
        this.PlayerName = name;
    }

    public void SetWrongName(string wrongName)
    {
        this.WrongPlayerName = wrongName;
    }
    

}




