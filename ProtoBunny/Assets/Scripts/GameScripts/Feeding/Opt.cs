using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opt : MonoBehaviour
{
    public FeedManager Feedie;

    private void OnMouseDown()
    {
        Feedie.Choice(gameObject);
    }
}
