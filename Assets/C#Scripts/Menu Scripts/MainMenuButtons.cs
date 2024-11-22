using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    //==========================================================
    //This script manages the buttons that are on the main menu.
    //==========================================================

    //References
    #region References

    [Header("References")]

    [Header("Scripts")]
    public Fade fade;

    [Header("Bools")]
    public bool playButton = false;
    public bool settingsButton = false;

    [Header("Animators")]
    public Animator anim;

    [Header("GameObjects")]
    public GameObject exitCanvas;


    #endregion

    //PlayButton Method
    #region PlayButton()

    public void PlayButton()
    {
        playButton = true;
        anim.SetBool("Fade In", true);
        StartCoroutine(fade.Wait());
        
    }

    #endregion

    //SettingsButton Method
    #region SettingsButton()

    public void SettingsButton()
    {
        anim.SetBool("Fade In", true);
        StartCoroutine(fade.Wait());
        settingsButton = true;
    }

    #endregion

    //Quit Method
    #region Quit()
    public void Quit()
    {
        Debug.Log("Quit Game");
        exitCanvas.SetActive(true);
        StartCoroutine(fade.Wait());
    }

    #endregion

    //==========================================================
}
