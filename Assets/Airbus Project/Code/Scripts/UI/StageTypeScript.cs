using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTypeScript : MainMenu {

    public static int StageTypeSave;
    public int StageType;
    protected static int TestStageTypeSave;
    private bool CanPlayNextStep;
    public GameObject ButtonPlay;
    public GameObject LeaderBoard;
    public string planeName;
    public GameObject AllPlaneShowed;
    public GameObject planeShowed;
    public Material MaterialPlane;
    public Renderer rend;

    private Vector3 spawnPosition;
    public GameObject plateform;

    private bool activeOrNot;


    void Start () {
        planeName = null;
        StageType = 0;
        
        if (StageType == 0 ) //si pas selectionne de stage je peu pas passer a l etape suivante
        {
            CanPlayNextStep = false;
            ButtonPlay.SetActive(false);

            if (LeaderBoard != null)
            {
                LeaderBoard.SetActive(false);
            }
            

        }
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void DefStageType(int StageTypeSave)
    {
        if (LeaderBoard != null)
        { 
             LeaderBoard.SetActive(true);
        }
        ButtonPlay.SetActive(true);
        CanPlayNextStep = true;
        //StageType = newValue;
        // StageTypeSave = StageType
        Debug.Log("stage type:" + StageTypeSave);
        TestStageTypeSave = StageTypeSave;
        Debug.Log(TestStageTypeSave);
        StageType = StageTypeSave;
    }

    public void DefPlaneShowed()
    {
        planeShowed = GameObject.FindGameObjectWithTag(planeName).gameObject;
        planeShowed.SetActive(true);
        Debug.Log(planeShowed.tag);
        Vector3 spawnPosition = new Vector3(0, 1, 0);
        planeShowed.transform.position = spawnPosition;

    }

    public void DefPlane(string NomAvion)
    {
        if (planeName != null)
        {
            planeShowed.transform.position = new Vector3(10, 101, 10);

        }
        planeName = NomAvion;

        // rend = GetComponent<Renderer>();
        //rend.enabled = false;

        ButtonPlay.SetActive(true);
        CanPlayNextStep = true;
        Debug.Log("model de l'avion:" + planeName);
        // GameObject planeShowed = GameObject.FindGameObjectWithTag("F35").gameObject;    
       //Material MaterialPlane = Material.Find(skin1);

        DefPlaneShowed();
    }

}
