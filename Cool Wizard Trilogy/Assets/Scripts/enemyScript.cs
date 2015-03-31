using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {

	public bool canMove = false;
	GameObject wizardControlObj;
	wizardVisionControlScript wvcScr;
	GameObject player;
	Rigidbody rig;

	// Use this for initialization
	void Start () {
		wizardControlObj = GameObject.FindGameObjectWithTag ("wizardVisionController");
		wvcScr = wizardControlObj.GetComponent<wizardVisionControlScript> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		rig = GetComponent<Rigidbody> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		canMove = wvcScr.inWizardVision;

		if (canMove) {
			rig.velocity = player.transform.position - transform.position;
		}
	
	}

}
