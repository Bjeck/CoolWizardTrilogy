using UnityEngine;
using System.Collections;

public class ShaderControlPickupableObjectScript : MonoBehaviour {


	GameObject wizardControlObj;
	wizardVisionControlScript wvcScr;

	bool switchShader = false;
	float randomTimer = 0f;
	bool glitchCard = false;

	//public float limit = 5;
	//public float yval = 0;



	// Use this for initialization
	void Start () {
		wizardControlObj = GameObject.FindGameObjectWithTag ("wizardVisionController");
		wvcScr = wizardControlObj.GetComponent<wizardVisionControlScript> ();

		GetComponent<Renderer> ().material.SetFloat ("_DISPVALUE", 5);
		GetComponent<Renderer> ().material.SetFloat ("_XPOS", wvcScr.xVal);
		GetComponent<Renderer> ().material.SetFloat ("_YPOS", wvcScr.yVal);
		GetComponent<Renderer> ().material.SetFloat ("_ZPOS", wvcScr.zVal);
		
		//it's dumb to do this every frame.
		GetComponent<Renderer> ().material.SetFloat ("_MOVE", 0);
	
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
				GetComponent<Renderer>().material.shader = wvcScr.pickupableObjectShader;
			}
			else{
				//Debug.Log ("Wizard Shader");
				GetComponent<Renderer>().material.shader = wvcScr.normalShader;
			}
			switchShader = false;
		}

		if (wvcScr.inWizardVision) {
			GetComponent<Renderer> ().material.SetFloat ("_DISPVALUE", 5);
			GetComponent<Renderer> ().material.SetFloat ("_XPOS", wvcScr.xVal*2);
			GetComponent<Renderer> ().material.SetFloat ("_YPOS", wvcScr.yVal*2);
			GetComponent<Renderer> ().material.SetFloat ("_ZPOS", wvcScr.zVal*2);
			
			//it's dumb to do this every frame.
			GetComponent<Renderer> ().material.SetFloat ("_MOVE", 0);

		} else {

			//GLITCHING:
			if (glitchCard) {
				randomTimer -= Time.deltaTime;
				GetComponent<Renderer> ().material.SetFloat ("_XPOS", Random.Range(-1f,1f));
				GetComponent<Renderer> ().material.SetFloat ("_YPOS", Random.Range(-1f,1f));
				GetComponent<Renderer> ().material.SetFloat ("_ZPOS", Random.Range(-1f,1f));
				if (randomTimer <= 0) {
					glitchCard = false;
					GetComponent<Renderer> ().material.shader = wvcScr.normalShader;
					GetComponent<Renderer> ().material.SetFloat ("_DISPVALUE", 5);
					GetComponent<Renderer> ().material.SetFloat ("_MOVE", 0);
					randomTimer = Random.Range (1f, 8f);
				}
			} else {
				randomTimer -= Time.deltaTime;
				if (randomTimer <= 0) {
					glitchCard = true;
					GetComponent<Renderer> ().material.shader = wvcScr.pickupableObjectShader;
					randomTimer = Random.Range (0.1f, 0.2f);
				}
			}
		}

	} // Update End
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