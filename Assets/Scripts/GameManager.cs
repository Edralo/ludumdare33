using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	public List<House> m_houses;

	void Start()
	{
		m_houses = new List<House>();
		StartCoroutine (LoopWinCheck ());
	}
	
	IEnumerator LoopWinCheck()
	{
		while ( true )
		{
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
