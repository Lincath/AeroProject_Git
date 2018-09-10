using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feedBackCheckPoint : MonoBehaviour
{
    private Transform transformArrow;
    public GameObject fourArrow;


    // Use this for initialization
    void Start()
    {

        transformArrow = this.gameObject.transform.GetChild(0);
        fourArrow = this.gameObject.transform.GetChild(0).gameObject;

        setUnactiveArrows();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setActiveArrows()
    {
        fourArrow.SetActive(true);
    }

    public void setUnactiveArrows()
    {
        fourArrow.SetActive(false);
    }
}
