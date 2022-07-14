using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX = 0f;
    private float timeAttack;
    private float invincibilityFrameCount; 
    public float startTimeAttack; 
    public int hpMax = 4;
    public int currentHp;
    public Transform atkPos;
    public float atkRange;
    public LayerMask whatIsEnemies;
    public LayerMask whatIsDestructible;
    public int playerDamage;
    public int score;
    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyhearts;
    [SerializeField] private bool isDamageable;
    [SerializeField] private bool canMove; 
    [SerializeField] private LayerMask jumpableGround;
    //[SerializeField] private LayerMask Destructible;
    [SerializeField] private float moveSpeed ;
    [SerializeField] private float jumpForce ;
    private float DeathMenuCount;
    [SerializeField] private AudioSource jumpsound;
    [SerializeField] private AudioSource kicksound;

    private enum MovementState { idle, running, jumping, falling }

    

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        currentHp = hpMax;
       

        isDamageable = true;
        canMove = true;
        invincibilityFrameCount = 3;
        DeathMenuCount = 4;
    }

    // Update is called once per frame
    private void Update()
    {
        if (canMove)
        {
            dirX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {

                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                Jump();  
            }

            UpdateAnimationState();

            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("keypressed");
                anim.SetTrigger("Attack");
                Kick();
                
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(atkPos.position, atkRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    Debug.Log("ATK " + enemiesToDamage[i].gameObject.name);
                    Enemy enemy = enemiesToDamage[i].GetComponent<Enemy>();
                    if ( enemy != null )
                    {
                        enemy.TakeDamage(playerDamage);
                    }
                }

                enemiesToDamage = Physics2D.OverlapCircleAll(atkPos.position, atkRange, whatIsDestructible);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<DestructibleCrate>().PlayDestruction();
                    Debug.Log("DESTROY");

                }
            }
        }
       /* if(currentHp > hpMax)
        {
            currentHp = hpMax; 
        }
        for (int g = 0; g < hearts.Length ; g++)
        {
            if(g < hpMax)
            {
                hearts[g].sprite = fullHearts; 
            }
            else
            {
                hearts[g].sprite = emptyhearts; 
            }
            if(g < currentHp)
            {
                hearts[g].enabled = true; 
            } else
            {
                hearts[g].enabled = false; 
            }
        }*/


        if(transform.position.y < -10)
        {
            GameOver(); 
        }
           
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround + whatIsDestructible);
    }




    public void TakeDamage(int damage)
    {
        if (isDamageable == true)
        {
            
            currentHp -= damage;
            //isDamageable = true; 
            if (currentHp <= 0)
            {
                currentHp = 0;
                isDamageable = false;
                StartCoroutine(DeathMenu());
                
            }
            else
            {
                StartCoroutine(InvincibilityFrame());
            }
        }
    }

    private int AddHp(int hpToAdd,int Hp)
    {

        return Hp;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(atkPos.position, atkRange);
         
    }
    public void AddScore(int amout)
    {
        score += amout;
        //ui.SetScoreText(score); 
    }


    IEnumerator InvincibilityFrame()
    {
        isDamageable = false; 
        anim.SetBool("Flickering", true);
        yield return new WaitForSeconds(invincibilityFrameCount);
        anim.SetBool("Flickering", false);
        //serve numero di secondi da contare prima di far spuntare il menu
        isDamageable = true;
    }

    IEnumerator DeathMenu()
    {
        canMove = false;
        anim.SetTrigger("Dead");

        yield return new WaitForSeconds(DeathMenuCount);

        SceneManager.LoadScene("DEATH");
    }



    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    private void Jump()
    {
        jumpsound.Play();
    }
    private void Kick()
    {
        kicksound.Play();
    }
}



