using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopPrefabFigure : MonoBehaviour {

   // private Renderer m_Renderer;
    private GameObject objectOnCollider;


    void Start () {

       // m_Renderer = GetComponent<Renderer>();

        //m_Renderer.enabled = false;

    }
	

	void Update () {

        
    }

    void OnTriggerEnter(Collider other)
    {

        Renderer m_Renderer = other.gameObject.GetComponent<Renderer>();
        m_Renderer.enabled = false;

    }

}
