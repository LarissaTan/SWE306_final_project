using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Enemy enemy;  //��õ�����ײ��



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player") {  //�����ײ������� 
            enemy.isEnter = true; //����ڵ�����ǰ
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {  //����뿪������� 
            enemy.isEnter = false ; //��Ҳ��ڵ�����ǰ
        }
    }
}
