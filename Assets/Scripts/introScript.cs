using UnityEngine;
using System.Collections;

public class introScript : MonoBehaviour {
	public string[] texts;
	private int txtIndex = 0;
	public AudioSource thunderStrike;
	public AudioSource intro;
	public AudioSource title;
	public CanvasRenderer flash;
	public GameObject titleScreen;
	public GameObject titleCanvas;

	// Use this for initialization
	void Start () {
		flash.SetAlpha (0);
		StartCoroutine (textUpdate ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator textUpdate(){
		while (gameObject.GetComponent<TextMesh> ().color.a < 1) {
			gameObject.GetComponent<TextMesh> ().color = new Color(255, 255, 255, gameObject.GetComponent<TextMesh> ().color.a +0.1f);
			yield return new WaitForSeconds(0.4f);
		}
		yield return new WaitForSeconds(1);
		if (txtIndex >= texts.Length) {
			StartCoroutine(thunder());
		}
		else{
			while (gameObject.GetComponent<TextMesh> ().color.a > 0) {
				gameObject.GetComponent<TextMesh> ().color = new Color(255, 255, 255, gameObject.GetComponent<TextMesh> ().color.a -0.1f);
				yield return new WaitForSeconds(0.4f);
			}
			ChangeText ();
		}
	}

	IEnumerator thunder(){
		thunderStrike.Play ();
		intro.Stop ();
		flash.SetAlpha (1);
		titleScreen.SetActive (true);
		yield return new WaitForSeconds(2);
		while (flash.GetAlpha() > 0){
			flash.SetAlpha(flash.GetAlpha() - 0.20f);
			yield return new WaitForSeconds(1);
		}
		//fade out the thunder
		while (thunderStrike.volume > 0) {
			thunderStrike.volume -= 0.1f;
			yield return new WaitForSeconds(0.25f);
		}
		title.Play ();
		titleCanvas.SetActive (true);
	}

	void ChangeText(){
		if (txtIndex <= texts.Length) {
			gameObject.GetComponent<TextMesh> ().text = texts [txtIndex];
			StartCoroutine (textUpdate ());
		}
		txtIndex++;
	}
}
