using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BunActions { Empty, Feed, Wash, Explore, Ball, Dance }

public class GameInfos : MonoBehaviour
{
    [SerializeField]
    private static int day = 1;
    private static int corruption = 0;
    private static int activity = 0;
    private static BunActions firstActivity = BunActions.Empty;
    private static BunActions secActivity = BunActions.Empty;
    private static BunActions thirdActivity = BunActions.Empty;

    #region Set Things
    public void SetActivity(int action,BunActions doing)
    {
        switch (action)
        {
            case 1:
                firstActivity = doing;
                break;
            case 2:
                secActivity = doing;
                break;
            case 3:
                thirdActivity = doing;
                break;
            default:
                Debug.Log("Activity messed up.");
                break;
        }
    }

    public void ResetGame()
    {
        Debug.Log("Resetting Game.");
        day = 1;
        corruption = 0;
        activity = 0;
        ResetActivities();
    }

    public void ResetActivities()
    {
        firstActivity = BunActions.Empty;
        secActivity = BunActions.Empty;
        thirdActivity = BunActions.Empty;
    }
    #endregion

    #region Days & Corruption
    public void AddCorruption(int Cor)
    {
        corruption = Mathf.Min(100,corruption+Cor*day);
    }

    public void CleanseCorruption(int chance)
    {
        corruption /= (8 - chance);
        Debug.Log("Current Corruption: " + corruption);
    }

    public void NextDay()
    {
        if (day < 7)
        {
            day++;
            CleanseCorruption(day);
            Debug.Log("Next day; "+day);
            SceneManager.LoadSceneAsync("Bedroom", LoadSceneMode.Single);
        }
        else
        {
            Debug.Log("Game Ending.");
            //Ending
            GetEnding();
        }
    }

    public void NextActivity()
    {
        if (activity < 3)
        {
            activity++;
            switch (activity)
            {
                case 1:
                    LoadMinigame(firstActivity);
                    break;
                case 2:
                    LoadMinigame(secActivity);
                    break;
                case 3:
                    LoadMinigame(thirdActivity);
                    break;
            }
            Debug.Log("Starting next activity... " + activity);
        }
        else
        {
            activity = 0;
            Debug.Log("All activities completed.");
            NextDay();
        }
    }

    public void LoadMinigame(BunActions Activity)
    {
        switch (Activity)
        {
            case BunActions.Wash:
                SceneManager.LoadSceneAsync("Washing", LoadSceneMode.Single);
                break;
            case BunActions.Dance:
                SceneManager.LoadSceneAsync("Dance", LoadSceneMode.Single);
                break;
            case BunActions.Explore:
                // Load Explore minigame - click a direction, bunny goes in that direction. reach goal, avoid bads.
            case BunActions.Ball:
                // Load Ball minigame - BBTan, shoot ball to bunny.
            case BunActions.Feed:
                // Load Feed minigame scene - Memory Match, 5 cards, one card matches bun's request, find the match.
                SceneManager.LoadSceneAsync("Placeholder", LoadSceneMode.Single);
                break;
            case BunActions.Empty:
                AddCorruption(7);
                NextActivity();
                break;
        }
    }

    public void GetEnding()
    {
        /* if (corruption <= 10)
         {
             //Purged Ending
         }
         else
         {
             if (corruption <= 70)
             {
                 //Sickness Ending
             }
             else
             {
                 //Murder Ending
             }
         }*/
        SceneManager.LoadSceneAsync("Ending", LoadSceneMode.Single);
    }
    #endregion

    #region freeGets

    public int GetDay()
    {
        return day;
    }

    public int GetCorruption()
    {
        return corruption;
    }

    public int GetActivity()
    {
        return activity;
    }

    public BunActions GetActivity(int act)
    {
        switch (act)
        {
            case 1:
                return firstActivity;
            case 2:
                return secActivity;
            case 3:
                return thirdActivity;
        }
        return BunActions.Empty;
    }

    #endregion
}
