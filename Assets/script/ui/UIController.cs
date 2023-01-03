using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIController : MonoBehaviour
{
    public TextMeshProUGUI coin_num;
    public GameObject coin;

    public TextMeshProUGUI m1_txt;
    public GameObject m1;

    public TextMeshProUGUI m2_txt;
    public GameObject m2;

    public GameObject error;
    private bool check = false;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        coin_num = coin.GetComponentInChildren<TextMeshProUGUI>();
        m1_txt = m1.GetComponentInChildren<TextMeshProUGUI>();
        m2_txt = m2.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(globe.error_status && !check){
            Debug.Log("here is working");
            timer = Time.time;
            check = true;
        }

        if(Time.time - timer > 2){
            check = false;
            globe.error_status = false;
            error.SetActive(false);
        }

        coin_num.text = globe.coins.ToString();
        m1_txt.text = globe.m1.ToString();
        m2_txt.text = globe.m2.ToString();
    }
}
