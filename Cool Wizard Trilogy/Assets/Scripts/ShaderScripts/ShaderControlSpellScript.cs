using UnityEngine;
using System.Collections;

public class ShaderControlSpellScript : MonoBehaviour {


	GameObject wizardControlObj;
	wizardVisionControlScript wvcScr;
	public AudioSource spellSound;

	float timer = 0.5f;

	//public float limit = 5;
	//public float yval = 0;



	// Use this for initialization
	void Start () {
		wizardControlObj = GameObject.FindGameObjectWithTag ("wizardVisionController");
		wvcScr = wizardControlObj.GetComponent<wizardVisionControlScript> ();
		GetComponent<Renderer> ().material.SetFloat ("_DISPVALUE", 10);
		GetComponent<Renderer> ().material.SetFloat ("_MOVE", 1);
		timer = Random.Range (0.3f, 0.7f);


	
	}
	
	// Update is called once per frame
	void Update () {

		if (timer < 0) {
			GetComponent<Renderer>().material.shader = wvcScr.normalShader;
			Destroy(GetComponent<ShaderControlSpellScript>());
		}
		if (spellSound != null && !spellSound.isPlaying) {
			spellSound.Play ();
		}
		
			GetComponent<Renderer>().material.SetFloat("_DISPVALUE",wvcScr.dispVal);
			GetComponent<Renderer> ().material.SetFloat ("_XPOS", Random.Range(-0.5f,0.5f));
			GetComponent<Renderer> ().material.SetFloat ("_YPOS", Random.Range(-0.5f,0.5f));
			GetComponent<Renderer> ().material.SetFloat ("_ZPOS", Random.Range(-0.5f,0.5f));
			GetComponent<Renderer> ().material.SetColor ("_COLOR",new Color (Random.Range (0, 2), Random.Range (0, 2), Random.Range (0, 2), 1));
			
			//it's dumb to do this every frame.
			GetComponent<Renderer>().material.SetFloat("_MOVE",3);

			timer -= Time.deltaTime;
				//Debug.Log ("Wizard Shader");
		
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