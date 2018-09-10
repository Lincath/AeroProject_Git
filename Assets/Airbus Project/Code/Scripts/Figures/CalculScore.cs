using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculScore : MonoBehaviour {

    private float perfectScore;
    private float goodScore;
    private float badScore;

    private float scoreTotal;

    private float pourcentGood;
    private float pourcentBad;

    private float nbrCheckpoint;

    private float scoreFigure;


    // Use this for initialization
    void Start () {

        scoreFigure = 100;

        pourcentGood = 50;
        pourcentBad = 25;


        if (gameObject.transform.name == "loopCollider")
        {
            nbrCheckpoint = 10;
           
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


	
    public void ScoreTotalFigure (int nbrPerfect, int nbrGood, int nbrBad)
    {

        if (nbrPerfect + nbrGood + nbrBad == nbrCheckpoint)
        {

            scoreTotal = (perfectScore * nbrPerfect) + (goodScore * nbrGood) + (badScore * nbrBad);
            Debug.Log(scoreTotal);
        }

        else
        {
            Debug.Log("error");
            scoreTotal = scoreFigure / 2;
        }

    }
        
}
