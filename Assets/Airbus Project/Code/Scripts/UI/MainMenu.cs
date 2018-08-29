using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu: MonoBehaviour {

    public GameObject PanelMainMenu;
    public GameObject MenuPrincipal;
    public GameObject MenuCup;
    public GameObject MenuHangar;

    public GameObject MenuInGame;
    public GameObject MenuPause;

    //public GameObject ColliderScaleButon;

    public GameObject BoutonMenuPrincipal;

    private ScriptBouton private_ScripteBouton;
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
        MenuPause.SetActive(false);
        MenuCup.SetActive(false);
        MenuHangar.SetActive(false);
        MenuInGame.SetActive(true);
       // ColliderScaleButon.SetActive(false);
        /* MenuPause.SetActive(false);
         MenuPause.SetActive(false);*/
        Debug.Log("animfinished");

        private_ScripteBouton = BoutonMenuPrincipal.GetComponent<ScriptBouton>();

        PlayMainMenu();                                                                      
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

         //anims

        //animator = GetComponent<Animator>();
       // animator.SetBool("AnimBoutonType1", true);

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
            //anim.SetInteger(_hashOnOff, True);
            //  animator.SetBool("slideOut", fire);


               //bouton hangar
           
        }		
	}
          // buttons
   public void changeScene()
    {
        SceneManager.LoadScene(sceneNameToLoad);// change de scene
    }

    public void BackToSceneMenu()
    {
        SceneManager.LoadScene("menu 1");
    }

    public void PlayMainMenu()
    {
        PanelMainMenu.SetActive(true);
        MenuPrincipal.SetActive(true);
        MenuHangar.SetActive(false);
        MenuPause.SetActive(false);
        MenuInGame.SetActive(false);
        InGame = false;
       // GamePause = false;
        Time.timeScale = 1;

    }

    public void PlayTuto()
    {
        animator.SetBool("slideOut", true);
        Debug.Log("slideOut");
        animator.SetTrigger(_hashOnOff);
        animator.SetBool("AnimBoutonType1", true);
        Debug.Log("Tuto");
        //PanelMainMenu.SetActive(false);
       // MenuInGame.SetActive(true); 
        InGame = true;


        SceneManager.LoadScene("TutoScene");

    }

    public void ChangeScene(int ChangeScene)
    {
       
        SceneManager.LoadScene(ChangeScene);
        Debug.Log("scene loaded: "+ ChangeScene);

    }

    public void PlayPauseMenu()
    {
        Debug.Log("pause");
        MenuInGame.SetActive(false);
        MenuPause.SetActive(true);
        InGame = true;
        Time.timeScale = 0;
    }

    public void EndPauseMenu()
    {
        Debug.Log("reprise jeu");
        MenuInGame.SetActive(true);
        MenuPause.SetActive(false);
        InGame = true;
        Time.timeScale = 1;
    }

    public void restartCurrentScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void PlayHangar()
    {
        //animator.SetBool("test", true);
        Debug.Log("PlayHangar");
        MenuPrincipal.SetActive(false);
        MenuHangar.SetActive(true);
        /*if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("AnimBoutonType1"))
        {
            Debug.Log("animfinished");
            MenuPrincipal.SetActive(false);
            MenuHangar.SetActive(true);
        }         */
    }

    public void MenuHangarToMainMenu()
    {
        Debug.Log("pressBack");
        MenuHangar.SetActive(false);
        MenuPrincipal.SetActive(true);

        private_ScripteBouton.ResetBoutons();
    }

    public void PlayCup()
    {

        //animator.SetBool("test", true);
        Debug.Log("PlayCup");
        MenuPrincipal.SetActive(false);
        MenuCup.SetActive(true);
     
       // ColliderScaleButon.SetActive(true);
    }

    public void MenuCupToMainMenu()
    {
       // ColliderScaleButon.SetActive(false);
        Debug.Log("pressBack");
        MenuCup.SetActive(false);
        MenuPrincipal.SetActive(true);

        private_ScripteBouton.ResetBoutons();
    }

    public void Test()
    {
        Debug.Log("fonction Appelée");
    }

    
}
