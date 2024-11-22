using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class CursorManager : MonoBehaviour
{
    //===============================
    //This script manages the cursor.
    //===============================

    //References
    #region References

    [Header("References")]

    [Header("Scripts")]
    public MainMenuManager SceneLoaderAndButtons;

    [Header("Textures")]
    public Texture2D cursor;        
    public Texture2D cursorClicked;

    [Header("Buttons")]
    public Button playButton;
    public Button settingsButton;
    public Button quitButton;

    [Header("AudioSources")]
    public AudioSource clickSound;
    public AudioSource hoverSound;

    private Scene currentScene;
    private string sceneName;

    #endregion

    //Awake Method
    #region Awake()

    private void Awake()
    {
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.None;
    }

    #endregion

    //Start Method
    #region Start()

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if(sceneName == "MainMenu" && SceneLoaderAndButtons.mainMenu == false)
        {
            Cursor.visible = false;
        }
        
    }

    #endregion

    //OnEnable Method
    #region OnEnable

    private void OnEnable()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(OnButtonClicked);
        }

        if (settingsButton != null)
        {
            settingsButton.onClick.AddListener(OnButtonClicked);
        }

        if (quitButton != null)
        {
            quitButton.onClick.AddListener(OnButtonClicked);
        }
    }

    #endregion

    //OnDisable Method
    #region OnDisable()

    private void OnDisable()
    {
        if (playButton != null)
        {
            playButton.onClick.RemoveListener(OnButtonClicked);
        }

        if (settingsButton != null)
        {
            settingsButton.onClick.RemoveListener(OnButtonClicked);
        }

        if (quitButton != null)
        {
            quitButton.onClick.RemoveListener(OnButtonClicked);
        }
    }

    #endregion

    //OnButtonClicked Method
    #region OnButtonClicked()

    private void OnButtonClicked()
    {
        clickSound.Play();
        ChangeCursor(cursorClicked);
        Invoke(nameof(ResetCursor), 1f);
    }

    #endregion

    //ResetCursor Method
    #region ResetCursor()

    private void ResetCursor()
    {
        ChangeCursor(cursor);
    }

    #endregion

    //ChangeCursor Method
    #region ChangeCursor()

    private void ChangeCursor(Texture2D cursorType)
    {
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.ForceSoftware);
    }

    #endregion

    //OnButtonCursorEnter Method
    #region OnButtonCursorEnter

    public void OnButtonCursorEnter()
    {
        hoverSound.Play();
    }

    #endregion

    //OnButtonCursorExit Method
    #region OnButtonCursorExit()
    public void OnButtonCursorExit()
    {
        hoverSound.Stop();
    }

    #endregion

    //===============================
}
