
#region Explication du Script
/*
 CE SCRIPT PERMET DE DEFINIR LA CAMERA QUI SUIT l'AVION



 Méthodes:
     Handle Camera () => fonction qui détermine la 
 */
#endregion



using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WeloveAero
{
    public class Basic_Follow_Camera : MonoBehaviour
    {

        #region Variables
        [Header("Follow CameraProperties")]
        public Transform target;
        public float distance = 5f;
        public float height = 2f;
        public float smoothspeed = 0.5f;

        private Vector3 smoothVelocity;

        protected float origHeight;
        #endregion



        #region Basics Methods
        // Use this for initialization
        void Start()
        {
            origHeight = height;
        }

        // Update du moteur physiue plusieurs fois par frame
        void FixedUpdate()
        {
            HandleCamera();
        }

        #endregion


        #region Custom Methods
        protected virtual void HandleCamera ()
        {
            //Positionnement de la camera
            Vector3 wantedPosition = target.position + (-target.forward * distance) + (Vector3.up * height);


            //Création d'un rayon en debug log
            Debug.DrawLine(target.position, wantedPosition, Color.blue);


            //Mouvement adoucit de la Camera
            transform.position = Vector3.SmoothDamp(transform.position,wantedPosition,ref smoothVelocity,smoothspeed);

            //transform.position = wantedPosition;


            //La camera regarde la cible
            transform.LookAt(target);
        }

        #endregion
    }

}
