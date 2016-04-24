using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Leap.Unity
{
    public class GameHandler : MonoBehaviour
    {
        private GrabbingHand grabAndPinchScriptLeft;
        private GrabbingHand grabAndPinchScriptRight;

        private GameObject leftHandPhysics;
        private GameObject rightHandPhysics;

        private GameObject greenPlane;
        private GameObject redPlane;

        // 1 = Left; 2 = Right; 3 = Either hand
        private int caseSwitchHandedness = 1;
        private bool pinchMode = false;

        private GameObject camera;

        private GameObject controllerGameObject;
        private LeapServiceProvider leapServiceProviderScript;
        protected Controller leap_controller_;

        private RigidHand rigidHandScript;

        private string instructionStart = "Please make 2 towers on the green plane";
        private string instructionLeft = "using only your left hand";
        private string instructionRight = "using only your right hand";
        private string instructionPinch = "and only your pointing finger and thumb";
        private string instructionGrab = "without using your thumb";

        private string instructionHandedness;
        private string instructionGrabOrPinch;

        private GameObject InstructionObject;
        private Text Instructions;

        private GameObject DeathTimerBar;
        private Image DeathTimerBarImage;

        private GameObject okButton;
        private ButtonControl buttonControl;

        //private BlockPlacementChecker[] TowerChildrenScripts;

        public GameObject TowerSets;

        private bool resetOnce = true;

        protected void UpdateInstructions()
        {
            switch (caseSwitchHandedness)
            {
                case 1:
                    instructionHandedness = instructionLeft;
                    break;
                case 2:
                    instructionHandedness = instructionRight;
                    break;
                case 3:
                    instructionHandedness = "";
                    break;
            }

            if (pinchMode)
            {
                instructionGrabOrPinch = instructionPinch;
            }
            else
            {
                instructionGrabOrPinch = instructionGrab;
            }
            //Debug.Log("Instructions: " + Instructions.text);
            Instructions.text = instructionStart + " " + instructionHandedness + " " + instructionGrabOrPinch;
        }


        // Use this for initialization
        void Start()
        {
            InstructionObject = GameObject.FindGameObjectWithTag("Instructions");
            Instructions = InstructionObject.GetComponent<Text>();

            okButton = GameObject.FindGameObjectWithTag("Button");
            buttonControl = okButton.GetComponent<ButtonControl>();

            //DeathTimerBar = GameObject.FindGameObjectWithTag("Respawn");
            //DeathTimerBarImage = InstructionObject.GetComponent<Image>();

            if (!buttonControl.asResetButton())
            {
                UpdateInstructions();
            } 
            greenPlane = GameObject.FindGameObjectWithTag("Finish");
            redPlane = GameObject.FindGameObjectWithTag("Respawn");

            controllerGameObject = GameObject.FindGameObjectWithTag("GameController");
            leapServiceProviderScript = controllerGameObject.GetComponent<LeapServiceProvider>();
            leap_controller_ = leapServiceProviderScript.GetLeapController();

            KinematicSwitch(TowerSets, true);

            //TowerChildrenScripts = TowerSets.GetComponentsInChildren<BlockPlacementChecker>();
        }

        protected void UpdateHand(GameObject handPhysics, Hand hand)
        {
            GrabbingHand grabAndPinchScript = handPhysics.GetComponent<GrabbingHand>();
            grabAndPinchScript.pinchMode = pinchMode;
            //Debug.Log("grabAndPinchScript.pinchMode: " + grabAndPinchScript.pinchMode);
            if (caseSwitchHandedness == 1 && hand.IsRight)
            {
                grabAndPinchScript.enabled = false;           
            }
            if (caseSwitchHandedness == 3 && hand.IsLeft)
            {
                grabAndPinchScript.enabled = true;
            }
            if (caseSwitchHandedness == 2)
            {
                if (hand.IsLeft)
                {
                    grabAndPinchScript.enabled = false;
                }
                else
                {
                    grabAndPinchScript.enabled = true;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (InstructionObject.activeSelf && okButton.activeSelf)
            {
                if (Input.GetKeyUp(KeyCode.Keypad2))
                {
                    pinchMode = !pinchMode;
                    //Debug.Log("pinchMode = " + pinchMode);
                }
            }


            try
            {
                rightHandPhysics = GameObject.FindGameObjectWithTag("Right");

                if (InstructionObject.activeSelf && okButton.activeSelf)
                {
                    //Debug.Log("RIGIFY RIGHT");
                    CollisionsSwitch(rightHandPhysics, true);
                }
                else
                {
                    //Debug.Log("DERIGIFY RIGHT");
                    //CollisionsSwitch(rightHandPhysics, false);
                }           
                GrabbingHand grabAndPinchScript = rightHandPhysics.GetComponent<GrabbingHand>();
                grabAndPinchScript.enabled = true;
                rigidHandScript = rightHandPhysics.GetComponent<RigidHand>();
                Hand hand = rigidHandScript.GetLeapHand();
                //Debug.Log("Hand: " + hand);
                UpdateHand(rightHandPhysics, hand);
            }
            catch
            {
                //Debug.Log("No Right hand GameObject");
            }

            try
            {
                leftHandPhysics = GameObject.FindGameObjectWithTag("Left");
                if (InstructionObject.activeSelf && okButton.activeSelf)
                {
                    //Debug.Log("RIGIFY LEFT");
                    CollisionsSwitch(leftHandPhysics, true);
                }
                else
                {
                    //Debug.Log("DERIGIFY LEFT");
                    //CollisionsSwitch(leftHandPhysics, false);
                }
                GrabbingHand grabAndPinchScript = leftHandPhysics.GetComponent<GrabbingHand>();
                grabAndPinchScript.enabled = true;
                rigidHandScript = leftHandPhysics.GetComponent<RigidHand>();
                Hand hand = rigidHandScript.GetLeapHand();
                //Debug.Log("Hand: " + hand);
                UpdateHand(leftHandPhysics, hand);
            }
            catch
            {
                //Debug.Log("No Left hand GameObject");
            }

            if (InstructionObject.activeSelf && okButton.activeSelf)
            {
                if (Input.GetKeyUp(KeyCode.Keypad1))
                {
                    //Debug.Log("KEYPAD1 " + caseSwitchHandedness);
                    if (caseSwitchHandedness == 3)
                    {
                        caseSwitchHandedness = 1;
                    }
                    else
                    {
                        caseSwitchHandedness = caseSwitchHandedness + 1;
                    }
                }

                if (Input.GetKeyUp(KeyCode.Keypad3))
                {

                    camera = GameObject.FindGameObjectWithTag("MainCamera");
                    Debug.Log("camera: " + camera);
                    camera.transform.Rotate(0, 180, 0, Space.World);
                    // Please see Grabbing
                    //Debug.Log(grabAndPinchScript);
                    //grabAndPinchScript.enabled = !grabAndPinchScript.enabled;
                }
            }


            if (!buttonControl.asResetButton())
            {
                UpdateInstructions();
                resetOnce = true;
            }
            else
            {
                if (resetOnce)
                {
                    leap_controller_.StopConnection();
                    leap_controller_.StartConnection();
                    resetOnce = false;
                }
            }
            //VictoryCheck();
        }

        //void VictoryCheck()
        //{
        //    foreach (BlockPlacementChecker scrip in TowerChildrenScripts)
        //    {
        //        //victoryChecker = child.GetComponent<BlockPlacementChecker>();
        //        flag = scrip.AllBlocksCorrectlyPlaced();
        //        if (!flag)
        //        {
        //            break;
        //        }
        //    }

        //    if (flag)
        //    {
        //        Instructions.text = "You Win!";
        //        Instructions.enabled = true;
        //        okButton.SetActive(true);
        //        //SceneManager.LoadScene(SceneName);
        //    }
        //}


public void CollisionsSwitch(GameObject gameObject, bool flag)
        {
            //Debug.Log("gameObject in CollisionsSwitch: " + gameObject);
            Rigidbody[] rigidbodies = gameObject.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody body in rigidbodies)
            {
                body.detectCollisions = flag;
            }
        }

public void KinematicSwitch(GameObject gameObject, bool flag)
        {
            //Debug.Log("gameObject in CollisionsSwitch: " + gameObject);
            Rigidbody[] rigidbodies = gameObject.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody body in rigidbodies)
            {
                body.isKinematic = flag;
            }
        }
    }
}