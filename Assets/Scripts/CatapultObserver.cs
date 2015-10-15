using UnityEngine;
using System.Collections;

public class CatapultObserver : MonoObserver {

	// Use this for initialization
    public override void receiveUpdate(rubeState theState)
    {
        if(theState == rubeState.dominoStart)
        {
            gameObject.GetComponent<Rigidbody>().AddForceAtPosition(
                Vector3.down * 10000, new Vector3(-5, 0, 0));
        }
    }
}
