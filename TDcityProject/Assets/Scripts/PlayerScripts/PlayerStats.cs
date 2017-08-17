using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerStats : MonoBehaviour {

    public int  shieldCount = 0 ;
    public float Speed = 3;
    public int fireRate = 10;
    public int Money = 0;
    [HideInInspector]
    public bool playerDead = false;
    public String playerModel ;

    public static PlayerStats pStats ;

    void Awake()
    {
        
        if (pStats == null)
        {
            DontDestroyOnLoad(gameObject);
            playerModel = "Robot";
            pStats = this;
        }
        else if(pStats != this)
        {
            Destroy(gameObject);
        }

       pStats.Load();// loading saved parametrs in the beginning of scene
    }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/Save.dat", FileMode.OpenOrCreate);
        PlayerData data = new PlayerData();
        data.shieldCount = shieldCount;
        data.Speed = Speed;
        data.fireRate = fireRate;
        data.Money = Money;
        data.playerModel = playerModel;
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/Save.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Save.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            shieldCount = data.shieldCount;
            Speed = data.Speed;
            fireRate = data.fireRate;
            Money = data.Money;
            playerModel = data.playerModel;
            file.Close();
        }

    }

}




[Serializable]
class PlayerData
{
    public int shieldCount = 0;
    public float Speed = 3;
    public int fireRate = 10;
    public int Money = 0;
    public string playerModel; // not serializable ,string?
}