using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureManager : MonoBehaviour {

    private GameObject plane;
    private Vector3 planePosition;

    public GameObject[] prefabFigure;
    public bool alreadyPlace;

    private GameObject newFigure;
    private int futureFigure;

	// Use this for initialization
	void Start () {
        plane = GameObject.FindWithTag("plane");
        alreadyPlace = false;
        futureFigure = 0;

    }

    //LoopPrefabFigure()
    //setScript()
    // Update is called once per frame

    void Update () {

        if (Input.touchCount > 1 && !alreadyPlace)
        {
            placePlane();
        }



    }

    void placePlane()
    {
        planePosition = plane.transform.position;

        newFigure = Instantiate(prefabFigure[futureFigure], planePosition, Quaternion.identity);
        alreadyPlace = true;

        //Debug.Log(newFigure);
        LoopPrefabFigure scriptLoopPrefabFigure = plane.GetComponent<LoopPrefabFigure>();

        
        scriptLoopPrefabFigure.setScript();
     


    }

    public void allowToPlace()
    {
        alreadyPlace = false;
    }

}
