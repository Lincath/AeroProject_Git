using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WeloveAero
{
    public class Airplane_Camera : Basic_Follow_Camera
    {

        #region Variables
        [Header("Airplane Camera Properties")]
        public float minHeightFromGround = 2f;

        #endregion



        #region Basics Methods
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            HandleCamera();
        }

        #endregion



        //Camera Airplane
        protected override void HandleCamera()
        {
            base.HandleCamera();

            //
            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.down, out hit)) 
            {
                float wantedHeight = origHeight + (minHeightFromGround - hit.distance);
            }
        }
    }
}

