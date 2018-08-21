﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuInGame : MonoBehaviour {
 /*
    public GameObject PanelMainMenu;
    public GameObject MenuPrincipal;
    public GameObject MenuCup;
    public GameObject MenuHangar;       */

    public GameObject MenuInGame;
    public GameObject MenuPause;
    public GameObject BoutonMenuPrincipal;
    public GameObject smokegameObject;

    private ScriptBouton private_ScripteBouton;
    //scenes
    public string sceneNameToLoad;

    //private bool InGame;  // defini si le joueur est dans une partie
                          //private bool GamePause; // defini si le jeu est en pause ou non
    private bool smokeOn;
    private int SmokeLevel;
    public ParticleSystem smoke;
    public Button buttonSmoke;
    public Color colorRed;
    public Color colorActive;
    public Color colorDefault;

    public Button boutonFlaps1;
    public Button boutonFlaps2;
    public Button boutonFlaps3;

    private float pourcentageManetteMoteur;

    private int flapsMode;
    public float PourcentageSliderMoteur;

    // Use this for initialization
    void Start () {

       
        //colorFlaps.highlightedColor = colorGreen;
      

        /*ColorBlock cb = buttonSmoke.colors;
        ColorBlock colorFlaps = boutonFlaps1.colors;      */

       
        //buttonSmoke.colors = cb;
        SmokeLevel = 500;
        MenuPause.SetActive(false);
       /* MenuCup.SetActive(false);
        MenuHangar.SetActive(false);  */
        MenuInGame.SetActive(true);
        Debug.Log("animfinished");

       // private_ScripteBouton = BoutonMenuPrincipal.GetComponent<ScriptBouton>();                                                                     
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

       
    }

	// Update is called once per frame
	void Update () {
        float translation = Time.deltaTime * 10;
        

        if (smokeOn == true)
        {

            // smokegameObject.GetComponentsInChildren<UnityEngine.UI.Text>().text= "on";
            //ColorBlock cb = buttonSmoke.colors;
           
            
            if (SmokeLevel > 1)
            {
                
                //cb.highlightedColor = colorActive;
              //  buttonSmoke.colors = cb;
                smoke.Emit(1);
                SmokeLevel = SmokeLevel - 1;
                Debug.Log("SmokeLevel:" + SmokeLevel );

            }
            if (SmokeLevel < 3)
            {
                
              //  cb.highlightedColor = colorRed;
              //  buttonSmoke.colors = cb;
            }
              // Debug.Log("smokeOn");        
        }
    }
          // buttons
   public void changeScene()
    {
        SceneManager.LoadScene(sceneNameToLoad);// change de scene
    }
 /*  public void PlayTuto()
    {
        animator.SetBool("slideOut", true);
        Debug.Log("slideOut");
        animator.SetTrigger(_hashOnOff);
        animator.SetBool("AnimBoutonType1", true);
        Debug.Log("Tuto");
        InGame = true;

        SceneManager.LoadScene("TutoScene");
    }   */

    public void ChangeScene(int ChangeScene)
    {
        //Debug.Log(ChangeScene);
        SceneManager.LoadScene(ChangeScene);
        Debug.Log("scene loaded: "+ ChangeScene);
    }

    public void PlayPauseMenu()
    { 
        Debug.Log("pause");
        MenuInGame.SetActive(false);
        MenuPause.SetActive(true);
        Time.timeScale = 0;
    }

    public void EndPauseMenu()
    {
        Debug.Log("reprise jeu");
        MenuInGame.SetActive(true);
        MenuPause.SetActive(false);
        Time.timeScale = 1;
    }

    public void restartCurrentScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }


    public void SmokeButton()
    {
        
        ColorBlock smokeBoutonColor = buttonSmoke.colors;
      /*  smokeBoutonColor.normalColor = colorActive;
        smokeBoutonColor.normalColor = colorRed; */
        if (smokeOn == true)
        {
            smokeBoutonColor.normalColor = colorRed;
            smokeBoutonColor.highlightedColor = colorRed;
            buttonSmoke.colors = smokeBoutonColor;
            // cb.highlightedColor = colorRed;
            //  buttonSmoke.colors = cb;
            smokeOn = false;
            Debug.Log("smokeOff");
        }
        else
        {
            smokeBoutonColor.normalColor = colorActive;
            smokeBoutonColor.highlightedColor = colorActive;
            buttonSmoke.colors = smokeBoutonColor;
            //cb.highlightedColor = colorActive;
            //buttonSmoke.colors = cb;
            smokeOn = true;
            Debug.Log("smokeOn");
        }
        /*
        if (smokeOn == true)
        {
          

            for (int i = SmokeLevel; i > 0; i--   )
            {
                SmokeLevel = SmokeLevel - 1 ;
                if (SmokeLevel > 1) smoke.Emit(1);
                // Debug.Log("smokeOn");
                SmokeLevel = i;
                if (SmokeLevel <= 1) smoke.Emit(0);
            }
        }      */

       
    }


    public void MoteurSlideValeurChange(float newValue)
    {
        pourcentageManetteMoteur = newValue;
        Debug.Log("valeurMoteur:" + pourcentageManetteMoteur);
    }


    public void FlapsModeUI(int newValue)
    {
        ColorBlock colorActiveMode = boutonFlaps1.colors;
        ColorBlock colorRedMode = boutonFlaps2.colors;
        ColorBlock colorDefaultMode = boutonFlaps3.colors;
        colorActiveMode.normalColor = colorActive;
        colorRedMode.normalColor = colorRed;
        colorDefaultMode.normalColor = colorDefault;


        /* ColorBlock cb = boutonFlaps.colors;
         cb.highlightedColor = colorGreen;
         boutonFlaps.colors = cb;  */
        flapsMode = newValue;
        Debug.Log("flapsMode:" + flapsMode);
        if (flapsMode == 1)
         {
             ColorBlock colorFlaps = boutonFlaps1.colors;

            // colorFlaps.highlightedColor = colorGreen;
            // colorFlaps.normalColor = colorGreen;
            //cb.pressedColor = colorGreen;
            //boutonFlaps1.colors = colorFlaps;
            boutonFlaps1.colors = colorActiveMode;
            boutonFlaps2.colors = colorDefaultMode;
            boutonFlaps3.colors = colorDefaultMode;
        }
         if (flapsMode == 2 )
         {
            
            
            boutonFlaps1.colors = colorDefaultMode;
            boutonFlaps2.colors = colorActiveMode;
            boutonFlaps3.colors = colorDefaultMode;
        }
         if (flapsMode == 3)
         {
            /* ColorBlock colorFlaps = boutonFlaps3.colors;
            colorFlaps.highlightedColor = colorGreen;
             colorFlaps.normalColor = colorGreen;
             boutonFlaps3.colors = colorFlaps;*/
            boutonFlaps1.colors = colorDefaultMode;
            boutonFlaps2.colors = colorDefaultMode;            
            boutonFlaps3.colors = colorActiveMode;
        }
        

    }

    public void AcrobaticModeUI()
    {
       

    }

}
