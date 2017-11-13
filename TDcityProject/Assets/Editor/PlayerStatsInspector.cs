using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
[CustomEditor(typeof(PlayerStats))]
public class PlayerStatsInspector : Editor {

    public override void OnInspectorGUI()
    {
        PlayerStats pStats = (PlayerStats)target;
        base.OnInspectorGUI();


        if (GUILayout.Button("Save"))
        {
            pStats.Save();
        }
    }
}
