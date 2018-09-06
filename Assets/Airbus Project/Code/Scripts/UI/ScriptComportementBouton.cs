using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeLoveAero;

namespace WeLoveAero
{

    public class ScriptComportementBouton : MonoBehaviour
    {
        private ScriptBouton ScriptBouton;
        private Animator animator;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            animator.SetBool("test", true);

            Debug.Log("test");
            if (other.tag == "ScaleCollider")
            {
                Debug.Log("scaleDebug");

            }
        }
    }
}
