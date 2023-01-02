using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    private Rigidbody2D rbody;
    private Collider2D myCollider;
    private float timer = 0;


    void Start(){
        Debug.Log("this is created");
        rbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timer > 2)
            Destroy(this.gameObject);

        if(this.gameObject.transform.localScale.x > 0)
            transform.Translate(Vector2.right*30f*Time.deltaTime);
        else
            transform.Translate(Vector2.left*30f*Time.deltaTime);
    }


    // 碰撞检测
    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("2333333");
        if(collision.gameObject.tag == "eye"){
            eye tmp = collision.gameObject.GetComponent<eye>();
            tmp.kill();
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "ghost"){
            ghost tmp = collision.gameObject.GetComponent<ghost>();
            tmp.kill();
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "snail"){
            Debug.Log("col enter 2d is working");
            snails tmp = collision.gameObject.GetComponent<snails>();
            tmp.kill();
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "skeleton"){
            skeletion tmp = collision.gameObject.GetComponent<skeletion>();
            tmp.kill();
            Destroy(this.gameObject);
        }
    }
}
