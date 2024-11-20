using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public enum InputMode { Mouse, Controller, Keyboard }
    public InputMode currentInputMode;
    public SceneLoaderAndButtons sceneLoader;

    private Vector3 lastMousePosition;

    void Start()
    {
        lastMousePosition = Input.mousePosition;
        currentInputMode = InputMode.Controller;
    }

    void Update()
    {
        currentInputMode = ProcessInputMode();

        // Toggle cursor visibility based on the current input mode
        if (currentInputMode == InputMode.Mouse)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public InputMode ProcessInputMode()
    {
        if (!sceneLoader.mainMenu)
            return currentInputMode;

        // Detect mouse movement
        if (Input.mousePosition != lastMousePosition)
        {
            lastMousePosition = Input.mousePosition;
            return InputMode.Mouse;
        }

        // Detect controller input
        if (Input.GetJoystickNames().Length > 0)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                return InputMode.Controller;
            }

            // Check for any controller button press
            for (int i = 0; i <= 19; i++)
            {
                if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), $"JoystickButton{i}")))
                {
                    return InputMode.Controller;
                }
            }
        }

        // Detect keyboard input
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) ||
                Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) ||
                Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Return))
            {
                return InputMode.Keyboard;
            }
        }

        // If no input detected, return the last known mode
        return currentInputMode;
    }
}
