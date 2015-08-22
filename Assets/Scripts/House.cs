using UnityEngine;
using System.Collections;

public class House : MonoBehaviour {

	public float switchDelay;
	public bool state;

	// Use this for initialization
	void Start () {
		StartCoroutine(switchState());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator switchState() {
		while(true){
			Debug.Log("begin");
			yield return new WaitForSeconds(switchDelay);
			state = !state;
			Debug.Log("End");
		}
	}
}
