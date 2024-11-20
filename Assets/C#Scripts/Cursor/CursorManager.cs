using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class CursorManager : MonoBehaviour
{
    //
    //
    //

    //References
    #region References

    [Header("References")]

    [Header("Scripts")]
    public SceneLoaderAndButtons SceneLoaderAndButtons;

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

    //Start Method
    #region Start()

    private void Awake()
    {
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.None;
    }

    #endregion

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if(sceneName == "MainMenu" && SceneLoaderAndButtons.mainMenu == false)
        {
            Cursor.visible = false;
        }
        
    }

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

    private void OnButtonClicked()
    {
        clickSound.Play();
        ChangeCursor(cursorClicked);
        Invoke(nameof(ResetCursor), 1f);
    }

    private void ResetCursor()
    {
        ChangeCursor(cursor);
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void OnButtonCursorEnter()
    {
        hoverSound.Play();
    }

    public void OnButtonCursorExit()
    {
        hoverSound.Stop();
    }

}
