using UnityEngine;
using System.Collections;

public class ShaderControlObjectScript : MonoBehaviour {


	GameObject wizardControlObj;
	wizardVisionControlScript wvcScr;

	bool switchShader = false;

	//public float limit = 5;
	//public float yval = 0;



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
				GetComponent<Renderer>().material.shader = wvcScr.wizardVisionShader;
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
			
			//it's dumb to do this every frame.
			GetComponent<Renderer>().material.SetFloat("_MOVE",wvcScr.mode);
		}
	}
}



/*
 	if(Input.GetKey(KeyCode.Space)) {
//			Debug.Log("HEJ");
			GetComponent<Renderer>().material.SetFloat("_DISPVALUE",Mathf.Lerp(GetComponent<Renderer>().material.GetFloat("_DISPVALUE"),-1,Time.deltaTime*25));          
		}
		else{
			GetComponent<Renderer>().material.SetFloat("_DISPVALUE",Mathf.Lerp(GetComponent<Renderer>().material.GetFloat("_DISPVALUE"),1,Time.deltaTime*25));
		}

		if(Input.GetKey(KeyCode.G)){
			GetComponent<Renderer>().material.SetFloat("_DISPVALUE",wvcScr.yval);
		}
*/