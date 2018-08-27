
#region Explication du Script
/*
 CE SCRIPT PERMET DE DEFINIR LE MOTEUR ET LES HELICES DE l'AVION



 Méthodes:
     CalculateForce () => fonction qui détermine de combien l'avion avance et le tour pa rminutes des hélices
 */
#endregion



using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WeLoveAero
{
    public class Airplane_Engine : MonoBehaviour
    {

        #region Variables
        [Header("Engine Properties")]
        public float maxForce = 200f;
        public float maxRPM = 2550f;
        public float shutOffSpeed = 2f;
        public AnimationCurve powerCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

        [Header("Propellers")]
        public Airplane_Propeller propeller;


        private bool isShutOff = false;
        private float lastThrottleValue;
        private float finalShutoffThrottleValue;

        private Airplane_Fuel fuel;
        #endregion



        #region Properties
        public bool ShutEngineOff
        {
            set { isShutOff = value; }
        }

        private float currentRPM;
        public float CurrentRPM
        {
            get { return currentRPM; }
        }
        #endregion



        #region Basics Methods
        void Start()
        {
            if (!fuel)
            {
                fuel = GetComponent<Airplane_Fuel>();
                if (fuel)
                {
                    fuel.InitFuel();
                }
            }
        }
        #endregion



        #region Custom Methods
        public Vector3 CalculateForce(float throttle)
        {
            //Calcualte Power
            float finalThrottle = Mathf.Clamp01(throttle);


            if (!isShutOff)
            {
                finalThrottle = powerCurve.Evaluate(finalThrottle);
                lastThrottleValue = finalThrottle;
            }
            else
            {
                lastThrottleValue -= Time.deltaTime * shutOffSpeed;
                lastThrottleValue = Mathf.Clamp01(lastThrottleValue);
                finalShutoffThrottleValue = powerCurve.Evaluate(lastThrottleValue);
                finalThrottle = finalShutoffThrottleValue;
            }


            //Calculate RPM's
            currentRPM = finalThrottle * maxRPM;
            if (propeller)
            {
                propeller.HandlePropeller(currentRPM);
            }


            //Process the Fuel
            HandleFuel(finalThrottle);


            //Create Force
            float finalPower = finalThrottle * maxForce;
            Vector3 finalForce = transform.forward * finalPower;
            //            Debug.Log(finalForce.magnitude * 0.727f);

            return finalForce;
        }


        void HandleFuel(float throttleValue)
        {
            //Handle Fuel
            if (fuel)
            {
                fuel.UpdateFuel(throttleValue);
                if (fuel.CurrentFuel <= 0f)
                {
                    isShutOff = false;
                }
            }
        }
        #endregion



    }
}
