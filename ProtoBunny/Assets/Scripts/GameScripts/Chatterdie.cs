using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chatterdie : MonoBehaviour
{
    private float countdown = 5f;

    private static int line = 0,day;
    private GameInfos infos;
    private string texter;

    private void Start()
    {
        infos = GetComponent<GameInfos>();
        day = infos.GetDay();

        switch (day)
        {
            case 1:
                switch (line)
                {
                    default:
                        texter = "What do you want to do with Bunny?";
                        break;
                }
                break;
            case 2:
                switch (line)
                {
                    default:
                        texter = "Bunny is so cuuuuute~! What should we do today?";
                        break;
                }
                break;
            case 3:
                switch (line)
                {
                    default:
                        texter = "This is so much easier than taking care of a real pet. With school, I just don’t have the time anymore.";
                        break;
                }
                break;
            case 4:
                switch (line)
                {
                    default:
                        texter = ".. Hey, wait a second, this game used to be easier!";
                        break;
                }
                break;
            case 5:
                switch (line)
                {
                    default:
                        texter = "Did something move there? ... what's going on?";
                        break;
                }
                break;
            case 6:
                switch (line)
                {
                    default:
                        texter = "Bunny? Are you okay? .. Fiskers?!";
                        break;
                }
                break;
            case 7:
                switch (line)
                {
                    default:
                        texter = ".................................";
                        break;
                }
                break;
        }

        GetComponent<Text>().text = texter;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f||Input.GetMouseButton(0))
        {
            line++;
            SceneManager.UnloadSceneAsync("Chatterbox");
        }
    }
}
