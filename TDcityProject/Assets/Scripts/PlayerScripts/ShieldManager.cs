using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour {

    public  Vector3 outerBelt,innerBelt;
    public int ShieldCount ;
    public GameObject Player;
    public float shieldRotationSpeed = 30f;
    
	// Use this for initialization
	void Start () {

       Player = transform.parent.gameObject;
       StartCoroutine( InstantiateShield());
       
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        RotateShields();
        transform.position = Player.transform.position;
    }

    void RotateShields()
    {
        if (transform.childCount > 0)
        {
            ShieldCount = PlayerStats.pStats.shieldCount;

            for (int i = 0; i < ShieldCount; i++)
            {
                if (i % 2 > 0) transform.GetChild(i).RotateAround(transform.position, Vector3.up, shieldRotationSpeed * Time.deltaTime);
                else transform.GetChild(i).RotateAround(transform.position, Vector3.up, -shieldRotationSpeed * Time.deltaTime);
            }
        }
    }

    IEnumerator InstantiateShield()
    {
        yield return new WaitForSeconds(0.2f); 
        Player = transform.parent.gameObject;
        
        ShieldCount = PlayerStats.pStats.shieldCount;
        outerBelt = transform.forward * 0.7f;
        innerBelt = transform.forward * 0.5f;
        for (int i = 0; i < ShieldCount; i++)
        {
           
            if (i % 2 > 0) 
            {
                Vector3 instPos = transform.position + Quaternion.Euler(0, 60 * i, 0) * outerBelt;
                Instantiate(Resources.Load("Shield", typeof(GameObject)),instPos,Quaternion.identity* Quaternion.Euler(0, 60 * i, 0), transform);
            }
            else
            {
                Vector3 instPos = transform.position + Quaternion.Euler(0, 60 * i, 0) * innerBelt;
                Instantiate(Resources.Load("Shield", typeof(GameObject)), instPos, Quaternion.identity * Quaternion.Euler(0, 60 * i, 0), transform);
            }
        }
        
    
    }
}
