using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletion : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] protected Animator ani;
    public Collider2D col;
    public Transform leftpoint, rightpoint;
    public float Speed = 3.5f;

    private float timer = 0;
    private float Xleft, Xright;
    private float IsFaceRight = 0;
    private Rigidbody2D rb;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        ani.SetBool("IsDead", false);
        Xleft = leftpoint.position.x;
        Xright = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead ){
            ani.SetBool("IsDead", true);
            rb.velocity = new Vector2(0, rb.velocity.y);
            if(Time.time - timer > 0.4)
                Destroy(this.gameObject);
        }else{
            movement();
        }
    }

    void movement(){
        if(IsFaceRight == 1)
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            if(transform.position.x > Xright){
                transform.localScale = new Vector3(3f,3f,1);
                IsFaceRight = 0;
            }
        }else if (IsFaceRight != 1){
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
            if(transform.position.x < Xleft){
                transform.localScale = new Vector3(-3f,3f,1);
                IsFaceRight = 1;
            }
        }
    }

    public void kill(){
        isDead = true;
        timer = Time.time;
    }
}
