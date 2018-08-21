using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class DetectFigure : MonoBehaviour
{

    public Text figureCompleted;
    public Text loopStateText;
    public Text AngleText;


    private Vector3 updateAngleValue;


    private int angleMinStep;
    private int loopState;


    private bool loopCompleted = false;
    private bool quarterLoopCompleted = false;
    private bool halfLoopCompleted = false;
    private bool enterLoop = false;

    private bool onLoop = false;
   


    private bool bareelRollCompleted = false;


    private float SetcountDownUIfigure;
    private float countDownUIfigure;

    private float inclinaisonPhoneEnterLoop = 0.0f;


    // Use this for initialization
    void Start()
    {
        loopState = 0;
        figureCompleted.enabled = false;
        loopCompleted = false;
        quarterLoopCompleted = false;
        halfLoopCompleted = false;
        enterLoop = false;

        onLoop = false;

        bareelRollCompleted = false;
        SetcountDownUIfigure = 2.0f;
        countDownUIfigure = SetcountDownUIfigure;
    }

    // Update is called once per frame
    void Update()
    {
        if (onLoop)
        {
            loopStateText.enabled = true;
            loopStateText.text = "dans la loop";
        }
        else
        {
            loopStateText.enabled = false;
        }

        updateAngleValue = transform.rotation.eulerAngles;
        //Debug.Log("loop State = " + loopState);
        //Debug.Log(updateAngleValue.x);
        //Debug.Log("angle min = " + angleMinStep);

        //loopStateText.text = "Step = " + loopState.ToString();
        //AngleText.text = "Angle = " + Mathf.Round(updateAngleValue.x).ToString();


        if (Input.touchCount > 0) //PARTIE OU ON APPUIE SUR L'ECRAN
        {
            //Debug.Log("loop State = " + loopState);
            //Debug.Log(updateAngleValue.x);
            //Debug.Log("angle min = " + angleMinStep);
        }


        if (loopState == 0)
        {
            angleMinStep = 350;

            if (updateAngleValue.x >= 340)
            {
                loopState = 1;
                Debug.Log("On recommence");
                inclinaisonPhoneEnterLoop = Input.acceleration.y;
            }
        }
        

        if (loopState > 0)
        {
            if (Input.acceleration.y >0 )
            {
                loopState = 0;
                enterLoop = false;
                quarterLoopCompleted = false;
                halfLoopCompleted = false;
                enterLoop = false;

                Debug.Log("holé");
                onLoop = false;

            }
        }


        if (loopCompleted)
        {
            countDownUIfigure -= Time.deltaTime;
            figureCompleted.enabled = true;
            figureCompleted.text = "loop compleed";
            loopState = 0;
            quarterLoopCompleted = false;
            halfLoopCompleted = false;
            enterLoop = false;
            if (countDownUIfigure <= 0)
            {
                countDownUIfigure = SetcountDownUIfigure;
                loopCompleted = false;
            }

        }
        else
        {
            figureCompleted.enabled = false;
        }

        if (enterLoop)
        {
            detectLoop();
        }
        

        if (loopState == 1)
        {
            Debug.Log("state 1");
                if (updateAngleValue.x < 340 && !quarterLoopCompleted)
                {
                    loopState++;
                    angleMinStep = 340;
                    enterLoop = true;
                }           
        } 
        
    }

    void detectLoop()
    {
        onLoop = true;

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


        if (loopState == 12)
        {

            if (updateAngleValue.x < 88)
            {
                loopState++;
                angleMinStep = 70;
            }
        }

        if (loopState == 13)
        {

            if (updateAngleValue.x < 30)
            {
                loopState++;
                angleMinStep = 70;

            }
        }


        if (loopState == 14)
        {

            if (updateAngleValue.x < 5)
            {
                loopCompleted = true;
                Debug.Log("JE SUIS LA");
            }
        }
    }
}