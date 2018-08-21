

#region Explication du Script
/*
 CE SCRIPT PERMET DE GERER LES CAMERAS




 Méthodes:
    SwitchCamera() => fonction qui permet de changer de camera et d'afficher la camera en cours 
    DisableAllCameras() => Methode qui eteint toute les cameras 
 */
#endregion




using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WeLoveAero
{
    public class Airplane_Camera_Controller : MonoBehaviour
    {
        #region Variables
        [Header("Camera Controller Properties")]
        public Airplane_Input input;
        public int startCameraIndex = 0;
        public List<Camera> cameras = new List<Camera>();

        private int cameraIndex = 0;
        #endregion



        #region Basics Methods
        // Use this for initialization
        void Start()
        {
            if (startCameraIndex >= 0 && startCameraIndex < cameras.Count)
            {
                DisableAllCameras();
                cameras[startCameraIndex].enabled = true;
                cameras[startCameraIndex].GetComponent<AudioListener>().enabled = true;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (input)
            {
                if (input.CameraSwitch)
                {
                    SwitchCamera();
                }
            }
        }
        #endregion



        #region Custom Methods
        protected virtual void SwitchCamera()
        {
            if (cameras.Count > 0)
            {
                //Eteint toute les cameras
                DisableAllCameras();

                //incrémentation de l'index de la camera
                cameraIndex++;

                //Si nombre de camera superieur aux nombres de camera onretourna a lacamerade base
                if (cameraIndex >= cameras.Count)
                {
                    cameraIndex = 0;
                }

                //Affichage de la camera en fonction de l'index
                cameras[cameraIndex].enabled = true;
                //Allumeles audios listenrs de la camera encours
                cameras[cameraIndex].GetComponent<AudioListener>().enabled = true;
            }
        }

        void DisableAllCameras()
        {
            if (cameras.Count > 0)
            {
                //Prend toute les cameras de la liste de l'inspector
                foreach (Camera cam in cameras)
                {
                    cam.enabled = false;

                    //Eteint tous les audio listeners
                    cam.GetComponent<AudioListener>().enabled = false;
                }
            }
        }
        #endregion
    }
}

