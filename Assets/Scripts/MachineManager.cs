using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MachineManager : MonoBehaviour {

    private static MachineManager theMachineManager;
    private List<MonoObserver> subscribers = new List<MonoObserver>();
    private MachineFSM theFSM;

    private MachineManager()
    {
        
    }

    public static MachineManager getManager()
    {
        if(theMachineManager == null)
            theMachineManager = new MachineManager();
        return theMachineManager;
    }

    public void subscribe(MonoObserver o)
    {
        subscribers.Add(o);
    }

    public void unsubscribe(MonoObserver o)
    {
        subscribers.Remove(o);
    }
    
}