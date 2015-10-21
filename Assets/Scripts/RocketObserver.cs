using UnityEngine;
using System.Collections;

/// <summary>
/// This is the observer class for the rocket. 
/// </summary>
public class RocketObserver : MonoObserver {

    /// <summary>
    /// When the button is pressed,
    /// force is applied to the rocket so that it will hit the table. When the 
    /// table destroyed trigger is hit, and the machine enters the 
    /// "targetDestroyed" state, the rocket begins to use gravity so it falls
    /// </summary>
    /// <param name="theState">The current state</param>
    public override void receiveUpdate(rubeState theState)
    {
        if(theState == rubeState.buttonPressed)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().AddForce(
                transform.up * 7500
                );
        }
        if(theState == rubeState.targetDestroyed)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }

}
