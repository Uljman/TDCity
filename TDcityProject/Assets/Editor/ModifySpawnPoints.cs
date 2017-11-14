using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ModifySpawnPoints : EditorWindow {

    string sPToFind;
    Transform[] spawnPoints;
    bool findPressed = false;
    [MenuItem("Tools/Custom")]
	public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ModifySpawnPoints));

    }

    void OnGUI()
    {
        GUILayout.Label("Spawn");
        GUILayout.BeginHorizontal();
        sPToFind = EditorGUILayout.TextField("PointName", sPToFind,GUILayout.MaxWidth(400),GUILayout.ExpandWidth(false));
        if(GUILayout.Button("Find",GUILayout.Width (40)))
        {
            //TODO: find needed spawnpoints
            FindSpawnPoints();
            findPressed = true;
            
        }
        GUILayout.EndHorizontal();
        if (findPressed)
        {
            GUILayout.BeginHorizontal();
            ShowSpawnPoints();
            GUILayout.EndHorizontal();
        }
    }

    void FindSpawnPoints()
    {
        spawnPoints = GameObject.Find(sPToFind + "Container").GetComponentsInChildren<Transform>();
        
    }

    void ShowSpawnPoints()
    {
        
        int elementsInThisRow = 0;
        foreach (Transform child in spawnPoints)
        {
            //TODO: Go through every needed spawn point ,display all needed parametrs
            
           GUILayout.BeginVertical();
            if (child.name == "TankSpawnPoint" )
            {
                GameObject TankT = Resources.Load("TankTexture", typeof(GameObject)) as GameObject;
                GUILayout.Box(TankT.GetComponent<SpriteRenderer>().sprite.texture,GUILayout.Width(50),GUILayout.Height(50));      
                child.GetComponent<TankSpawnParametrs>().Armored = EditorGUILayout.Toggle("Armored", child.GetComponent<TankSpawnParametrs>().Armored, GUILayout.ExpandWidth(false));
                elementsInThisRow++;
            }
          
            GUILayout.EndVertical();
            if (elementsInThisRow % (spawnPoints.Length/4) == 0)
            {
               // elementsInThisRow = 0;
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
            }
        }
        

    }
}
