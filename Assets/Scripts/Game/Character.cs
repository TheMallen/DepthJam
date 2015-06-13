using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
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
	private Rigidbody2D m_Rigidbody2D = null;

	//
	//
	//
	protected override void Awake()
	{
		base.Awake();

		m_Rigidbody2D = GetComponent<Rigidbody2D>();

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
			//transform.Translate(m_Delta,Space.World);
			m_Rigidbody2D.AddForce(m_Delta,ForceMode2D.Impulse);

		}

		m_Delta = Vector2.zero;

	}

}



