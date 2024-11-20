using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SceneLoaderAndButtons : MonoBehaviour
{
    //
    //
    //

    //References
    #region References

    [Header("References")]

    [Header("Scripts")]

    public MainMenuButtons mainMenuButtons;


    [Header("Bools")]
    private bool canPressKey = false;  // New variable to control key press after delay
    public bool startingScene;
    public bool mainMenu;


    [Header("Animator")]  
    
    public Animator anim;

    [Header("GameObjects")]

    public GameObject mainMenuFirstButton;
    public GameObject startingSceneCanvas;
    public GameObject mainMenuCanvas;

    #endregion 

    void Start()
    {
        startingScene = true;
        mainMenu = false;
        canPressKey = false;
        StartCoroutine(EnableKeyPressAfterDelay(1));
    }

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


    // Coroutine to delay key press for 10 seconds
    IEnumerator EnableKeyPressAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canPressKey = true;
    }

    //Coroutine for waiting in the mai menu scene to press any key 
    IEnumerator Wait() //This
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

    IEnumerator WaitStart()
    {
        yield return new WaitForSeconds(0.1f);
        startingScene = false;
        mainMenu = true;
        // Deselect any currently selected object
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();

        // Set the target button as selected
        EventSystem.current.SetSelectedGameObject(mainMenuFirstButton);

        // Force update to ensure the selection is acknowledged
        mainMenuFirstButton.GetComponent<Button>().OnSelect(null);
    }

}