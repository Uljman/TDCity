using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeStats : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject LevelSelect;
    public GameObject UpgradeMenu;
    public GameObject[] Models;
   
    public int index = 0;
    GameObject currentModel;
    GameObject pP;

    void Start()
    {
        UpgradeMenu.transform.Find("ShieldValue").GetComponent<Text>().text = "Shield: " + PlayerStats.pStats.shieldCount.ToString();
        UpgradeMenu.transform.Find("SpeedValue").GetComponent<Text>().text = "Speed: " + PlayerStats.pStats.Speed.ToString();
        UpgradeMenu.transform.Find("ModelName").GetComponent<Text>().text = PlayerStats.pStats.playerModel;
        pP = GameObject.Find("PlayerPreview");
        for (int i = 0; i < Models.Length; i++)
        {
            if (Models[i].name == PlayerStats.pStats.playerModel)
            {
                index = i; break;
            }
        }
        Spawn();

    }

    public void UpgradeShield(int value)
    {
        if (PlayerStats.pStats.Money  >= 0)
        {

            PlayerStats.pStats.shieldCount += value;
           //PlayerStats.pStats.Money;

           UpgradeMenu.transform.Find("ShieldValue").GetComponent<Text>().text = "Shield: " + PlayerStats.pStats.shieldCount.ToString();
            PlayerStats.pStats.Save();
        }
    }

    public void UpgradeSpeed(int value)
    {
        if(PlayerStats.pStats.Money >= 0)
        {
            PlayerStats.pStats.Speed += value;
           // PlayerStats.pStats.Money -= cost;
            UpgradeMenu.transform.Find("SpeedValue").GetComponent<Text>().text = "Speed: " + PlayerStats.pStats.Speed.ToString();
            PlayerStats.pStats.Save();
        }   
    }
    public void ChangeModel(int Next)
    {
        
            if (index + Next >= Models.Length) index = 0;
            else  if (index + Next < 0) index = Models.Length - 1;
            else index += Next;
            Debug.Log("Upgraded");
            
            GameObject clone = Instantiate(Models[index], pP.transform.position, Quaternion.identity, pP.transform) as GameObject;
            Destroy(currentModel);
            currentModel = clone;
            PlayerStats.pStats.playerModel = Models[index].name;
            UpgradeMenu.transform.Find("ModelName").GetComponent<Text>().text = PlayerStats.pStats.playerModel;
            PlayerStats.pStats.Save();
              
    }

    void Spawn()//for preview
    {
        Debug.Log(PlayerStats.pStats.playerModel);
        
       GameObject clone = Instantiate(Resources.Load(PlayerStats.pStats.playerModel, typeof(GameObject)), pP.transform.position, Quaternion.identity, pP.transform) as GameObject;
       currentModel = clone;
       PlayerStats.pStats.playerModel = Models[index].name;
       
    }
}
