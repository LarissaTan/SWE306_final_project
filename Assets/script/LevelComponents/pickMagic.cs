using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickMagic : MonoBehaviour
{
    public AudioClip audio;

    private AudioSource audioSource;

    public bool isM1 = true;

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
            if(isM1)
                globe.m1 ++;
            else
                globe.m2 ++;

            audioSource.volume = 1f;
            audioSource.PlayOneShot(audio);

            Destroy(gameObject);
        }
    }
}
