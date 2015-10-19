using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MachineManager : MonoBehaviour {

    private List<MonoObserver> subscribers = new List<MonoObserver>();
    private static MachineFSM theFSM;
    private static MachineManager instance;
    private static GameObject theManager;
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



    private void Awake()
    {
        instance = this;
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