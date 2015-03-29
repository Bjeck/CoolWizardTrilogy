using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	Rigidbody rigbody;
	Vector3 movementVector;
	public float speed = 5f;
	public GameObject cameraObject;
	public GameObject wizardVisionObj;
	wizardVisionControlScript wvcScr;

	// Use this for initialization
	void Start () {
		rigbody = GetComponent<Rigidbody> ();
		wvcScr = wizardVisionObj.GetComponent<wizardVisionControlScript> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		movementVector.x = Input.GetAxis ("Horizontal")*speed;
		movementVector.z = Input.GetAxis ("Vertical")*speed;

		rigbody.velocity = movementVector;
	

		if(Input.GetKeyDown(KeyCode.Z)){
			wvcScr.ChangeVisionState();


		}
	}
	
}
