using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    //==========================================================
    //This script manages the buttons that are on the main menu.
    //==========================================================

    //References
    #region References

    public Animator anim;
    public Fade fade;
    public GameObject exitCanvas;
    public bool playButton = false;
    public bool settingsButton = false;

    #endregion

    public void PlayButton()
    {
        playButton = true;
        anim.SetBool("Fade In", true);
        StartCoroutine(fade.Wait());
        
    }

    public void SettingsButton()
    {
        anim.SetBool("Fade In", true);
        StartCoroutine(fade.Wait());
        settingsButton = true;
    }

    public void Quit()
    {
        Debug.Log("Quit Game");
        exitCanvas.SetActive(true);
        StartCoroutine(fade.Wait());
    }

    
}
