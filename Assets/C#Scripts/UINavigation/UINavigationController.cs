using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UINavigationController : MonoBehaviour
{
    //======================================
    //This script manages the UI navigation.
    //======================================

    //References
    #region References
    [Header("References")]

    [Header("Scripts")]
    public InputHandler input;

    [Header("GameObjects")]
    public GameObject firstButton;

    private GameObject lastSelectedButton;

    #endregion

    //Update Method
    #region Update()

    void Update()
    {
        // Get the current selected object from the EventSystem
        GameObject currentSelected = EventSystem.current.currentSelectedGameObject;

        // Handle keyboard or controller navigation
        if (input.currentInputMode == InputHandler.InputMode.Keyboard || input.currentInputMode == InputHandler.InputMode.Controller)
        {
            HandleKeyboardInput();
        }

        // Handle mouse hover or mouse input
        if (input.currentInputMode == InputHandler.InputMode.Mouse)
        {
            HandleMouseInput(currentSelected);
        }
    }

    #endregion

    //HandleKeyboardInput Method
    #region HandleKeyboardInput()

    public void HandleKeyboardInput()
    {

        // Check if no object is currently selected in the EventSystem
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            // If nothing is selected, set the default button
            EventSystem.current.SetSelectedGameObject(firstButton);

            // Force update to ensure the selection is acknowledged
            firstButton.GetComponent<Button>().OnSelect(null);
        }
    }

    #endregion

    //HandleMouseInput Method
    #region HandleMouseInput()

    private void HandleMouseInput(GameObject currentSelected)
    {
        // Reset keyboard selection when using the mouse
        if (currentSelected != null)
        {
            ResetLastButtonState();
            lastSelectedButton = null; // Clear keyboard selection
            EventSystem.current.SetSelectedGameObject(null); // Clear EventSystem selection
        }
    }

    #endregion

    //ResetLastButtonState Method
    #region ResetLastButtonState()

    private void ResetLastButtonState()
    {
        if (lastSelectedButton != null)
        {
            Button button = lastSelectedButton.GetComponent<Button>();
            if (button != null)
            {
                // Reset button to default state
                var colors = button.colors;
                colors.normalColor = Color.white; // Default button color
                button.colors = colors;
            }
        }
    }

    #endregion

    //======================================
}

