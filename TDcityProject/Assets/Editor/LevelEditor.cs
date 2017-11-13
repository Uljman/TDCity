using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof (LevelEditorParametrs))]
public class LevelEditor : Editor {

	public void OnGUI()
    {
        Event e = Event.current;
        Debug.Log("A was pressed");
        if (e.type == EventType.KeyDown)
        {
            Debug.Log("A was pressed");
        }
    }
}
