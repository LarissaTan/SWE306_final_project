using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = transform.parent.GetComponent<AudioSource>();
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void changeVolumn(float volume)
    {
        audioSource.volume = volume;
    }
}
