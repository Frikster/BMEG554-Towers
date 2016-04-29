using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using Leap.Unity;

public class PreviousButton : MonoBehaviour
{

    private GameObject InstructionObject;
    private Text Instructions;
    private GameObject nextButton;

    private GameObject surfaceCanvas;
    private GameHandler gameHandler;

    private int caseSwitchHandedness = 1;
    private bool pinchMode = false;

    private int ind = -1;
    private int[][] target = new int[12][];

    // Use this for initialization
    void Start()
    {
        InstructionObject = GameObject.FindGameObjectWithTag("Instructions");
        Instructions = InstructionObject.GetComponent<Text>();
        nextButton = GameObject.FindGameObjectWithTag("NextButton");
        surfaceCanvas = GameObject.FindGameObjectWithTag("SurfaceCanvas");
        gameHandler = surfaceCanvas.GetComponent<GameHandler>();

        int[] a1 = { 0, 0, 0 };
        int[] a2 = { 0, 1, 0 };
        int[] a3 = { 0, 2, 0 };
        int[] a4 = { 0, 0, 1 };
        int[] a5 = { 0, 1, 1 };
        int[] a6 = { 0, 2, 1 };
        int[] a7 = { 1, 0, 0 };
        int[] a8 = { 1, 1, 0 };
        int[] a9 = { 1, 2, 0 };
        int[] a10 = { 1, 0, 1 };
        int[] a11 = { 1, 1, 1 };
        int[] a12 = { 1, 2, 1 };
        int[][] source = { a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12 };
        Array.Copy(source, target, 12);
    }

    void OnTriggerEnter(Collider col)
    {
        ind = ind - 1;
        if (ind < 0)
        {
            ind = target.Length - 1;
        }
        gameHandler.setRules(target[ind]);
    }

}
