using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class DetectFigure : MonoBehaviour
{
    #region allVariable

    public Text figureCompleted;
<<<<<<< HEAD
    public Text loopStateText;
    public Text AngleText;

    private static float inclinMinY = 0;
=======
>>>>>>> parent of 58ec681... Loop presque complet !!

    private Vector3 updateAngleValueEuler;
    private Quaternion updateAngleValueQuaternion;
    

<<<<<<< HEAD

    private int angleMinStepLoop;
    private int angleMinStepInvertedLoop;
    private int angleMinStepLeftBareel;
    private int angleMinStepRightBareel;

    private int stepLoop;
    private int stepInvertedLoop;
    private int stepLeftBareel;
    private int stepRightBareel;
=======
    private int angleMinStep;
    private int loopState;
>>>>>>> parent of 58ec681... Loop presque complet !!

    private bool loopCompleted = false;
    private bool invertedLoopCompleted = false;
    private bool leftBareelCompleted = false;
    private bool rightBareelCompleted = false;

    private bool quarterLoopCompleted = false;
    private bool halfLoopCompleted = false;
<<<<<<< HEAD
    private bool onLoop = false;

    private bool enterLoop = false;
    private bool enterInvertedLoop = false;
    private bool enterLeftBareel = false;
    private bool enterRightBareel = false;

    

    private float SetcountDownUIfigure;
    private float countDownUIfigure;

    private float inclinaisonPhoneEnterLoop = 0.0f;
=======
>>>>>>> parent of 58ec681... Loop presque complet !!

    #endregion


    void Start()
    {
        stepLoop = 0;
        stepLeftBareel = 0;
        stepInvertedLoop = 0;
        figureCompleted.enabled = false;
        loopCompleted = false;
        invertedLoopCompleted = false;

        quarterLoopCompleted = false;
        halfLoopCompleted = false;
<<<<<<< HEAD

        enterLeftBareel = false;
        onLoop = false;
        leftBareelCompleted = false;
        SetcountDownUIfigure = 2.0f;
        countDownUIfigure = SetcountDownUIfigure;


        AccelerometerInputButton AccelerometerInputButton = GetComponent<AccelerometerInputButton>();
=======
>>>>>>> parent of 58ec681... Loop presque complet !!
    }


    void Update()
    {
<<<<<<< HEAD
        updateAngleValueEuler = transform.localEulerAngles;
        updateAngleValueQuaternion = transform.rotation;
        inclinMinY = AccelerometerInputButton.inclinMinY;

        loopStateText.text = "Step = " + stepInvertedLoop.ToString();
        AngleText.text = "Angle = " + updateAngleValueEuler.x.ToString();

        #region allDebug
        //updateAngleValueEuler = transform.rotation.eulerAngles;
        //Debug.Log("BAREEL State = " + stepLeftBareel);
        //Debug.Log(updateAngleValueEuler.x);
        //Debug.Log("angle min = " + angleMinStepLoop);
        //Debug.Log(updateAngleValueEuler.z);
        //Debug.Log(updateAngleValueEuler.z );
        //Debug.Log(updateAngleValueQuaternion.z);
        #endregion
        

        #region Commencement Bareel left and right

        /////////////////////////////////////
        ///////Bareel vers la gauche/////////
        /////////////////////////////////////

        if (stepLeftBareel == 0)
        {
            if (updateAngleValueEuler.z > 20 && updateAngleValueEuler.z < 30)
            {
                angleMinStepLeftBareel = 20;
                stepLeftBareel = 1;
            }
        }

        if (stepLeftBareel == 1)
        {
            if (updateAngleValueEuler.z > 40 && angleMinStepLeftBareel == 20 )
            {
                angleMinStepLeftBareel = 40;
                stepLeftBareel = 2;
               enterLeftBareel = true;
            }
        } 

        /////////////////////////////////////
        ///////Bareel vers la droite/////////
        /////////////////////////////////////

        if (stepRightBareel == 0)
        {
            if (updateAngleValueEuler.z < 340 && updateAngleValueEuler.z > 330)
            {
                angleMinStepRightBareel = 340;
                stepRightBareel = 1;
            }
        }
=======

        updateAngleValue = transform.rotation.eulerAngles;
        //Debug.Log("loop State = " + loopState);
        //Debug.Log(updateAngleValue.x);
        //Debug.Log("angle min = " + angleMinStep);

>>>>>>> parent of 58ec681... Loop presque complet !!

        if (stepRightBareel == 1)
        {
            if (updateAngleValueEuler.z < 320 && angleMinStepRightBareel == 340)
            {
               
                angleMinStepRightBareel = 320;
                stepRightBareel = 2;
                enterRightBareel = true;
            }
        }
        #endregion
        
        if (stepLoop == 0)
        {
            angleMinStepLoop = 350;

            if (updateAngleValueEuler.x >= 340)
            {
<<<<<<< HEAD
                stepLoop = 1;
                inclinaisonPhoneEnterLoop = Input.acceleration.y;
=======
                loopState = 1;
>>>>>>> parent of 58ec681... Loop presque complet !!
            }


        }

<<<<<<< HEAD
        if (stepLoop == 1)
        {
            if (updateAngleValueEuler.x < 340 && !quarterLoopCompleted)
            {
                stepLoop++;
                angleMinStepLoop = 340;
                enterLoop = true;
            }
        }



        if (stepInvertedLoop == 0)
        {
            angleMinStepInvertedLoop = 10;

            if(updateAngleValueEuler.x <= 20)
            {
                stepInvertedLoop = 1;
            }

        }

        if (stepInvertedLoop == 1)
        {

            if (updateAngleValueEuler.x > 40 && updateAngleValueEuler.x < 180)
            {
                stepInvertedLoop++;
                angleMinStepInvertedLoop = 30;
                enterInvertedLoop = true;
            }

        }


        #region figure completed
        if (loopCompleted)
=======
        if (updateAngleValue.x > angleMinStep && !quarterLoopCompleted || updateAngleValue.x < angleMinStep && loopState >= 6 && quarterLoopCompleted && !halfLoopCompleted || updateAngleValue.x < angleMinStep && loopState >= 10 && loopState < 4 || updateAngleValue.x > angleMinStep && loopState >= 15)
        {
            loopState = 0;

           // Debug.Log("holé");

        }

        if (loopCompleted )
>>>>>>> parent of 58ec681... Loop presque complet !!
        {
            figureCompleted.enabled = true;
            figureCompleted.text = "loop completed";
            stepLoop = 0;
            quarterLoopCompleted = false;
            halfLoopCompleted = false;

        }
<<<<<<< HEAD
        else if(leftBareelCompleted)
        {
            countDownUIfigure -= Time.deltaTime;
            figureCompleted.enabled = true;
            figureCompleted.text = "bareel left completed";
            stepLeftBareel = 0;
            if (countDownUIfigure <= 0)
            {
                countDownUIfigure = SetcountDownUIfigure;
                leftBareelCompleted = false;
            }
        }

        else if (rightBareelCompleted)
        {
            countDownUIfigure -= Time.deltaTime;
            figureCompleted.enabled = true;
            figureCompleted.text = "bareel right completed";
            stepRightBareel = 0;
            if (countDownUIfigure <= 0)
            {
                countDownUIfigure = SetcountDownUIfigure;
                rightBareelCompleted = false;
            }
        }
        else
        {
            figureCompleted.enabled = false;
        }
        #endregion
        

        #region EnterFigure
        if (enterLoop)
        {
            detectLoop();
        }
=======


>>>>>>> parent of 58ec681... Loop presque complet !!

        if (enterInvertedLoop)
        {
<<<<<<< HEAD
            detectInvertedLoop();
        }

        if (enterLeftBareel)
        {
            detectLeftBareel();
        }

        if (enterRightBareel)
        {
            detectRightBareel();
        }

       
        #endregion

    }


    void detectLoop()
    {
        onLoop = true;
=======
            if (updateAngleValue.x < 340 && !quarterLoopCompleted)
            {
                loopState++;
                angleMinStep = 340;
            }
        }
>>>>>>> parent of 58ec681... Loop presque complet !!


        if (Input.acceleration.y - inclinMinY > 0.2 || Input.acceleration.x > 0.2 || Input.acceleration.x < -0.2)
        {
            stepLoop = 0;
            enterLoop = false;
            quarterLoopCompleted = false;
            halfLoopCompleted = false;
            enterLoop = false;

            //Debug.Log("holé");
            onLoop = false;

        }


        
        if (stepLoop == 2)
        {
            if (updateAngleValueEuler.x < 320 && updateAngleValueEuler.x > 180)
            {
                stepLoop++;
                angleMinStepLoop = 320;
            }
        }

        if (stepLoop == 3)
        {
            if (updateAngleValueEuler.x < 300 && updateAngleValueEuler.x > 180)
            {
                stepLoop++;
                angleMinStepLoop = 300;
            }
        }

        if (stepLoop == 4)
        {
            if (updateAngleValueEuler.x < 285)
            {
                stepLoop++;
                angleMinStepLoop = 285;
            }
            quarterLoopCompleted = true;
        }

        if (stepLoop == 5)
        {
            if (updateAngleValueEuler.x > 300)
            {
                stepLoop++;
                angleMinStepLoop = 300;
            }
        }


        if (stepLoop == 6)
        {
            if (updateAngleValueEuler.x > 320)
            {
                stepLoop++;
                angleMinStepLoop = 320;
            }
        }

        if (stepLoop == 7)
        {
            if (updateAngleValueEuler.x > 355)
            {
                stepLoop++;
                angleMinStepLoop = 355;
            }

            halfLoopCompleted = true;

        }

        if (stepLoop == 8)
        {

            if (updateAngleValueEuler.x < 10)
            {
                stepLoop++;
                angleMinStepLoop = 10;
            }
        }

        if (stepLoop == 9)
        {
            if (updateAngleValueEuler.x > 30)
            {
                stepLoop++;
                angleMinStepLoop = 30;
            }
        }

        if (stepLoop == 10)
        {

            if (updateAngleValueEuler.x > 50)
            {
                stepLoop++;
                angleMinStepLoop = 50;
            }
        }

        if (stepLoop == 11)
        {

            if (updateAngleValueEuler.x > 70)
            {
                stepLoop++;
                angleMinStepLoop = 70;
            }
        }

<<<<<<< HEAD

        if (stepLoop == 12)
        {

            if (updateAngleValueEuler.x < 88)
=======
        
        if (loopState == 12)
        {

            if (updateAngleValue.x > 88)
>>>>>>> parent of 58ec681... Loop presque complet !!
            {
                stepLoop++;
                angleMinStepLoop = 70;
            }
        }

        if (stepLoop == 13)
        {

<<<<<<< HEAD
            if (updateAngleValueEuler.x < 30)
            {
                stepLoop++;
                angleMinStepLoop = 70;

=======
            if (updateAngleValue.x < 50)
            {
                loopState++;
                angleMinStep = 70;
>>>>>>> parent of 58ec681... Loop presque complet !!
            }
        }


        if (stepLoop == 14)
        {

<<<<<<< HEAD
            if (updateAngleValueEuler.x < 5)
            {
                loopCompleted = true;
            }
        }
    }


    void detectInvertedLoop()
    {
        if (updateAngleValueEuler.x < angleMinStepInvertedLoop)
        {
            stepInvertedLoop = 0;
            Debug.Log(updateAngleValueEuler.x);
            Debug.Log(angleMinStepInvertedLoop);
            enterInvertedLoop = false;
        }


        if (stepInvertedLoop == 2)
        {
            if (updateAngleValueEuler.x > 80 && updateAngleValueEuler.x < 180)
            {
                stepInvertedLoop++;
                angleMinStepInvertedLoop = 70;
            }
        }
        /*
        if (stepInvertedLoop == 3)
        {
            if (updateAngleValueEuler.x < 80 && updateAngleValueEuler.x < 180)
            {
                stepInvertedLoop++;
                angleMinStepInvertedLoop = 85;
            }
        }*/


    }


    void detectLeftBareel()
    {
        if (updateAngleValueEuler.z < angleMinStepLeftBareel)
        {
            stepLeftBareel = 0;
            enterLeftBareel = false;
        }

        if (stepLeftBareel == 2)
        {
            if (updateAngleValueEuler.z > 60 && updateAngleValueEuler.z < 70)
            {
                angleMinStepLeftBareel = 60;
                stepLeftBareel = 3;
                enterLeftBareel = true;
            }
        }

        if (stepLeftBareel == 3)
        {
            if (updateAngleValueEuler.z > 80 && updateAngleValueEuler.z < 90)
            {
                angleMinStepLeftBareel = 80;
                stepLeftBareel = 4;
                enterLeftBareel = true;
            }
        }

        if (stepLeftBareel == 4)
        {
            if (updateAngleValueEuler.z > 120 && updateAngleValueEuler.z < 130)
            {
                angleMinStepLeftBareel = 120;
                stepLeftBareel = 5;
                enterLeftBareel = true;
            }
        }

        if (stepLeftBareel == 5)
        {
            if (updateAngleValueEuler.z > 160 && updateAngleValueEuler.z < 170)
            {
                angleMinStepLeftBareel = 160;
                stepLeftBareel++;
                enterLeftBareel = true;
            }
        }

        if (stepLeftBareel == 6)
        {
            if (updateAngleValueEuler.z > 200 && updateAngleValueEuler.z < 210)
            {
                angleMinStepLeftBareel = 200;
                stepLeftBareel++;
                enterLeftBareel = true;
            }
        }

        if (stepLeftBareel == 7)
        {
            if (updateAngleValueEuler.z > 240 && updateAngleValueEuler.z < 250)
            {
                angleMinStepLeftBareel = 240;
                stepLeftBareel++;
                enterLeftBareel = true;
            }
        }

        if (stepLeftBareel == 8)
        {
            if (updateAngleValueEuler.z > 280 && updateAngleValueEuler.z < 290)
            {
                angleMinStepLeftBareel = 280;
                stepLeftBareel++;
                enterLeftBareel = true;
            }
        }

        if (stepLeftBareel == 9)
        {
            if (updateAngleValueEuler.z > 320 && updateAngleValueEuler.z < 330)
            {
                angleMinStepLeftBareel = 320;
                stepLeftBareel++;
                enterLeftBareel = true;
            }
        }


        if (stepLeftBareel == 10)
        {
            if (updateAngleValueEuler.z > 355)
            {
                leftBareelCompleted = true;
            }
        }

    }
    

    void detectRightBareel()
    {

        if (updateAngleValueEuler.z > angleMinStepRightBareel)
        {
            stepRightBareel = 0;
            //Debug.Log("yohohohoo !");
            enterRightBareel = false;
        }

        if (stepRightBareel == 2)
        {
            if (updateAngleValueEuler.z < 280 && updateAngleValueEuler.z > 270)
            {
                angleMinStepRightBareel = 280;
                stepRightBareel = 3;
                enterRightBareel = true;
            }
        }

        if (stepRightBareel == 3)
        {
            if (updateAngleValueEuler.z < 280 && updateAngleValueEuler.z > 270)
            {
                angleMinStepRightBareel = 280;
                stepRightBareel++;
                enterRightBareel = true;
            }
        }

        if (stepRightBareel == 4)
        {
            if (updateAngleValueEuler.z < 240 && updateAngleValueEuler.z > 230)
            {
                angleMinStepRightBareel = 240;
                stepRightBareel++;
                enterRightBareel = true;
            }
        }

        if (stepRightBareel == 5)
        {
            if (updateAngleValueEuler.z < 200 && updateAngleValueEuler.z > 190)
            {
                angleMinStepRightBareel = 200;
                stepRightBareel++;
                enterRightBareel = true;
            }
        }

        if (stepRightBareel == 6)
        {
            if (updateAngleValueEuler.z < 160 && updateAngleValueEuler.z > 150)
            {
                angleMinStepRightBareel = 160;
                stepRightBareel++;
                enterRightBareel = true;
            }
        }

        if (stepRightBareel == 7)
        {
            if (updateAngleValueEuler.z < 120 && updateAngleValueEuler.z > 110)
            {
                angleMinStepRightBareel = 120;
                stepRightBareel++;
                enterRightBareel = true;
            }
        }


        if (stepRightBareel == 8)
        {
            if (updateAngleValueEuler.z < 80 && updateAngleValueEuler.z > 70)
            {
                angleMinStepRightBareel = 80;
                stepRightBareel++;
                enterRightBareel = true;
            }
        }

        if (stepRightBareel == 9)
        {
            if (updateAngleValueEuler.z < 40 && updateAngleValueEuler.z > 30)
            {
                angleMinStepRightBareel = 40;
                stepRightBareel++;
                enterRightBareel = true;
            }
        }

        if (stepRightBareel == 10)
        {
            if (updateAngleValueEuler.z < 5)
            {
                rightBareelCompleted = true;
=======
            if (updateAngleValue.x < 30)
            {
                loopCompleted = true;
>>>>>>> parent of 58ec681... Loop presque complet !!
            }
        }
        
    }


    void detectLoop()
    {

    }
}