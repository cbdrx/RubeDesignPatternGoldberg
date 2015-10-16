using UnityEngine;
using System.Collections;

/// <summary>
/// This class implements the MonoObserver class for the catapult
/// </summary>
public class CatapultObserver : MonoObserver {

	// Use this for initialization
    public override void receiveUpdate(rubeState theState)
    {
        if(theState == rubeState.catapultFired)
        {
            gameObject.GetComponent<Rigidbody>().AddForceAtPosition(
                new Vector3(15, -750, 0),
                transform.position + new Vector3(5,0,0));
            Debug.Log("Firing!");
        }
    }
}
