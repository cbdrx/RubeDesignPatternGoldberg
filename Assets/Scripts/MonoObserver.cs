using UnityEngine;
using System.Collections;

/// <summary>
/// MonoObserver is a monobehavior that allows an object to receive messages
/// from the MachineManager. 
/// </summary>
public abstract class MonoObserver : MonoBehaviour {
    /// <summary>
    /// A reference to the manager
    /// </summary>
    protected MachineManager manager;

    /// <summary>
    /// Upon its creation, the MonoObserver will subscribe itself to the 
    /// Subject contained in manager.
    /// </summary>
 

	protected void Start () 
    {
        manager = MachineManager.Instance;
        manager.subscribe(this);
	}
    /// <summary>
    /// This is here for safety, to make sure there is no persistence of 
    /// observers across scenes.
    /// </summary>
    protected void OnDestroy()
    {
        manager.unsubscribe((MonoObserver)this);
    }
    /// <summary>
    /// This function defines which states an object reacts to, as well as 
    /// the actual functionality of that reaction.
    /// </summary>
    /// <param name="theState">this is the state the object will react to
    /// </param>
    public abstract void receiveUpdate(rubeState theState);

}
