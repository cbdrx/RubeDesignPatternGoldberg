using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MachineManager : MonoBehaviour {

    private List<MonoObserver> subscribers = new List<MonoObserver>();
    private MachineFSM theFSM;

    public static MachineManager Instance
    {
        get { return instance; }
        set
        {
            if (instance == null || instance == value)
            {
                instance = value;
            }
            else
            {
                Destroy(value.gameObject);
            }
        }
    }
    private static MachineManager instance;

    private void Awake()
    {
        instance = this;
        theFSM = gameObject.GetComponent<MachineFSM>();
    }

    public void subscribe(MonoObserver obs)
    {
        obs.receiveUpdate(theFSM.getState());
        subscribers.Add(obs);
    }

    public void unsubscribe(MonoObserver obs)
    {
        subscribers.Remove(obs);
    }

    public void updateSubs()
    {
        foreach(MonoObserver subscriber in subscribers)
        {
            subscriber.receiveUpdate(theFSM.getState());
        }
    }

    public void receiveControl(triggerList message)
    {
        theFSM.handleTrigger(message);
        updateSubs();
    }
    
}