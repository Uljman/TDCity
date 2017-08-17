using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automatic : MonoBehaviour {

    public Transform fPoint;
    float fireRate;
    float timeToFire = 0;
   public  GameObject UIscripts;
    public bool mobile =  true;
    // Use this for initialization
    void Start()
    {
        
        StartCoroutine(Init());
        
        UIscripts = GameObject.Find("UI/UIScriptsHolder");
        fireRate = PlayerStats.pStats.fireRate;
        //transform.Find("Model/FirePoint");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.Find("Model")) transform.Find("Model/FirePoint");
        if (!mobile)
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
        else
        {
            if (UIscripts.GetComponent<MobileShooting>().State == 1 && Time.time > timeToFire)
            {

                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }


    void Shoot()
    {
        GameObject _Bullet = Instantiate(Resources.Load("Bullet", typeof(GameObject)), fPoint.position, Quaternion.identity) as GameObject;
        _Bullet.transform.rotation = transform.rotation;
        _Bullet.transform.Rotate(90,_Bullet.transform.rotation.y,_Bullet.transform.rotation.z);
        _Bullet.GetComponent<Rigidbody>().AddForce(new Vector3(transform.forward.x, 0, transform.forward.z) * 300);
        Debug.Log(transform.rotation.y);
        Destroy(_Bullet, 2f);

    }
    IEnumerator Init()
    {
        yield return new WaitForSeconds(0.1f);
        
       
        fPoint= transform.Find("Model/FirePoint");
        
    }
}
