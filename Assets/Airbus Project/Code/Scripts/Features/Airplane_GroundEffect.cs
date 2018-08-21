using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeloveAero
{



    public class Airplane_GroundEffect : MonoBehaviour
    {
        #region Variables
        public float maxGroundDistance = 3f;
        public float liftForce = 100f;
        public float maxspeed = 15f;

        private Rigidbody rb;
        #endregion



        #region Basic Methods
        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();


        }

        // Update is called once per frame
        void FixedUpdate()
        {
            HandleGroundEffect();
        }
        #endregion


        #region Custom Methods
        protected virtual void HandleGroundEffect()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                if (hit.transform.tag == "ground" && hit.distance < maxGroundDistance)
                {
                    //Debug.Log("Hitting the ground !");

                    float currentSpeed = rb.velocity.magnitude;
                    float normalizedSpeed = currentSpeed / maxspeed;
                    normalizedSpeed = Mathf.Clamp01(normalizedSpeed);

                    float distance = maxGroundDistance - hit.distance;
                    float finalforce = liftForce * distance * normalizedSpeed;
                    rb.AddForce(Vector3.up * finalforce);
                }
            }
        }
        #endregion

    }
}
