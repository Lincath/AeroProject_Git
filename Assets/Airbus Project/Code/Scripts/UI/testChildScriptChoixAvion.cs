using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testChildScriptChoixAvion : StageTypeScript {
    public int typeAvion;
    GameObject[] AvionsTypeVoltige;
    GameObject[] AvionsTypeChasse;
    GameObject[] AvionsTypeLigne;
    // Use this for initialization
    void Start () {
       
        AvionsTypeVoltige = GameObject.FindGameObjectsWithTag("Voltige");
        AvionsTypeChasse = GameObject.FindGameObjectsWithTag("Chasse");
        AvionsTypeLigne = GameObject.FindGameObjectsWithTag("Ligne");
        Debug.Log("testchild type stage = " + TestStageTypeSave);


        if (ModeDeJeu == "StageMode")
        {

       
            if (TestStageTypeSave == 1)
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
        if (TestStageTypeSave == 2)
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
        if (TestStageTypeSave == 3)
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

        if (TestStageTypeSave != typeAvion)
        {
            this.enabled = false;
            Debug.Log("testchild type stage = " + TestStageTypeSave);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
