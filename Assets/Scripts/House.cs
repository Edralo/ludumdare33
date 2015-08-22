using UnityEngine;
using System.Collections;

public class House : MonoBehaviour {
	
	public bool m_state;
	public int m_resourcesValue;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (m_state && other.CompareTag("Player")){
			m_state = !m_state;
			other.GetComponent<Character>().m_resources += m_resourcesValue;
		}
	}

	void OnTriggerStay(Collider other){
		if (m_state && other.CompareTag("Player")){
			m_state = !m_state;
			other.GetComponent<Character>().m_resources += m_resourcesValue;
		}
	}
	

}
