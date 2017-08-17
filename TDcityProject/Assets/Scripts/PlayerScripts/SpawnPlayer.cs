using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour {

	// Use this for initialization
	void Awake() {
        Spawn();
	}
	
	void Spawn()
    {
        GameObject player = Instantiate(Resources.Load("Player", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
        player.name ="Player";
        Instantiate(Resources.Load(PlayerStats.pStats.playerModel, typeof(GameObject)), transform.position, Quaternion.identity,player.transform).name = "Model";
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
       
        Gizmos.DrawCube(transform.position, Vector3.one / 4);
    }
}
