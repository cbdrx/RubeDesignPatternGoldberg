using UnityEngine;
using System.Collections;

public class RocketObserver : MonoObserver {

    public override void receiveUpdate(rubeState theState)
    {
        if(theState == rubeState.buttonPressed)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().AddForce(
                transform.up * 7500
                );
        }
    }

}
