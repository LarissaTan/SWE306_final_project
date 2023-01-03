using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LayerLab
{
    public class Panel : MonoBehaviour
    {
        [SerializeField] private GameObject[] otherPanels;
        public GameObject error;

        public void OnEnable()
        {
            for (int i = 0; i < otherPanels.Length; i++) otherPanels[i].SetActive(true);
        }

        public void OnDisable()
        {
            for (int i = 0; i < otherPanels.Length; i++) otherPanels[i].SetActive(false);
        }

        public void OpenShop()
        {
            Time.timeScale = 0;
            transform.Find("Popup_shop").gameObject.SetActive(true);
        }
        public void CloseShop()
        {
            Time.timeScale = 1;
            transform.Find("Popup_shop").gameObject.SetActive(false);
        }
        public void OpenSetting()
        {
            Time.timeScale = 0;
            transform.Find("Popup_Settings").gameObject.SetActive(true);
        }
        public void CloseSetting()
        {
            Time.timeScale = 1;
            transform.Find("Popup_Settings").gameObject.SetActive(false);
        }

        public void returnMenu()
        {
            SceneManager.LoadScene("menu");
        }

        public void buyBandage(){
            if(globe.coins < 1){
                error.SetActive(true);
                globe.error_status = true;
            }else{
                globe.coins --;
                if(Player.HP != 100)
                    Player.HP +=10;
            }
        }
    }
}