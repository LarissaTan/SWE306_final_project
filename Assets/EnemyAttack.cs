using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Enemy enemy;  //获得敌人碰撞器



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player") {  //如果碰撞的是玩家 
            enemy.isEnter = true; //玩家在敌人面前
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {  //如果离开的是玩家 
            enemy.isEnter = false ; //玩家不在敌人面前
        }
    }
}
