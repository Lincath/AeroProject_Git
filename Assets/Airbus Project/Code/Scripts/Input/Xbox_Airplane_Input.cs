

#region Explication du Script
/*
 CE SCRIPT HERITE DU SCRIPT Airplane_Input 

 IL ACTUALISE LES INPUTS DE L'AVION LORSQUE L"ON UTILISE LA MANETTE XBOX


 Méthodes:
    HandleInput () => fonction qui override la fonction HandleInput de Airplane_Input
    StickyThrottleControl() => Methode qui permet de controler la puissance du moteur
 */
#endregion


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeLoveAero
{
    public class Xbox_Airplane_Input : Airplane_Input
    {
        #region Custom Methods
        protected override void HandleInput()
        {
            //Appelle les inputs claviers
            base.HandleInput();
           

            // edition des inputs dans   Edit -> project settings -> Input -> Axes
            pitch += Input.GetAxis("Vertical");
            roll += Input.GetAxis("Horizontal");
            yaw += Input.GetAxis("X_RH_Stick");
            throttle += Input.GetAxis("X_RV_Stick");


            // controle des freins
            // creation de float avec vrai faux  ( comme si c'etait un bool)
            // la condition? deux resultats possible
            brake = Input.GetAxis("Fire1");


            //control des ailerons
            if (Input.GetButtonDown("X_R_Bumper"))
            {
                flaps += 1;
            }


            if (Input.GetButtonDown("X_L_Bumper"))
            {
                flaps -= 1;
            }

            flaps = Mathf.Clamp(flaps, 0, maxFlapsIncrements);


            //Camera Switch Button
            cameraSwitch = Input.GetButtonDown("X_Y_Button") || Input.GetKeyDown(cameraKey);
        }
        #endregion
    }
}



