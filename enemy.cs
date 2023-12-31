using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3[] positions;
    public int health;
    private int index, reduce;
    private SpriteRenderer src; 
    private float oldPosition;
    public GameObject Player, bullet, bigcoin, ulti;
    public Transform shootPos;
    public Transform shootPos2;
    private Rigidbody2D myBody;
    private Animator anim;
    [SerializeField]
    public bool attack, wait, die,a, bgate;
    private string IDLE_ANIMATION = "EnemyIdle";
    private string ATTACK_ANIMATION = "EnemyAttack";
    private string DIE_ANIMATION = "Enemydie";
    private string WAIT_ANIMATION = "Wait";
    public float x,y;
    float dist;
    // Start is called before the first frame update
    
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        src = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        oldPosition = transform.position.x;
        reduce = 0;
        anim.SetBool(IDLE_ANIMATION,false);
        anim.SetBool(ATTACK_ANIMATION,false);
        anim.SetBool(WAIT_ANIMATION,true);
        attack = false;
        wait = true;
        die = false;
        a = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(die==false){
            dist = Vector2.Distance(transform.position,Player.transform.position);
            Move();
            Flip();
            if(health<=0)
            {
                StartCoroutine(Die());
            }
            //if(Vector2.Distance(Player.transform.position,transform.position)<9)
            //{
            //    check();
            //}
            if(((transform.position.y-Player.transform.position.y)*(transform.position.y-Player.transform.position.y))<4 && reduce>17 && dist<5)
            {
                check();
            }
            if(reduce<18)
            {
                reduce++;
            }
            else
            {
                reduce = 0;
            }
        }
    }

    void Move()
    {
        if(wait)
        {
        if(dist>=5) 
        {
             transform.position = Vector2.MoveTowards(transform.position,positions[index],Time.deltaTime*speed);
            if(transform.position==positions[index])
            {
                if(index==positions.Length-1)
                {
                index=0;
            }
                else
                {
                    index++;
                }
            }
            anim.SetBool(ATTACK_ANIMATION,false);
        } 
        else if(((transform.position.y-Player.transform.position.y)*(transform.position.y-Player.transform.position.y))<4 && bgate==true)
        { 
            StartCoroutine(Wait());
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,positions[index],Time.deltaTime*speed);
            if(transform.position==positions[index])
            {
                if(index==positions.Length-1)
                {
                index=0;
            }
                else
                {
                    index++;
                }
            }
            anim.SetBool(ATTACK_ANIMATION,false);
        }
        }
    }
    void Flip()
    {
       if(attack==false)
       {
            if (transform.position.x > oldPosition)
            {
                src.flipX = false;
                oldPosition = transform.position.x;
            }
            if (transform.position.x < oldPosition)
            {
                src.flipX = true;
                oldPosition = transform.position.x;
            }
       }
    } 
    
    IEnumerator Wait()
    {
        if(a)
        {
            a = false;
            anim.SetBool(WAIT_ANIMATION,false);
            anim.SetBool(ATTACK_ANIMATION,true);
            wait = false;
            StartCoroutine(shoot());
            yield return new WaitForSeconds(0.2f);
            anim.SetBool(ATTACK_ANIMATION,false);
            yield return new WaitForSeconds(2.5f);
            anim.SetBool(WAIT_ANIMATION,true);
            wait = true;
            yield return new WaitForSeconds(0.2f);
            a = true;
        }
    }
    IEnumerator shoot()
    {
        attack = true;
        if (transform.position.x > Player.transform.position.x)
        {
            src.flipX = true;
        }
        if (transform.position.x < Player.transform.position.x)
        {
            src.flipX = false;
        }
        yield return new WaitForSeconds(0.25f);
        if(src.flipX==true)
        {   
            GameObject newBullet = Instantiate(bullet,shootPos2.position,Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-x,y);
        }
        else
        {
            GameObject newBullet = Instantiate(bullet,shootPos.position,Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(x,y);
        }  
        attack = false;  
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(die==false)
        {
            if(collision.tag == "Attack")
            {
                    check();
                    if(bgate)
                    {
                        health -= Player.GetComponent<Player>().damage;
                        if(ulti.GetComponent<ulti>().curcount<ulti.GetComponent<ulti>().ulticount)
                        {    
                            ulti.GetComponent<ulti>().curcount++;
                        }
                    }
            }
        }
    } 
    IEnumerator Die()
    {
        die = true;
        anim.SetBool(DIE_ANIMATION,true);
        yield return new WaitForSeconds(0.625f);
        GameObject bigcoins = Instantiate(bigcoin,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

    void check()
    {
        RaycastHit2D hit2D = Physics2D.Linecast(transform.position,Player.transform.position);
        if(hit2D.collider != null)
        {
            if(hit2D.transform.tag == "Player")
            {
                bgate = true;
            }
            else
            {
                bgate = false;
            }           
        }
        Debug.Log(hit2D.transform.tag);
    }
}
