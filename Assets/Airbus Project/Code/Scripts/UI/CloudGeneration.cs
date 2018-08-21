using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGeneration : MonoBehaviour {

    public Transform nuage;

    public GameObject flair;


    // Collider m_avion;
    // public GameObject avion;
    // Use this for initialization
    void Start () {
        //m_avion = GetComponent<Collider>();
        // m_avion.isTrigger = false;
        //Debug.Log("Trigger On:" + m_avion.isTrigger);
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

         void OnTriggerEnter(Collider other)
    {
        //Output the Collider's GameObject's name
        //  Debug.Log("on collider");
       
        if (other.tag == "cloud")
        {
            // GameObject nuage= GameObject.FindGameObjectWithTag("cloud");
            //GameObject nuage = other.gameObject;
            //nuage.SetActive(true);
            nuage = other.transform.GetChild(0);

            //nuage.transform.GetChild(0).gameObject.SetActive(true);
            //nuage.SetActive(false);
           // Debug.Log(nuage);

        }


        if (other.tag == "Player")
        {
            Debug.Log("nuage2");
        }

    }


    //to change color of flairs


    void ChangeColorFlair()
    {
          
       // flair.GetComponent<ParticleSystem>().startColor = new Color(1, 0, 1, .5f);

    }


}
