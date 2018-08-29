using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



namespace WeLoveAero
{
    //creation d'un visuel editor dans le script concerné
    [CustomEditor(typeof(Android_Airplane_Input2))]

    public class Android_Airplane_Editor : Editor
    {
        #region Variables
        private Android_Airplane_Input2 targetInput;
        #endregion



        #region Basics Methods
        void OnEnable()
        {
            targetInput = (Android_Airplane_Input2)target;
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
