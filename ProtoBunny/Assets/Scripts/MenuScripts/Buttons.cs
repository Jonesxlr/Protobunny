using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    #region AllButtons/Start
    public Button playButton,credButton,backButton,yesButton,noButton;

    // Start is called before the first frame update
    void Start()
    {
        if (playButton != null)
            playButton.onClick.AddListener(PlayClicked);
        if (credButton != null)
            credButton.onClick.AddListener(CredClicked);
        if (backButton != null)
            backButton.onClick.AddListener(BackClicked);
        if (yesButton != null)
            yesButton.onClick.AddListener(YesClicked);
        if (noButton != null)
            noButton.onClick.AddListener(NoClicked);
    }
    #endregion

    #region MenuFunctions
    void PlayClicked()
    {
        Debug.Log("Play button was clicked!");
        SceneManager.LoadSceneAsync("Bedroom", LoadSceneMode.Single);
    }

    void CredClicked()
    {
        Debug.Log("Credits button was clicked!");
        SceneManager.LoadSceneAsync("Credits", LoadSceneMode.Single);
    }
    #endregion

    #region Credit/Game Functions
    void BackClicked()
    {
        Debug.Log("Back button was clicked!");
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Credits"))
        {
            Debug.Log("From Credits!");
            SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadSceneAsync("ConfirmMenu", LoadSceneMode.Additive);
            Debug.Log("From  Game!");
        }

    }
    #endregion

    #region Confirmation
    void YesClicked()
    {
        SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
    }

    void NoClicked()
    {
        SceneManager.UnloadSceneAsync("ConfirmMenu");
    }
    #endregion
}
