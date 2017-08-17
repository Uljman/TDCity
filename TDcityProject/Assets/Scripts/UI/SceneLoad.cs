using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour {

    public void LoadScene(int index)
    {
        PlayerStats.pStats.Load();
        SceneManager.LoadScene(index);
    }
    public void ReloadScene()
     {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void  LoadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;

    }
    public void Exit()
    {
        Application.Quit();

    }
}
