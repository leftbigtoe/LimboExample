using UnityEngine;
using System.Collections;

public class AlphaFader : MonoBehaviour {

	public float tFade = 0.5f; 
	public float maxAlpha = 1; 
	public float minAlpha = 0;
	public string colorName = "_TintColor";

	private bool isVisible = false;
	
	private float fadeProgress = 0.1f;
	private Color opaqueColor;
	private Color transparentColor;
	private Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		opaqueColor = rend.material.GetColor(colorName);
		transparentColor = opaqueColor;
		opaqueColor.a = maxAlpha;
		transparentColor.a = minAlpha;

	}
	
	// Update is called once per frame
	void Update () {
		if ((isVisible && fadeProgress < 1) || !isVisible && fadeProgress > 0) {
			fadeProgress += Time.deltaTime / tFade * (isVisible ? 1 : -1);
			rend.material.SetColor(colorName, Color.Lerp(transparentColor, opaqueColor, fadeProgress));
		}
	}

	public void fadeIn(){
		isVisible = true;
	}

	public void fadeOut(){
		isVisible = false;
	}


}
