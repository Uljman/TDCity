using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ModifySpawnPoints : EditorWindow {

    string sPToFind;
    Transform[] spawnPoints;
    Transform prevSelectedObj;
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
          GUILayout.Box((Texture)Resources.Load("MapPreview", typeof(RenderTexture)));
          int elementsInThisRow = 0;
          foreach (Transform child in spawnPoints)
          {
            GUILayout.BeginVertical();
            if (child.name == "TankSpawnPoint" )
            {
                GameObject TankT = Resources.Load("TankTexture", typeof(GameObject)) as GameObject;
               
                if(GUILayout.Button("", GUILayout.Width(20), GUILayout.Height(20)))
                {
                    //insert object highlight

                    HighLightSP(child);
                    if (prevSelectedObj) resetColor(prevSelectedObj);
                    Debug.Log(child.position);
                }
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

    void HighLightSP(Transform sP)
    {
        Material material = new Material(Shader.Find("Specular"));
        material.color = Color.yellow;
        sP.GetChild(0).GetComponent<Renderer>().sharedMaterial = material;
        prevSelectedObj = sP;
    }

    void resetColor(Transform prGO)
    {
        Material material = new Material(Shader.Find("Specular"));
        material.color = Color.white;
        prGO.GetChild(0).GetComponent<Renderer>().sharedMaterial = material;
    }
}
