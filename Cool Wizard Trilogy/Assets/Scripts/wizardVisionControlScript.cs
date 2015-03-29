using UnityEngine;
using System.Collections;

public class wizardVisionControlScript : MonoBehaviour {

	public bool inWizardVision = false;

	public float limit = 5;
	public float mode;
	public float dispVal;
	public float xVal;
	public float yVal;
	public float zVal;

	public Shader wizardVisionShader;
	public Shader normalShader;
	public Shader floorShader;
	public bool shouldSwitch = false;
	public bool randomizeEverything = false;
	float ridiculousTimer = 0f;
	float dispValGoal;

	//public AudioSource sound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		if (shouldSwitch) {
			shouldSwitch = false;
			//Debug.Log ("shouldswitch reset");
		}

		if(Input.GetKeyDown(KeyCode.Alpha1)){
			mode = 0;
		}
		else if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			mode = 1;
		}
		else if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			mode = 2;
		}
		else if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			mode = 3;
		}


		if (randomizeEverything) {
			if(ridiculousTimer <= 0){
				Camera.main.GetComponent<CRTshaderScript> ().enabled = false;
				dispValGoal = Random.Range(0.0f,1f);

				mode = Random.Range(0,4);
				if(mode == 2){
					ridiculousTimer = Random.Range(0.1f,0.4f);
				}
				else{
					ridiculousTimer = Random.Range(0.5f,2f);
				}

				int CRTDecider = Random.Range(0,4);
				if(CRTDecider == 0){
					Camera.main.GetComponent<CRTshaderScript> ().enabled = true;
				}

				//sound.Stop ();
				//sound.pitch = 1; sound.pitch += Random.Range(-0.2f,0.2f);
				//sound.Play ();

			}
			else{
				dispVal = Mathf.Lerp(dispVal,dispValGoal,0.01f);
				//dispVal = 1;
				ridiculousTimer -= Time.deltaTime;
			}

			xVal = Random.Range(-1f,1f);
			yVal = Random.Range(-1f,1f);
			zVal = Random.Range(-1f,1f);

		}

	}

	public void GoCrazy(){
		mode = 3;
		dispVal = 1;
		xVal = 1;
		yVal = 1;
		zVal = 1;
	}

	public void GoRidiculous(){
		mode = 3;
		ridiculousTimer = 0f;
		randomizeEverything = true;

	}

	public void DeactivateWizardVision(){
		mode = 1;
		dispVal = -1;
		xVal = 0;
		yVal = 0;
		zVal = 0;
		randomizeEverything = false;
		Camera.main.GetComponent<CRTshaderScript> ().enabled = false;
		//sound.Stop();

	}


		public void ChangeVisionState(){
			inWizardVision = !inWizardVision;
			//Debug.Log ("Change vision state "+inWizardVision);
			if(inWizardVision){
				GoRidiculous();
			}
			else{
				DeactivateWizardVision();
			}
			shouldSwitch = true;
		}
}
