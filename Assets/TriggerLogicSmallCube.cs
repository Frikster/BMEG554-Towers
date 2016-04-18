using UnityEngine;
using System.Collections;

public class TriggerLogicSmallCube : MonoBehaviour {

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
        //Debug.Log("Small BlockCorrectlyPlaced() " + BlockCorrectlyPlaced());
        //Debug.Log("Small touchingMidBlock " + touchingMidBlock);
        //Debug.Log("Small touchingGreen " + touchingGreen);
    }

    void OnTriggerEnter(Collider other)
    {
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
        //Debug.Log("Small BlockCorrectlyPlaced() " + BlockCorrectlyPlaced());
       // Debug.Log("Small touchingMidBlock " + touchingMidBlock);
        //Debug.Log("Small touchingGreen " + touchingGreen);
    }

    public bool BlockCorrectlyPlaced()
    {
        return !touchingGreen && touchingMidBlock;
    }
}

