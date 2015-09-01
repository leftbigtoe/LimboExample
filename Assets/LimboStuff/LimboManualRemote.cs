using UnityEngine;
using System.Collections;

public class LimboManualRemote : MonoBehaviour {

	public AlphaFader[] remoteTargets;

	public void showObject(int i){
		remoteTargets [i].show ();
	}

	public void hideObject(int i){
		remoteTargets [i].hide ();
	}

	public void fadeObjectIn(int i){
		remoteTargets [i].fadeIn ();
	}

	public void fadeObjectOut(int i){
		remoteTargets [i].fadeOut ();
	}
}
