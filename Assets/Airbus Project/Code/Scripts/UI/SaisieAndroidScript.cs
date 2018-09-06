using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SaisieAndroidScript : MonoBehaviour {
   
    private TouchScreenKeyboard clavier;
    public Text txt;
    string Pseudo;

    // Use this for initialization

    // Update is called once per frame
    private void Start()
    {
       /* clavier = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        //TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, true);
        //  TouchScreenKeyboard.area returns(0, 0, 0, 0);
        clavier = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.ASCIICapable);   */
    }
    void Update () {

      /*  if (TouchScreenKeyboard.visible == false && clavier != null)
        {
            Debug.Log("test2");
           // if (clavier.done)
            //{
                Debug.Log("test3  "+Pseudo);
                Pseudo = clavier.text;
                txt.text = "Bonjour" + Pseudo;
                clavier = null;
            
           // }
        }     */
		
	}

    public void OpenKeyboard()
    {
        clavier = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, true);
        //clavier = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        Debug.Log("test");
    }

    public void Vibreur()
    {
        Handheld.Vibrate();
    }
}
