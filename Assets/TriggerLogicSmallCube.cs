using UnityEngine;
using System.Collections;

//namespace Leap.Unity
//{
public class TriggerLogicSmallCube : MonoBehaviour {
    private bool touchingGreen = false;
    private bool touchingMidBlock = false;

    private bool contactThumbBone1_L = false;
    private bool contactIndexBone1_L = false;
    private bool contactMidBone1_L = false;
    private bool contactPinkyBone1_L = false;
    private bool contactRingBone1_L = false;
    private bool contactPalm_L = false;
    private bool contactThumbBone1_R = false;
    private bool contactIndexBone1_R = false;
    private bool contactMidBone1_R = false;
    private bool contactPinkyBone1_R = false;
    private bool contactRingBone1_R = false;
    private bool contactPalm_R = false;

    private bool contactThumbBone3_L = false;
    private bool contactIndexBone3_L = false;
    private bool contactMidBone3_L = false;
    private bool contactPinkyBone3_L = false;
    private bool contactRingBone3_L = false;
    private bool contactThumbBone3_R = false;
    private bool contactIndexBone3_R = false;
    private bool contactMidBone3_R = false;
    private bool contactPinkyBone3_R = false;
    private bool contactRingBone3_R = false;

    private GrabbingHand grabbingHandLeft;
    private GrabbingHand grabbingHandRight;
    private GameObject leftHand;
    private GameObject rightHand;

    private float unstickifyGrab;
    private float unstickifyPinch;
    private bool stickified = false;

    public GameObject smallObj;

    //Leap controller
    //private GameObject controllerGameObject;
    //private LeapServiceProvider leapServiceProviderScript;
    //protected Controller leap_controller_;

    void start()
    {
        smallObj = this.transform.parent.gameObject;
        //controllerGameObject = GameObject.FindGameObjectWithTag("GameController");
        //leapServiceProviderScript = controllerGameObject.GetComponent<LeapServiceProvider>();
        //leap_controller_ = leapServiceProviderScript.GetLeapController();
    }

    void Update()
    {
        if (FingerTipContact() && touchingMidBlock && !touchingGreen)
        //if (touchingMidBlock && !touchingGreen)
        {
            stickified = true;
        }
        else
        {
                stickified = false;
        }

    }

    public bool Stickified()
    {
        return stickified;
    }

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
        if (other.gameObject.CompareTag("MidBlock"))
        {
            touchingMidBlock = false;
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            touchingGreen = false;
        }

        //Bone1
        if (other.gameObject.CompareTag("ThumbBone1_L"))
        {
            contactThumbBone1_L = false;
        }
        if (other.gameObject.CompareTag("IndexBone1_L"))
        {
            contactIndexBone1_L = false;
        }
        if (other.gameObject.CompareTag("MidBone1_L"))
        {
            contactMidBone1_L = false;
        }
        if (other.gameObject.CompareTag("PinkyBone1_L"))
        {
            contactPinkyBone1_L = false;
        }
        if (other.gameObject.CompareTag("RingBone1_L"))
        {
            contactRingBone1_L = false;
        }
        if (other.gameObject.CompareTag("ThumbBone1_R"))
        {
            contactThumbBone1_R = false;
        }
        if (other.gameObject.CompareTag("IndexBone1_R"))
        {
            contactIndexBone1_R = false;
        }
        if (other.gameObject.CompareTag("MidBone1_R"))
        {
            contactMidBone1_R = false;
        }
        if (other.gameObject.CompareTag("PinkyBone1_R"))
        {
            contactPinkyBone1_R = false;
        }
        if (other.gameObject.CompareTag("RingBone1_R"))
        {
            contactRingBone1_R = false;
        }

        //Palm
        if (other.gameObject.CompareTag("Palm_L"))
        {
            contactPalm_L = false;
        }
        if (other.gameObject.CompareTag("Palm_R"))
        {
            contactPalm_R = false;
        }

