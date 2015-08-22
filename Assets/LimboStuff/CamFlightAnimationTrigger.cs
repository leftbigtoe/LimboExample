using UnityEngine;
using System.Collections;

public class CamFlightAnimationTrigger : MonoBehaviour {
	
	[SerializeField]
	string limboStateName = "limboActive";
	[SerializeField]
	LimboController limboController;

	int limboStateHsh;
	
	Animator ani;
	int flightIdx;

	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator> ();
		limboController = GetComponent<LimboController> ();
		limboStateHsh = Animator.StringToHash (limboStateName);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && !LimboController.limboActive) {
			limboController.enterLimbo();
		}

		// tell the animator if the limbo is active or not
		ani.SetBool (limboStateHsh, LimboController.limboActive);
	}
}
