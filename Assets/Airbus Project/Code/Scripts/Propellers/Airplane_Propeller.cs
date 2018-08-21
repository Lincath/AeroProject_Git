
#region Explication du Script
/*
 CE SCRIPT PERMET DE CONTROLER LES HELICES DE L'AVION




 Méthodes:

    HandleSwapping () => fonction qui permet de swtich entre le modele 3d et les images des hélices 
    HandlePropeller() => fonction qui permet de controller la vitesse des hélices 
     */
#endregion



using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WeLoveAero
{
    public class Airplane_Propeller : MonoBehaviour
    {
        #region Variables
       
        [Header("Propeller Properties")]
        public float minRotationRPM = 30f;
        public float minQuadRPMs = 300f;
        public float minTextureSwap = 600f;
        public GameObject mainProp;
        public GameObject blurredProp;

        [Header("Material Properties")]
        public Material blurredPropMat;
        public Texture2D blurLevel1;
        public Texture2D blurLevel2;
        #endregion



        #region Basics methods

        // Use this for initialization
        void Start ()
        {
            if (mainProp && blurredProp)
            {
                HandleSwapping(0f);
            }
        }
	
	    // Update is called once per frame
	    void Update ()
        {
		
	    }
        #endregion



        #region Custom Methods
        public void HandlePropeller(float currentRPM)
        {
            //Degré par secondes
            float dps = ((currentRPM * 360f) / 60f) * Time.deltaTime;
            transform.Rotate(Vector3.forward, dps);

            //Changement d' helice ( gameobjet ou  image)
            if (mainProp && blurredProp)
            {
                HandleSwapping(currentRPM);

            }
        }

         
           //Switch entre l'helice et l'image
            void HandleSwapping (float currentRPM)
            {
                //Test sur la rotation
                if (currentRPM > minQuadRPMs)
                {
                    blurredProp.gameObject.SetActive(true);
                    mainProp.gameObject.SetActive(false);

                    if (blurredPropMat && blurLevel1 && blurLevel2)
                    {
                        //test sur la rotation pour choisir  la bonne image 
                        if (currentRPM > minTextureSwap)
                        {
                            //_Maintex fait reference a l'albedo  => dans  inspector -> parametre -> select shader
                            blurredPropMat.SetTexture("_MainTex", blurLevel2);   
                        }
                        else
                        {
                            //_Maintex fait reference a l'albedo  => dans  inspector -> parametre -> select shader
                            blurredPropMat.SetTexture("_MainTex", blurLevel1);
                        }
                    }
                }
                else
                {
                    blurredProp.gameObject.SetActive(false);
                    mainProp.gameObject.SetActive(true);
                }
            }








        #endregion

    }
}
