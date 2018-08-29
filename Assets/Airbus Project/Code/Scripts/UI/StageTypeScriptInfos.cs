using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageTypeScriptInfos: MonoBehaviour {
    public string TypeDeStage;
    public string TitreStage;
    public Text TypeStageText;
    public Text TitreStageText;
    // Use this for initialization
    void Start () {

        TypeStageText.text = "Type: " + TypeDeStage;
        TitreStageText.text = TitreStage;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
