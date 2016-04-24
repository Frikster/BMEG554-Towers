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
    void Start () {
        //SmallCubeTrigger = this.FindComponentInChildWithTag<GameObject>("Small");


        SmallCubeTrigger = GameObject.FindGameObjectWithTag("Small");
        trigSmall = SmallCubeTrigger.GetComponent<TriggerLogicSmallCube>();
        MidCubeTrigger = GameObject.FindGameObjectWithTag("Mid");
        trigMid = MidCubeTrigger.GetComponent<TriggerLogicMidCube>();
        BigCubeTrigger = GameObject.FindGameObjectWithTag("Big");
        trigBig = BigCubeTrigger.GetComponent<TriggerLogicBigCube>();
    }

    public bool AllBlocksCorrectlyPlaced()
    {
        Debug.Log("trigSmall.BlockCorrectlyPlaced()"+ trigSmall.BlockCorrectlyPlaced());
        Debug.Log("trigMid.BlockCorrectlyPlaced()"+ trigMid.BlockCorrectlyPlaced());
        Debug.Log("trigBig.BlockCorrectlyPlaced()"+ trigBig.BlockCorrectlyPlaced());
        return trigSmall.BlockCorrectlyPlaced() && trigMid.BlockCorrectlyPlaced() && trigBig.BlockCorrectlyPlaced();
    }

    public bool OneGrabContact()
    {
        //return trigMid.GrabContact();
        return trigSmall.GrabContact() || trigMid.GrabContact() || trigBig.GrabContact();
    }

    public bool OnePinchContact()
    {
        return trigSmall.PinchContact() || trigMid.PinchContact() || trigBig.PinchContact();
    }

    // Update is called once per frame
    void Update () {
	
	}
}

