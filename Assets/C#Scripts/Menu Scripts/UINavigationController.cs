using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UINavigationController : MonoBehaviour
{
    //
    //
    //

    //References
    #region References

    public InputHandler input;
    public SceneLoaderAndButtons scene;

    private GameObject lastSelectedButton;

    private bool isUsingMouse = false; // Tracks if mouse is being used

    #endregion

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

    public void HandleKeyboardInput()
    {
        isUsingMouse = false; // We're now using the keyboard

        // Check if no object is currently selected in the EventSystem
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            // If nothing is selected, set the default button
            EventSystem.current.SetSelectedGameObject(scene.mainMenuFirstButton);

            // Force update to ensure the selection is acknowledged
            scene.mainMenuFirstButton.GetComponent<Button>().OnSelect(null);
        }
    }

    private void HandleMouseInput(GameObject currentSelected)
    {
        isUsingMouse = true; // We're now using the mouse

        // Reset keyboard selection when using the mouse
        if (currentSelected != null)
        {
            ResetLastButtonState();
            lastSelectedButton = null; // Clear keyboard selection
            EventSystem.current.SetSelectedGameObject(null); // Clear EventSystem selection
        }
    }

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
}

