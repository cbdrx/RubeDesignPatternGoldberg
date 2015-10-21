using UnityEngine;
using System.Collections;

/// <summary>
/// This class implements the MonoObserver class for the Marble Tower Object
/// </summary>
public class MTObserver : MonoObserver {

	/// <summary>
	/// Upon the ball hitting the ground, the rigidbody becomes no longer 
    /// kinematic, so it can become the largest domino
	/// </summary>
	/// <param name="theState">the current state of the machien</param>
    
    public override void receiveUpdate(rubeState theState)
    {
        if(theState == rubeState.dominoStart)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
