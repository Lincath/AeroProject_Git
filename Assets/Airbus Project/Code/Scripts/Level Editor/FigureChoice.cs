using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FigureChoice : MonoBehaviour {
    /// <summary>
    /// Update les tableaux pour stocker les enchainements de figures, 20 events max de 5 figures Max
    /// Index Figure : 
    /// 0 = End
    /// 1 = Loop
    /// 2 = montée
    /// </summary>

    private static int numberStage = 20;
    private static int numberFigureTotal = 5;

    public int[,] numberFigureArray = new int[numberStage, numberFigureTotal];

    private int curentNumberLevel = 0;
    private int numberFigure;

    private bool endFigure = false;


    public Text[] textArray;

    private string carre = "square";
    private string nameFigure;
    private Text holly;

    // Use this for initialization
    void Start () {

        numberFigure = 0;

        for (int i = 0; i < textArray.Length; i++)
        {
            textArray[i].text = " ";
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void clickButtonFigureChoice (int numeroFigure)
    {
        Debug.Log(nameFigure);

        if (numeroFigure == 0 || )
        {
            endFigure = true;
        }
        
        if(!endFigure)
        {
            numberFigureArray[curentNumberLevel, numberFigure] = numeroFigure;
            textArray[numberFigure].text = nameFigure;
            numberFigure++;
            
        }

        /*
        for (int i = 0; i < textArray.Length; i++)
        {
            Debug.Log(numberFigureArray[curentNumberLevel, i]);
        }*/

    } 
    
    public void getNameFigure(string name)
    {
        nameFigure = name;        
    }
    

}
