
#region Explication du Script
/*
 CE SCRIPT PERMET DE CREER UN MENU DEROULANT POUR CREER DE  NOUVEAUX AVIONS


 Méthodes:
     
 

 */
#endregion




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace WeLoveAero
{

    public static class Airplane_Menus 
    {
        [MenuItem("Airplane Tools/Create New Airplane")]
        public static void CreateNewAirplane()
        {
            /*
            GameObject curSelected = Selection.activeGameObject;
            if (curSelected)
            {
                curSelected.AddComponent<Airplane_Controller>();
            }
            */
            Airplane_Setup_Tools.BuildDefaultAirplane("New Airplane");


        }
    }
    
}




