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
            button.text = "Wow, thank you!";
            Text.text = "Considering that you have been away from home for a long time. So I arranged some hints around the screen.";
        }
        
        if (index == 2) {
            button.text = "What can I do with it?";
            Text.text = "Be careful, these wizards are cunning. They have arranged a lot of little monsters nearby.";
        }

        if (index == 3) {
            button.text = "But this hammer sucks.";
            Text.text = "You don't need worry too much, I believe you can kill with one blow.";
        }

        if (index == 4) {
            button.text = "That`s great!";
            Text.text = "Oh my boy, watch out, there are magic learning points on the way. You can get the magic you need there.";
        }

        if (index == 5) {
            button.text = "I will save the town!";
            Text.text = "Come on boy, the future of our hometown depends on you.";
            Invoke("desDialog", 2f);
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
