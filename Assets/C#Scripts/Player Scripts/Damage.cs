using UnityEngine;

public class Damage : MonoBehaviour
{
    //====================================================================================
    //This script manages and calculates the damage that will inflict on the other player. 
    //====================================================================================

    //References
    #region References

    [Header("References")]

    [Header("Scripts")]
    public Player2 playerTwo;

    [Header("Floats")]
    public float critChance = 0.2f;  // Critical hit chance (e.g., 0.2 = 20% chance)
    public float critMultiplier = 1.5f; // Critical hit multiplier (e.g., 1.5 = 150% damage)

    [Header("Ints")]
    public int minDamage = 10;       
    public int maxDamage = 20;

    #endregion

    //CalculateRandomDamageWithCritical Method
    #region CalculateRandomDamageWithCritical()

    // Function to calculate random damage with a chance of critical hit
    public int CalculateRandomDamageWithCritical()
    {
        // Generate a random damage value between minDamage and maxDamage (inclusive)
        int damage = Random.Range(minDamage, maxDamage + 1);

        // Check if a critical hit occurs
        if (Random.value < critChance) // Random.value generates a float between 0 and 1
        {
            damage = Mathf.RoundToInt(damage * critMultiplier); // Apply critical hit multiplier
            Debug.Log("Critical hit! Damage: " + damage);
        }
        else
        {
            Debug.Log("Normal hit. Damage: " + damage);
        }

        playerTwo.health -= damage;
        Debug.Log("Remaining Health: " + playerTwo.health);

        return damage;

    }

    #endregion

    //====================================================================================
}
