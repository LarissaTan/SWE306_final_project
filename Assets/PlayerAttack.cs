using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Enemy") {   //如果攻击到敌人
            collision.transform.GetComponent<Enemy>().TakeValue(20);   //扣除敌人20血量
        }
    }
}
