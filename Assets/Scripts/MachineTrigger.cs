using UnityEngine;
using System.Collections;

public class MachineTrigger : MonoBehaviour {

    [SerializeField]
    private triggerList messageToSend;
    [SerializeField]
    private GameObject triggerTarget;

    private MachineManager theManager;            
    private bool triggered;

    void Start()
    {
        theManager = MachineManager.Instance;            
        triggered = false;
    }   

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.Equals(triggerTarget) && !triggered)
        {
            triggered = true;
            theManager.receiveControl(messageToSend);
        }
    }
	
}