        //Bone3
        if (other.gameObject.CompareTag("ThumbBone3_L"))
        {
            contactThumbBone3_L = false;
        }
        if (other.gameObject.CompareTag("IndexBone3_L"))
        {
            contactIndexBone3_L = false;
        }
        if (other.gameObject.CompareTag("MidBone3_L"))
        {
            contactMidBone3_L = false;
        }
        if (other.gameObject.CompareTag("PinkyBone3_L"))
        {
            contactPinkyBone3_L = false;
        }
        if (other.gameObject.CompareTag("RingBone3_L"))
        {
            contactRingBone3_L = false;
        }
        if (other.gameObject.CompareTag("ThumbBone3_R"))
        {
            contactThumbBone3_R = false;
        }
        if (other.gameObject.CompareTag("IndexBone3_R"))
        {
            contactIndexBone3_R = false;
        }
        if (other.gameObject.CompareTag("MidBone3_R"))
        {
            contactMidBone3_R = false;
        }
        if (other.gameObject.CompareTag("PinkyBone3_R"))
        {
            contactPinkyBone3_R = false;
        }
        if (other.gameObject.CompareTag("RingBone3_R"))
        {
            contactRingBone3_R = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerStay");
        //Debug.Log(other.gameObject.tag + " " + other.gameObject);
        if (other.gameObject.CompareTag("MidBlock"))
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

        //Bone1
        if (other.gameObject.CompareTag("ThumbBone1_L"))
        {
            contactThumbBone1_L = true;
        }
        if (other.gameObject.CompareTag("IndexBone1_L"))
        {
            contactIndexBone1_L = true;
        }
        if (other.gameObject.CompareTag("MidBone1_L"))
        {
            contactMidBone1_L = true;
        }
        if (other.gameObject.CompareTag("PinkyBone1_L"))
        {
            contactPinkyBone1_L = true;
        }
        if (other.gameObject.CompareTag("RingBone1_L"))
        {
            contactRingBone1_L = true;
        }
        if (other.gameObject.CompareTag("ThumbBone1_R"))
        {
            contactThumbBone1_R = true;
        }
        if (other.gameObject.CompareTag("IndexBone1_R"))
        {
            contactIndexBone1_R = true;
        }
        if (other.gameObject.CompareTag("MidBone1_R"))
        {
            contactMidBone1_R = true;
        }
        if (other.gameObject.CompareTag("PinkyBone1_R"))
        {
            contactPinkyBone1_R = true;
        }
        if (other.gameObject.CompareTag("RingBone1_R"))
        {
            contactRingBone1_R = true;
        }

        ///Palm
        if (other.gameObject.CompareTag("Palm_L"))
        {
            contactPalm_L = true;
        }
        if (other.gameObject.CompareTag("Palm_R"))
        {
            contactPalm_R = true;
        }

        //Bone3
        if (other.gameObject.CompareTag("ThumbBone3_L"))
        {
            contactThumbBone3_L = true;
        }
        if (other.gameObject.CompareTag("IndexBone3_L"))
        {
            contactIndexBone3_L = true;
        }
        if (other.gameObject.CompareTag("MidBone3_L"))
        {
            contactMidBone3_L = true;
        }
        if (other.gameObject.CompareTag("PinkyBone3_L"))
        {
            contactPinkyBone3_L = true;
        }
        if (other.gameObject.CompareTag("RingBone3_L"))
        {
            contactRingBone3_L = true;
        }
        if (other.gameObject.CompareTag("ThumbBone3_R"))
        {
            contactThumbBone3_R = true;
        }
        if (other.gameObject.CompareTag("IndexBone3_R"))
        {
            contactIndexBone3_R = true;
        }
        if (other.gameObject.CompareTag("MidBone3_R"))
        {
            contactMidBone3_R = true;
        }
        if (other.gameObject.CompareTag("PinkyBone3_R"))
        {
            contactPinkyBone3_R = true;
        }
        if (other.gameObject.CompareTag("RingBone3_R"))
        {
            contactRingBone3_R = true;
        }

        //Debug.Log("OTHER" + other);
    }

    public bool BlockCorrectlyPlaced()
    {
        //return false;
        //Debug.Log("smallObj.GetComponent<Rigidbody>()" + smallObj.GetComponent<Rigidbody>());
        //Debug.Log("Small touchingMidBlock " + touchingMidBlock);
        //Debug.Log("Small touchingGreen " + touchingGreen);
        return !touchingGreen && touchingMidBlock && smallObj.GetComponent<Rigidbody>().IsSleeping();
    }

    public bool GrabContact()
    {
        return (contactMidBone1_L && contactPinkyBone1_L && contactRingBone1_L)
            || (contactMidBone1_R && contactPinkyBone1_R && contactRingBone1_R)
            || (contactMidBone3_L && contactPinkyBone3_L && contactRingBone3_L)
            || (contactMidBone3_R && contactPinkyBone3_R && contactRingBone3_R);
    }

    public bool PinchContact()
    {
        return (contactThumbBone3_L && contactIndexBone3_L && !contactMidBone3_L && !contactPinkyBone3_L && !contactRingBone3_L && !contactPalm_L)
    || (contactThumbBone3_R && contactIndexBone3_R && !contactMidBone3_R && !contactPinkyBone3_R && !contactRingBone3_R && !contactPalm_R);
    }

    public bool FingerTipContact()
    {
        return (contactThumbBone3_L || contactIndexBone3_L || contactMidBone3_L || contactPinkyBone3_L || contactRingBone3_L)
    || (contactThumbBone3_R || contactIndexBone3_R || contactMidBone3_R || contactPinkyBone3_R || contactRingBone3_R);
    }
}

//}