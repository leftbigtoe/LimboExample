using UnityEngine;
using System.Collections;

public class LimboTextureSwitcher : MonoBehaviour {
	
	public Texture[] limboTextures;
	private Material[] mats;
	public Texture[] normalTextures;
	private bool limboLastFrame;
	private Texture texture2;

	private float blend = 0;

	// Use this for initialization
	void Start () {
		mats = GetComponent<Renderer>().materials;
		normalTextures = new Texture[mats.Length];
		for (int i = 0; i < mats.Length; i++) {
			normalTextures[i] = mats[i].mainTexture;
		}

	}
	
	// Update is called once per frame
	void Update () {
		// if limbo state changed
		if (LimboController.limboActive != limboLastFrame) {
			// change ALL the textures
			for(int i = 0; i < mats.Length; i++){
				mats[i].mainTexture = LimboController.limboActive ?
										limboTextures[i] :
										normalTextures[i];
			}
			limboLastFrame = !limboLastFrame;
		}
	}
}
