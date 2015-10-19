using UnityEngine;
using System.Collections;

public class Starter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            MachineManager.Instance.receiveControl(triggerList.started);
            gameObject.SetActive(false);
        }
	
	}
}
