using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snails : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] protected Animator ani;
    public Collider2D col;
    public Transform leftpoint, rightpoint;
    public float Speed = 3;

    private float timer = 0;
    private float Xleft, Xright;
    private float IsFaceRight = 0;
    private Rigidbody2D rb;

    private bool isDead = false;
    private bool isWalk = false;
    private bool isAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        ani.SetBool("IsDead", false);
        ani.SetBool("IsWalk", false);
        ani.SetBool("IsAttack", false);
        Xleft = leftpoint.position.x;
        Xright = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        if(isDead){
            ani.SetBool("IsDead", true);
            rb.velocity = new Vector2(0, rb.velocity.y);
            if(Time.time - timer > 1.02)
                Destroy(this.gameObject);
        }else{
            if(!isWalk && !isAttack && Time.time - timer > 0.5){
            isWalk = true;
            ani.SetBool("IsWalk", true);
            timer = Time.time;
        }

        if(isWalk)  movement();

        if(isWalk && Time.time - timer > 1){
            rb.velocity = new Vector2(0, rb.velocity.y);
            isAttack = true;
            isWalk = false;
            ani.SetBool("IsAttack", true);
            ani.SetBool("IsWalk", false);
            timer = Time.time;
        }

        if(isAttack && Time.time - timer > 0.2){
            rb.velocity = new Vector2(0, rb.velocity.y);
            isAttack = false;
            ani.SetBool("IsAttack", false);
            timer = Time.time;
        }
        }
    }

    void movement(){
        if(IsFaceRight == 1)
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            if(transform.position.x > Xright){
                transform.localScale = new Vector3(2.5f,2.5f,1);
                IsFaceRight = 0;
            }
        }else if (IsFaceRight != 1){
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
            if(transform.position.x < Xleft){
                transform.localScale = new Vector3(-2.5f,2.5f,1);
                IsFaceRight = 1;
            }
        }
    }

    public int damage(){
        if(isAttack)
            return 30;
        else
            return 10;
    }

    public void kill(){
        isDead = true;
        timer = Time.time;
    }
}
