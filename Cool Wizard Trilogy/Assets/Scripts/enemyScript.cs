using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {

	public bool canMove = false;
	GameObject wizardControlObj;
	wizardVisionControlScript wvcScr;
	GameObject player;
	Rigidbody rig;
	public float speed = 6f;
	public float maxDistToChase;
	string name;
	TextMesh nameText;

	// Use this for initialization
	void Start () {
		wizardControlObj = GameObject.FindGameObjectWithTag ("wizardVisionController");
		wvcScr = wizardControlObj.GetComponent<wizardVisionControlScript> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		rig = GetComponent<Rigidbody> ();
		nameText = GetComponentInChildren<TextMesh> ();
		//Debug.Log (nameText);

		nameText.text = GameObject.FindGameObjectWithTag ("EnemyNameManager").GetComponent<EnemyNameManager> ().GetName ();
		//Debug.Log (nameText.text);
	}
	
	// Update is called once per frame
	void Update () {
		canMove = wvcScr.inWizardVision;

		if (canMove) {
			float dist = Vector3.Distance(player.transform.position,transform.position);
			if(dist < maxDistToChase){
				rig.velocity = (player.transform.position - transform.position).normalized*speed;
			}

		}
	
	}

	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "Player" && wvcScr.inWizardVision) {

			rig.AddForce((transform.position-player.transform.position)*40f,ForceMode.VelocityChange);
			c.gameObject.GetComponent<Rigidbody>().AddForce((player.transform.position - transform.position)*40f,ForceMode.VelocityChange);
		}
	}


}
