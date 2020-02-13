using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BunActions { Empty, Feed, Wash, Explore, Ball, Dance }

public class InfoManager : MonoBehaviour
{
    [SerializeField]
    private int day = 0;
    private int corruption = 0;
    private int activity = 0;
    private BunActions firstActivity = BunActions.Empty;
    private BunActions secActivity = BunActions.Empty;
    private BunActions thirdActivity = BunActions.Empty;

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
        day = 0;
        corruption = 0;
        activity = 0;
        //Go to Menu
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
        Debug.Log("Adding " + Cor + " corruption.");
        corruption += Cor;
    }

    public void NextDay()
    {
        if (day < 7)
        {
            day++;
            Debug.Log("Next day; "+day);
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
            Debug.Log("Starting next activity...");

            switch (activity)
            {
                case 1:
                    //Play firstActivity
                    break;
                case 2:
                    //Play secActivity
                    break;
                case 3:
                    //Play thirdActivity
                    break;
            }
        }
        else
        {
            activity = 0;
            Debug.Log("All activities completed.");
            NextDay();
        }
    }

    public void GetEnding()
    {
        if (corruption <= 10)
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
        }
    }
    #endregion

    // Made this edit at home.
    // made this one in class.
}
