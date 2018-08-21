using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace WeLoveAero
{
    public static class Airplane_Setup_Tools
    {
        public static void BuildDefaultAirplane(string aName)
        {
            //Création du Game Object
            GameObject rootGO = new GameObject(aName, typeof(Airplane_Controller), typeof(Airplane_Input));


            //Création du gameobject COG (centre de gravité)
            GameObject cogGO = new GameObject("COG");
            cogGO.transform.SetParent(rootGO.transform, false);


            //Assignation des scripts dans l'éditor
            Airplane_Input input = rootGO.GetComponent<Airplane_Input>();
            Airplane_Controller controller = rootGO.GetComponent<Airplane_Controller>();
            Airplane_Characteristics characteristics = rootGO.GetComponent<Airplane_Characteristics>();


            //Setup du nouvel avion 
            if (controller)
            {
                //Assignation des composants dans l'editeur
                controller.input = input;
                controller.characteristics = characteristics;
                controller.centerOfGravity = cogGO.transform;

                //Création de la hierarchy du nouvel avion 
                GameObject graphicsGrp = new GameObject("Graphics_GRP");
                GameObject collisionGrp = new GameObject("Collision_GRP");
                GameObject controlSurfaceGrp = new GameObject("ControlSurfaces_GRP");

                graphicsGrp.transform.SetParent(rootGO.transform, false);
                collisionGrp.transform.SetParent(rootGO.transform, false);
                controlSurfaceGrp.transform.SetParent(rootGO.transform, false);

                //Création du moteur
                GameObject engineGO = new GameObject("Engine", typeof(Airplane_Engine));
                Airplane_Engine engine = engineGO.GetComponent<Airplane_Engine>();
                controller.engines.Add(engine);
                engineGO.transform.SetParent(rootGO.transform, false);

                //Création du model 3D  Regarder le chemin dans window du model 3D 
                //GameObject defaultAirplane = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Airbus Project/Art/Objects/Airplanes/IndiePixel_Airplanes/Indie-Pixel_Airplane/IndiePixel_Airplane.fbx", typeof(GameObject));
                GameObject defaultAirplane = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Airbus Project/Art/Objects/Airplanes/IndiePixel_Airplanes/F4U_Corsair/F4U_WithCockPit_Geo.fbx", typeof(GameObject));
                if (defaultAirplane)
                {
                    GameObject.Instantiate(defaultAirplane, graphicsGrp.transform);
                }
            }

            //Selection du setup de l'avion 
            Selection.activeGameObject = rootGO;

        }




        //F:\Unity Project\WeLoveAero\Assets\Airbus Project\Art\Objects\Airplanes\IndiePixel_Airplanes\Indie-Pixel_Airplane







    }
}
