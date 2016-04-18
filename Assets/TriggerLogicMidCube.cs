using UnityEngine;
using System.Collections;

public class TriggerLogicMidCube : MonoBehaviour
{

    private bool touchingGreen = false;
    private bool touchingBigBlock = false;
    private bool touchingSmallBlock = false;

    // Use this for initialization
    void OnTriggerStay(Collider other)
    {

    }

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
        if (other.gameObject.CompareTag("Big"))
        {
            touchingBigBlock = false;
        }
        if (other.gameObject.CompareTag("Small"))
        {
            touchingSmallBlock = false;
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            touchingGreen = false;
        }
        //Debug.Log("mid touching big: " + other.gameObject.CompareTag("Big"));
       // Debug.Log("mid touching small: " + other.gameObject.CompareTag("Small"));
    //    Debug.Log("Mid BlockCorrectlyPlaced() " + BlockCorrectlyPlaced());
        //Debug.Log("touchingBigBlock " + touchingBigBlock);
        //Debug.Log("touchingSmallBlock " + touchingSmallBlock);
        //Debug.Log("touchingGreen " + touchingGreen);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Big"))
        {
            touchingBigBlock = true;
        }
        if (other.gameObject.CompareTag("Small"))
        {
            touchingSmallBlock = true;
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            touchingGreen = true;
        }
      //  Debug.Log("mid touching big: " + other.gameObject.CompareTag("Big"));
     //   Debug.Log("mid touching small: " + other.gameObject.CompareTag("Small"));
    //    Debug.Log("Mid BlockCorrectlyPlaced() " + BlockCorrectlyPlaced());
        //Debug.Log("touchingBigBlock " + touchingBigBlock);
        //Debug.Log("touchingSmallBlock " + touchingSmallBlock);
        //Debug.Log("touchingGreen " + touchingGreen);
    }

    public bool BlockCorrectlyPlaced()
    {
        return !touchingGreen && touchingBigBlock;
    }
}
