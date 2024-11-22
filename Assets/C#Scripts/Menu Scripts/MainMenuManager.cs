using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    //==================================
    //This script manages the main menu.
    //==================================

    //References
    #region References

    [Header("References")]

    [Header("Scripts")]
    public MainMenuButtons mainMenuButtons;
    public UINavigationController uINav;

    [Header("Bools")]
    private bool canPressKey = false;  // New variable to control key press after delay
    public bool startingScene;
    public bool mainMenu;

    [Header("Animator")]  
    public Animator anim;

    [Header("GameObjects")]
    public GameObject startingSceneCanvas;
    public GameObject mainMenuCanvas;

    #endregion

    //Start Method
    #region Start()

    void Start()
    {
        startingScene = true;
        mainMenu = false;
        canPressKey = false;
        StartCoroutine(EnableKeyPressAfterDelay(1));
    }

    #endregion

    //Update Method
    #region Update()

    void Update()
    {
        if (startingScene)
        {
            startingSceneCanvas.SetActive(true);
            mainMenuCanvas.SetActive(false);
            StartCoroutine(EnableKeyPressAfterDelay(1));

            if (canPressKey && Input.anyKeyDown)
            {
                // TODO: Play a sound effect and handle transitions

                StartCoroutine(WaitStart());
            }
        }
        else
        {
            canPressKey = false;
            startingSceneCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);

            if(mainMenu)
            {
                StartCoroutine(Wait());
            }
        }  
    }

    #endregion

    //EnableKeyPressAfterDelay Coroutine
    #region EnableKeyPressAfterDelay()
    // Coroutine to delay key press for 10 seconds
    IEnumerator EnableKeyPressAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canPressKey = true;
    }

    #endregion

    //Wait Coroutine
    #region Wait()

    //Coroutine for waiting in the main menu scene to press any key 
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(300);
        
        if(mainMenuButtons.playButton == false)
        {
            anim.SetBool("Fade In", true);
            yield return new WaitForSeconds(3);
            mainMenu = false;
            startingScene = true;
        }

    }

    #endregion

    //WaitStart Method
    #region WaitStart()

    IEnumerator WaitStart()
    {
        yield return new WaitForSeconds(0.1f);
        startingScene = false;
        mainMenu = true;
        // Deselect any currently selected object
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();

        // Set the target button as selected
        EventSystem.current.SetSelectedGameObject(uINav.firstButton);

        // Force update to ensure the selection is acknowledged
        uINav.firstButton.GetComponent<Button>().OnSelect(null);
    }

    #endregion

    //==================================
}