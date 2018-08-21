#region Explicationdu script
// CE SCRIPT PERMET DE MANIPULER LES PARTIES MOBILES DE L'AVION QUI SERT A SIMULER LE VOL

//
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WeLoveAero
{
    public class Airplane_ControlSurface : MonoBehaviour
    {

        //Enumeration des parties mobiles 
        public enum ControlSurfaceType
        {
            Rudder ,
            Elevator,
            Flap,
            Aileron
        }

        #region variables
        [Header("Control Surfaces Properties")]
        public ControlSurfaceType type = ControlSurfaceType.Rudder;

        public float maxAngle = 30f;
        public Vector3 axis = Vector3.right;

        private float wantedAngle;

        public Transform controlSurfaceGraphic;
        public float smoothSpeed = 2f;
        #endregion



        #region Basic Methods

        // Use this for initialization
        void Start()
        {

        }

        void Update()
        {
            //Déplacement de l'élément mobile selon l'angle
            if (controlSurfaceGraphic)
            {
                Vector3 finalAngleAxis = axis * wantedAngle;
                controlSurfaceGraphic.localRotation = Quaternion.Slerp(controlSurfaceGraphic.localRotation,Quaternion.Euler(finalAngleAxis),Time.deltaTime * smoothSpeed );
            }
        }
        #endregion



        #region Custom methods
        public void HandleControlSurface(Airplane_Input input)
        {
            float inputValue = 0f;

            //Choix de l'élément  mobile
            switch (type)
            {
                case ControlSurfaceType.Rudder:
                    inputValue = input.Yaw;
                    break;

                case ControlSurfaceType.Elevator:
                    inputValue = input.Pitch;
                    break;

                case ControlSurfaceType.Flap:
                    inputValue = input.Flaps;
                    break;


                case ControlSurfaceType.Aileron:
                    inputValue = input.Roll;
                    break;

                default:
                    break;
            }

            //calcul de l'angle de rotation
            wantedAngle = maxAngle * inputValue;
        }

        #endregion





    }

}

