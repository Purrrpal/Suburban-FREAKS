using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    //=============================================================================================
    //This script manages the fading that will happen when changing the scenes or pressing buttons.
    //=============================================================================================

    //References
    #region References

    public Animator animFade;
    
    public MainMenuButtons mainMenuButtons;

    #endregion

    //Wait Coroutine
    #region Wait()

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        animFade.SetTrigger("FadeOutTrigger");

    }

    #endregion

    //OnFadeComplete Method
    #region OnFadeComplete()

    public void OnFadeComplete()
    {
        if (mainMenuButtons.playButton)
        {
            SceneManager.LoadScene("CharacterSelectionScene");
            mainMenuButtons.playButton = false;
        }
        else if(mainMenuButtons.settingsButton) 
        {
            SceneManager.LoadScene("SettingsScene");
            mainMenuButtons.playButton = false;
        }
        else
        {
            Application.Quit();
        }

    }

    #endregion

    //=============================================================================================
}
