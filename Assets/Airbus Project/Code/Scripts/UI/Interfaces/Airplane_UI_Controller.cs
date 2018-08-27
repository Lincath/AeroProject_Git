using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;  //permet de convertire un tableau en une liste
using WeLoveAero;



namespace WeLoveAero
{
    public class Airplane_UI_Controller : MonoBehaviour 
    {
        #region Variables
        public List<IAirplane_UI> instruments = new List<IAirplane_UI>();
        #endregion


        #region Basics Methods
    	// Use this for initialization
    	void Start () 
        {
            instruments = transform.GetComponentsInChildren<IAirplane_UI>().ToList<IAirplane_UI>();
    	}
    	
    	// Update is called once per frame
    	void Update () 
        {
            if(instruments.Count > 0)
            {
                foreach(IAirplane_UI instrument in instruments)
                {
                    instrument.HandleAirplaneUI();
                }
            }
    	}
        #endregion
    }
}
