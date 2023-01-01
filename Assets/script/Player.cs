using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public Animator animator;   
    public Rigidbody2D rig;
    public Slider hunSlider; 
    public Slider slider;  

    public int HP = 100;
    public int hudun = 100; 

    public float jump;  
    public float attack; 

    public GameObject[] endpanel; 


    void Start()
    {
        hunSlider.value = hudun; 
        slider.value = HP; 
    }


    void Update()
    {
        jump += Time.deltaTime; 
        attack += Time.deltaTime; 
        if (Input.GetKeyDown("k")) { 

            if (jump >=1) {
                jump = 0;
                rig.AddForce(Vector2.up * 1000); 
            }
        }

        if (Input.GetKeyDown("j")) {
            if (attack >=0.6f) {

                attack = 0; 
                animator.SetTrigger("attack"); 
            }
        }
       
        if (Input.GetKey("a") || Input.GetKey("d"))
        {

            animator.SetBool("Walk", true);   
        }
        else
        {
            animator.SetBool("Walk", false);  
        }

        if (Input.GetKey("a"))
        {
            transform.position += new Vector3(-0.03f, 0, 0);
            transform.localScale = new Vector3(1,1,1);

        }

        if (Input.GetKey("d"))
        {
            transform.position += new Vector3(0.03f, 0, 0);  
            transform.localScale = new Vector3(-1, 1, 1); 
        }

    }


    public void TakeDame(int i) {
        if (hudun >= i)  
        {
            hudun -= i;
            hunSlider.value = hudun;  
            slider.value = HP;
        }
        else
        {
            HP -= i;  
            slider.value = HP;  
        }

        if (HP<=0) {
            endpanel[0].SetActive(true); 
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "End") {
            endpanel[1].SetActive(true);  
        }
    }

}
