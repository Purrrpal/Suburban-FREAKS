using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RandomCharacterSelectionButton : MonoBehaviour
{
    //===========================================================================
    //This script manages the functions of the random character selection button.
    //===========================================================================

    //References
    #region References

    [Header("References")]

    [Header("Sprites")]
    public Sprite[] originalSprites;
    public Sprite[] hoverSprites;
    public Sprite[] finalselectionImages;

    [Header("Floats")]
    public float hoverTime = 2f;
    public float hoverSpeed = 0.1f;

    [Header("Buttons")]
    public Button[] characterButtons;

    private bool isSelecting = false;

    #endregion

    //Start Method
    #region Start()

    void Start()
    {
        // Store the original sprites of the buttons.
        originalSprites = new Sprite[characterButtons.Length];
        for (int i = 0; i < characterButtons.Length; i++)
        {
            originalSprites[i] = characterButtons[i].GetComponent<Image>().sprite;
        }
    }

    #endregion

    //RandomSelection Method
    #region RandomSelection()

    public void RandomSelection()
    {
        if(!isSelecting)
        {
            StartCoroutine(RandomSelectionProcess());
            Debug.Log("Selecting Random Character...");
        }
    }

    #endregion

    //RandomSelectionProcess Coroutine
    #region RandomSelectionProcess()

    private IEnumerator RandomSelectionProcess()
    {
        isSelecting = true;

        float elapsedTime = 0f;
        int previousCharacter = -1;

        while (elapsedTime < hoverTime)
        {
            int randomCharacter = Random.Range(0, characterButtons.Length);

            if(randomCharacter != previousCharacter)
            {
                Debug.Log(characterButtons[randomCharacter].name);
                //TODO: Add sound!
                //TODO: Change Image of the button!
                HighlightButton(characterButtons[randomCharacter], randomCharacter);
                previousCharacter = randomCharacter;
            }
            yield return new WaitForSeconds(hoverSpeed);
            elapsedTime += hoverSpeed;

            ResetButtonAppearance(characterButtons[previousCharacter], previousCharacter);
        }

        int finalCharacter = Random.Range(0, characterButtons.Length);
        Debug.Log("Selected Character: " + characterButtons[finalCharacter].name);
        //TODO: Add sound for the final selection!
        //TODO: Add animation or a new image for the selected button!

        isSelecting = false;

    }

    #endregion

    private void HighlightButton(Button button, int index)
    {
        // Change the button's image to the hover sprite.
        button.GetComponent<Image>().sprite = hoverSprites[index];
    }

    private void ResetButtonAppearance(Button button, int index)
    {
        // Reset the button's image to its original sprite.
        button.GetComponent<Image>().sprite = originalSprites[index];
    }

    //===========================================================================
}
