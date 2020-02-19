using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{
    public Text enderText;

    private void Start()
    {
        GameInfos infos = GetComponent<GameInfos>();
        int corruption = infos.GetCorruption();

        enderText.text = "Bunny intolerance level: " + corruption + ".";

        if (corruption < 10)
        {
            enderText.text += "\nBunny is most pleased with you.";
        }
        else if (corruption < 70)
        {
            enderText.text += "\nBunny is indifferent with your performance.";
        }
        else
        {
            enderText.text += "\nBunny is most displeased with your efforts.";
        }
    }

}
