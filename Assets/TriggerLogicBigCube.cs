using UnityEngine;
using System.Collections;

public class TriggerLogicBigCube : MonoBehaviour
{

    private bool touchingGreen = false;
    private bool touchingMidBlock = false;

    // Use this for initialization
    void OnTriggerStay(Collider other)
    {

    }

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        //Debug.Log("OnTriggerExit");
        // Debug.Log("entered");
        //Debug.Log("OnTriggerStay");
        //Debug.Log(other.gameObject.tag + " " + other.gameObject);
        if (other.gameObject.CompareTag("Mid"))
        {
            touchingMidBlock = false;
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            touchingGreen = false;
        }
       // Debug.Log("Big BlockCorrectlyPlaced() " + BlockCorrectlyPlaced());
    }

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("entered");
        //Debug.Log("OnTriggerStay");
        //Debug.Log(other.gameObject.tag + " " + other.gameObject);
        if (other.gameObject.CompareTag("Mid"))
        {
            touchingMidBlock = true;
        }    
        if (other.gameObject.CompareTag("Finish"))
        {
            touchingGreen = true;
        }
      //  Debug.Log("Big BlockCorrectlyPlaced() " + BlockCorrectlyPlaced());
    }

    public bool BlockCorrectlyPlaced()
    {
        return touchingGreen;
    }
}
