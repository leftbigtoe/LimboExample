using UnityEngine;
using System.Collections;

public class ManualRenderRemote : MonoBehaviour {

	public GameObject target;
	public AlphaConstantFader fadingSphereFader;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void toggleTargetRenderer(){
		target.GetComponent<Renderer>().enabled = !target.GetComponent<Renderer>().enabled;
	}

	public void toggleRendererWithFade(){
		if (fadingSphereFader != null) {
			StartCoroutine(toggleObject (false));
		}
	}

	IEnumerator toggleObject(bool visible){

		//fadingSphereFader.gameObject.renderer.enabled = true;
		//toggleTargetRenderer ();
		// activate fading sphere
		fadingSphereFader.fadeIn ();
		yield return new WaitForSeconds(fadingSphereFader.tFade);


		//fadingSphereFader.gameObject.renderer.enabled = false;
		
	}

}
