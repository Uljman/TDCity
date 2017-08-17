using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {


	void Awake () {
        Spawn();
	}
	
	
    void Spawn()
    {             
         Instantiate(Resources.Load("Tank",typeof (GameObject)), transform.position, Quaternion.identity);
        LevelManager.lMan.EnemyCount++;
    }
}
