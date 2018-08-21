
#region Explication du Script
/*
 CE SCRIPT PERMET DE DEFINIR LES INPUTS VIRTUEL DE L'AVION
 DE MANIERE GENERALE

 IL SERVIRA DE SCRIPT  REFERENCE POUR LES DIFFERENTS SCRIPTS
 QUI SERONT EN HERITAGE PAR RAPPORT A CELUI CI


 Méthodes:
    HandleInput () => fonction qui attribue les inputs à chaque mouvement de l'avion
 */
#endregion


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace WeLoveAero
{

    //creation d'un visuel editor dans le script concerné
    [CustomEditor(typeof(Airplane_Input))]

    public class Airplane_Input_Editor : Editor
    {
        #region Variables
        private Airplane_Input targetInput;
        #endregion



        #region Bultin Methods
        void OnEnable()
        {
            targetInput = (Airplane_Input)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            string debugInfo = "";
            debugInfo += "Pitch = " + targetInput.Pitch + "\n";
            debugInfo += "Roll = " + targetInput.Roll + "\n";
            debugInfo += "Yaw = " + targetInput.Yaw + "\n";
            debugInfo += "Throttle = " + targetInput.Trottle + "\n";
            debugInfo += "Brake = " + targetInput.Brake + "\n";
            debugInfo += "Flaps = " + targetInput.Flaps + "\n";

            //création visuel de l'éditeur
            GUILayout.Space(20);
            EditorGUILayout.TextArea(debugInfo, GUILayout.Height(100));
            GUILayout.Space(20);

            Repaint();
        }
        #endregion
    }
}