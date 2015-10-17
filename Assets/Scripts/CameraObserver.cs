using UnityEngine;
using System.Collections;

public class CameraObserver : MonoObserver {

    [SerializeField]
    private Transform [] targets, positions;
    private rubeState currentState;
    private float timeSinceTransition;

    public override void receiveUpdate(rubeState theState)
    {
        this.currentState = theState;
        timeSinceTransition = 0f;
    }
	
	// Update is called once per frame
	void Update () 
    {
	    switch(currentState)
        {
            case rubeState.init:
            {
                transform.position = new Vector3(
                    transform.position.x,
                    targets[0].position.y,
                    transform.position.z
                    );
                transform.LookAt(targets[0].position);
                break;
            }
            case rubeState.dominoStart:
            {
                if (timeSinceTransition > .8f)
                {
                    transform.position = positions[0].position;
                    transform.rotation = positions[0].rotation;
                }
                else 
                    timeSinceTransition += Time.deltaTime;
                break;
            }
            case rubeState.catapultFired:
            {
                transform.position = positions[1].position;
                transform.LookAt(targets[1]);
                break;
            }
            case rubeState.wallDestroyed:
            {
                transform.LookAt(targets[2]);
                break;
            }
            case rubeState.buttonPressed:
            {
                transform.LookAt(targets[3]);
                break;
            }
            case rubeState.moveCameraToFinalPos:
            {
                transform.position = positions[2].position;
                transform.rotation = positions[2].rotation;
                break;
            }
        }

	}
}
