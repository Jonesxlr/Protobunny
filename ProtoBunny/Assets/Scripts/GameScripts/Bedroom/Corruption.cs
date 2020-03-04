using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corruption : MonoBehaviour
{
    private int corruption;
    public GameObject corShadow, startDay;
    private GameInfos infos;
    private float delay, timer = 0f;
    private bool shadow = false;

    // Start is called before the first frame update
    void Start()
    {
        infos = startDay.GetComponent<GameInfos>();
        corruption = infos.GetCorruption();
        delay = 100 - corruption;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (!shadow)
        {
            if (timer >= delay)
            {
                timer = 0;
                shadow = true;
                corShadow.SetActive(shadow);

                corShadow.transform.localScale = new Vector3(1.0f + Random.Range(0.0f,1.0f), 1.0f + Random.Range(0.0f, 1.0f), 1f);
            }
        }
        else
        {
            if (timer >= 0.15f)
            {
                timer = 0;
                shadow = false;
                corShadow.SetActive(shadow);
            }
        }
    }
}
