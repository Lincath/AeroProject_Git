using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeLoveAero;

namespace WeLoveAero
{
    public class ScriptButtonInGame : MonoBehaviour
    {

        public Animation animScale;
        public Animator anim;
        public int IdBouton; //permet de savoir sur quel bouton le joueur a appuyer pour lancer la page correspondante
        private Animator animator;

        public GameObject CanvasMenu;

        private MainMenu scriptMainMenu; //le nom de mon script main menu qui gere mon menu dans le canvas





        // Use this for initialization
        void Start()
        {



            //  animator.SetBool("test", false);

            animator = GetComponent(typeof(Animator)) as Animator;

            scriptMainMenu = CanvasMenu.GetComponent<MainMenu>();

            animScale = GetComponent<Animation>();



        }

        // Update is called once per frame
        void Update()
        {



        }








    }
}

