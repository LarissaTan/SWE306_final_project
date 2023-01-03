using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public int Speed = 5;
    public Transform leftpoint, rightpoint;

    [Header("Components")]
    [SerializeField] protected Animator animator;
    public Collider2D myCollider;

    public GameObject l;
    public Transform lp1, lp2, lp3, lp4;
    private float timer = 0;
    private float tmp_timer = 0;
    private Rigidbody2D rb;

    private bool isAttack = false;
    public bool isAngry = false;
    private bool isDie = false;
    private bool isHurt = false;
    public bool isRun = false;
    public bool isIdle = true;

    private float Xleft, Xright;
    private float IsFaceRight = 0;

    private int status = 0;
    public HealthBar bar;

    [Header("audio")]
    public AudioSource music;
    public AudioClip skill;
    public AudioClip hurt;

    void Start()
    {
        timer = Time.time;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        bar = GetComponent<HealthBar>();
        Xleft = leftpoint.position.x;
        Xright = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
        animator.SetBool("IsRun", false);
        animator.SetBool("IsHurt", false);
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsDead", false);
        animator.SetBool("IsIdle", true);
        animator.SetBool("IsAngry", false);
        animator.SetBool("IsSkill", false);

        music = gameObject.AddComponent<AudioSource>();
        skill = Resources.Load<AudioClip>("music/skill");
        hurt = Resources.Load<AudioClip>("music/boss_hurt");
    }

    // Update is called once per frame
    void Update()
    {
        if(isRun)   Movement();
        else        rb.velocity = new Vector2(0, 0);

        if(isHurt){
            if(Time.time - timer > 0.03){
                isHurt = false;
                animator.SetBool("IsHurt", false);
                timer = Time.time;
            }

            if(bar.healthLevel() == 0.0f){
                if(Time.time - timer > 1.02)
                Destroy(this.gameObject);
            }
        }else{
            if(isIdle && Time.time - timer > 0.1){
                isIdle = false;
                animator.SetBool("IsIdle", false);
                switch (status){
                    case 0:
                        isRun =  true;
                        animator.SetBool("IsRun", true);
                        break;
                    case 1:
                        isAttack = true;
                        animator.SetBool("IsAttack", true);
                        break;
                    default:
                        break;
                }
                status++;
                timer = Time.time;
                if(status == 2)   status = 0;
            }
        }

        action();


        
    }

    void light(){
        music.clip = skill;
        music.Play();

        //lp1.transform.position = new Vector3(lp1.transform.position.x + 73, lp1.transform.position.y - 0.38f, lp1.transform.position.z);
        Instantiate(l, lp1.position, lp1.rotation);
        Instantiate(l, lp2.position, lp2.rotation);
        Instantiate(l, lp3.position, lp3.rotation);
        Instantiate(l, lp4.position, lp4.rotation);
    }

    void Movement(){
        if(IsFaceRight == 1)
        {
            rb.velocity = new Vector2(Speed, 0);
            if(transform.position.x > Xright){
                transform.localScale = new Vector3(-2,2,1);
                IsFaceRight = 0;
            }
        }else if (IsFaceRight != 1){
            rb.velocity = new Vector2(-Speed, 0);
            if(transform.position.x < Xleft){
                transform.localScale = new Vector3(2,2,1);
                IsFaceRight = 1;
            }
        }
        bar.turn(transform.position.x, transform.position.y + 1.5f);
    }

    void action(){
        if(isRun && Time.time - timer > 3){
            isRun = false;
            animator.SetBool("IsRun", false);
            isIdle = true;
            animator.SetBool("IsIdle", true);
            timer = Time.time;
        }

        if(isAttack && Time.time - timer > 1.1){
            isAttack = false;
            animator.SetBool("IsAttack", false);
            isIdle = true;
            animator.SetBool("IsIdle", true);
            timer = Time.time;
        }

        if(isAngry && isAttack && Time.time - timer > 0.7) light();
    }

    public int damage(){
        if(isAttack)
            return 40;
        else
            return 20;
    }

    public void getHurt(int i){
        isAngry = true;
        isHurt = true;
        animator.SetBool("IsHurt", true);
        animator.SetBool("IsAngry", true);
        timer = Time.time;
        bar.damage(i);
    }

}
