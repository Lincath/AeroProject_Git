
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
        public float maxRPM = 2250f;                 //rotation helice par minute

        public AnimationCurve powerCurve = AnimationCurve.Linear(0f,0f,1f,1f);

        [Header("Propellers")]
        public Airplane_Propeller propeller;
        #endregion



        #region Basics Methods

        #endregion



        #region Custom Methods
        public Vector3 CalculateForce (float throttle)
        {
            //Calcul Puissance
            float finalThrottle = Mathf.Clamp01(throttle);
            finalThrottle = powerCurve.Evaluate(finalThrottle);


            //création du vecteur translation force
            float finalPower = finalThrottle * maxForce;
            Vector3 finalForce = transform.TransformDirection(transform.forward) * finalPower;


            //calcul des tours par minutes 
            float currentRPM = finalThrottle * maxRPM;
            if (propeller)
            {
                propeller.HandlePropeller(currentRPM);
            }

            return finalForce;
        }
        #endregion
    }
}
