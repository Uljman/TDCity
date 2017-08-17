using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    public Transform fPoint;
    public float rotationOffset = 90;
    public float fireRate = 5f;
   // public string WeaponType = "BasicAutofire";
    float timeToFire = 0;
    // Use this for initialization
    void Start () {
        //  GameObject.Find("Player/Robot/FirePoint");
        StartCoroutine(Init());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if (Input.GetButton("Fire1") && Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            Shoot();
        }
    }


    void Shoot()
    {
       GameObject _Bullet = Instantiate(Resources.Load("Bullet",typeof( GameObject)),fPoint.position,Quaternion.identity) as GameObject;
        // _Bullet.transform.rotation = transform.rotation;
        _Bullet.transform.rotation = Quaternion.Euler(90, transform.rotation.y*100, 0);
        _Bullet.GetComponent<Rigidbody>().AddForce(new Vector3(transform.forward.x,0,transform.forward.z)*500);
        Debug.Log(transform.rotation.y);
        Destroy(_Bullet,2f);
        
    }
    void Shoot(string _WeaponType)
    {
        
        switch (_WeaponType)
        {
            case "BasicAutofire":
                GameObject _Bullet = Instantiate(Resources.Load("Bullet", typeof(GameObject)), fPoint.position, Quaternion.identity) as GameObject;
                _Bullet.transform.rotation = Quaternion.Euler(90, transform.rotation.y * 100, 0);
                _Bullet.GetComponent<Rigidbody>().AddForce(new Vector3(transform.forward.x, 0, transform.forward.z) * 500);               
                Destroy(_Bullet, 2f);

                break;
            case "Arc":


                break;
            case "DoubleBarrelAutofire":


                break;
        }
     }
    IEnumerator Init()
    {
        yield return new WaitForSeconds(0.2f);
        GameObject.Find("Player/Robot/FirePoint");
    }
}
