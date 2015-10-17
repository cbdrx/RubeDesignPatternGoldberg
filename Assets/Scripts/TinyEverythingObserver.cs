﻿using UnityEngine;
using System.Collections;

public class TinyEverythingObserver : MonoObserver {
        
    public override void receiveUpdate(rubeState theState)
    {
        if(theState == rubeState.targetDestroyed)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
