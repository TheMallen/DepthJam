using UnityEngine;
using System.Collections;

public class Global : Singleton<Global>
{
	//**********
	// Constants
	//**********
	private static readonly Vector2 c_DefaultTestPlayerPosition = new Vector2(32f,32f);
	private static readonly string  c_DefaultTestLevel = "Test";

	public const float c_DefaultBulletSpeed = 250f;

	//*************
	// Data members
	//*************
	private Vector2 m_PositionBuffer  = c_DefaultTestPlayerPosition;
	private string  m_LevelNameBuffer = c_DefaultTestLevel;

	//**********
	// Accessors
	//**********
	public Vector2 a_PositionBuffer {get{return m_PositionBuffer ;}set{m_PositionBuffer  = value;}}
	public string  a_LevelNameBuffer{get{return m_LevelNameBuffer;}set{m_LevelNameBuffer = value;}}

	//****************
	// Unity interface
	//****************
	protected override void Awake ()
	{
		base.Awake ();
		DontDestroyOnLoad(gameObject);
		name = "Global";

	}

	//
	//
	//


}








