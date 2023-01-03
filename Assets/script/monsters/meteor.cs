using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour
{
    public Rigidbody2D rbody;
    //public Transform Point;

    private float timer;

    void Start(){
        Debug.Log("Meteor is woki");
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timer > 0.4f)
            Destroy(this.gameObject);
    }

    // 碰撞检测
    void OnCollisionEnter2D(Collision2D other){
        Destroy(this.gameObject);
    }
}
