using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int addNum = 1;
    public AudioClip small;
    public AudioClip large;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("players");
        audioSource = player.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            globe.coins += addNum;
            // gameObject.SetActive(false);
            if (addNum == 1)
            {
                audioSource.volume = 0.6f;
                audioSource.PlayOneShot(small);
            }

            else
            {
                audioSource.volume = 1f;
                audioSource.PlayOneShot(large);
            }

            Destroy(gameObject);
        }
    }
}
