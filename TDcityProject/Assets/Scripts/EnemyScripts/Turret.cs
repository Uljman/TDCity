using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public Transform Target;
    public Transform firePoint;
    public Transform turretPivot;
    public float rotOffset = 90;
    public int fireRate;
    public int hitsRemaining = 3; 
    float timeToFire = 0;

	// Use this for initialization
	void Start () {
        hitsRemaining = Random.Range(3, 5);
	}
	
	// Update is called once per frame
	void Update () {
        Aim();
        if (Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            Shoot();
        }
    }
    void Aim()
    {
        if (Target)
        {
            Vector3 difference = Target.transform.position - turretPivot.transform.position;
            difference.Normalize();     // normalizing the vector. Meaning that all the sum of the vector will be equal to 1

            float rotY = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
            turretPivot.transform.rotation = Quaternion.Euler(0, rotY + rotOffset , 0);
        }
        else Debug.Log("Player does not exist");
    }


    void Shoot()
    {
        GameObject _Bullet = Instantiate(Resources.Load("EnemyProjectile", typeof(GameObject)), firePoint.position, Quaternion.identity) as GameObject;
        _Bullet.GetComponent<Rigidbody>().AddForce(turretPivot.transform.forward * 300);
        Destroy(_Bullet, 3f);

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        if(other.tag == "Player")
        {
            if (hitsRemaining > 0) hitsRemaining--;
            else Destroy(gameObject);


        }
    }
}
