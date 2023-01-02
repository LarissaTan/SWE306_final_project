using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public int AttackNum = 20; 

    public float Speed;

    public Transform leftPoint;
    public Transform rightPoint;
    public float leftX;

    public float rightX;
    public bool isleft = true;

    public CapsuleCollider2D ca;


    public bool isEnter; 
    public int HP = 100;
    public float AttackTime = 1f;  

    public Player player; 
  
    void Start()
    {
        leftX = leftPoint.position.x;
        rightX = rightPoint.position.x;
    }
    public void Detah() {
        Destroy(gameObject);
    }

    void Update()
    {
        AttackTime += Time .deltaTime; 
        if (isEnter) {
            if (AttackTime >= 1) {
                AttackTime = 0; 
                anim.SetTrigger("attack");
            }
        }


        if (HP <= 0) 
        {
            anim.SetTrigger("Die");
            Invoke("Detah", 2f);  

        }
        else
        {
            if (isEnter==false) {
                if (isleft)
                {
                    //        rb.velocity = new Vector2(-Speed*Time.deltaTime, rb.velocity.y);
                    transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);

                    if (transform.position.x < leftX)
                    {
                        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
                        isleft = false;
                    }
                }
                else
                {
                    transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
                    if (transform.position.x > rightX)
                    {
                        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
                        isleft = true;
                    }
                }
            }
        }
    }


    public void Attack() {
        player.TakeDame(10); 
     }

    public void TakeValue(int i) {
        HP -= i; 
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().rig.AddForce(Vector2.left * 250); 
            collision.gameObject.GetComponent<Player>().rig.AddForce(Vector2.up * 250);  
        }
    }
}
