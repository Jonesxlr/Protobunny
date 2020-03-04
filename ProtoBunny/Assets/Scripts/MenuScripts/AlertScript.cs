using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AlertScript : MonoBehaviour
{
    private float countdown = 2.5f;

    public void UpdateMessage(string Message)
    {
        gameObject.GetComponent<Text>().text = Message;
    }

    private void Start()
    {
        int act = GetComponent<GameInfos>().GetActivity();
        if (act == 0)
        {
            UpdateMessage("Day " + GetComponent<GameInfos>().GetDay() + "\nBedroom");
        }
        else
        {
            BunActions action = GetComponent<GameInfos>().GetActivity(act);
            switch (action)
            {
                case BunActions.Wash:
                    UpdateMessage("Day " + GetComponent<GameInfos>().GetDay() + "\nWashing");
                    break;
                case BunActions.Dance:
                    UpdateMessage("Day " + GetComponent<GameInfos>().GetDay() + "\nDance");
                    break;
                case BunActions.Explore:
                    UpdateMessage("Day " + GetComponent<GameInfos>().GetDay() + "\nExplore");
                    break;
                case BunActions.Feed:
                    UpdateMessage("Day " + GetComponent<GameInfos>().GetDay() + "\nFeeding");
                    break;
                case BunActions.Ball:
                    UpdateMessage("Day " + GetComponent<GameInfos>().GetDay() + "\nBall");
                    break;
            }
        }
    }

    private void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0.0f)
        {
            if (GetComponent<GameInfos>().GetActivity() == 0)
                SceneManager.LoadSceneAsync("Chatterbox", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("Alert");
        }
    }
}
