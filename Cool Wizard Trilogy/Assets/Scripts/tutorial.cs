using UnityEngine;
using System.Collections;

public class tutorial : MonoBehaviour {

	public GameObject tutObject;
	bool tutActive = true;

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
}
