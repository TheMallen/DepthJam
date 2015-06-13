using UnityEngine;
using System.Collections;

abstract public class Character : BaseObject
{
	//
	//
	//


	//
	//
	//
	[SerializeField] protected float   m_MoveSpeed = 0.25f;
	protected Vector2 m_Delta     = Vector2.zero;

	//
	//
	//


	//
	//
	//
	protected override void Awake()
	{
		base.Awake();

	}

	protected override void Start()
	{
		base.Start();


	}

	protected override void Update()
	{
		base.Update();

		moveCharacter();

	}

	private void moveCharacter()
	{
		m_Delta = m_Delta.normalized * m_MoveSpeed;
		{
			transform.Translate(m_Delta,Space.World);
		
		}

		m_Delta = Vector2.zero;

	}

}



