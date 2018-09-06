using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeLoveAero;

namespace WeLoveAero
{

    public class testChildScriptChoixAvion : MonoBehaviour
    {
        //scripts
        public StageTypeScript stageTypeScript;
        public MainMenu mainMenuScr;

        public int typeAvion;
        GameObject[] AvionsTypeVoltige;
        GameObject[] AvionsTypeChasse;
        GameObject[] AvionsTypeLigne;
        // Use this for initialization
        void Start()
        {
            Debug.Log("bonjour");
           

            AvionsTypeVoltige = GameObject.FindGameObjectsWithTag("Voltige");
            AvionsTypeChasse = GameObject.FindGameObjectsWithTag("Chasse");
            AvionsTypeLigne = GameObject.FindGameObjectsWithTag("Ligne");
            if (stageTypeScript)
            { 
                if(stageTypeScript.TestStageTypeSave != null)
               // Debug.Log("testchild type stage = " + stageTypeScript.TestStageTypeSave);

                    
                if (mainMenuScr.ModeDeJeu == "StageMode")
                {


                    if (stageTypeScript.TestStageTypeSave == 1)
                    {
                        foreach (GameObject r in AvionsTypeVoltige)
                        {
                            Destroy(r.gameObject);
                        }
                        foreach (GameObject r in AvionsTypeChasse)
                        {
                            Destroy(r.gameObject);
                        }


                    }
                    if (stageTypeScript.TestStageTypeSave == 2)
                    {
                        foreach (GameObject r in AvionsTypeLigne)
                        {
                            Destroy(r.gameObject);
                        }
                        foreach (GameObject r in AvionsTypeChasse)
                        {
                            Destroy(r.gameObject);
                        }

                    }
                    if (stageTypeScript.TestStageTypeSave == 3)
                    {

                        foreach (GameObject r in AvionsTypeLigne)
                        {
                            Destroy(r.gameObject);
                        }
                        foreach (GameObject r in AvionsTypeVoltige)
                        {
                            Destroy(r.gameObject);
                        }


                    }
                }


                
                if (stageTypeScript.TestStageTypeSave != typeAvion)
                {
                    this.enabled = false;
                    Debug.Log("testchild type stage = " + stageTypeScript.TestStageTypeSave);
                }

            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
