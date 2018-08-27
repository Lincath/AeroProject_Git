using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeLoveAero;


namespace WeloveAero
{
    public class Airplane_Altimeter : MonoBehaviour, IAirplane_UI

    {

        #region Variables
        [Header("Altimeter Properties")]
        public Airplane_Controller airplane;
        public RectTransform hundredsPointer;
        public RectTransform thousandsPointer;
        #endregion



        #region Interface Methods
        public void HandleAirplaneUI()
        {
            if (airplane)
            {
                float currentAlt = airplane.CurrentMSL;

                float currentThousands = currentAlt / 1000f;
                //Clamp la valeur en fonctiondes chiffres du cadran de l'altimetre
                currentThousands = Mathf.Clamp(currentThousands, 0f, 10f);

                float currentHundreds = currentAlt - (Mathf.Floor(currentThousands) * 1000f);
                currentHundreds = Mathf.Clamp(currentHundreds, 0f, 1000f);

                //Debug.Log(currentAlt);

                if (thousandsPointer)
                {
                    float normalizedThousands = Mathf.InverseLerp(0f, 10f, currentThousands);
                    float thousandsRotation = 360f * normalizedThousands;
                    thousandsPointer.rotation = Quaternion.Euler(0f, 0f, -thousandsRotation);
                }


                if (hundredsPointer)
                {
                    float normalizedHundreds = Mathf.InverseLerp(0f, 1000f, currentHundreds);
                    float hundredsRotation = 360f * normalizedHundreds;
                    hundredsPointer.rotation = Quaternion.Euler(0f, 0f, -hundredsRotation);
                }
            }
        }
        #endregion
    }
}
