using UnityEngine;
using System.Collections;

public class LimboController : MonoBehaviour {

	public GameObject world;
	public Terrain terrain;
	public AlphaFader fadingSphere;
	public GameObject groundPlane;
	public GameObject limboParticleParent;
	public GameObject limboBackground;

	public bool fadeTerrain = true;
	public bool useLimboBackground = true;
	public bool useGroundPlane = true;
	public bool useParticles = true;


	// public variables for use with the animation system
	public static bool limboActive = false;
	public GameObject[] camPosObjects;

	private Renderer[] rends;

	// Use this for initialization
	void Awake () {
		rends = world.GetComponentsInChildren<Renderer> ();
		groundPlane.GetComponent<Renderer>().enabled = false;
		limboParticleParent.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}


	public void enterLimbo (){
		StartCoroutine (_fadeSphereProcess ());
		StartCoroutine(_toggleLimboProcess (false));
	}

	public void enterLimboTo (int i){
		StartCoroutine (_fadeSphereProcess ());
		StartCoroutine(_toggleLimboProcess (false));
		jumpToPos (i);
	}

	public void leaveLimbo(){
		StartCoroutine (_fadeSphereProcess ());
		StartCoroutine(_toggleLimboProcess (true));
	}

	public void leaveLimboToPos(int i){
		StartCoroutine (_fadeSphereProcess ());
		StartCoroutine(_toggleLimboProcess (true));
		jumpToPos (i);
	}
	
	public void fadeSphereInOut(){
		StartCoroutine (_fadeSphereProcess ());
	}

	public void jumpToPos(Vector3 newPos, Quaternion newRot){
		StartCoroutine (_fadeSphereProcess ());
		StartCoroutine (_jumpToProcess (newPos, newRot));
	}

	public void jumpToPos(Vector3 newPos, Vector3 newRot){
		jumpToPos(newPos, Quaternion.Euler(newRot));
	}

	public void jumpToPos(int i){
		jumpToPos (camPosObjects[i].transform.position,
		                     camPosObjects[i].transform.rotation);
	}



	// #### coroutines for fine grained temporal control of the fading ####


	private IEnumerator _toggleLimboProcess(bool visible){

		yield return new WaitForSeconds(fadingSphere.tFade);

		limboActive = !visible;

		if(useLimboBackground)
			limboBackground.GetComponent<Renderer>().enabled = !visible;

		if(useGroundPlane)	
			groundPlane.GetComponent<Renderer>().enabled = !visible;

		if(useParticles)
			limboParticleParent.SetActive (!visible);

		// toggle the world
		foreach (Renderer r in rends) {
			r.enabled = visible;
		}

		// if a terrain is there, toggle it as well
		if (terrain && fadeTerrain) {
			terrain.enabled = visible;
		}
	}

	private IEnumerator _fadeSphereProcess(){
		
		// activate fading sphere
		fadingSphere.fadeIn ();
		yield return new WaitForSeconds(fadingSphere.tFade);
		
		// deacticvate fading sphere
		fadingSphere.fadeOut ();
		//yield return new WaitForSeconds(fadingSphere.tFade);
		
	}

	private IEnumerator _jumpToProcess(Vector3 newPos, Quaternion newRot){
		
		// activate fading sphere
		fadingSphere.fadeIn ();
		yield return new WaitForSeconds(fadingSphere.tFade);

		// set new position and rotation
		gameObject.transform.position = newPos;
		gameObject.transform.rotation = newRot;

		// deacticvate fading sphere
		fadingSphere.fadeOut ();
		//yield return new WaitForSeconds(fadingSphere.tFade);
		
	}
}
