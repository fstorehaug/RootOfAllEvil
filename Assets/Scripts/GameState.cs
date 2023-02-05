using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState
{
    private static GameState _state;
    public static GameState GameStateInstance = _state ??= new GameState();

    private static int currentScore;
    private static int totalScore;

    public int StoryIndex { private set; get; }
    public string PlayerName { private set; get; }
    public string WrongPlayerName { private set; get; }

    private void ProgressStoryIndex()
    {
        StoryIndex++;
        currentScore = 0;
    }

    public void SetPlayerName(string name)
    {
        this.PlayerName = name;
    }

    public void SetWrongName(string wrongName)
    {
        this.WrongPlayerName = wrongName;
    }
    
    public void AddScore(int increment)
    {
        currentScore += increment;
        totalScore += increment;
    }

    public bool CanProgress()
    {
        float levelSoulDemand = (Mathf.Pow(1.02f, (float)((StoryIndex ^ StoryIndex))) + (10 ^ StoryIndex) + (1000 * StoryIndex) + StoryIndex + 200);
        if (currentScore > levelSoulDemand)
        {
            return true;
        }

        return false;
    }

    public void EndSceene()
    {
        ProgressStoryIndex();
        SceneManager.SetActiveScene(SceneManager.GetActiveScene());
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}




