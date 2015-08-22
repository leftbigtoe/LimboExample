using UnityEngine;
using System.Collections;

public class LimboControllerRelay : MonoBehaviour {

	[SerializeField]
	LimboController limboController;
	[SerializeField]
	string limboState = "limboActive";

	int limboStateHsh;
	Animator ani;


	public void enterLimbo(){
		limboController.enterLimbo ();
	}

	public void leaveLimbo(){
		limboController.leaveLimbo ();
	}

	public void Start(){
		ani = GetComponent<Animator> ();
		limboStateHsh = Animator.StringToHash (limboState);
	}

	public void Update(){
		// tell the animator if the limbo is active or not
		ani.SetBool (limboStateHsh, LimboController.limboActive);
	}

}
