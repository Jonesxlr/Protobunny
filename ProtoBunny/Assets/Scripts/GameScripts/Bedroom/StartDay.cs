using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartDay : MonoBehaviour
{
    public GameObject actDock, actDock2, actDock3;
    GameInfos infos;
    public Text stats;

    private void Start()
    {
        infos = GetComponent<GameInfos>();
        gameObject.GetComponent<Button>().onClick.AddListener(StartingDay);
        stats.text = "Clean: " + infos.GetClean() + "\nTummy: " + infos.GetFed() + "\nHappy: " + infos.GetHappy();
    }

    void StartingDay()
    {
       if (actDock.GetComponent<Dock>().action!=BunActions.Empty && actDock2.GetComponent<Dock>().action != BunActions.Empty && actDock3.GetComponent<Dock>().action != BunActions.Empty)
       {
            infos.SetActivity(1, actDock.GetComponent<Dock>().action);
            infos.SetActivity(2, actDock2.GetComponent<Dock>().action);
            infos.SetActivity(3, actDock3.GetComponent<Dock>().action);

            infos.NextActivity();
       }
    }
}
