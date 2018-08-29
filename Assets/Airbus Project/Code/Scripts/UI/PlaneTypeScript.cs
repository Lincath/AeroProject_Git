using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTypeScript : MonoBehaviour {
    public GameObject CanvasChoixDuStage;
    private StageTypeScript scriptChoixDuStage;

    public GameObject CanvasMainMenu;
    private MainMenu scriptMainMenu;

    public string SceneActuelle;
    public int StageSelected;
    private bool CanPlayNextStep;
    public GameObject ButtonPlay;
    public string planeName;

    // Use this for initialization
    void Start () {

        //  CheckScene();
        planeName = null;
     
            CanPlayNextStep = false;
        if (ButtonPlay != null)
        { ButtonPlay.SetActive(false); }
          

      
        // scriptChoixDuStage = CanvasChoixDuStage.GetComponent<MainMenu>();
        if (SceneActuelle == "Hangar")
        {
            scriptChoixDuStage = CanvasChoixDuStage.GetComponent<StageTypeScript>();
        StageSelected = scriptChoixDuStage.StageType;
        }
        AvionDisponibles();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void AvionDisponibles ()
    {
        
        if (StageSelected == 1)
        {
            
            Debug.Log("test");
        }
    }
}
