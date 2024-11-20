using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class CharacterSelectionButton : MonoBehaviour
{
    //=================================================================================
    //This script manages the character selection buttons and many more related things.
    //=================================================================================

    //Variables
    #region Variables

    [Header("References")]
    public Image buttonImage;  // Reference to the Image component on the button

    [Header("Sprites")]
    public List<Sprite> buttonSprites;  // List of sprites to switch between on hover

    [Header("GameObjects")]
    public List<GameObject> nameSprites;
    public List<GameObject> characterSprites;

    [Header("Strings")]
    public string playerSelected;
    #endregion

    //Dictionary
    #region Dictionary

    // Dictionary to map button names to the index of the sprite to keep active
    private Dictionary<string, int> buttonNameToActiveIndex = new Dictionary<string, int>()
    {
        { "VoXButton", 0 },
        { "ZaraButton", 1 },
        { "ZoeButton", 2 },
        { "CarlButton", 3 },
        { "PamButton", 4 },
        { "TylerButton", 5 },
        { "BRADButton", 6 },
        { "KevinButton", 7 },
        { "RandomButton", 8 }
        //TODO: Add 2 more characters
    };

    #endregion

    //OnHoverEnter Method
    #region OnHoverEnter()

    public void OnHoverEnter()
    {

        if (buttonNameToActiveIndex.TryGetValue(this.gameObject.name, out int targetIndex))
        {
            // Disable all nameSprites except for the one at targetIndex
            DisableAllExcept(targetIndex);
        }
        else
        {
            Debug.LogWarning("Button name not found in dictionary: " + this.gameObject.name);
        }
       
        //TODO: Add sound!

        //Enable the name and character sprite every time that the button it's hovered
        if (this.gameObject.name == "VoXButton") { nameSprites[0].SetActive(true); characterSprites[0].SetActive(true);  }
        else if(this.gameObject.name == "ZaraButton") { nameSprites[1].SetActive(true); characterSprites[1].SetActive(true); }
        else if(this.gameObject.name == "ZoeButton") { nameSprites[2].SetActive(true); characterSprites[2].SetActive(true); }
        else if(this.gameObject.name == "CarlButton") { nameSprites[3].SetActive(true); characterSprites[3].SetActive(true); }
        else if(this.gameObject.name == "PamButton") { nameSprites[4].SetActive(true); characterSprites[4].SetActive(true); }
        else if(this.gameObject.name == "TaylerButton") { nameSprites[5].SetActive(true); characterSprites[5].SetActive(true); }
        else if(this.gameObject.name == "BradButton") { nameSprites[6].SetActive(true); characterSprites[6].SetActive(true); }
        else if(this.gameObject.name == "KevinButton") { nameSprites[7].SetActive(true); characterSprites[7].SetActive(true); }
        else if(this.gameObject.name == "RandomButton") { nameSprites[8].SetActive(true); characterSprites[8].SetActive(true); }
    }

    #endregion

    //DisableAllExcept Method
    #region DisableAllExcept()

    private void DisableAllExcept(int targetIndex)
    {
        for (int i = 0; i < nameSprites.Count; i++)
        {
            // Disable the sprite if it's not the target index
            nameSprites[i].SetActive(i == targetIndex);
        }
        //TODO: Disable all except the current player sprite!
        for (int i =0; i< characterSprites.Count; i++)
        {
            characterSprites[i].SetActive(i == targetIndex);
        }
    }

    #endregion

    //SelecterCharacter Method
    #region SelectedCharacter()

    public void SelectedCharacter()
    {
        if (this.gameObject.name == "VoXButton") { playerSelected = "VoX"; }
        else if (this.gameObject.name == "ZaraButton") {playerSelected = "Zara"; }
        else if (this.gameObject.name == "ZoeButton") { playerSelected = "Zoe"; }
        else if (this.gameObject.name == "CarlButton") { playerSelected = "Carl"; }
        else if (this.gameObject.name == "PamButton") { playerSelected = "Pam"; }
        else if (this.gameObject.name == "BRADButton") { playerSelected = "BRAD"; }
        else if (this.gameObject.name == "TylerButton") { playerSelected = "Tyler"; }
        else if (this.gameObject.name == "KevinButton") { playerSelected = "Kevin"; }
        else { playerSelected = "Random"; }

        Debug.Log(playerSelected);
        //Extra character 1 if(this.name == "VoXButton") { playerSelected = "VoX";}
        //Extra character 2 if(this.name == "VoXButton") { playerSelected = "VoX";}
    }

    #endregion

    //=================================================================================
}
