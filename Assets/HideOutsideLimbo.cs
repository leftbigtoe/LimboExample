using UnityEngine;
using System.Collections;

public class HideOutsideLimbo : MonoBehaviour {

	public bool hideOutsideLimbo = true;
	Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!LimboController.limboActive) {
			rend.enabled = false;
		}
	}
}
