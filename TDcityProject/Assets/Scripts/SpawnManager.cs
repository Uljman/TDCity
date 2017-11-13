using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {


    GameObject levelCont;
	// Use this for initialization
	void Start () {
        levelCont = GameObject.Find("LevelContainer");
        SpawnPlayer();
        SpawnTank();
	}
	

    void SpawnPlayer()
    {
        if (levelCont.transform.Find("PlayerSpawnPointContainer"))
        {
            Transform playerC = levelCont.transform.Find("PlayerSpawnPointContainer");
            GameObject player =  Instantiate(Resources.Load("Player", typeof(GameObject)), playerC.GetChild(0).position, Quaternion.identity) as GameObject;
            player.name = "Player";
            Instantiate(Resources.Load(PlayerStats.pStats.playerModel, typeof(GameObject)), playerC.GetChild(0).position, Quaternion.identity, player.transform).name = "Model";
        }
    }

    void SpawnTank()
    {
        if (levelCont.transform.Find("TankSpawnPointContainer"))
        {
            int tankC = levelCont.transform.Find("TankSpawnPointContainer").childCount; // count of tank spawn points

            for (int i = 0; i < tankC; i++)
            {
                Instantiate(Resources.Load("Tank", typeof(GameObject)), levelCont.transform.Find("TankSpawnPointContainer").GetChild(i).position, Quaternion.identity);
            }
        }
    }

}
