using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIController : MonoBehaviour
{
    public TextMeshProUGUI coin_num;
    public GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        coin_num = coin.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        coin_num.text = globe.coins.ToString();
    }
}
