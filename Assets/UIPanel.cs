using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIPanel : MonoBehaviour
{
    public void chongxing() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void tuichu() {
        Application.Quit();
    }
}
