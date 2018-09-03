using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class DetectFigure : MonoBehaviour
{

    public Text figureCompleted;

    private Vector3 updateAngleValue;

    private int angleMinStep;
    private int loopState;

    private bool loopCompleted = false;
    private bool quarterLoopCompleted = false;
    private bool halfLoopCompleted = false;


    // Use this for initialization
    void Start()
    {
        loopState = 0;
        figureCompleted.enabled = false;
        loopCompleted = false;
        quarterLoopCompleted = false;
        halfLoopCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {

        updateAngleValue = transform.rotation.eulerAngles;
        //Debug.Log("loop State = " + loopState);


        Debug.Log(updateAngleValue.x);

        Debug.Log("angle min = " + angleMinStep);

        if (loopState == 0)
        {
            angleMinStep = 350;

            if (updateAngleValue.x >= 340)
            {
                loopState = 1;
            }


        }

        if (updateAngleValue.x > angleMinStep && !quarterLoopCompleted || updateAngleValue.x < angleMinStep && loopState >= 6 && quarterLoopCompleted && !halfLoopCompleted || updateAngleValue.x < angleMinStep && loopState >= 10)
        {
            loopState = 0;

            Debug.Log("holé");

        }


        if (loopState >= 1)
        {
            figureCompleted.enabled = true;
            figureCompleted.text = loopState + " Completed";
        }
        else
        {
            figureCompleted.enabled = false;
        }


        if (loopState == 1)
        {
            if (updateAngleValue.x < 340 && !quarterLoopCompleted)
            {
                loopState++;
                angleMinStep = 340;
            }
        }

        if (loopState == 2)
        {
            if (updateAngleValue.x < 320 && updateAngleValue.x > 180)
            {
                loopState++;
                angleMinStep = 320;
            }
        }

        if (loopState == 3)
        {
            if (updateAngleValue.x < 300 && updateAngleValue.x > 180)
            {
                loopState++;
                angleMinStep = 300;
            }
        }

        if (loopState == 4)
        {
            if (updateAngleValue.x < 285)
            {
                loopState++;
                angleMinStep = 285;
            }
            quarterLoopCompleted = true;
        }

        if (loopState == 5)
        {
            if (updateAngleValue.x > 300)
            {
                loopState++;
                angleMinStep = 300;
            }
        }


        if (loopState == 6)
        {
            if (updateAngleValue.x > 320)
            {
                loopState++;
                angleMinStep = 320;
            }
        }

        if (loopState == 7)
        {
            if (updateAngleValue.x > 355)
            {
                loopState++;
                angleMinStep = 355;
            }

            halfLoopCompleted = true;

        }

        if (loopState == 8)
        {

            if (updateAngleValue.x < 10)
            {
                loopState++;
                angleMinStep = 10;
            }
        }

        if (loopState == 9)
        {
            if (updateAngleValue.x > 30)
            {
                loopState++;
                angleMinStep = 30;
            }
        }

        if (loopState == 10)
        {

            if (updateAngleValue.x > 50)
            {
                loopState++;
                angleMinStep = 50;
            }
        }

        if (loopState == 11)
        {

            if (updateAngleValue.x > 70)
            {
                loopState++;
                angleMinStep = 70;
            }
        }




    }
}