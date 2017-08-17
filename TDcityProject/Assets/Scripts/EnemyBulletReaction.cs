using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletReaction : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
       
        
        Debug.Log(other);
                             
        if (other.tag == "Player")
        {
            GameObject effect = Instantiate(Resources.Load("BulletCollision", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
            if (other.transform.Find("ShieldHolder"))
            {
                if (other.transform.Find("ShieldHolder").childCount > 0) Destroy(other.transform.Find("ShieldHolder").GetChild(other.transform.Find("ShieldHolder").childCount - 1).gameObject);
                else Destroy(other.gameObject);
                Destroy(effect, 0.5f);
            }
            Destroy(effect, 0.5f);
        }        
        if(other.tag != "Enemy")
        {
            GameObject effect = Instantiate(Resources.Load("BulletCollision", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
            Destroy(effect, 0.5f);
        }
       
    }     

}
