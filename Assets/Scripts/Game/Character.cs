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
	private float m_AnimationTime = 0;

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
		handleAnimation();

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

	private void handleAnimation()
	{
		//Animation direction
		m_Graphic.material.SetVector("_Dir",m_Rigidbody2D.velocity.normalized);
		
		//Animation rate
		float speed = m_Rigidbody2D.velocity.magnitude;
		
		if (speed < 0.5f)
			m_AnimationTime = 0;
		else
			m_AnimationTime += Time.deltaTime * speed * 50f;
		
		m_Graphic.material.SetFloat("_AnimationTime",m_AnimationTime);
		
	}

}



