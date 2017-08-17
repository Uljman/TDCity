using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContainer : MonoBehaviour {

    public static ButtonContainer bT;
    public GameObject MainMenu;
    public GameObject LevelSelect;
    public GameObject UpgradeMenu;

    // Use this for initialization
    void Start () {
        bT = this;
	}
}
