
#region Explication du Script
/*
 CE SCRIPT PERMET DE SAUVEGARDER LES DONNEESDES AVIONS


 Méthodes:
     ONGUI () => fait l'interface de lafenetre windows qui pop 
 

 */
#endregion



using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace WeLoveAero
{
    [CreateAssetMenu(menuName = "WeLoveAero/Create Airplane Preset")]
    //ScriptableObject => permet de faire du data
    public class Airplane_Preset : ScriptableObject
    {
        #region Controller Properties
        [Header("Controller Properties")]
        public Vector3 cogPosition;
        public float airplaneWeight;
        #endregion


        #region Characteristics Properties
        [Header("Characteristics Properties")]
        public float maxMPH;
        public float rbLerpSpeed;
        public float maxLiftPower;
        public AnimationCurve liftCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        public float dragFactor;
        public float flapDragFactor;
        public float pitchSpeed;
        public float rollSpeed;
        public float yawSpeed;
        #endregion
    }
}

