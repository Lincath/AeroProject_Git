﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeLoveAero;

namespace WeloveAero
{
    public class IP_Airplane_FuelGauge : MonoBehaviour, IAirplane_UI
    {
        #region Variables
        [Header("Fuel Guage Properties")]
        public Airplane_Fuel fuel;
        public RectTransform pointer;
        public Vector2 minMaxRotation = new Vector2(-90f, 90f);
        #endregion


        #region Custom Methods
        public void HandleAirplaneUI()
        {
            if(fuel && pointer)
            {
                float wantedRotation = Mathf.Lerp(minMaxRotation.x, minMaxRotation.y, fuel.NormalizedFuel);
                pointer.rotation = Quaternion.Euler(0f, 0f, -wantedRotation);
            }
        }
        #endregion

    }
}
