using UnityEngine;
using System.Collections;

/// <summary>
/// This class implements the MonoObserver class for the Marble Tower Object
/// </summary>
public class MTObserver : MonoObserver {

	// Use this for initialization
    public override void receiveUpdate(rubeState theState)
    {
        if(theState == rubeState.dominoStart)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
