
#region Explication du Script
/*
 CE SCRIPT PERMET DE DEFINIR 



 > 
 */
#endregion



using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace WeLoveAero
{

    //Ce script marche que si ya u nrigidbody sur le gameobjet auquel est rattache ce script
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(AudioSource))]

    public class Rigidbody_Controller : MonoBehaviour
    {
        #region
        protected Rigidbody rb;
        protected AudioSource aSource;
        #endregion



        #region Basics methods
        // Use this for initialization
        public virtual void Start()
        {
            rb = GetComponent<Rigidbody>();
            aSource = GetComponent<AudioSource>();

            if (aSource)
            {
                aSource.playOnAwake = false;
            }

        }

        // Fixed Update c'est pour la physique ( possibilite de le faire plus d'une fois par frame
        void FixedUpdate()
        {
            if (rb)
            {
                HandlePhysics();
            }
            
        }
        #endregion



        #region Custom Methods
        protected virtual void HandlePhysics() { }
        #endregion
    }

}


