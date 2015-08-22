using UnityEngine;
using System.Collections;

public class House : MonoBehaviour {

	public float m_SwitchDelay;
	public float m_CooldownDelay;
	public bool m_State;

	// Use this for initialization
	void Start () {
		StartCoroutine("SwitchState");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (m_State && other.CompareTag("Player")){
			m_State = !m_State;
			StopCoroutine("SwitchState");
			StartCoroutine(Cooldown());
		}
	}

	void OnTriggerStay(Collider other){
		if (m_State && other.CompareTag("Player")){
			m_State = !m_State;
			StopCoroutine("SwitchState");
			StartCoroutine(Cooldown());
		}
	}

	public IEnumerator SwitchState() {
		while(true){
			yield return new WaitForSeconds(m_SwitchDelay);
			m_State = !m_State;
		}
	}

	public IEnumerator Cooldown() {
		yield return new WaitForSeconds(m_CooldownDelay);
		m_State = !m_State;
		StartCoroutine("SwitchState");
	}
	

}
