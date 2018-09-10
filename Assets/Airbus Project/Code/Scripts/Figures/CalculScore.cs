using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculScore : MonoBehaviour {

    private float perfectScore;
    private float goodScore;
    private float badScore;

    private float scoreTotal;

    private float pourcentGood;
    private float pourcentBad;

    private float nbrCheckpoint;

    private float scoreFigure;

    private GameObject plane;
    private LoopPrefabFigure scriptPrefab;


    // Use this for initialization
    void Start () {

        scoreFigure = 100;

        pourcentGood = 50;
        pourcentBad = 25;
        plane =  GameObject.FindWithTag("plane");
        scriptPrefab = plane.GetComponent<LoopPrefabFigure>();
        


        if (gameObject.transform.name == "loopCollider")
        {
            nbrCheckpoint = 12;
           
        }
        else
        {
            Debug.Log("error");
        }
    
        perfectScore = scoreFigure/ nbrCheckpoint;
        goodScore = perfectScore * (pourcentGood / 100);
        badScore = perfectScore * (pourcentBad / 100);

       /* Debug.Log(perfectScore);
        Debug.Log(goodScore);
        Debug.Log(badScore);*/
        
    }



	
    public void scoreTotalFigure (int nbrPerfect, int nbrGood, int nbrBad, int nbrMiss)
    {
        Debug.Log("Perfect = " + nbrPerfect);
        Debug.Log("Good = " + nbrGood);
        Debug.Log("Bad = " + nbrBad);
        Debug.Log("Miss = " + nbrMiss);

        if (nbrPerfect + nbrGood + nbrBad + nbrMiss == nbrCheckpoint)
        {
            Debug.Log("not an error ! ");

            scoreTotal = (perfectScore * nbrPerfect) + (goodScore * nbrGood) + (badScore * nbrBad);
            scriptPrefab.scoreTxt.enabled = true;
            scriptPrefab.CheckpointSuccess.enabled = true;
            scriptPrefab.scoreTxt.text = scoreTotal.ToString();



            


            if (scoreTotal == 100)
            {
                scriptPrefab.CheckpointSuccess.text = "PERFECT Figure !";
            }
            else
            {
                scriptPrefab.CheckpointSuccess.text = "Figure finished";
            }

            //Debug.Log(scoreTotal);
            Destroy(gameObject);
        }

        else
        {
            Debug.Log("error");
            scoreTotal = scoreFigure / 2;

        }

        Destroy(gameObject);
    }
    
}
