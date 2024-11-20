using UnityEngine;

public class Player2 : MonoBehaviour
{
    public Damage dmg;
    public int health = 100;
    public float speed;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if(health == 0)
        {
            Debug.Log("First Round Finished");
        }
    }

    public void TakeDamage(int damage)
    {
        dmg.CalculateRandomDamageWithCritical();
    }
}
