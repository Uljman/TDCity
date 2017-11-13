using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelParametrs : MonoBehaviour {

    public Texture2D map;

    public ColorToPrefab[] colorMappings;
    GameObject levelContainer;

    // Use this for initialization
    void Awake()
    {

        // GenerateLevel();
       
    }

    public void GenerateLevel()
    {
        levelContainer = new GameObject("LevelContainer");
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                //PictureToLevel(x, y);
                GenerateTile(x, y);
               
            }
        }
       
    }

    public void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);
        
        if (pixelColor.a == 0)
        {
            // The pixel is transparrent. Let's ignore it!
            return;
        }

        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                
                Vector3 position = new Vector3(x * colorMapping.prefab.transform.localScale.x, 0, y * colorMapping.prefab.transform.localScale.z);
                Instantiate(colorMapping.prefab, position, Quaternion.identity,levelContainer.transform).name = colorMapping.prefab.name;
            }
        }
    }
    public void SortLevel()
    {
        GameObject[] levElArr = new GameObject[levelContainer.transform.childCount];// array of all elements under level container
        GameObject Container;
       for (int i=0;i < levelContainer.transform.childCount;i++)
        {
            levElArr[i] = levelContainer.transform.GetChild(i).gameObject;          
        }

       foreach(GameObject gO in levElArr)
        {          
           if(!levelContainer.transform.Find(gO.name+ "Container"))
            {
                Container = new GameObject(gO.name + "Container");              
                Container.transform.parent = levelContainer.transform;              
                Container.name = gO.name + "Container";
                gO.transform.parent = Container.transform;
  
            }
            else
            {
                gO.transform.parent = levelContainer.transform.Find(gO.name + "Container");
            }
        }
    }
}
