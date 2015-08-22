using UnityEngine;
using System.Collections;

public class House : MonoBehaviour {

	public float m_switchDelay;
	public bool m_state;

	// Use this for initialization
	void Start () {
		StartCoroutine("SwitchState");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (m_state && other.CompareTag("Player")){
			m_state = !m_state;
			StopCoroutine("SwitchState");
		}
	}

	void OnTriggerStay(Collider other){
		if (m_state && other.CompareTag("Player")){
			m_state = !m_state;
			StopCoroutine("SwitchState");
		}
	}

	public IEnumerator SwitchState() {
		while(true){
			yield return new WaitForSeconds(m_switchDelay);
			m_state = !m_state;
		}
	}
	

}
