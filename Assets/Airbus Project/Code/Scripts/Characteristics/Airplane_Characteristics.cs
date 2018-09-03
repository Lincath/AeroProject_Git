#region Explication du Script
/*
 CE SCRIPT PERMET DE DEFINIR LES CHARACTERISTIQUES DE L'AVION
 DE MANIERE GENERALE

 IL SERVIRA DE SCRIPT  POUR DEFINIR LES CHARACTERISTIQUES DES
 AVIONS SUPPLEMENTAIRE


 Méthodes:

    InitCharacteritics()    => Methode qui définit les characteristiques au départ
    Updatecharacteristics() => Méthode qui update les characteristiques de l'avion


     CalculateforwardSpeed() =>
     CalculateLift() =>
     CalculateDrag() =>
     HandlePitch() =>
     HandleRoll()=>
     HandleYaw()=>
     HandleBanking()=>
     HandleRigibodyTransform()=>
 */
#endregion


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WeLoveAero
{
    public class Airplane_Characteristics : MonoBehaviour
    {

        #region Variables

        [Header("Characteristics Properties")]
        public float maxMPH = 110f;
        public float rbLerpSpeed = 0.01f;


        [Header("Lift Properties")]
        public float maxLiftPower = 800f;
        public AnimationCurve liftCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        public float flapLiftPower = 100f;


        [Header("Drag Properties")]
        public float dragFactor = 0.01f;
        public float flapDragFactor = 0.005f;


        [Header("Control Properties")]
        public float pitchSpeed = 1000f;
        public float rollSpeed = 1000f;
        public float yawSpeed = 1000f;
        public AnimationCurve controlSurfaceEfficiency = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);


        private float forwardSpeed;
        public float ForwardSpeed
        {
            get { return forwardSpeed; }
        }

        private float mph;
        public float MPH
        {
            get { return mph; }
        }


        private Airplane_Input input;
        private Rigidbody rb;
        private float startDrag;
        private float startAngularDrag;


        private float maxMPS;
        private float normalizeMPH;


        private float angleOfAttack;
        private float pitchAngle;
        public float rollAngle;

        private float csEfficiencyValue;
       
        #endregion



        #region Constants
        //Transform les miles en km/heure
        const float mpsToMph = 2.23694f;
        #endregion



        #region Basics Methods
        #endregion



        #region Custom Methods

        public void InitCharacteritics(Rigidbody curRB, Airplane_Input curInput)
        {
            //basic initialisation
            input = curInput;
            rb = curRB;
            startDrag = rb.drag;
            startAngularDrag = rb.angularDrag;

            //Find the Max Meters Per Second
            maxMPS = maxMPH / mpsToMph;
        }


        public void Updatecharacteristics()
        {
            if (rb)
            {
                //Calcul de la physique
                CalculateforwardSpeed();
                CalculateLift();
                CalculateDrag();

                //Gestion des controls
                HandleControlSurfaceEfficiency();
                HandlePitch();
                HandleRoll();
                HandleYaw();
                HandleBanking();

                //Gestion du rigibody
                HandleRigibodyTransform();

            }

        }


        void CalculateforwardSpeed()
        {
            Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
            forwardSpeed = localVelocity.z;

            //Clamp de la valeur speed
            //forwardSpeed = Mathf.Clamp(forwardSpeed, 0f, maxMPS);


            mph = forwardSpeed * mpsToMph;
           // mph = Mathf.Clamp(mph, 0f, maxMPH);
            normalizeMPH = Mathf.InverseLerp(0f, maxMPH, mph);

            //Debug.Log(normalizeMPH);


            //trace un rayon vert en debug
            //Debug.DrawRay(transform.position, transform.position + localVelocity, Color.green);
        }



        void CalculateLift()
        {
            //récupere  l'angle d'attaque
            angleOfAttack = Vector3.Dot(rb.velocity.normalized, transform.forward);
            angleOfAttack *= angleOfAttack;
            //Debug.Log(angleOfAttack);

            //create the lift direction
            Vector3 liftDir = transform.up;
            float liftPower = liftCurve.Evaluate(normalizeMPH) * maxLiftPower;
            //Debug.Log(liftPower);

            //Ajout flap lift
            float finalLiftPower = flapLiftPower * input.NormalizedFlaps;

            //Applique  le  final lift force au rigibody
            Vector3 finalLiftForce = liftDir * (liftPower + finalLiftPower) * angleOfAttack;
            rb.AddForce(finalLiftForce);
        }



        void CalculateDrag()
        {
            //Calcul de le résistance de l'air
            float speedDrag = forwardSpeed * dragFactor;

            //Bonus de resistance avec les flaps ouvert
            float flapDrag = input.Flaps * flapDragFactor;

            float finalDrag = startDrag + speedDrag + flapDrag;

            rb.drag = finalDrag;
            rb.angularDrag = startAngularDrag * forwardSpeed;
        }



        void HandleRigibodyTransform()
        {
            if (rb.velocity.magnitude > 1f)
            {
                Vector3 updateVelocity = Vector3.Lerp(rb.velocity, transform.forward * forwardSpeed, forwardSpeed * angleOfAttack * Time.deltaTime * rbLerpSpeed);
                rb.velocity = updateVelocity;

                Quaternion updateRotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(rb.velocity.normalized, transform.up), Time.deltaTime * rbLerpSpeed);
                rb.MoveRotation(updateRotation);
            }
        }


        void HandleControlSurfaceEfficiency()
        {
            csEfficiencyValue = controlSurfaceEfficiency.Evaluate(normalizeMPH);
        }



        void HandlePitch()
        {
            Vector3 flatForward = transform.forward;
            flatForward.y = 0f;
            flatForward = flatForward.normalized;
            pitchAngle = Vector3.Angle(transform.forward, flatForward);
            //Debug.Log(pitchAngle);

            Vector3 pitchTorque = input.Pitch * pitchSpeed * transform.right * csEfficiencyValue;
            rb.AddTorque(pitchTorque);
        }



        void HandleRoll()
        {
            Vector3 flatRight = transform.right;
          
            flatRight.y = 0f;

            
            flatRight = flatRight.normalized ;
            rollAngle = Vector3.SignedAngle(transform.right, flatRight,transform.forward);
           


            Vector3 rollTorque = -input.Roll * rollSpeed * transform.forward * csEfficiencyValue;
            rb.AddTorque(rollTorque);

        }



        void HandleYaw()
        {
            Vector3 yawTorque = input.Yaw * yawSpeed * transform.up * csEfficiencyValue;
            rb.AddTorque(yawTorque);
        }



        void HandleBanking()
        {
            float bankSide = Mathf.InverseLerp(-90f, 90f, rollAngle);
            float bankAmount = Mathf.Lerp(-1, 1f, bankSide);
            Vector3 bankTorque = bankAmount * rollSpeed * transform.up;
            rb.AddTorque(bankTorque);
        }

        #endregion
    }
}

