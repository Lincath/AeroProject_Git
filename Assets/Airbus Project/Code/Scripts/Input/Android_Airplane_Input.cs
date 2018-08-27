using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace WeLoveAero
{
    public class Android_Airplane_Input : Airplane_Input
    {

        #region Variables
        #endregion





        #region Basic methods
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(new Vector3(Input.acceleration.x, Input.acceleration.y,20) * Time.deltaTime * 2f);
        }
        #endregion


        #region Custom method
        #endregion


    }
}
