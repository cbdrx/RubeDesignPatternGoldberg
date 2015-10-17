using UnityEngine;
using System.Collections;

/// <summary>
/// All buttons will show the "pressed" behavior when they have been
/// triggered, but since the state activation of each button may be different,
/// the targetState is exposed to the editor.
/// </summary>
public class ButtonObserver : MonoObserver {

    [SerializeField]
    private rubeState targetState;

    public override void receiveUpdate(rubeState theState)
    {
        if (theState == targetState)
        {
            transform.position += new Vector3(0, .1f, 0);
            transform.localScale = new Vector3(
                transform.localScale.x,
                transform.localScale.y - .5f * transform.localScale.y,
                transform.localScale.z);

            gameObject.GetComponent<SphereCollider>().center
                = new Vector3(0, -.5f, 0);
        }
    }
}
