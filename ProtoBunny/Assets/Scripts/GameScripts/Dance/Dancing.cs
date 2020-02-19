using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dancing : MonoBehaviour
{
    public int progress = 0;
    private int max = 10;
    private bool ready = false,dancer = true;
    private GameInfos infos;
    private float cd,vanish;
    public GameObject dances, bad;
    public Text startText;

    // Start is called before the first frame update
    void Start()
    {
        infos = GetComponent<GameInfos>();
        max = 10 + (2 * infos.GetDay());
        cd = 1.0f / Mathf.Max(1, (infos.GetDay() / 2));
        vanish = 4.0f / Mathf.Max(1,(infos.GetDay()/2));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ready = true;
        }

        if (ready)
        {
            cd -= Time.deltaTime;

            if (cd <= 0f)
            {
                GameObject newDancer;
                if (dancer)
                {
                    newDancer = Instantiate(dances, new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(-4.5f, 4.5f)), transform.rotation);
                    newDancer.name = "Dance";
                    dancer = false;
                }
                else
                {
                    newDancer = Instantiate(bad, new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(-4.5f, 4.5f)), transform.rotation);
                    newDancer.name = "Bad";
                    dancer = true;
                }
                newDancer.GetComponent<DelayDeath>().DanceManager = gameObject;
                newDancer.GetComponent<DelayDeath>().deathdelay = vanish;
                cd = 1.0f / infos.GetDay();
            }
        }
    }
    public void ClickedBad()
    {
        progress--;
        startText.text = progress + "/" + max;
        infos.AddCorruption(2);
    }

    public void ClickedGood()
    {
        progress++;
        startText.text = progress + "/" + max;
        if (progress >= max)
        {
            Debug.Log("End Dance.");
            infos.NextActivity();
        }
    }
}
