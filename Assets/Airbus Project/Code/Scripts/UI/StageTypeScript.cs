using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WeLoveAero;

namespace WeLoveAero
{


public class StageTypeScript : MonoBehaviour
    {
        //SCRIPTS
    public MainMenu mainMenuScr;


    public Animator animatorBandeInfos;
    public static int StageTypeSave;
    public int StageType;
    public  int TestStageTypeSave;
    private bool CanPlayNextStep;
    public GameObject ButtonPlay;
    public GameObject LeaderBoard;
    public string planeName;
    private static string planeNameTest;
    public GameObject AllPlaneShowed;
    public GameObject planeShowed;
    public Material MaterialPlane;
    public Renderer rend;
    public GameObject TextInfosPlane;
    private bool infosVisibles;
    public Text TextInfosContent;

        public Text txtInfo1;
        public Text txtInfo2;
        public Text txtInfo3;

        //private text                                                   s


        //  public Text TxtChoosePlane;

        public GameObject InfoButton;

    private Vector3 spawnPosition;
    public GameObject plateform;

    private bool activeOrNot;


    void Start () {
           // TextInfosContent = gameObject.GetComponent<Text>();
            TextInfosContent.text = "";



            // animatorBandeInfos.anim_InfosBegin. setBool (true);
            //  animatorBandeInfos.Play("anim_InfosBegin");

            //animatorBandeInfos = GetComponent(typeof(Animator)) as Animator;
            planeName = null;
        StageType = 0;
        //InfoButton.SetActive(false);
        //mainMenuScr.UIChoixAvions.SetActive(true);
        if (StageType == 0 ) //si pas selectionne de stage je peu pas passer a l etape suivante
        {
                infosVisibles = false;
            CanPlayNextStep = false;
            ButtonPlay.SetActive(false);
          TextInfosPlane.SetActive(false);
                InfoButton.SetActive(false);
            //mainMenuScript.UIInfosAvion.SetActive(false);

            if (LeaderBoard != null)
            {
                LeaderBoard.SetActive(false);
            }
            

        }
            TextInfosPlane.SetActive(false);
        }
	
	// Update is called once per frame
	void Update () {

       //if (TextInfosPlane != null) Debug.Log(TextInfosPlane);

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
       // mainMenuScript.UIChoixAvions.SetActive(true);                                                                      
       // TxtChoosePlane.SetActive(false);
       
    }




    

    public void DefPlaneShowed()
    {
            TextInfosPlane.SetActive(true);
            Debug.Log("planeName = " + planeNameTest);
            if (planeNameTest == "F-35")
            {
                TextInfosContent.text = txtInfo1.text;
            }
            if (planeNameTest == "Extra330")
            {
                TextInfosContent.text = txtInfo2.text;
            }

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
        planeNameTest = NomAvion;

        // rend = GetComponent<Renderer>();
        //rend.enabled = false;

        ButtonPlay.SetActive(true);
        InfoButton.SetActive(true);
        CanPlayNextStep = true;
        Debug.Log("model de l'avion:" + planeName);
        // GameObject planeShowed = GameObject.FindGameObjectWithTag("F35").gameObject;    
       //Material MaterialPlane = Material.Find(skin1);

        DefPlaneShowed();
    }

}
}
