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

    public Image attackImage;
    public Image aImage;
    public Image sImage;
    public Image wImage;
    public Image dImage;
    public Image spaceImage;
    public float attackCoolDownTime = 0.5f;
    public float attackCoolDownTimeCount = 0.0f;

    public Image dashImage;
    public bool isDashing = false;
    public float dashCoolDownTime = 2.0f;
    public float dashCoolDownTimeCount = 0.0f;
    public float dashEffectCoolDownTime = 0.02f;
    public float dashEffectCoolDownTimeCount = 0.0f;

    private float coolTimeKey = 0.05f;
    private float timer_a = 0.0f;
    private float timer_s = 0.0f;
    private float timer_w = 0.0f;
    private float timer_d = 0.0f;
    private float timer_space = 0.0f;

    public int dashImageCount = 20;


    public GameObject[] endpanel;


    void Start()
    {
        CharacterInit();
        hunSlider.value = hudun;
        slider.value = HP;
    }


    void Update()
    {
        if (attackCoolDownTimeCount > 0.0f)
        {
            attackCoolDownTimeCount -= Time.deltaTime;
            attackImage.fillAmount = attackCoolDownTimeCount / attackCoolDownTime;
        }

        if (dashCoolDownTimeCount > 0.0f)
        {
            dashCoolDownTimeCount -= Time.deltaTime;
            dashImage.fillAmount = dashCoolDownTimeCount / dashCoolDownTime;
        } 

        if (dashEffectCoolDownTimeCount > 0.0f)
        {
            dashEffectCoolDownTimeCount -= Time.deltaTime;
        }

        if (timer_a > 0.0f)
        {
            timer_a -= Time.deltaTime;
            aImage.fillAmount = timer_a / coolTimeKey;
        }

        if (timer_s > 0.0f)
        {
            timer_s -= Time.deltaTime;
            sImage.fillAmount = timer_s / coolTimeKey;
        }

        if (timer_w > 0.0f)
        {
            timer_w -= Time.deltaTime;
            wImage.fillAmount = timer_w / coolTimeKey;
        }

        if (timer_d > 0.0f)
        {
            timer_d -= Time.deltaTime;
            dImage.fillAmount = timer_d / coolTimeKey;
        }

        if (timer_space > 0.0f)
        {
            timer_space -= Time.deltaTime;
            spaceImage.fillAmount = timer_space / coolTimeKey;
        }

        if (dashCoolDownTimeCount <= 0.0f)
        {
            isDashing = false;
        }

        if (dashEffectCoolDownTimeCount <= 0.0f)
        {
            isDashing = false;
        }


        // 如果按下J键
        if (Input.GetKeyDown("j"))
        {
            if (attackCoolDownTimeCount <= 0.0f)
            {
                // attackImage fillamount = 1
                attackImage.fillAmount = 1;
                attackCoolDownTimeCount = attackCoolDownTime;
            }
        }

        // 如果按下s键
        if (Input.GetKeyDown("s"))
        {
            sImage.fillAmount = 1;
            timer_s = coolTimeKey;
	    }

        // 如果按下a键
        if (Input.GetKeyDown("a"))
        {
            aImage.fillAmount = 1;
            timer_a = coolTimeKey;
        }

        if (Input.GetKeyDown("w"))
        {
            wImage.fillAmount = 1;
            timer_w = coolTimeKey;
        }

        if (Input.GetKeyDown("d"))
        {
            dImage.fillAmount = 1;
            timer_d = coolTimeKey;
        }

        if (Input.GetKeyDown("space"))
        {
            spaceImage.fillAmount = 1;
            timer_space = coolTimeKey;
        }

        if (Input.GetKeyDown("k"))
        {
            if (dashCoolDownTimeCount <= 0.0f)
            {
                dashImage.fillAmount = 1;
                dashCoolDownTimeCount = dashCoolDownTime;
                dashEffectCoolDownTimeCount = dashEffectCoolDownTime;

                // dash
                float moveHorizontal = Input.GetAxis("Horizontal");
                rig.velocity = new Vector2(moveHorizontal * 1700.0f * Time.fixedDeltaTime, 0);
                // Pool.instance.GetFromPool();
                isDashing = true;
            }
        }

        if (isDashing)
        {
            Pool.instance.GetFromPool();
            dashImageCount--;
        }

        if (Input.GetKeyUp("j"))
        {
            Debug.Log("attack");
            attackImage.fillAmount = 0;
        }

        if (Input.GetKeyUp("k"))
        {
            Debug.Log("dash");
            dashImage.fillAmount = 0;
        }

        if (Input.GetKeyUp("s"))
        {
            Debug.Log("s");
            dashImage.fillAmount = 0;
        }

        if (Input.GetKeyUp("a"))
        {
            Debug.Log("a");
            dashImage.fillAmount = 0;
        }

        if (Input.GetKeyUp("w"))
        {
            Debug.Log("w");
            dashImage.fillAmount = 0;
        }

        if (Input.GetKeyUp("d"))
        {
            Debug.Log("d");
            dashImage.fillAmount = 0;
        }

        if (Input.GetKeyUp("space"))
        {
            Debug.Log("space");
            dashImage.fillAmount = 0;
        }



        jump += Time.deltaTime;
        attack += Time.deltaTime;
        if (Input.GetKeyDown("space"))
        {

            if (jump >= 1)
            {
                jump = 0;
                rig.AddForce(Vector2.up * 1000);
            }
        }

        if (Input.GetKeyDown("j"))
        {
            if (attack >= 0.6f)
            {

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
            transform.localScale = new Vector3(1, 1, 1);

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


    public void TakeDame(int i)
    {
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

        if (HP <= 0)
        {
            endpanel[0].SetActive(true);
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "End")
        {
            endpanel[1].SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bandage")
        {
            if (HP != 100 && HP + 1 <= 100)
            {
                HP++;
                slider.value = HP;
                collision.gameObject.SetActive(false);
            }
        }

        if (collision.gameObject.tag == "kit")
        {
            if (HP != 100 && HP + 5 <= 100)
            {
                HP += 5;
                slider.value = HP;
                collision.gameObject.SetActive(false);
            }

            if (HP != 100 && HP + 5 > 100)
            {
                HP = 100;
                slider.value = HP;
                collision.gameObject.SetActive(false);
            }
        }

           // monster
        if (collision.gameObject.tag == "skeleton")
        {
            hurtAnimation();
            skeletion tmp;
            tmp = collision.gameObject.GetComponent<skeletion>();
            TakeDame(10);
        }
    }

    private void hurtAnimation(){

    }


}
