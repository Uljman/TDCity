using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

    
    LevelManager lM;

    // Use this for initialization
    void Start()
    {
        
        lM = GameObject.Find("CameraHolder").GetComponent<LevelManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (PlayerStats.pStats.shieldCount == 0) {
                PlayerStats.pStats.playerDead = true;
                Destroy(gameObject);
                lM.EndTheGame();
            }
            else if (PlayerStats.pStats.shieldCount > 0)
            {
                PlayerStats.pStats.shieldCount--;

                Destroy(transform.Find("ShieldContainer").GetChild(0).gameObject);
            }
            //TODO:call endgame function from level manager

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            if (PlayerStats.pStats.shieldCount == 0)
            {
                PlayerStats.pStats.playerDead = true;
                Destroy(gameObject);
                lM.EndTheGame();
            }
            else if (PlayerStats.pStats.shieldCount > 0)
            {
                PlayerStats.pStats.shieldCount--;
                Destroy(transform.Find("ShieldContainer").GetChild(0).gameObject);
            }
        }
    }
    IEnumerator Inicialization()
    {
        yield return new WaitForSeconds(0.1f);

    }
}
