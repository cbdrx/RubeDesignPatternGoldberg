using UnityEngine;
using System.Collections;
/// <summary>
/// This tells the table and the rocket what to do when the table has been
/// hit by the rocket. They both fly upward, and the table is flipped
/// </summary>
public class TinyEverythingObserver : MonoObserver {
        
    public override void receiveUpdate(rubeState theState)
    {
        if(theState == rubeState.targetDestroyed)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().AddForce(0, 20, 20);
        }
    }
    
}
