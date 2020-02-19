using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    private float wait = 6.0f;
    private GameInfos infos;
    private bool done = true;

    private void Start()
    {
        infos = GetComponent<GameInfos>();
    }

    // Update is called once per frame
    void Update()
    {
        wait -= Time.deltaTime;
        if (wait <= 0f)
        {
            if (done)
            {
                Debug.Log("End Placeholder");
                infos.NextActivity();
                done = false;
            }
        }
    }
}
