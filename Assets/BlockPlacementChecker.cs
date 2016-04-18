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
        return trigSmall.BlockCorrectlyPlaced() && trigMid.BlockCorrectlyPlaced() && trigBig.BlockCorrectlyPlaced();
    }

    // Update is called once per frame
    void Update () {
	
	}
}

