using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {
    static string ScenePrecedente;
    public string SceneActuelle;
    private string ScenePrecedenteSave;// pour donner une identité au chemin parcouru dans l interface
    public GameObject PanelMainMenu;
    public GameObject MenuPrincipal;
    public GameObject MenuCup;
    public GameObject MenuHangar;
    public GameObject ChoixDuStage;
    static int StageBeSelectionned;
    public int Test;
    public static string ModeDeJeu;
    
    //public GameObject ColliderScaleButon;

    public GameObject BoutonMenuPrincipal;

    private ScriptBouton private_ScripteBouton;
    private StageTypeScript private_ScriptChoixStage;
    //scenes
    public string sceneNameToLoad;

    


    //public Scene TutoScene;
    //private GameObject TutoScene;
    private bool InGame;  // defini si le joueur est dans une partie
                          //private bool GamePause; // defini si le jeu est en pause ou non
    private Animator animator;

    private int _hashOnOff;

    // Use this for initialization
    void Start () {
    
       
      // private_ScriptChoixStage = ChoixDuStage.GetComponent<StageTypeScript>();
      // StageBeSelectionned = private_ScriptChoixStage.StageType;
//Test = StageBeSelectionned; //on rend acceccible cette variable partout dans les autres scenes
        // stage type est le nom de la variables dans le script stage type scrpit

        if (ScenePrecedente == null)
        {            
            ScenePrecedente = SceneActuelle;       
        }
                                                                              
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        animator = GetComponent(typeof(Animator)) as Animator;
        _hashOnOff = Animator.StringToHash("SlideOut");
    }

	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //bool fire = Input.GetButtonDown("Fire1");
            Debug.Log("slideOut");
            animator.SetTrigger(_hashOnOff);
        }		
	}

    public void backToLastScene ()
    {

     if(SceneActuelle == "Hangar")
        {

            if (ScenePrecedente == "MainMenu")
            {
               
                Debug.Log("la scene precedente est :  " + ScenePrecedente);
                SceneManager.LoadScene("MainMenu");
            }

            if (ScenePrecedente == "Stage")
            {                  
                Debug.Log("la scene precedente est :  " + ScenePrecedente);
                SceneManager.LoadScene("FreeFlightMenu");
            }
        }

        if (SceneActuelle == "Stage")
        {           
                Debug.Log("la scene precedente est :  " + ScenePrecedente);
            SceneManager.LoadScene("MainMenu");       
        }

        if (SceneActuelle == "Database")
        {
            Debug.Log("la scene precedente est :  " + ScenePrecedente);
            SceneManager.LoadScene("MainMenu");
        }



    }

   public void PlayFreeMode()
    {
        ModeDeJeu = "FreeMode";
        PlayHangar();
    }
    public void PlayStagesMode()
    {
        ModeDeJeu = "StageMode";
        PlayStage();
    }
    public void PlayCupMode()
    {
        ModeDeJeu = "CupMode";
        PlayLogIn();


    }

    public void PlayStage()
    {
        ScenePrecedente = SceneActuelle;  //deviendra la bonne scene precedente dans la scene a suivre
        SceneManager.LoadScene("FreeFlightMenu");
    }

    public void PlayHangar()
    {
        if (ScenePrecedente == "MainMenu")
        {
            ScenePrecedente = SceneActuelle;  //deviendra la bonne scene precedente dans la scene a suivre
            SceneManager.LoadScene("HangarScene");

            Test = 4;
            Debug.Log("Tous les avions possible test: "+ Test);
        }
            ScenePrecedente = SceneActuelle;  //deviendra la bonne scene precedente dans la scene a suivre
        SceneManager.LoadScene("HangarScene");
    }

    public void PlayLogIn()
    {
        ScenePrecedente = SceneActuelle;
        SceneManager.LoadScene("Database");

    }

    public void changeScene()
    {
        SceneManager.LoadScene(sceneNameToLoad);// change de scene
    }

    public void BackToSceneMenu()
    {
        SceneManager.LoadScene("menu 1");
    }


  public void PlayTuto()     //en attendant des niveaux spécifiques
    {
        ScenePrecedente = SceneActuelle;
        SceneManager.LoadScene("SceneTuto");
    }   

    public void ChangeScene(int ChangeScene)
    {
       
        SceneManager.LoadScene(ChangeScene);
        Debug.Log("scene loaded: "+ ChangeScene);

    }
    
}
