﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace WeLoveAero
{
    public class Airplane_EngineCutoff : MonoBehaviour
    {
        #region Variables
        [Header("Engine Cutoff Properties")]
        public KeyCode cutoffKey = KeyCode.O;
        public UnityEvent onEngineCutoff = new UnityEvent();
        #endregion


        #region Basics Methods
        void Update()
        {
            if (Input.GetKeyDown(cutoffKey))
            {
                HandleEngineCutoff();
            }
        }
        #endregion


        #region Custom Methods
        void HandleEngineCutoff()
        {
            if (onEngineCutoff != null)
            {
                onEngineCutoff.Invoke();
            }
        }
        #endregion
    }
}
