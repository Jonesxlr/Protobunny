using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDeath : MonoBehaviour
{
    public float deathdelay = 2.0f;
    public GameObject DanceManager;
    
    // Update is called once per frame
    void Update()
    {
        deathdelay -= Time.deltaTime;
        if (deathdelay <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (name == "Dance")
            DanceManager.GetComponent<Dancing>().ClickedGood();
        else
            DanceManager.GetComponent<Dancing>().ClickedBad();
        Destroy(gameObject);
    }
}
