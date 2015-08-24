using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public List<House> m_houses;
	public Text m_housesText;

	void Start()
	{
		StartCoroutine (LoopWinCheck ());
	}

	void Update(){
		m_housesText.text = "Houses left : " + m_houses.Count;
	}
	
	IEnumerator LoopWinCheck()
	{
		while ( true )
		{
			yield return 0;
			if( IsWin () )
			{
				DoWin();
			}
		}
	}

	bool IsWin()
	{
		foreach( House it in m_houses ) 
		{
			if( it.m_state )
			{
				return false;
			}
		}
		return true;
	}

	void DoWin()
	{
		Debug.Log ( " you win " );
	}
}
