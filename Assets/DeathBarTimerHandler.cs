using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Leap.Unity;

public class DeathBarTimerHandler : MonoBehaviour {
    public Image DeathTimerBar;
    public float DecreaseAmount;
    private GameObject InstructionObject;
    private Text Instructions;
    private GameObject okButton;

    public string SceneName;
    public Transform TowerSets;
    public GameObject TowerSets_obj;
    private BlockPlacementChecker[] TowerChildrenScripts;

    private bool flag = false;
    private BlockPlacementChecker victoryChecker;
    private GameObject ButtonObject;
    private ButtonControl buttonControl;

    private GameObject leftHandPhysics;
    private GameObject rightHandPhysics;

    private GameObject controllerGameObject;
    private LeapServiceProvider leapServiceProviderScript;
    //protected Controller leap_controller_;

    // Use this for initialization
    void Start () {
        InstructionObject = GameObject.FindGameObjectWithTag("Instructions");
        Instructions = InstructionObject.GetComponent<Text>();
        okButton = GameObject.FindGameObjectWithTag("Button");
        TowerChildrenScripts = TowerSets.GetComponentsInChildren<BlockPlacementChecker>();
        ButtonObject = GameObject.FindGameObjectWithTag("Button");
        buttonControl = ButtonObject.GetComponent<ButtonControl>();
        leftHandPhysics = GameObject.FindGameObjectWithTag("Left");
        rightHandPhysics = GameObject.FindGameObjectWithTag("Left");

        controllerGameObject = GameObject.FindGameObjectWithTag("GameController");
        leapServiceProviderScript = controllerGameObject.GetComponent<LeapServiceProvider>();
        //leap_controller_ = leapServiceProviderScript.GetLeapController();
    }
	
	// Update is called once per frame
	void Update () {
        if (DeathTimerBar.enabled) {

            DeathTimerBar.fillAmount -= DecreaseAmount * Time.deltaTime;

            if (DeathTimerBar.fillAmount <= 0)
            {
                //this.enabled = false;
                //SceneManager.LoadScene(SceneName);
                Instructions.text = "You Lose!";
                Instructions.enabled = true;
                okButton.SetActive(true);
                DeathTimerBar.enabled = false;
                buttonControl.setAsResetButton(true);
                KinematicSwitch(TowerSets_obj, true);
                //leap_controller_.StopConnection();
                // leap_controller_.StartConnection();
            }

            foreach (BlockPlacementChecker scrip in TowerChildrenScripts)
            {
                //victoryChecker = child.GetComponent<BlockPlacementChecker>();
                flag = scrip.AllBlocksCorrectlyPlaced();
                if (!flag)
                {
                    break;
                }
            }

            if (flag)
            {
                Instructions.text = "You Win!";
                Instructions.enabled = true;
                okButton.SetActive(true);
                DeathTimerBar.enabled = false;
                buttonControl.setAsResetButton(true);
                KinematicSwitch(TowerSets_obj, true);
                // leap_controller_.StopConnection();
                // leap_controller_.StartConnection();
                //SceneManager.LoadScene(SceneName);
            }

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
