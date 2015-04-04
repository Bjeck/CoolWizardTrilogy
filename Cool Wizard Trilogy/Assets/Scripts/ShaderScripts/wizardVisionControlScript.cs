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
	public Shader pickupableObjectShader;
	public Shader enemyShader;
	public bool shouldSwitch = false;
	public bool randomizeEverything = false;
	float ridiculousTimer = 0f;
	float dispValGoal;

	bool inBombMode = false;
	bool bombShouldTrigger = false;
	bool bombWindupTrigger = false;

	public AudioSource saintsRowTheme;
	public AudioSource[] wizardVisionSounds;
	public AudioSource[] wizardGlitchSounds;
	AudioSource currentlyPlayingSound;

	public AudioSource BGMusic;
	bool hasPlayedIntroMusic = false;
	public AudioSource BGMusic2;
	AudioSource musicPlaying;
	
	public AudioSource[] imawizardSounds;
	public bool hasIntroed = false;

	// Use this for initialization
	void Start () {
		musicPlaying = BGMusic;
	}
	
	// Update is called once per frame
	void Update () {
		if (!SpellUIManager.instance.gameObject.GetComponent<tutorial> ().tutActive && !musicPlaying.isPlaying) {
			if (!inWizardVision) {
				SelectMusicToPlay();
				musicPlaying.Play();
			}
		}
		if (inWizardVision && musicPlaying.isPlaying) {
			musicPlaying.Stop ();
		}



		if (bombShouldTrigger) {
			inWizardVision = true;
			inBombMode = true;
			GoRidiculous();
			bombShouldTrigger = false;
			StartCoroutine(bombEffect(28.5f));
		}

		if (bombWindupTrigger) {
			inWizardVision = true;
			GoRidiculous();
			bombWindupTrigger = false;
			StartCoroutine(bombEffect(0.4f));
		}
	

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

				if(!inBombMode){
					if(mode == 2){
						if(currentlyPlayingSound != null){
							currentlyPlayingSound.Stop();
						}

						int soundChooser = Random.Range(0,wizardGlitchSounds.Length);
						currentlyPlayingSound = wizardGlitchSounds[soundChooser];
						currentlyPlayingSound.Play();
					}
					else{
						if(currentlyPlayingSound != null){
							currentlyPlayingSound.Stop();
						}
						int soundChooser = Random.Range(0,wizardVisionSounds.Length);
						currentlyPlayingSound = wizardVisionSounds[soundChooser];
						currentlyPlayingSound.Play();
					}
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
		if(currentlyPlayingSound != null){
			currentlyPlayingSound.Stop();
		}

	}


	public void ChangeVisionState(){
		if (!inBombMode) {
			if(hasIntroed){
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
			else{
				musicPlaying.Stop ();
				StartCoroutine(ImAWizIntro(1.5f));
			}
		}
	}

	public void ChangeVisionForBomb(){
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



	public IEnumerator ImAWizIntro(float time){
		imawizardSounds[0].Play();
		while (time > 0) {
			musicPlaying.Stop ();
			time -= Time.deltaTime;
			yield return 0;
		}
		hasIntroed = true;
		ChangeVisionState ();
	}




	public void GiantBomb(){
		//sound starts
		saintsRowTheme.Play ();
		StartCoroutine (bombWindUp (2.6f));
		//timer runs 2.5 seconds until bomb effect triggers (wizardvision)
		//trigger bombeffect, have it run again, this time longer and wizardvision is turned off

	}

	IEnumerator bombWindUp(float time){
		float microTimer = 0.0f;
		while (time > 0) {
			if(microTimer <= 0 && time > .637f){
				bombWindupTrigger = true;
				microTimer = 0.637f;
				//GO FOR 0.4 SECONDS
			}

			microTimer -= Time.deltaTime;
			time -= Time.deltaTime;
			yield return 0;
		}
		bombShouldTrigger = true;
	}

	IEnumerator bombEffect(float time){
		while (time > 0) {
			shouldSwitch = true;
			time -= Time.deltaTime;
			yield return 0;
		}
		//DeactivateWizardVision ();
		inBombMode = false;
		ChangeVisionForBomb ();
	}



	void SelectMusicToPlay(){
		if (hasPlayedIntroMusic) {
			musicPlaying = BGMusic2;
		} else {
			musicPlaying = BGMusic;
			hasPlayedIntroMusic = true;
		}
	}


}
