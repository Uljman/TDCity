using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigator : MonoBehaviour {

    private void Start()
    {
        HideAllMenus();
        
        Debug.Log( Application.persistentDataPath);
        GameObject.Find("Menus").transform.Find("MainMenu").gameObject.SetActive(true);
    }

    public void MenuToShow(string MenuName)
    {
        HideAllMenus();
       
        GameObject.Find("Menus").transform.Find(MenuName).gameObject.SetActive(true);
    }

    void HideAllMenus()
    {
        int chCount = GameObject.Find("Menus").transform.childCount;
        for (int i = 0; i < chCount; i++)
        {
            GameObject.Find("Menus").transform.GetChild(i).gameObject.SetActive(false) ;
        }
    }
}
