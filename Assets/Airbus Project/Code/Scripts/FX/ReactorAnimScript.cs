using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeLoveAero;

namespace WeLoveAero
{

    public class ReactorAnimScript : MonoBehaviour
    {
        public GameObject UI_Ingame;
        public Animator animator;
        private MainMenuInGame scriptUI_InGame;
        private int ModeMoteur;
        // Use this for initialization
        void Start()
        {
            animator = GetComponent<Animator>();

        }

        // Update is called once per frame
        void Update()
        {

            scriptUI_InGame = UI_Ingame.GetComponent<MainMenuInGame>();

        }

        public void PlayAnimationReacteur(int newValue)
        {
            ModeMoteur = newValue;
            animator.SetInteger("ModeMoteur", ModeMoteur);
            Debug.Log("modeMoteur = " + ModeMoteur);
        }


    }
}
