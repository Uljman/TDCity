using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileShooting : MonoBehaviour {
    public int State;
    

    public void Shoot(int _State)
    {
        if (State == 1) State = 0;
        else State = 1;
    }
}
