using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    public Transform teleportLocation;
    public Transform currentLocation;
    public Transform player;
    public bool inPortal;

    public GameObject tip;
    private float timer = 0f;
    private bool isTip = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        currentLocation = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (inPortal)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentLocation.position = teleportLocation.position;
            }
        }

        if(isTip && Time.time - timer > 1){
            tip.SetActive(false);
        }
    }


    void OnTriggerEnter2D(Collider2D myCollider2d)
    {
        Debug.Log(myCollider2d.gameObject.name);
        if (myCollider2d.gameObject.CompareTag("Player"))
        {
            tip.SetActive(true);
            inPortal = true;
        }
    }

    void OnTriggerExit2D(Collider2D myCollider2d)
    {
        Debug.Log(myCollider2d.gameObject.name);
        if (myCollider2d.gameObject.CompareTag("Player"))
        {
            inPortal = false;
            // GameObject portalDialog = GameObject.Find("Canvas (1)").transform.Find("PortalDialog").gameObject;
            // portalDialog.SetActive(false);
        }
    }
}
