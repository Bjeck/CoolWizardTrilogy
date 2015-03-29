using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {

	public GameObject player;
	Vector3 cameraPos;
	public float camHeight;
	public float camXOffSet = -2.24f;
	public float camSpeed = 2f;
	public float LerpSpeed = 0.1f;
	public float LerpspeedModifier = 0.05f;
	public float camXThreshold = 2f;
	public float camZThreshold = 2f;
	float horiz;
	float verti;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		cameraPos = player.transform.position;

		horiz = Input.GetAxis ("Horizontal") * camSpeed;
		verti = Input.GetAxis ("Vertical") * camSpeed;
		cameraPos.x += horiz;
		cameraPos.z += verti;

		LerpSpeed = LerpspeedModifier;
		LerpSpeed *= Vector3.Distance (cameraPos, transform.position);
		cameraPos.y += camHeight;
		cameraPos.z += camXOffSet;

		transform.position = new Vector3 (Mathf.Lerp (transform.position.x, cameraPos.x, LerpSpeed),
		                                 Mathf.Lerp (transform.position.y, cameraPos.y, LerpSpeed),
		                                 Mathf.Lerp (transform.position.z, cameraPos.z, LerpSpeed));

	
	}
}
