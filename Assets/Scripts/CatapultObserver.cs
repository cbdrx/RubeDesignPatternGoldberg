using UnityEngine;
using System.Collections;

/// <summary>
/// This class implements the MonoObserver class for the catapult
/// </summary>
public class CatapultObserver : MonoObserver {

	/// <summary>
	/// Implements the receive update for the catapult, applying a force to 
    /// the end of the lever. This causes the payload to be launched.
	/// </summary>
	/// <param name="theState">the state passed by the manager</param>
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
