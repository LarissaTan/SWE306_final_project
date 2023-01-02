using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medicine : MonoBehaviour
{
    public AudioClip audio;

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

            audioSource.volume = 1f;
            audioSource.PlayOneShot(audio);

            Destroy(gameObject);
        }
    }
}
