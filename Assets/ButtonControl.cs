using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonControl : MonoBehaviour
{
    public Image DeathTimerBar;
    private GameObject InstructionObject;
    private Text Instructions;
    private GameObject okButton;

    private bool resetButton = false;

    public string SceneName;
    public GameObject TowerSets;


    // Use this for initialization
    void Start()
    {
        InstructionObject = GameObject.FindGameObjectWithTag("Instructions");
        Instructions = InstructionObject.GetComponent<Text>();
        okButton = GameObject.FindGameObjectWithTag("Button");
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name != "Plane")
        {
            //Debug.Log("TRIGGER BUTTON");
            if (resetButton)
            {
                resetButton = false;
                SceneManager.LoadScene(SceneName);
            }
            DeathTimerBar.enabled = true;
            Instructions.enabled = false;
            okButton.SetActive(false);
            KinematicSwitch(TowerSets, false);
        }
    }

    public void setAsResetButton(bool flag)
    {
        resetButton = flag;
    }

    public bool asResetButton()
    {
        return resetButton;
    }

    public void KinematicSwitch(GameObject gameObject, bool flag)
    {
        //Debug.Log("gameObject in KinematicSwitch: " + gameObject);
        Rigidbody[] rigidbodies = gameObject.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody body in rigidbodies)
        {
            body.isKinematic = flag;
        }
    }

}
