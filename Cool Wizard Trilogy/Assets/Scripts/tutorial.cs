using UnityEngine;
using System.Collections;

public class tutorial : MonoBehaviour {

	public GameObject tutObject;
	public GameObject creditsObject;
	bool credActive = false;
	public bool tutActive = true;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			TutorialState(!tutActive);
		}
	
	}

	public void TutorialState(bool active){
		tutObject.SetActive (active);
		tutActive = active;
		if (active) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}


	public void ChangeCreditsState(){
		if (credActive) {
			CreditsDeactivate ();
		} else {
			CreditsActivate();
		}
	}


	public void CreditsActivate(){
		creditsObject.SetActive (true);
		credActive = true;
	}
	public void CreditsDeactivate(){
		creditsObject.SetActive (false);
		credActive = false;
	}

	public void QuitGame(){
		Application.Quit ();
	}


}
