
#region Explication du Script
/*
 CE SCRIPT PERMET
 


 */
#endregion



using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WeLoveAero
{
    [RequireComponent(typeof(Airplane_Characteristics))]
    public  class Airplane_Controller : Rigidbody_Controller
    {

        #region Variables
        [Header("Base Airplane Properties")]
        public Airplane_Input input;
        public Airplane_Characteristics characteristics;
        public Transform centerOfGravity;

        [Tooltip("Weight is in  pounds")]
        public float airplaneWeight = 800f;


        //creation d'une liste dans l'editeur uniteur dans le component script IP-airplane_Controller
        [Header("Engines")]
        public List<Airplane_Engine> engines = new List<Airplane_Engine>();


        //creation d'une liste dans l'editeur uniteur dans le component script IP-airplane_Controller
        [Header("Wheels")]
        public List<Airplane_Wheel> wheels = new List<Airplane_Wheel>();


        //creation d'une liste dans l'editeur pour lister les differents élémentsmobiles de l'avion
        [Header("Control Surfaces")]
        public List<Airplane_ControlSurface> controlSurfaces = new List<Airplane_ControlSurface>();



        #endregion



        #region Constantes
        const float poundToKilos = 0.453592f;
        #endregion



        #region Basics Methods
        public override void Start()
        {
            base.Start();
            float finalMass = airplaneWeight * poundToKilos;

            if (rb)
            {
                rb.mass = finalMass;
                if (centerOfGravity)
                {
                    rb.centerOfMass =centerOfGravity.localPosition;
                }

                characteristics = GetComponent<Airplane_Characteristics>();
                if (characteristics)
                {
                    characteristics.InitCharacteritics(rb,input);
                }

            }

            if (wheels != null)
            {
                if (wheels.Count > 0)
                {
                    foreach (Airplane_Wheel wheel in wheels)
                    {
                        wheel.InitWheel();
                    }
                }
            }

          

        }
        #endregion

      

        #region Custom Methods
        protected override void HandlePhysics()
        {
            if (input)
            { 
                HandlEngines();
                Handlecharacteristics();
                HandleControlSurfaces();
                HandleWheel();
               
                
                HandleAltitude();
            }

        }

        void HandlEngines()
        {
            if (engines !=null)
            {
                if (engines.Count > 0)
                {
                    foreach (Airplane_Engine engine in engines)
                    {
                        rb.AddForce(engine.CalculateForce(input.StickyThrottle));
                    }
                }
            }
        }

        void Handlecharacteristics()
        {
            if (characteristics)
            {
                characteristics.Updatecharacteristics();
            }
        }



        void HandleWheel()
        {
            if (wheels.Count > 0)
            {
                foreach (Airplane_Wheel wheel in wheels)
                {
                    wheel.HandleWheel(input);
                }
            }
        }


        void HandleControlSurfaces()
        {
            if (controlSurfaces.Count > 0)
            {
                foreach (Airplane_ControlSurface controlSurface in controlSurfaces)
                {
                    controlSurface.HandleControlSurface(input);
                }
            }
        }




        void HandleAltitude()
        {

        }
        #endregion

    }
}
