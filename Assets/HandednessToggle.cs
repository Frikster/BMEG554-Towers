using UnityEngine;
using System.Collections;

public class HandednessToggle : MonoBehaviour {
    private GrabbingHand grabAndPinchScript;

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        try
        {
            grabAndPinchScript = GameObject.FindGameObjectWithTag("Left").GetComponent<GrabbingHand>();
        }
        catch
        {
           // Debug.Log("Left hand not in scene");
        }
        //Debug.Log(GameObject.FindGameObjectWithTag("Left"));
       // Debug.Log("grabAndPinchScript = " + grabAndPinchScript);


        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            Debug.Log(grabAndPinchScript);
            grabAndPinchScript.enabled = !grabAndPinchScript.enabled;
        }

        if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            Debug.Log(grabAndPinchScript);
            grabAndPinchScript.enabled = !grabAndPinchScript.enabled;
        }

        if (Input.GetKeyUp(KeyCode.Keypad3))
        {
            Debug.Log(grabAndPinchScript);
            grabAndPinchScript.enabled = !grabAndPinchScript.enabled;
        }
    }
}
