using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIPanel : MonoBehaviour
{
    public void chongxing() {
        //重新
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void tuichu() {
        //退出游戏
        Application.Quit();
    }
}
