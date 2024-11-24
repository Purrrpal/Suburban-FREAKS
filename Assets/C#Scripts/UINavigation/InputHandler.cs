using System.Collections;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    //==========================================================
    //This script hnadles the control input from the 1st player.
    //==========================================================

    //References
    #region References

    [Header("References")]

    [Header("References")]
    public InputMode currentInputMode;
    public enum InputMode { Mouse, Controller, Keyboard }

    private Vector3 lastMousePosition;

    #endregion

    //Start Method
    #region Start()

    void Start()
    {
        lastMousePosition = Input.mousePosition;
        currentInputMode = InputMode.Mouse;
    }

    #endregion

    //Update Method
    #region Update()

    void Update()
    {
        currentInputMode = ProcessInputMode();

        // toggle cursor visibility based on the current input mode
        if (currentInputMode == InputMode.Mouse)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {

            Cursor.visible = false;
            StartCoroutine(MouseEnableLockState());
        }
    }

    #endregion

    //ProcessInputMode Method
    #region ProcessInputMode()

    public InputMode ProcessInputMode()
    {
        const float joystickDeadzone = 0.1f;

        // Detect mouse movement
        if (Input.mousePosition != lastMousePosition)
        {
            lastMousePosition = Input.mousePosition;
            return InputMode.Mouse;
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
            else if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                return InputMode.Mouse;
            }
            else if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.JoystickButton10) || Input.GetKeyDown(KeyCode.JoystickButton11)
                || Input.GetKeyDown(KeyCode.JoystickButton12) || Input.GetKeyDown(KeyCode.JoystickButton13) || Input.GetKeyDown(KeyCode.JoystickButton13) || Input.GetKeyDown(KeyCode.JoystickButton14)
                || Input.GetKeyDown(KeyCode.JoystickButton15) || Input.GetKeyDown(KeyCode.JoystickButton16) || Input.GetKeyDown(KeyCode.JoystickButton17) || Input.GetKeyDown(KeyCode.JoystickButton18)
                || Input.GetKeyDown(KeyCode.JoystickButton19) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.JoystickButton3) || Input.GetKeyDown(KeyCode.JoystickButton4)
                || Input.GetKeyDown(KeyCode.JoystickButton5) || Input.GetKeyDown(KeyCode.JoystickButton6) || Input.GetKeyDown(KeyCode.JoystickButton7) || Input.GetKeyDown(KeyCode.JoystickButton8)
                || Input.GetKeyDown(KeyCode.JoystickButton9))
            {
                return InputMode.Controller;
            }

        }
        
        if (Input.GetAxis("Joystick Horizontal") > joystickDeadzone || Mathf.Abs(Input.GetAxis("Joystick Vertical")) > joystickDeadzone)
        {
            return InputMode.Controller;
        }

        // Return the last known input mode if no new input detected
        return currentInputMode;
    }

    #endregion

    //MouseEnableLockState Coroutine
    #region MouseEnableLockState()
    private IEnumerator MouseEnableLockState()
    {
        yield return new WaitForEndOfFrame();
        Cursor.lockState = CursorLockMode.Locked;
    }

    #endregion

    //==========================================================
}
