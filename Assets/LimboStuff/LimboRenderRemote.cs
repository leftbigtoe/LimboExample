using UnityEngine;
using System.Collections;

public class LimboRenderRemote : MonoBehaviour {

	public GameObject[] visibleInLimbo;
	public GameObject[] invisibleInLimbo;
	
	private bool limboLastFrame = true;

	// Update is called once per frame
	void Update () {
		// if limbo state has changed, toggle the renderer
		if (LimboController.limboActive != limboLastFrame) {
			foreach(GameObject g in visibleInLimbo){
				g.GetComponent<Renderer>().enabled = LimboController.limboActive;
			}
			foreach(GameObject g in invisibleInLimbo){
				g.GetComponent<Renderer>().enabled = !LimboController.limboActive;
			}
		}
		limboLastFrame = LimboController.limboActive;
	}
}
