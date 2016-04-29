using UnityEngine;
using System.Collections;

public class BlockPlacementChecker : MonoBehaviour {
    private TriggerLogicSmallCube trigSmall;
    private TriggerLogicMidCube trigMid;
    private TriggerLogicBigCube trigBig;

    private GameObject SmallCubeTrigger;
    private GameObject MidCubeTrigger;
    private GameObject BigCubeTrigger;

    // Use this for initialization
    void Start() {
        //Debug.Log("Run BlockPlacementChecker start()");

        //SmallCubeTrigger = this.FindComponentInChildWithTag<GameObject>("Small");
        SmallCubeTrigger = GameObject.FindGameObjectWithTag("Small");
        trigSmall = SmallCubeTrigger.GetComponent<TriggerLogicSmallCube>();
        MidCubeTrigger = GameObject.FindGameObjectWithTag("Mid");
        trigMid = MidCubeTrigger.GetComponent<TriggerLogicMidCube>();
        BigCubeTrigger = GameObject.FindGameObjectWithTag("Big");
        trigBig = BigCubeTrigger.GetComponent<TriggerLogicBigCube>();

        //Debug.Log("SmallCubeTrigger " + SmallCubeTrigger);
        //Debug.Log("trigSmall " + trigSmall);
        //Debug.Log("MidCubeTrigger " + MidCubeTrigger);
        //Debug.Log("trigMid " + trigMid);
        //Debug.Log("BigCubeTrigger " + BigCubeTrigger);
        //Debug.Log("trigBig " + trigBig);
    }

    public bool OneStickifyRequest()
    {
        Debug.Log("trigSmall.Stickified() " + trigSmall.Stickified());
        Debug.Log("trigMid.Stickified() " + trigMid.Stickified());
        //Debug.Log("trigBig.Stickified() " + trigBig.Stickified());
        return trigSmall.Stickified() || trigMid.Stickified();
    }

    //public bool BigStickified()
    //{
    //    return trigBig.Stickified();
    //}

    //public bool MidStickified()
    //{
    //    return trigMid.Stickified();
    //}

    //public bool SmallStickified()
    //{
    //    return trigSmall.Stickified();
    //}

    public bool AllBlocksCorrectlyPlaced()
    {
        //Debug.Log("trigSmall.BlockCorrectlyPlaced()" + trigSmall.BlockCorrectlyPlaced());
        //Debug.Log("trigMid.BlockCorrectlyPlaced()" + trigMid.BlockCorrectlyPlaced());
        //Debug.Log("trigBig.BlockCorrectlyPlaced()" + trigBig.BlockCorrectlyPlaced());
        return trigSmall.BlockCorrectlyPlaced() && trigMid.BlockCorrectlyPlaced() && trigBig.BlockCorrectlyPlaced();
    }

    public bool OneGrabContact()
    {
        //return trigMid.GrabContact();
        //Debug.Log("SmallCubeTrigger " + SmallCubeTrigger);
        //Debug.Log("trigSmall " + trigSmall);
        //Debug.Log("MidCubeTrigger " + MidCubeTrigger);
        //Debug.Log("trigMid " + trigMid);
        //Debug.Log("BigCubeTrigger " + BigCubeTrigger);
        //Debug.Log("trigBig " + trigBig);
        if (trigSmall!=null&& trigMid != null && trigBig != null)
        {
            return trigSmall.GrabContact() || trigMid.GrabContact() || trigBig.GrabContact();
        }
        else
        {
            return false;
        }
        
    }

    public bool OnePinchContact()
    {
        return trigSmall.PinchContact() || trigMid.PinchContact() || trigBig.PinchContact();
    }

    // Update is called once per frame
    void Update () {
        SmallCubeTrigger = GameObject.FindGameObjectWithTag("Small");
        trigSmall = SmallCubeTrigger.GetComponent<TriggerLogicSmallCube>();
        MidCubeTrigger = GameObject.FindGameObjectWithTag("Mid");
        trigMid = MidCubeTrigger.GetComponent<TriggerLogicMidCube>();
        BigCubeTrigger = GameObject.FindGameObjectWithTag("Big");
        trigBig = BigCubeTrigger.GetComponent<TriggerLogicBigCube>();
    }
}

