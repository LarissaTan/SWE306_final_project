using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class startLines : MonoBehaviour
{

    public TextMeshProUGUI button;
    public TextMeshProUGUI Text;
    public GameObject speech;
    public GameObject btn;

    private int index = 0;

    void Start()
    {
        Text = speech.GetComponentInChildren<TextMeshProUGUI>();
        button = btn.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        if (index == 1) {
            button.text = "I have to say it`s super cool to have this kind of holiday !!!";
            Text.text = "Ya, that`s right. Día de Muertos is actually spanish. In English, you can call it as Day of the dead. And it is a holiday celebrated in Mexico, during which people remember and honor their deceased loved ones.";
        }
        
        if (index == 2) {
            button.text = "OMG, anything that I have help you?";
            Text.text = "Hahahaha, yeah~~ It is not easy to have a fulfilling and happy Day of the Dead. Now there are a bunch of monsters from nowhere filling the forest, blocking my way to meet my gramma.";
        }

        if (index == 3) {
            button.text = "Oh~ Got it. But...emmm....kill the monsters with this scythe?";
            Text.text = "If you really want to help me, you can use your scythe to kill those monsters and lead me to my grandma's grave! ! ! I really need your help.";
        }

        if (index == 4) {
            button.text = "Seriously?!?!?! That`s great!";
            Text.text = "Are you worried that this weapon is not easy to use? Hahahaha, don't worry, my friend. This forest holds magic that my grandma used to collect. If you find them, use them to help you defeat monsters.";
        }

        if (index == 5) {
            button.text = "I will!";
            Text.text = "On this journey, I will be with you. When necessary, I'll show up to give you some hints or something. Hope it can help you. By the way, there are still some traps on the road, please be careful! ! ! good luck~~~";
        }

        if(index == 6){
            desDialog();
        }
    }

    public void Next(){
        index++;
    }

    void desDialog(){
        Destroy(this.gameObject);
        Time.timeScale = 1f;
    }
}
