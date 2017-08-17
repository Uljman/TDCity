using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
[CustomEditor (typeof(LevelParametrs))]
public class LevelGenerator : Editor {

    
    public override void OnInspectorGUI()
    {
        LevelParametrs lPar = (LevelParametrs) target;
        base.OnInspectorGUI();


        if (GUILayout.Button("Create"))
        {
            Debug.Log("Pressed create");
            lPar.GenerateLevel();
        }
    }

}
