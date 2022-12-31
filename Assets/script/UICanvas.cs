using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UICanvas : MonoBehaviour
{
    public GameObject RolePane;

    public void ShowRole() {
        RolePane.SetActive(true);
    }

    public void HideRole()
    {
        RolePane.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
    }


    public void OnPlayerGame( )
    {
        SceneManager.LoadScene(1);
    }
    public void ToPlayerGame()
    {
        SceneManager.LoadScene(2);
    }
}
