﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BunMove : MonoBehaviour
{
    public float yLevel = -3.5f;
    private GameInfos infos;
    private int progress = 0, total = 0;
    private bool ready = false,waters=false;
    public GameObject Water, Mud;
    public Text StartText;
    private float cd = 0.6f, tTimer=25f;

    private void Start()
    {
        infos = GetComponent<GameInfos>();
        cd /= infos.GetDay();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.localPosition = new Vector2(Mathf.Clamp(mousePos.x,-9.0f,9.0f), yLevel);
        if (Input.GetMouseButtonDown(0))
        {
            ready = true;
            StartText.text = "";
        }

        if (ready)
        {
            //spawning water & mud
            cd -= Time.deltaTime;
            if (cd <= 0f)
            {
                if (waters)
                {
                    GameObject water = Instantiate(Water, new Vector3(Random.Range(-9.0f, 9.0f), 5.5f, 0f), transform.rotation);
                    water.name = "Water";
                    waters = false;
                }
                else
                {
                    GameObject mud = Instantiate(Mud, new Vector3(Random.Range(-9.0f, 9.0f), 5.5f, 0f), transform.rotation);
                    mud.name = "Mud";
                    waters = true;
                }
                cd = 0.6f/infos.GetDay();
            }
            //reduce timer
            tTimer -= Time.deltaTime;
            if (tTimer <= 0f)
            {
                Debug.Log("End Wash.");
                Cursor.visible = true;
                infos.NextActivity();
                ready = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.name == "Water")
        {
            progress++;
            total++;
        }
        if (other.name == "Mud")
        {
            infos.AddCorruption(2);
            total++;
        }

        StartText.text = progress + " - " + (int)((progress * 1f) / (total * 1f) * 100) + "%";

        Destroy(other);
    }
}
