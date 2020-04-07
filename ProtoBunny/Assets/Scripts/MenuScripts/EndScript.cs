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
            enderText.text += "\nBunny is most pleased with you. Ending 1/3.";
        }
        else if (corruption < 70)
        {
            enderText.text += "\nBunny is indifferent with your performance. Ending 2/3.";
        }
        else
        {
            enderText.text += "\nBunny is most displeased with your efforts. Ending 3/3.";
        }

        enderText.text += "\n\nIn the final build, there will be artwork here based on the above message.\nDue to issues outside our control, we've been unable to implement said artwork.";
    }

}
