using UnityEngine;
using System.Collections;

public class AlphaConstantFader : MonoBehaviour {

	public float tFade = 0.5f;
	public float maxConstant = 1;
	public float minConstant = 0;

	public bool isVisible = false;

	private float tZero = 0;

	private bool fading = false;

	private Color c;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.SetFloat("_Constant", 0);

	}
	
	// Update is called once per frame
	void Update () {
		if(isVisible){
			float t = (Time.time - tZero) / tFade;
			
			GetComponent<Renderer>().material.SetFloat("_Constant", Mathf.Lerp(minConstant, maxConstant, t));

			//if(t >= 1.0f) fading = false;

		}else{
			float t = (Time.time - tZero) / tFade;

			GetComponent<Renderer>().material.SetFloat("_Constant", Mathf.Lerp(maxConstant, minConstant, t));	

			//if(t >= 1.0f) fading = false;
		}
	}

	public void fadeIn(){
		//if(!fading){
			if(!isVisible){
				isVisible = true;
				tZero = Time.time;
				fading = true;
			}
		//}
	}

	public void fadeOut(){
		//if(!fading){
			if (isVisible) {
				isVisible = false;
				tZero = Time.time;
				fading = true;
			}
		//}
	}


}
