using UnityEngine;

public class Player2 : MonoBehaviour
{
    //=================================
    //This script handles the player 2.
    //=================================

    //References
    #region References
    [Header("References")]

    [Header("Scripts")]
    public Damage dmg;

    [Header("Floats")]
    public float speed;

    [Header("Ints")]
    public int health = 100;

    private Animator anim;

    #endregion

    //Start Method
    #region Start()

    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    #endregion

    //Update Method
    #region Update()

    private void Update()
    {
        if(health == 0)
        {
            Debug.Log("First Round Finished");
        }
    }

    #endregion

    //TakeDamage Method
    #region TakeDamage()

    public void TakeDamage(int damage)
    {
        dmg.CalculateRandomDamageWithCritical();
    }

    #endregion

    //=================================
}
