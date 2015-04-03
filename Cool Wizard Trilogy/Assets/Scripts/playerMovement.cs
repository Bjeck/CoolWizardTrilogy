using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerMovement : MonoBehaviour {

	Rigidbody rigbody;
	Vector3 movementVector;
	public float speed = 5f;
	public GameObject cameraObject;
	public GameObject wizardVisionObj;
	wizardVisionControlScript wvcScr;

	bool isTargeting = false;
	public GameObject targetCursor;
	Vector3 spellTarget;
	GameObject spellObject;
	public float spellSpeed;
    Card cardClicked;


	// Use this for initialization
	void Start () {
		rigbody = GetComponent<Rigidbody> ();
		wvcScr = wizardVisionObj.GetComponent<wizardVisionControlScript> ();
	}
	
	// Update is called once per frame
	void Update () {

		movementVector.x = Input.GetAxis ("Horizontal");
		movementVector.z = Input.GetAxis ("Vertical");
		movementVector = movementVector.normalized;
		movementVector *= speed;
		rigbody.velocity = movementVector;

        cardClicked = SpellUIManager.instance.cardClicked();


		if (cardClicked != null) { //updates the target cursor to mouse position and color to see range.
//			Debug.Log("CARD CLICKED "+cardClicked.name);

			//Vector3 temp = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			//temp.z = -1f;
			//targetCursor.transform.position = temp;

			if (Input.GetMouseButtonDown (0)) {
				RaycastHit hit;
				if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 100f)) {
					CastSpell(hit.point);
					isTargeting = false;
				}
			}
		}


		if(Input.GetKeyDown(KeyCode.Z)){
			wvcScr.ChangeVisionState();
		}


		if (Input.GetKeyDown (KeyCode.U)) {
			Application.LoadLevel(Application.loadedLevel);
		}

	}

	//right now, just generic spell. include spell, probably, when we get there.
	void CastSpell(Vector3 target){
		spellObject = (GameObject)Instantiate(Resources.Load("SpellObject",typeof(GameObject)));
		spellObject.transform.position = transform.position;
		target.y = transform.position.y;
		spellObject.GetComponent<SpellObjectScript> ().dir = (target - spellObject.transform.position).normalized;
		spellObject.GetComponent<SpellObjectScript> ().spellName = cardClicked.name;
	}
}
