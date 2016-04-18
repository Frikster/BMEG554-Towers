using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Leap.Unity
{
    public class ToggleControls : MonoBehaviour
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

        public void buttonTest()
        {
            Debug.Log("ButtonClicked!");
        }

        // Use this for initialization
        void Start()
        {
            greenPlane = GameObject.FindGameObjectWithTag("Finish");
            redPlane = GameObject.FindGameObjectWithTag("Respawn");

            controllerGameObject = GameObject.FindGameObjectWithTag("GameController");
            leapServiceProviderScript = controllerGameObject.GetComponent<LeapServiceProvider>();
            leap_controller_ = leapServiceProviderScript.GetLeapController();

            // Frame frame = controller.Frame();
        }


        protected void UpdateHand(GameObject handPhysics, Hand hand)
        {
            GrabbingHand grabAndPinchScript = handPhysics.GetComponent<GrabbingHand>();
            grabAndPinchScript.pinchMode = pinchMode;
            Debug.Log("grabAndPinchScript.pinchMode: " + grabAndPinchScript.pinchMode);
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

            if (Input.GetKeyUp(KeyCode.Keypad2))
            {
                pinchMode = !pinchMode;
                Debug.Log("pinchMode = " + pinchMode);
            }

            
            try
            {
                rightHandPhysics = GameObject.FindGameObjectWithTag("Right");
                CollisionsSwitch(rightHandPhysics, false);
                GrabbingHand grabAndPinchScript = rightHandPhysics.GetComponent<GrabbingHand>();
                grabAndPinchScript.enabled = true;
                rigidHandScript = rightHandPhysics.GetComponent<RigidHand>();
                Hand hand = rigidHandScript.GetLeapHand();
                Debug.Log("Hand: " + hand);
                UpdateHand(rightHandPhysics, hand);             
            }
            catch
            {
                Debug.Log("No Right hand GameObject");
            }

            try
            {
                leftHandPhysics = GameObject.FindGameObjectWithTag("Left");
                CollisionsSwitch(leftHandPhysics, false);
                GrabbingHand grabAndPinchScript = leftHandPhysics.GetComponent<GrabbingHand>();
                grabAndPinchScript.enabled = true;
                rigidHandScript = leftHandPhysics.GetComponent<RigidHand>();
                Hand hand = rigidHandScript.GetLeapHand();
                Debug.Log("Hand: " + hand);
                UpdateHand(leftHandPhysics, hand);
            }
            catch
            {
                Debug.Log("No Left hand GameObject");
            }


            //try
            //{
            //    leftHandPhysics = GameObject.FindGameObjectWithTag("Left");
            //    CollisionsSwitch(leftHandPhysics, false);
            //    grabAndPinchScriptLeft = leftHandPhysics.GetComponent<GrabbingHand>();
            //    grabAndPinchScriptLeft.pinchMode = pinchMode;
            //    Debug.Log("grabAndPinchScriptLeft.pinchMode" + grabAndPinchScriptLeft.pinchMode);
            //    if (caseSwitchHandedness == 3)
            //    {
            //        grabAndPinchScriptLeft.enabled = true;
            //    }
            //}
            //catch
            //{
            //    Debug.Log("Left hand not in scene");
            //}

            //try
            //{
            //    leftHandPhysics = GameObject.FindGameObjectWithTag("Left");
            //    CollisionsSwitch(leftHandPhysics, false);
            //    rigidHandScript = leftHandPhysics.GetComponent<RigidHand>();
            //    Hand hand = rigidHandScript.GetLeapHand();
            //    if (hand.IsLeft)
            //    {
            //        UpdateLeftHand(leftHandPhysics);
            //    }
            //    else
            //    {
            //        UpdateRightHand(leftHandPhysics);
            //    }
            //}
            //catch
            //{
            //    Debug.Log("No Left hand GameObject");
            //}
            




            
            //try
            //{
            //    rightHandPhysics = GameObject.FindGameObjectWithTag("Right");
            //    CollisionsSwitch(rightHandPhysics, false);
            //    grabAndPinchScriptRight = rightHandPhysics.GetComponent<GrabbingHand>();
            //    grabAndPinchScriptRight.pinchMode = pinchMode;
            //    Debug.Log("grabAndPinchScriptRight.pinchMode" + grabAndPinchScriptRight.pinchMode);
            //    if (caseSwitchHandedness == 1)
            //    {
            //        grabAndPinchScriptRight.enabled = false;
            //    }
            //}
            //catch
            //{
            //    Debug.Log("Right hand not in scene");
            //}



            ////try
            //{
            //    leftHandPhysics = GameObject.FindGameObjectWithTag("Left");
            //    CollisionsSwitch(leftHandPhysics, false);
            //    grabAndPinchScriptLeft = leftHandPhysics.GetComponent<GrabbingHand>();
            //    grabAndPinchScriptLeft.pinchMode = pinchMode;
            //    Debug.Log("grabAndPinchScriptLeft.pinchMode" + grabAndPinchScriptLeft.pinchMode);
            //    if (caseSwitchHandedness == 3)
            //    {
            //        grabAndPinchScriptLeft.enabled = true;
            //    }
            //}
            //catch
            //{
            //    Debug.Log("Left hand not in scene");
            //}


            //try
            //{
            //    if (caseSwitchHandedness == 2)
            //    {
            //        grabAndPinchScriptRight.enabled = true;
            //        grabAndPinchScriptLeft.enabled = false;
            //    }
            //}
            //catch
            //{
            //    Debug.Log("Both hands not in scene");
            //}

            // Just here to keep track of handedness. Can delete later
            //if (leftHandPhysics != null && rightHandPhysics != null)
            //{
            //    Debug.Log("leftHandPhysics.activeSelf = " + leftHandPhysics.activeSelf);
            //    Debug.Log("rightHandPhysics.activeSelf = " + rightHandPhysics.activeSelf);
            //    Debug.Log("grabAndPinchScriptRight.enabled " + grabAndPinchScriptRight.enabled);
            //    Debug.Log("grabAndPinchScriptLeft.enabled " + grabAndPinchScriptLeft.enabled);
            //}

            if (Input.GetKeyUp(KeyCode.Keypad1))
            {
                Debug.Log("KEYPAD1 " + caseSwitchHandedness);
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

        void CollisionsSwitch(GameObject gameObject, bool flag)
        {
            Debug.Log("gameObject in CollisionsSwitch: " + gameObject);
            Rigidbody[] rigidbodies = gameObject.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody body in rigidbodies)
            {
                body.detectCollisions = flag;
            }
        }
    }
}