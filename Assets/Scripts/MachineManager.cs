using UnityEngine;
using System.Collections;

public class MachineManager : MonoBehaviour {

    private MachineManager theMachineManager;
    private MachineFSM theFSM;

    private MachineManager()
    {
        
    }

    public MachineManager getManager()
    {
        if(theMachineManager == null)
            theMachineManager = new MachineManager();
        return theMachineManager;
    }
}
