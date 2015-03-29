using UnityEngine;
using System.Collections;

public class ShaderControlFloorScript : MonoBehaviour {


	GameObject wizardControlObj;
	wizardVisionControlScript wvcScr;
	
	bool switchShader = false;

	// Use this for initialization
	void Start () {
		wizardControlObj = GameObject.FindGameObjectWithTag ("wizardVisionController");
		wvcScr = wizardControlObj.GetComponent<wizardVisionControlScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		switchShader = wvcScr.shouldSwitch;
		//Debug.Log (switchShader + "  " + wvcScr.shouldSwitch);
		
		if (switchShader) {
			//Debug.Log ("switching "+wvcScr.inWizardVision);
			if(wvcScr.inWizardVision){
				//NON WIZARD SHADER
				//Debug.Log ("Normal Shader");
				GetComponent<Renderer>().material.shader = wvcScr.floorShader;
			}
			else{
				//Debug.Log ("Wizard Shader");
				GetComponent<Renderer>().material.shader = wvcScr.normalShader;
			}
			switchShader = false;
		}

		if (wvcScr.inWizardVision) {
			GetComponent<Renderer>().material.SetFloat("_DISPVALUE",wvcScr.dispVal);
			GetComponent<Renderer> ().material.SetFloat ("_XPOS", wvcScr.xVal);
			GetComponent<Renderer> ().material.SetFloat ("_YPOS", wvcScr.yVal);
			GetComponent<Renderer> ().material.SetFloat ("_ZPOS", wvcScr.zVal);
		}

	}
}
