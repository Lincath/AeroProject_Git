using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeLoveAero;


namespace WeLoveAero
{
    public class Airplane_Horizon : MonoBehaviour, IAirplane_UI
    {

        #region Variables
        [Header("HorizonProperties")]
        public Airplane_Characteristics rollCharac;
        public RectTransform horizonArtificial;
        #endregion


        #region Interface Methods
        public void HandleAirplaneUI()
        {
                float horizonRotation = rollCharac.rollAngle;
                Debug.Log("rotation :" + horizonRotation);

                float horizonRotationDegre = horizonRotation * 1;
                //Clamp la valeur del'horizon entre -360 degré et 360 degré
                horizonRotationDegre = Mathf.Clamp(horizonRotationDegre, -359f, 359f);

                //Debug.Log("degre :" + horizonRotationDegre);


                if (horizonArtificial)
                {
                    float normalizedHorizon = Mathf.InverseLerp(-359f, 359f, horizonRotationDegre);
                    //Debug.Log("horizon :" + normalizedHorizon);
                    float normalizedHorizonRotation = 360f * normalizedHorizon *-2f;
                    //Debug.Log("normalized :" + normalizedHorizonRotation);
                    horizonArtificial.rotation = Quaternion.Euler(0f, 0f, normalizedHorizonRotation);
                    //horizonArtificial.rotation =  normalizedHorizonRotation.transform.localEulerAngles.z;

                //Debug.Log("horizon :" +  horizonArtificial.rotation);


                }

            //}





        }
        #endregion

    }
}
