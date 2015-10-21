using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// The MachineManager class represents a Singleton tha contains both the
/// FSM controlling the rube goldberg machine and the subject of the observer
/// pattern. It sends messages to the subscribed objects in the scene, 
/// updating them on the current state of the FSM.
/// </summary>
public class MachineManager : MonoBehaviour {
    /// <summary>
    /// The list of MonoObservers that will be updated when the state changes
    /// </summary>
    private List<MonoObserver> subscribers = new List<MonoObserver>();

    /// <summary>
    /// Static reference to the FSM controlling the machine.
    /// </summary>
    private static MachineFSM theFSM;

    /// <summary>
    /// Static reference to the singleton instance of the MachineManager
    /// </summary>
    private static MachineManager instance;

    /// <summary>
    /// Static reference to the singleton GameObject that the monobehavior
    /// gets attached
    /// </summary>
    private static GameObject theManager;
    
    /// <summary>
    /// Instance is the accessor property for the singleton object. It 
    /// implements the lazy instantiation of both the gameobject and the
    /// MonoBehaviors needed
    /// </summary>
    public static MachineManager Instance
    {
        get 
        { 
            if(instance == null)
            {
                theManager = new GameObject("Machine Manager");
                theManager.AddComponent<MachineManager>();
                theManager.AddComponent<MachineFSM>();
                theFSM = theManager.GetComponent<MachineFSM>();
                instance = theManager.GetComponent<MachineManager>();
            }

            return instance;
        }
        set
        {
            if(instance == null)
            {
                instance = Instance;
            }
        }
    }

    /// <summary>
    /// When it is needed, the singleton is called
    /// </summary>
    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Adds a MonoObserver to the subscriber list and notifies it of the
    /// current state
    /// </summary>
    /// <param name="obs">The observer to be added to the subscriber
    /// list</param>
    public void subscribe(MonoObserver obs)
    {
        obs.receiveUpdate(theFSM.getState());
        subscribers.Add(obs);
    }

    /// <summary>
    /// Removes a MonoObserver from the subscriber list
    /// </summary>
    /// <param name="obs">The observer to be removed from the subscriber
    /// list</param>
    public void unsubscribe(MonoObserver obs)
    {
        subscribers.Remove(obs);
    }
    /// <summary>
    /// The Manager iterates through the list of subscribers, notifying each
    /// of the current state
    /// </summary>
    public void updateSubs()
    {
        foreach(MonoObserver subscriber in subscribers)
        {
            subscriber.receiveUpdate(theFSM.getState());
        }
    }
    /// <summary>
    /// Used by machineTriggers to notify the manager of criteria being met.
    /// This signal is then sent to the FSM, which performs the appropriate
    /// transition
    /// </summary>
    /// <param name="message">The "input" that the FSM is meant to respond to
    /// </param>
    public void receiveControl(triggerList message)
    {
        theFSM.handleTrigger(message);
        updateSubs();
    }
    
}