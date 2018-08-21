

#region Explication du Script
/*
 CE SCRIPT PERMET DE DEFINIR TOUS LES PARAMETRES QUE L'ON VEUT


 Méthodes:
     ONGUI () => fait l'interface de lafenetre windows qui pop 
 

 */
#endregion



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;          //Permet de convertir des tableaux en une liste 


namespace WeLoveAero
{
    [CustomEditor(typeof(Airplane_Controller))]
    public class Airplane_Controller_Editor : Editor
    {
        #region Variables
        private Airplane_Controller targetController;
        #endregion



        #region Basics Methods
        //Méthode qui se lance au lancement
        void OnEnable()
        {
            targetController = (Airplane_Controller)target;
        }


        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            //Créer de l'espace entre les boutons
            GUILayout.Space(15);

            if (GUILayout.Button("Get Airplane Components", GUILayout.Height(35)))
            {
                //Trouve le moteur
                targetController.engines.Clear();
                targetController.engines = FindAllEngines().ToList<Airplane_Engine>();

                //Trouve les roues de l'avion
                targetController.wheels.Clear();
                targetController.wheels = FindAllWheels().ToList<Airplane_Wheel>();

                //Trouve les controlles de surfaces
                targetController.controlSurfaces.Clear();
                targetController.controlSurfaces = FindAllControlSurfaces().ToList<Airplane_ControlSurface>();
            }

            if (GUILayout.Button("Create Airplane Preset", GUILayout.Height(35)))
            {
                //Permetde créer dans le projet le nouvel asset d'avion
                string filePath = EditorUtility.SaveFilePanel("Save Airplane Preset", "Assets", "New_Airplane_Preset", "asset");
                SaveAirplanePreset(filePath);
            }

            //Créer de l'espace entre les boutons
            GUILayout.Space(15);
        }
        #endregion



        #region Custom Methods

        //Créationd'un tableau pour le moteur
        Airplane_Engine[] FindAllEngines()
        {
            Airplane_Engine[] engines = new Airplane_Engine[0];
            if (targetController)
            {
                engines = targetController.transform.GetComponentsInChildren<Airplane_Engine>(true);
            }

            return engines;
        }


        //Créationd'un tableau pour les roues
        Airplane_Wheel[] FindAllWheels()
        {
            Airplane_Wheel[] wheels = new Airplane_Wheel[0];
            if (targetController)
            {
                wheels = targetController.transform.GetComponentsInChildren<Airplane_Wheel>(true);
            }

            return wheels;
        }


        //Créationd'un tableau pour les controles de surface
        Airplane_ControlSurface[] FindAllControlSurfaces()
        {
            Airplane_ControlSurface[] controlSurfaces = new Airplane_ControlSurface[0];
            if (targetController)
            {
                controlSurfaces = targetController.transform.GetComponentsInChildren<Airplane_ControlSurface>(true);
            }

            return controlSurfaces;
        }

        
        void SaveAirplanePreset(string aPath)
        {
            if (targetController && !string.IsNullOrEmpty(aPath))
            {
                //Pour que le chemin du path comment par Assets - l'enregistrment du nouvel asset se fera automiquement dans Assets
                string appPath = Application.dataPath;
                string finalPath = "Assets" + aPath.Substring(appPath.Length);
               

                //Création d'un nouveau preset
                Airplane_Preset newPreset = ScriptableObject.CreateInstance<Airplane_Preset>();
                newPreset.airplaneWeight = targetController.airplaneWeight;



                if (targetController.centerOfGravity)
                {
                    newPreset.cogPosition = targetController.centerOfGravity.localPosition;
                }

                //Les caracteristiques de l'avion
                if (targetController.characteristics)
                {
                    newPreset.dragFactor = targetController.characteristics.dragFactor;
                    newPreset.flapDragFactor = targetController.characteristics.flapDragFactor;
                    newPreset.maxMPH = targetController.characteristics.maxMPH;
                    newPreset.rbLerpSpeed = targetController.characteristics.rbLerpSpeed;
                    newPreset.liftCurve = targetController.characteristics.liftCurve;
                    newPreset.maxLiftPower = targetController.characteristics.maxLiftPower;
                    newPreset.pitchSpeed = targetController.characteristics.pitchSpeed;
                    newPreset.rollSpeed = targetController.characteristics.rollSpeed;
                    newPreset.yawSpeed = targetController.characteristics.yawSpeed;
                }

                //Création du final preset
                AssetDatabase.CreateAsset(newPreset, finalPath);
            }
        }
        
        #endregion


    }
}
