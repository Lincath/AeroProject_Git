using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeLoveAero;

namespace WeLoveAero
{

    public class VitesseFxScript : MonoBehaviour
    {
        public GameObject UI_Ingame;
        // public Animator animator;
        private MainMenuInGame scriptUI_InGame;
        public int vitesseTest;  //en attendant le raccord
        public ParticleSystem vitesseScreenNiveau1;
        public ParticleSystem vitesseScreenNiveau2;
        public ParticleSystem vitesseAvionNiveau1;
        public ParticleSystem vitesseAvionNiveau2;
        public ParticleSystem vitesseTrailGauche;
        public ParticleSystem vitesseTrailDroit;
        public GameObject FxVitessePlane;

        private float FieldOfView;

        private bool fxVitesseCanBeStop;
        //private int fxVitesseCanBePlay;

        // Use this for initialization
        void Start()
        {
            FieldOfView = 60f;
            fxVitesseCanBeStop = true;
        }

        // Update is called once per frame
        void Update()
        {



            if (FieldOfView < vitesseTest / 4.2)
            {
                if (vitesseTest <= 350 && vitesseTest >= 220)
                {
                    FieldOfView = FieldOfView + 0.2f;
                    Debug.Log("cameraField: " + FieldOfView);
                    Camera.main.fieldOfView = FieldOfView;
                }
            }

            if (FieldOfView > vitesseTest / 4.2)
            {
                if (vitesseTest <= 350 && vitesseTest >= 220)
                {
                    FieldOfView = FieldOfView - 0.2f;
                    Debug.Log("cameraField: " + FieldOfView);
                    Camera.main.fieldOfView = FieldOfView;

                }
            }

            if (vitesseTest > 300)
            {

                if (!vitesseScreenNiveau2.isPlaying)
                {
                    vitesseScreenNiveau1.Stop();
                    vitesseAvionNiveau1.Stop();
                    //vitesseTrailGauche.Play();
                    // vitesseTrailDroit.Play();
                    vitesseScreenNiveau2.Play();
                    vitesseAvionNiveau2.Play();
                    Debug.Log("vitesse elevee");
                    fxVitesseCanBeStop = true;
                }

            }
            if (vitesseTest <= 300 && vitesseTest > 250)
            {
                if (!vitesseScreenNiveau1.isPlaying)
                {
                    vitesseScreenNiveau1.Play();
                    vitesseAvionNiveau1.Play();
                    vitesseTrailGauche.Play();
                    vitesseTrailDroit.Play();
                    vitesseScreenNiveau2.Stop();
                    vitesseAvionNiveau2.Stop();
                    //Debug.Log("vitesse moyenne");
                    fxVitesseCanBeStop = true;
                }
            }

            if (vitesseTest <= 250)
            {

                if (!vitesseTrailGauche.isPlaying || vitesseScreenNiveau1.isPlaying)
                {

                    vitesseScreenNiveau1.Stop();
                    vitesseScreenNiveau2.Stop();
                    vitesseAvionNiveau1.Stop();
                    vitesseAvionNiveau2.Stop();
                    vitesseTrailGauche.Play();
                   // Debug.Log("basse vitesse");
                    fxVitesseCanBeStop = true;
                }
            }
            if (vitesseTest <= 200)
            {

                /* if (FieldOfView > vitesseTest / 4.3)   // 60 de focal
                 {
                     FieldOfView = FieldOfView - 0.2f;
                    // Debug.Log("cameraField: " + FieldOfView);
                     Camera.main.fieldOfView = FieldOfView;
                 }  */

                if (fxVitesseCanBeStop == true)
                {

                    vitesseTrailGauche.Stop();
                    vitesseTrailDroit.Stop();
                    //Debug.Log(" TRES basse vitesse");
                    fxVitesseCanBeStop = false;
                }
            }
        }
    }
}


