using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseColorTrail : MonoBehaviour {

    public ParticleSystem flair;
    public int chargeFlair;
    public Gradient particleColorGradient;
	// Use this for initialization
	void Start () {
        chargeFlair = 10000;
	}

    // Update is called once per frame

    void ChangeColorFlair ()
    {
        ParticleSystem.MainModule psMain = flair.main;
        psMain.startColor = particleColorGradient.Evaluate(Random.Range(0f, 1f));

    }


    void Update () {

        if (Input.GetKey("space"))
        {
            if (chargeFlair >= 0)
            {
                flair.Emit(1);
               // Debug.Log("charge flair: " + chargeFlair);
                chargeFlair = chargeFlair - 1;
            }
        }


        if (Input.GetKey("down"))
        {
            ChangeColorFlair();
        }

    }
}
