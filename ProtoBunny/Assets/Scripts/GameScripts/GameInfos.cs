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
    private static int clean = 10, fed = 10, happy = 10;

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
        clean = 10;
        fed = 10;
        happy = 10;
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
        corruption = Mathf.Max(0,corruption - (7-chance) * 5);
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
            case BunActions.Wash: // +*clean, -happy
                clean = 10;
                happy = Mathf.Max(happy - 3, 0);
                SceneManager.LoadSceneAsync("Washing", LoadSceneMode.Single);
                break;
            case BunActions.Dance: // ++happy, -fed
                happy = Mathf.Min(happy + 2, 10);
                fed = Mathf.Max(fed - 1, 0);
                SceneManager.LoadSceneAsync("Dance", LoadSceneMode.Single);
                break;
            case BunActions.Explore: // ++happy, -clean
                // Load Explore minigame - click a direction, bunny goes in that direction. reach goal, avoid bads.
                happy = Mathf.Min(happy + 2, 10);
                clean = Mathf.Max(clean - 1, 0);
                SceneManager.LoadSceneAsync("Placeholder", LoadSceneMode.Single);
                break;
            case BunActions.Ball: // +++happy, -fed, -clean
                // Load Ball minigame - BBTan, shoot ball to bunny.
                happy = Mathf.Min(happy + 3, 10);
                fed = Mathf.Max(fed - 1, 0);
                clean = Mathf.Max(clean - 1, 0);
                SceneManager.LoadSceneAsync("Placeholder", LoadSceneMode.Single);
                break;
            case BunActions.Feed: // +*fed
                // Load Feed minigame scene - Memory Match, 5 cards, one card matches bun's request, find the match.
                fed = 10;
                SceneManager.LoadSceneAsync("Placeholder", LoadSceneMode.Single);
                break;
            case BunActions.Empty:
                happy = Mathf.Max(happy - 2, 0);
                clean = Mathf.Max(clean - 1, 0);
                fed = Mathf.Max(fed - 1, 0);
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

    public int GetFed()
    {
        return fed;
    }

    public int GetClean()
    {
        return clean;
    }

    public int GetHappy()
    {
        return happy;
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
