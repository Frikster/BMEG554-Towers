using UnityEngine;
using System.Collections;

public class buttonTest : MonoBehaviour {
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("TRIGGER BUTTON");
        switch (col.tag)
        {
            case "Button":
                Debug.Log("BUTTON TRIGGERED");
                break;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("COLLISION");
        //switch (col.tag)
        //{
        //    case "Button":
        //        Debug.Log("BUTTON COLLISION");
        //        break;
        //}
    }

}
