using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    //[HideInInspector]
    public int EnemyCount = 0;
    PlayerStats pStats;
    GameObject defeatScreen,victoryScreen;

    public static LevelManager lMan;
    // Use this for initialization
    
    void Awake() {
        
       
        lMan = this;
        Cursor.visible = false;
       
        defeatScreen = GameObject.Find("DefeatScreen");
        victoryScreen = GameObject.Find("VictoryScreen");
        defeatScreen.SetActive(false);
        victoryScreen.SetActive(false);
        // Time.timeScale = 0;
    }

    public void EndTheGame()
    {
       
        if (PlayerStats.pStats.playerDead)
        {
            Debug.Log("Dead!");
            defeatScreen.SetActive(true) ;
        }
        
        if (EnemyCount == 0 )
        {

            victoryScreen.SetActive(true);
            
        }
        Cursor.visible = true;
        Time.timeScale = 0;

    }

   

   
}
