using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Leap;
using UnityEditor;
using Leap.Unity;

public class OutputStream : MonoBehaviour
{
    public Text PinchStrengthText;
    public Text GrabStrengthText;
    public Text ConfidenceText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
       HandModel hand_model = GetComponent<HandModel>();
        try
        {
            Hand leap_hand = hand_model.GetLeapHand();
        }
        catch
        {
            Debug.Log("leap_hand: "+ leap_hand);
        }
        try
        {
            PinchStrengthText.text = "Pinch Strength: " + leap_hand.PinchStrength.ToString();
            GrabStrengthText.text = "Grab Strength: " + leap_hand.GrabStrength.ToString();
            ConfidenceText.text = "Confidence: " + leap_hand.Confidence.ToString();

        }
        catch
        {

        }

        }
        */
    }
}