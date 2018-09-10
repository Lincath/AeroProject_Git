
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoopPrefabFigure : MonoBehaviour
{
    
    private GameObject objectOnCollider;
    public int numberOnLoop;
    private string numberOnLoopString;
    private string numberOnLoopStringMoreOne;

    public bool alreadyIncrease;

    public Text CheckpointSuccess;

    public int checkPointPassageSuccess;

    public string figureName;

    public GameObject nextCheckpoint;
    public GameObject CurrentCheckpoint;

    private int nbrPerfect;
    private int nbrGood;
    private int nbrBad;



    void Start()
    {
        numberOnLoop = 1;
        checkPointPassageSuccess = 0;
        CheckpointSuccess.enabled = false;
        alreadyIncrease = false;
        Getcheckpoint(true);
    }


    void Update()
    {

    }

    void Getcheckpoint(bool callOnstart)
    {
        if (callOnstart)
        {
            numberOnLoopString = numberOnLoop.ToString();
            CurrentCheckpoint = GameObject.Find(numberOnLoopString);

            if (CurrentCheckpoint.transform.root != transform)
            {
                //Debug.Log("is a child !");
                CurrentCheckpoint = CurrentCheckpoint.transform.parent.gameObject;
            }
           
            feedBackCheckPoint sn = CurrentCheckpoint.GetComponent<feedBackCheckPoint>();
            sn.setActiveArrows();
        }

        else
        {
            numberOnLoopStringMoreOne = (numberOnLoop + 1).ToString();
            nextCheckpoint = GameObject.Find(numberOnLoopStringMoreOne);
            //Debug.Log(nextCheckpoint);

            if (nextCheckpoint == null)
            {
                nextCheckpoint = GameObject.Find("endFigure");
            }


            if (nextCheckpoint.transform.root != transform && nextCheckpoint.transform.parent.name == nextCheckpoint.name)
            {
                    // Debug.Log("is a child !");
                    nextCheckpoint = nextCheckpoint.transform.parent.gameObject;
            }
            feedBackCheckPoint sn = nextCheckpoint.GetComponent<feedBackCheckPoint>();
            sn.setActiveArrows();
            
        }

    }


    void OnTriggerEnter(Collider other)
    {
        CheckpointSuccess.enabled = false;
        Renderer m_Renderer = other.gameObject.GetComponent<Renderer>();
        numberOnLoopString = numberOnLoop.ToString();
        Getcheckpoint(false);


        //Debug.Log(numberOnLoopString);

        if (m_Renderer != null)
        {
            m_Renderer.enabled = false;
        }

        if (other.gameObject.name == numberOnLoopString)
        {
            if (other.gameObject.tag == "small")
            {
                checkPointPassageSuccess = 1;
            }
            else if (other.gameObject.tag == "medium")
            {
                checkPointPassageSuccess = 2;

            }
            else if(other.gameObject.tag == "large")
            {
                
                checkPointPassageSuccess = 3;
            }

        }

        else if (other.gameObject.name == "endFigure")
        {
            if (other.gameObject.tag == "small")
            {
                checkPointPassageSuccess = 5;
            }
            else if (other.gameObject.tag == "medium")
            {
                checkPointPassageSuccess = 6;

            }
            else if (other.gameObject.tag == "large")
            {
                checkPointPassageSuccess = 7;
            }

            numberOnLoop = 0;
        }

        else
        {
            checkPointPassageSuccess = 4;
        }

        alreadyIncrease = false;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "large")
        {
            CheckpointSuccess.enabled = true;


            if (checkPointPassageSuccess == 1)
            {
                Debug.Log("Perfect !!");

                CheckpointSuccess.text = "Perfect !!";
                
            }

            else if(checkPointPassageSuccess == 2)
            {
                //Debug.Log("Good !");

                CheckpointSuccess.text = "Good !";
            }

            else if(checkPointPassageSuccess == 3)
            {
                //Debug.Log("Bad.");

                CheckpointSuccess.text = "Bad.";
            }

            else if (checkPointPassageSuccess == 4)
            {
                //Debug.Log("Miss...");

                CheckpointSuccess.text = "Miss...";
            }

            else if (checkPointPassageSuccess == 5)
            {

                CheckpointSuccess.text = "Perfect !!" + "\n" + figureName + " finish";
                Handheld.Vibrate();
            }
            else if (checkPointPassageSuccess == 6)
            {

                CheckpointSuccess.text = "Good !" + "\n" + figureName + " finish";
                Handheld.Vibrate();
            }
            else if (checkPointPassageSuccess == 7)
            {

                CheckpointSuccess.text = "Bad" + "\n" + figureName + " finish";
                Handheld.Vibrate();
            }


            if (!alreadyIncrease)
            {
                numberOnLoop++;
                alreadyIncrease = true;
            }

            checkPointPassageSuccess = 0;
           


        }
            
    }

}
