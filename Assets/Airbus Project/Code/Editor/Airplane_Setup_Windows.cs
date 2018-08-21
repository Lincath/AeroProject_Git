
#region Explication du Script
/*
 CE SCRIPT PERMET DE CREER UN UNE FENETRE WINDOWS DANS LE MENU DEROULANT AIRPLANE TOOLS


 Méthodes:
     ONGUI () => fait l'interface de lafenetre windows qui pop 
 

 */
#endregion



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace WeLoveAero
{
    public class Airplane_Setup_Windows : EditorWindow
    {
        #region Variables
        private string wantedName;
        #endregion


        #region Basics Methods
        public static void LaunchSetupWindow()
        {
            // Permet de créer une fenetre Windows
            Airplane_Setup_Windows.GetWindow(typeof(Airplane_Setup_Windows), true, "Airplane Setup").Show();
        }


       
        void OnGUI()
        {
            //Création d'un champ texte
            wantedName = EditorGUILayout.TextField("Airplane Name:", wantedName);

            //Création d'un boutton
            if (GUILayout.Button("Create new Airplane"))
            {
                //Appel la Fonction de création du nouvel avion 
                Airplane_Setup_Tools.BuildDefaultAirplane(wantedName);

                //Ferme la fenetre windows
                Airplane_Setup_Windows.GetWindow<Airplane_Setup_Windows>().Close();
            }
        }
        #endregion
    }
}


