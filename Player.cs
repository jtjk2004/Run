using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Joystick joystick;
    [SerializeField]
    public int health, dashcount;
    Transform trans;
    public Transform pos;
    public Transform pos2;

    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    private float movementX;
    private float movementY;
    [SerializeField]
    public Rigidbody2D myBody;
    public SpriteRenderer sr;
    private Animator anim;
    public AudioSource teehee, coinaudio, runaudio, jumpaudio, dropaudio, dashaudio, bigswingaudio;
    public bool isGrounded = true;
    private string WALK_ANIMATION = "Run";
    private string JUMP_ANIMATION = "Jump";
    private string DROP_ANIMATION = "Down";
    //private string GROUND_TAG = "ground";
    private string BULLET_TAG = "bullet";
    private string COIN_TAG = "coin";
    public int coins = 0, damage;
    private string ATTACKED_ANIMATION = "attacked";
    private bool _attack, _attack2, attacked, cooldown;
    public bool checktack,end,powerup,shield,top,dashs,ultitack;
    public GameObject attack, victory, lose, ultiss, cameras;
    // Start is called before the first frame update
    private void /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        trans = GetComponent<Transform>();
    }
    // playerdamage, ultidamage, ulticount - how much hit to charge
    void Start()
    {
        powerup = false;
        _attack = false;
        dashs = false;
        _attack = false;
        attacked = false;
        checktack = false;
        ultitack = false;
        end = true;
        top = false;
        cooldown = false;
        damage = PlayerPrefs.GetInt("playerdamage");
        dashcount = 0;
        Application.targetFrameRate = 60;
        anim.SetBool("dash",false);
        anim.SetBool("ulti",false);
        teehee.volume = (float)((float)PlayerPrefs.GetInt("uivolume")/100f)*teehee.volume;
        coinaudio.volume = (float)((float)PlayerPrefs.GetInt("uivolume")/100f)*coinaudio.volume;
        runaudio.volume = (float)((float)PlayerPrefs.GetInt("uivolume")/100f)*runaudio.volume;
        jumpaudio.volume = (float)((float)PlayerPrefs.GetInt("uivolume")/100f)*jumpaudio.volume;
        dropaudio.volume = (float)((float)PlayerPrefs.GetInt("uivolume")/100f)*dropaudio.volume;
        dashaudio.volume = (float)((float)PlayerPrefs.GetInt("uivolume")/100f)*dashaudio.volume;
        bigswingaudio.volume = (float)((float)PlayerPrefs.GetInt("uivolume")/100f)*bigswingaudio.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(attacked==false)
        {   
            PlayerMoveKeyboard();
            AnimatePlayer();
        }
        else
        {
            StartCoroutine(Attacked());
        }
        if(health <= 0)
        {
            lose.SetActive(true);
        }
        dashes();
    }

     /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if(attacked==false)
        {   
            PlayerJump();
        }
    }

    void PlayerMoveKeyboard()
    {
        //movementX = Input.GetAxisRaw("Horizontal");
        joystick = FindObjectOfType<Joystick>();
        if(joystick.Horizontal >= .2f)
        {
            movementX = joystick.Horizontal;
            if(isGrounded && !attacked)
            {
                runaudio.enabled = true;
            }
            else
            {
                runaudio.enabled = false;
            }
        }
        else if(joystick.Horizontal <= -.2f)
        {
            movementX = joystick.Horizontal; 
            if(isGrounded && !attacked)
            {
                runaudio.enabled = true;
            }
            else
            {
                runaudio.enabled = false;
            }
        }
        else
        {
            movementX = 0f;
            runaudio.enabled = false;
        }
        //if(isGrounded==false && myBody.velocity.y==0 &&joystick.Horizontal < .2f&&joystick.Horizontal > -.2f)
        //{
            //isGrounded = true;
        //}
        if(isGrounded)
        {
            if(movementY < .5f)
            {
                dropaudio.enabled = true;
            }
        }
        else
        {
            dropaudio.enabled = false;
        }
        transform.position += new Vector3(movementX,0f,0f)*Time.deltaTime*moveForce;
    }

    void PlayerJump()
    {
        joystick = FindObjectOfType<Joystick>();
        
        movementY = joystick.Vertical;
        if (movementY >= .5f && isGrounded)
        {
            if(!top)
            {
            jumpaudio.enabled = false;
            myBody.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
            isGrounded = false;
            jumpaudio.enabled = true;
            jumpaudio.time = 0.1f;
            }
        }
        anim.SetFloat(DROP_ANIMATION,myBody.velocity.y);
        if(myBody.velocity.y<-6)
        {
            isGrounded = false;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(BULLET_TAG))
        {
            if(!shield)
            {
                attacked = true;
                anim.SetBool(ATTACKED_ANIMATION,true);
                health = health-1;
            }
        }
        if(collision.gameObject.CompareTag("bullet1"))
        {
            if(!shield)
            {
                attacked = true;
                anim.SetBool(ATTACKED_ANIMATION,true);
                health = health-2;
            }
        }
        if(collision.gameObject.CompareTag("power"))
        {
            powerup = true;
        }
        if(collision.gameObject.CompareTag("portal"))
        {
            victory.SetActive(true);
        }
    } 
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == COIN_TAG)
        {
            coinaudio.enabled = false;
            coins ++;
            coinaudio.enabled = true;
            coinaudio.time = 0.1f;
        }
        if(other.tag == "bigcoin")
        {
            coinaudio.enabled = false;
            coins += 3;
            coinaudio.enabled = true;
            coinaudio.time = 0.1f;
        }
    }
       
    
    void AnimatePlayer()
    {
        if (movementX>0)
        {
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX = false;
        }
        else if (movementX<0)
        {
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION,false);
        }
        if(isGrounded)
        {
            anim.SetBool(JUMP_ANIMATION,false);
        }
        else
        {
            anim.SetBool(JUMP_ANIMATION,true);

        }
    }

    public void PlayAnimation() 
    {
        if(ultitack==false)
        {
        if(attacked==false){ 
        if(_attack==true)
        {
            StartCoroutine(Settings());
            _attack2 = true;
        }
        else
        {
            teehee.enabled = false;
            _attack = true;
            GetComponent<Animator>().SetBool("Attack",true);
            teehee.enabled = true;
            checktack = true;
            StartCoroutine(Setting());
        }}}
    }
    IEnumerator Setting()
    {
        yield return new WaitForSeconds(0.2f);
        GetComponent<Animator>().SetBool("Attack",false);
        checktack = false;
        attacks();
        yield return new WaitForSeconds(0.4f);
        _attack = false;
    }
    IEnumerator Settings()
    {
        if(_attack2 == false)
        {   
            yield return new WaitUntil(()=> _attack==false);
            teehee.enabled = false;
            GetComponent<Animator>().SetBool("Attack",true);
            teehee.enabled = true;
            checktack = true;
            StartCoroutine(Setting());
            _attack2 = false;
            _attack = true;
        }
    }
    IEnumerator Attacked()
    {
        yield return new WaitForSeconds(0.0f);
        anim.SetBool(ATTACKED_ANIMATION,false);
        
        if(myBody.velocity.y>1)
        {
            myBody.AddForce(new Vector2(0f,-.1f),ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(0.4f);
        attacked = false;
    }
    void attacks()
    {
        damage = PlayerPrefs.GetInt("playerdamage");
        if(sr.flipX==false)
        {   
            GameObject newBullet = Instantiate(attack,pos.position,Quaternion.identity);
        }
        else
        {
            GameObject newBullet = Instantiate(attack,pos2.position,Quaternion.identity);
        }    
    }

    public void dash()
    { 
        if(cooldown==false)
        {
            dashaudio.enabled = false;
            dashs = true;
            cooldown = true;
            anim.SetBool("dash",true);
            anim.SetBool("dashes",true);
            dashaudio.enabled = true;
            StartCoroutine(cooldownow());
        }
    }

    void dashes()
    {  
        if(dashs)
        {
            if(dashcount == 2)
            {
                anim.SetBool("dash",false);
            }
            if(sr.flipX)
            {
                transform.position = Vector2.MoveTowards(transform.position,new Vector3(transform.position.x-8,transform.position.y,0),0.11f);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position,new Vector3(transform.position.x+8,transform.position.y,0),0.11f);
            }
            dashcount++;
            if(dashcount > 15)
            {
                dashs = false;
                dashcount = 0;
                anim.SetBool("dashes",false);
            }
        }
    }

    IEnumerator cooldownow()
    {
        yield return new WaitForSeconds(2f);
        cooldown = false;
    }

    public void ultis()
    {
        if(ultiss.GetComponent<ulti>().curcount==ultiss.GetComponent<ulti>().ulticount)
        {
            ultiss.GetComponent<ulti>().curcount = 0;
            anim.SetBool("ulti",true);
            StartCoroutine(ultiwait());
        }
    }

    IEnumerator ultiwait()
    {
        ultitack = true;
        cameras.GetComponent<Camera>().fieldOfView = 50f;
        yield return new WaitForSeconds(0.05f);
        bigswingaudio.enabled = false;
        anim.SetBool("ulti",false);
        bigswingaudio.enabled = true;
        yield return new WaitForSeconds(0.35f);
        damage = PlayerPrefs.GetInt("ultidamage");
        if(sr.flipX==false)
        {   
            GameObject newBullet = Instantiate(attack,pos.position,Quaternion.identity);
        }
        else
        {
            GameObject newBullet = Instantiate(attack,pos2.position,Quaternion.identity);
        } 
        yield return new WaitForSeconds(0.12f);
        ultitack = false;
        cameras.GetComponent<Camera>().GetComponent<Camera>().fieldOfView = 60f;
        damage = PlayerPrefs.GetInt("playerdamage");
    }
}
