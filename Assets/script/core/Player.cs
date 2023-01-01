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
        CharacterInit();
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

    public void CharacterInit()
    {
        if (globe.characterIndex == 0)
        {
            animator.runtimeAnimatorController =
                Resources.Load("animation/Player") as
                RuntimeAnimatorController;
        }

        if (globe.characterIndex == 1)
        {
            // 切换animator
            animator.runtimeAnimatorController =
                Resources.Load("animation/idle_side") as
                RuntimeAnimatorController;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bandage")
        {
            if(HP != 100 && HP + 1 <= 100){
                HP++;
                slider.value = HP;
                collision.gameObject.SetActive(false);
            }
        }

        if (collision.gameObject.tag == "kit")
        {
            if(HP != 100 && HP + 5 <= 100){
                HP+=5;
                slider.value = HP;
                collision.gameObject.SetActive(false);
            }

            if(HP != 100 && HP + 5 > 100){
                HP = 100;
                slider.value = HP;
                collision.gameObject.SetActive(false);
            }
        }
    }

}
