using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedManager : MonoBehaviour
{
    private float study=1.5f, wait=4f;
    private GameInfos infos;
    public GameObject OptOne, OptTwo, OptThr, OptFor, OptFiv;
    private int chosen,picked,progress,max;
    private bool ready = false,waiting=false;

    // Start is called before the first frame update
    void Start()
    {
        infos = GetComponent<GameInfos>();
        max = 4 + infos.GetDay();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ready = true;

        if (ready)
        {
            if(!waiting)
                study -= Time.deltaTime;
            if (study <= 0)
            {
                waiting = true;
                study = 1.5f;
            }
            if (waiting)
            {
                wait -= Time.deltaTime;
                if (wait <= 0)
                {
                    Wrong();
                }
            }
        }
    }

    public void Choice(GameObject sel)
    {
        waiting = false;
        wait = 4.0f;
        if (sel == OptOne)
        {
            chosen = 1;
        }
        else
        {
            if (sel == OptTwo)
            {
                chosen = 2;
            }
            else
            {
                if(sel == OptThr)
                {
                    chosen = 3;
                }
                else
                {
                    if (sel == OptFor)
                    {
                        chosen = 4;
                    }
                    else
                    {
                        if (sel == OptFiv)
                        {
                            chosen = 5;
                        }
                    }
                }
            }
        }
        CompareChoice();
    }

    private void pickFood()
    {
        float chose = Random.Range(1f, 5f);
        picked = Mathf.RoundToInt(chose);
        Debug.Log(picked);
        SetDisplay();
    }

    private void CompareChoice()
    {
        if (chosen == picked)
        {
            Correct();
        }
        else
            Wrong();
    }

    private void Correct()
    {
        progress++;
        if (progress >= max)
        {
            Debug.Log("Feeding Done");
            infos.NextActivity();
        }
    }

    private void Wrong()
    {
        progress--;
    }

    private void SetDisplay()
    {
        //wait
    }
}
