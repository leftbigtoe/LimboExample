using UnityEngine;
using System.Collections;

public class SimpleWalking : MonoBehaviour {

	public float walkingSpeed = 1;
	public float stravingSpeed = 0.5f;
	public float turningSpeed = 60;

	CharacterController c;

	// Use this for initialization
	void Start () {
		c = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W)){
			c.SimpleMove(transform.forward * walkingSpeed);
		}
		if(Input.GetKey(KeyCode.S)){
			c.SimpleMove(-1 * transform.forward * walkingSpeed);
		}
		if(Input.GetKey(KeyCode.D)){
			c.SimpleMove(transform.right * stravingSpeed);
		}
		if(Input.GetKey(KeyCode.A)){
			c.SimpleMove(-1 * transform.right * stravingSpeed);
		}

		transform.Rotate(Vector3.up,    Time.deltaTime * turningSpeed * Input.GetAxis("Mouse X"), Space.Self);
		transform.Rotate(Vector3.right, Time.deltaTime * turningSpeed * Input.GetAxis("Mouse Y"), Space.Self);
	}
}
