using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
//------------------------------------------------------------------------------
//This script is a player script for a 2D retro fighting game and its not finished.
//TODO: Implement animations and combos.
//------------------------------------------------------------------------------

public class Player_Script : MonoBehaviour
{   
    //Declaring the variables for the movement of the player.

    private float horizontal;
    private float speed = 8f;
    private float jumpHeight = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] InputActionReference lightAttack, midAttack, heavyAttack , crouching, itemAttack;

    //declaring the variables for the attacks.

    public Transform attackPos;
    public float attackRange;
    public float attackCooldown = 1f;
    public int lightDamage;
    public int midDamage;
    public int heavyDamage;
    public int itemDamage;

    public LayerMask enemy;
    public LayerMask player2;

    //Declaring the variables for the health.

    public int health;

    //Declaring the variables for the dash.

    public bool canDash = true;
    public bool isDashing;

    public bool canAttack = true;
    public bool isAttacking;

    private float dashingDistance = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    private float attackingTime = 0.2f;
    //private float attackingCooldown = 1f;

    //Declaring the variables for the Duck
    public SpriteRenderer spriteRenderer;
    public Sprite Standing;
    public Sprite Ducking;

    public BoxCollider2D boxCollider;

    public Vector2 StandingSize;
    public Vector2 DuckingSize;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.size = StandingSize;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Standing;

        StandingSize = boxCollider.size;
    }

    void Update()
    {
        if (isDashing)
        {
            return;
        }

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y);
        
        FlipSprite();

    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }
    //Declaring what is IsGrounded.

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //Creating a way to flip the sprite of the player that match the way that the player faces.

    private void FlipSprite()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    //Creating a horizontal movement method.

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        //TODO: Implement Waliking animation.
    }

    //Creating a Jump method.

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && IsGrounded())//Checking if the jump button is pressed and the player is on the ground.
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);//And if the above is true then the jump is performed.
            //TODO: Implement Jump animation.
        }
    }
    
    //Creating a Dash method.

    public void Dashing(InputAction.CallbackContext context)
    {
        if (canDash == true)
        {
            StartCoroutine(Dash());
        }
    }

    public void Duck(InputAction.CallbackContext context)
    {
        spriteRenderer.sprite = Ducking;
        boxCollider.size = DuckingSize;
    }

    public void UnDuck(InputAction.CallbackContext context)
    {
        spriteRenderer.sprite = Standing;
        boxCollider.size = StandingSize;
    }
    //=======================================================
    //Creating an OnEnable and OnDisable so that the player will hit ones when the button is pressed.

    private void OnEnable()
    {
        lightAttack.action.performed += LightAttackPressed;
        midAttack.action.performed += MidAttackPressed;
        heavyAttack.action.performed += HeavyAttackPressed;
        itemAttack.action.performed += ItemAttackPressed;
        crouching.action.performed += Duck;

    }

    private void OnDisable()
    {
        lightAttack.action.performed -= LightAttackPressed;
        midAttack.action.performed -= MidAttackPressed;
        heavyAttack.action.performed -= HeavyAttackPressed;
        itemAttack.action.performed -= ItemAttackPressed;
        crouching.action.performed += UnDuck;
    }
    //=====================================================
    //Normal attacks.(Not yet finished)
    //TODO: ADD COOLDOWN

    public void LightAttackPressed(InputAction.CallbackContext context)
    {
        if(canAttack)
        {
            StartCoroutine(Attack());
            Collider2D[] dmgEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, player2);
            foreach (Collider2D enemy in dmgEnemies)
            {
                enemy.GetComponent<Player2>().TakeDamage(lightDamage);
                //TODO: Implement Light Attack animation.
                Debug.Log("light" + enemy.name);
            }
        }
        
    }

    public void MidAttackPressed(InputAction.CallbackContext context)
    {
        if(canAttack)
        {
            StartCoroutine(Attack());
            Collider2D[] dmgEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, player2);
            foreach (Collider2D enemy in dmgEnemies)
            {
                enemy.GetComponent<Player2>().TakeDamage(midDamage);
                //TODO: Implement Mid Attack animation.
                Debug.Log("mid" + enemy.name);
            }
        }
        
    }

    public void HeavyAttackPressed(InputAction.CallbackContext context)
    {
        if(canAttack)
        {
            StartCoroutine(Attack());
            Collider2D[] dmgEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, player2);
            foreach (Collider2D enemy in dmgEnemies)
            {
                enemy.GetComponent<Player2>().TakeDamage(heavyDamage);
                //TODO: Implement Heavy Attack animation.
                Debug.Log("heavy" + enemy.name);
            }
        }
        
    }

    public void ItemAttackPressed(InputAction.CallbackContext context)
    {
        if(canAttack)
        {
            StartCoroutine(Attack());
            Collider2D[] dmgEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, player2);
            foreach (Collider2D enemy in dmgEnemies)
            {
                enemy.GetComponent<Player2>().TakeDamage(itemDamage);
                //TODO: Implement Item Attack animation.
                Debug.Log("item" + enemy.name);
            }
        }
        
    }

    //TODO: Ultimate...
    //=====================================================================
    //Creating a method that will allow the player to take damage from the enemy.

    //public void TakeDamage(int damage)
    //{
    //    health -= damage;
    //}

    //Creating Gizmos for the attack range.

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    //TODO: Combo Attacks...

    
    //Dash with cooldown.
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(transform.localScale.x * dashingDistance, 0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private IEnumerator Attack()
    {
        canAttack = false;
        isAttacking = true;
        yield return new WaitForSeconds(attackingTime);
        yield return new WaitForSeconds(attackCooldown);

        isAttacking = false;
        canAttack = true;
    }

}
