
#region Explication du Script
/*
 CE SCRIPT PERMET DE DEFINIR DE CONTROLER LES ROUES DE L'AVION (Rotation et frein )


 Méthodes:
    InitWheel() => Methode qui initialise les roues de l'avion
    HandleWheel () => Permet une rotation des roues de l'avion
 */
#endregion



using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WeLoveAero
{
    //mise en place automatique du WheelCollider
    [RequireComponent(typeof(WheelCollider))]
    public class Airplane_Wheel : MonoBehaviour
    {

        #region Variables
        [Header("wheel Properties")]
        public Transform wheelGraphic;
        public bool isBraking = false;
        public float brakePower = 5f;
        public bool isSteering = false;
        public float steerAngle = 20f;
        private float finalSteerAngle;
        public float steerSmoothSpeed = 2f;

        private WheelCollider WheelCol;
        private Vector3 worldPos;
        private Quaternion worldRot;
        private float finalBrakeForce;
        #endregion




        #region Basics Methods
        void Start ()
        {
            WheelCol = GetComponent<WheelCollider>();
        }
        #endregion




        #region Custom Methods
        public void InitWheel()
        {
            if (WheelCol)
            {
                WheelCol.motorTorque = 0.000000000001f;
            }
        }


        
        public void HandleWheel (Airplane_Input input)
        {
            if (WheelCol)
            {
                WheelCol.GetWorldPose(out worldPos, out worldRot);

                if (wheelGraphic)
                {
                    wheelGraphic.rotation = worldRot;
                    wheelGraphic.position = worldPos;
                }


                if (isBraking)
                {
                    if (input.Brake > 0.1f)
                    {
                        //Permet un freinage progressif
                        finalBrakeForce = Mathf.Lerp(finalBrakeForce, input.Brake * brakePower, Time.deltaTime);
                        WheelCol.brakeTorque = finalBrakeForce;
                    }

                    else
                    {
                        finalBrakeForce = 0f;
                        WheelCol.brakeTorque = 0f;
                        WheelCol.motorTorque = 0.000000000001f;
                    }
                }


                if (isSteering)
                {
                    finalSteerAngle = Mathf.Lerp(finalSteerAngle, -input.Yaw * steerAngle, Time.deltaTime * steerSmoothSpeed);
                    WheelCol.steerAngle = finalSteerAngle;
                }
            }
        }
        #endregion



    }
}
