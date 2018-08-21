
#region Explication du Script
/*
 CE SCRIPT PERMET DE DEFINIR LES INPUTS VIRTUEL DE L'AVION
 DE MANIERE GENERALE

 IL SERVIRA DE SCRIPT  REFERENCE POUR LES DIFFERENTS SCRIPTS
 QUI SERONT EN HERITAGE PAR RAPPORT A CELUI CI


 Méthodes:
    HandleInput () => fonction qui attribue les inputs à chaque mouvement de l'avion
 */
#endregion



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeLoveAero
{

    public class Airplane_Input : MonoBehaviour

    {

        #region Variables

        protected float pitch = 0f;                  // controler par les elevateurs
        protected float roll = 0f;                  // valeur de -1 à 1 - controlle par le ailerons
        protected float yaw = 0f;                   // controlle par le gouvernail
        protected float throttle = 0f;              // puissance moteur  variable de 0 à 1 
        public float throttleSpeed = 0.1f;


        protected float stickyThrottle;
        public float StickyThrottle
        {
            get { return stickyThrottle; }
        }


        public int maxFlapsIncrements = 2;
        protected int flaps = 0;                    // valeurs en dégré   1 = 15  2 = 30   3 = 60 degré


        //Permet de voir dans l'inspecteur des variables private
        [SerializeField]
        // mis en place d'une  touche public  dans une variable
        public KeyCode breakKey = KeyCode.Space;
        protected float brake = 0f;                 // valeur de -1 à 1 - controlle par le ailerons

        //Permet de voir dans l'inspecteur des variables private
        [SerializeField]
        public KeyCode cameraKey = KeyCode.C;
        protected bool cameraSwitch = false;                 

        #endregion



        #region Properties
        public float Pitch
        {
            get { return pitch; }
        }

        public float Roll
        {
            get { return roll; }
        }

        public float Yaw
        {
            get { return yaw; }
        }

        public float Trottle
        {
            get { return throttle; }
        }

        public float Flaps
        {
            get { return flaps; }
        }

        public float Brake
        {
            get { return brake; }
        }
        #endregion



        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            HandleInput();
            StickyThrottleControl();
            ClampInputs();
        }

        public bool CameraSwitch
        {
            get { return cameraSwitch; }
        }



        #region Custom Methods
        protected virtual void HandleInput ()
        {
            //Edition des inputs dans   Edit -> project settings -> Input -> Axes
            pitch = Input.GetAxis("Vertical");
            roll = Input.GetAxis("Horizontal");
            yaw = Input.GetAxis("Yaw");
            throttle = Input.GetAxis("Throttle");


            // controle des freins
            // creation de float avec vrai faux  ( comme si c'etait un bool)
            // la condition? deux resultats possible
            brake = Input.GetKey(breakKey) ? 1f : 0f;


            //control des ailerons
            if (Input.GetKeyDown(KeyCode.A))
            {
                flaps += 1;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                flaps -= 1;
            }

            flaps = Mathf.Clamp(flaps, 0, maxFlapsIncrements);

            //Camera Switch Key
            cameraSwitch = Input.GetKeyDown(cameraKey);
        }

        //Créez une valeur d'accélérateur qui augmente et diminue progressivement
        protected void StickyThrottleControl()
        {
            stickyThrottle = stickyThrottle + (-throttle * throttleSpeed * Time.deltaTime);
            stickyThrottle = Mathf.Clamp01(stickyThrottle);
        }

        protected void ClampInputs()
        {
            pitch = Mathf.Clamp(pitch, -1f, 1f);
            roll = Mathf.Clamp(roll, -1f, 1f);
            yaw = Mathf.Clamp(yaw, -1f, 1f);
            throttle = Mathf.Clamp(throttle, -1f, 1f);
            brake = Mathf.Clamp(brake, 0f, 1f);
        }
        #endregion

    }
}
