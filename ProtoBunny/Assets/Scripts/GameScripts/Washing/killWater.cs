using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killWater : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}
