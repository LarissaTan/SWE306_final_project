using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    private Rigidbody2D rbody;
    private float timer = 0;


    void Start(){
        Debug.Log("this is created");
        rbody = GetComponent<Rigidbody2D>();
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
    void OnCollisionEnter2D(Collision2D other){
        Destroy(this.gameObject);
    }
}
