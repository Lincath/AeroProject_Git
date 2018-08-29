using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class DetectFigure : MonoBehaviour {

    public Text figureCompleted;

    private Vector3 updateAngleValue;

    private int angleMinStep;
    private int loopState;

    private bool loopFailed = false;

    // Use this for initialization
    void Start () {
        loopState = 0;
        figureCompleted.enabled = false;
        loopFailed = false;
    }
	
	// Update is called once per frame
	void Update () {

        updateAngleValue = transform.rotation.eulerAngles;
       
        //Debug.Log(updateAngleValue);

        if (updateAngleValue.x >= 340)
        {
           
            loopState = 1;
        }

        if (loopState >= 1 )
        {
            figureCompleted.enabled = true;
            figureCompleted.text = loopState + " Completed";
        }
        if (loopState == 0)
        {
            figureCompleted.enabled = true;
        }
        
        

        if (loopState == 1)
        {
            if (updateAngleValue.x < 340 && updateAngleValue.x > 180)
            {
                Debug.Log("done");
                loopState ++;
                angleMinStep = 340;
            }
        }

        /*if (loopFailed && updateAngleValue.x > 350)
        {
            figureCompleted.enabled = false;
            //loopFailed = false;
        }*/

        
        if (updateAngleValue.x > angleMinStep)
        {
            loopFailed = true;
            loopState = 0;
            
        }

        if (loopState == 2)
        {
            if (updateAngleValue.x < 320 && updateAngleValue.x > 180)
            {
                loopState ++;
                angleMinStep = 320;
            }
        }

        if (loopState == 3)
        {
            if (updateAngleValue.x < 300 && updateAngleValue.x > 180)
            {
                loopState ++;
            }
        }

        Debug.Log("loop State = " + loopState);



    }
}