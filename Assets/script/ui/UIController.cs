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
        coin_num.text = globe.coins.ToString();
        m1_txt.text = globe.m1.ToString();
        m2_txt.text = globe.m2.ToString();
    }
}
