using UnityEngine;
using System.Collections;

/// <summary>
/// MonoObserver is a monobehavior that allows an object to receive messages
/// from the MachineManager. 
/// </summary>
public abstract class MonoObserver : MonoBehaviour {

    protected MachineManager manager;              
    protected rubeState currentState;

    // Use this for initialization
	protected void Start () 
    {
        manager = MachineManager.Instance;
        manager.subscribe(this);
	}

    protected void OnDestroy()
    {
        manager.unsubscribe((MonoObserver)this);
    }

    public abstract void receiveUpdate(rubeState theState);

}
