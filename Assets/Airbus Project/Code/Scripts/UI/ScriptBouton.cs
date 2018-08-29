using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBouton : MonoBehaviour {
    public Animation animScale;
    public Animator anim;
    public int IdBouton; //permet de savoir sur quel bouton le joueur a appuyer pour lancer la page correspondante
    private Animator animator;

    public GameObject CanvasMenu;

    private MainMenu scriptMainMenu; //le nom de mon script main menu qui gere mon menu dans le canvas
    

 


// Use this for initialization
void Start () {

       

        //  animator.SetBool("test", false);

        animator = GetComponent(typeof(Animator)) as Animator;

        scriptMainMenu = CanvasMenu.GetComponent<MainMenu>();

        animScale = GetComponent<Animation>();



    }

    // Update is called once per frame
    void Update () {

        if (animator.GetBool("test") == true)
        {
            if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("AnimBoutonType1") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                Debug.Log("animationEnd");
                if (IdBouton == 1) //tuto
                {

                }

                if (IdBouton == 2)  //arcade
                {

                }

                if (IdBouton == 3)  //cup
                {
                    Debug.Log("IDCup");
                  //  scriptMainMenu.PlayCup();
                }
                if (IdBouton == 4) //hangar
                {
                    Debug.Log("IDhangar");
                    scriptMainMenu.PlayHangar();

                }

                if (IdBouton == 5)   //doc
                {
                    Debug.Log("documentation");
                    scriptMainMenu.PlayHangar();
                }

                if (IdBouton == 6)   //we love aero
                {

                }


            }
        }

    }


    public void AnimBouton()  //lancé depuis le bouton
    {

        animator.SetBool("test", true); //lance l animation du bouton dans l update
        Debug.Log("animhangar");


    }

    public void ScaleBouton()  //lancé depuis le bouton
    {
     

    


    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("0");
      // animator.SetBool("IfScale", true);
        //Animation.animScale.play
        animator.Play("AnimBoutonScale");



        if (other.gameObject.tag == "ScaleCollider")
        {
            Debug.Log("scaleDebug");
            ScaleBouton();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("IfScale", false);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "ScaleCollider")
        {
            Debug.Log("scaleDebug");
        }
    }

 

    public void ResetBoutons()
    {
        animator.SetBool("test", false);
    }

    public void test()
    {
        Debug.Log("test");
    }
}
