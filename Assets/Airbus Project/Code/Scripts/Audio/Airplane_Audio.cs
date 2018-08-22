
#region Explication du Script
/*
 CE SCRIPT PERMET DE DEFINIR DE GERE LE SON DU JEU


 Méthodes:
     HandleAudio() => permet de gere le sonenfonction du throttle
 

 */
#endregion


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WeLoveAero
{
    public class Airplane_Audio : MonoBehaviour
    {
        #region Variables
        [Header("Airplane Audio Properties")]
        public Airplane_Input input;
        public AudioSource idleSource;
        public AudioSource fullThrottleSource;
        public float maxPitchValue = 1.5f;

        private float finalVolumeValue;
        private float finalPitchValue;
        #endregion



        #region Basics Methods
        // Use this for initialization
        void Start()
        {
            if (fullThrottleSource)
            {
                //Initialisation du volume du son à Zero
                fullThrottleSource.volume = 0f;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (input)
            {
                HandleAudio();
            }
        }
        #endregion



        #region Custom Methods
        protected virtual void HandleAudio()
        {
            //Définition du Volume et du pitch en fonction de l'input StickyThrottle);
            finalVolumeValue = Mathf.Lerp(0f, 1f, input.StickyThrottle);
            finalPitchValue = Mathf.Lerp(1f, maxPitchValue, input.StickyThrottle);

            if (fullThrottleSource)
            {
                fullThrottleSource.volume = finalVolumeValue;
                fullThrottleSource.pitch = finalPitchValue;
            }
        }
        #endregion
    }
}


