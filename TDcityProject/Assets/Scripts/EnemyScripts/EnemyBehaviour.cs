using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public Transform towerPivot;
    public Transform Player;
    public Transform fPoint;
    public int bulletForce = 200;
    public float rotationOffset = 90;
    public float fireRate =5f;
    float timeToFire = 0;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Player == null)
        {
            Player = GameObject.Find("Player").transform;
        }
        else
        {
            Aim();
            if (Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
	}

    void Aim()
    {
        if (Player)
        {
            Vector3 difference = Player.transform.position - towerPivot.transform.position;
            difference.Normalize();     // normalizing the vector. Meaning that all the sum of the vector will be equal to 1

            float rotY = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
            towerPivot.transform.rotation = Quaternion.Euler(0, rotY + rotationOffset, 0);
        }
        else Debug.Log("Player does not exist");
    }

    void Shoot()
    {
        GameObject _Bullet = Instantiate(Resources.Load("EnemyProjectile", typeof(GameObject)), fPoint.position, Quaternion.identity) as GameObject;
        _Bullet.GetComponent<Rigidbody>().AddForce(towerPivot.transform.forward * bulletForce);
         Destroy(_Bullet,3f);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player") Destroy(gameObject);
    }
}
