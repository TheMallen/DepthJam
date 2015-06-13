using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter  ))]

public abstract class ParticleEffect : BaseObject, PoolableTypeInterface
{
	//*************
	// Data members
	//*************
	private Vector2 m_UVOffset       = new Vector2(0f,1-0.125f);
	private Vector2 m_UVSampleSize   = new Vector2(0.125f,0.125f);
	private int     m_AnimationDelay = 5;
	private int     m_AnimationTimer = 0;

	[SerializeField] private int     m_AnimationLength = 7;
	private int     m_FrameCounter = 0;

	//****************
	// Unity interface
	//****************
	protected virtual void Start()
	{
		if (m_Graphic == null)
			m_Graphic = transform.FindChild("Graphic").GetComponent<MeshRenderer>();

		m_Graphic.material.mainTextureOffset = m_UVOffset;
		m_Graphic.material.mainTextureScale = m_UVSampleSize;
		
	}

	protected virtual void FixedUpdate()
	{
		if (--m_AnimationTimer <= 0)
		{
			if (++m_FrameCounter >= m_AnimationLength)
			{
				m_FrameCounter = 0;
				m_UVOffset = new Vector2(0f,1-0.125f);

				gameObject.SetActive(false);

			}


			m_AnimationTimer = m_AnimationDelay;
			
			//constrain
			m_UVOffset.x += m_UVSampleSize.x;
			
			if (m_UVOffset.x >= 1)
			{
				m_UVOffset.x = 0;
				m_UVOffset.y-= m_UVSampleSize.y;
				
				if (m_UVOffset.y < 0)
					m_UVOffset.y = 1 - m_UVSampleSize.y;


				
			}
			
			//set
			m_Graphic.material.mainTextureOffset = m_UVOffset;
			
		}

	}

	//**********************
	// PoolableTypeInterface
	//**********************
	public void Reset()
	{
		//GetComponent<Renderer>().material.SetFloat (BrawlerConstants.c_OverlayName, 0);
		transform.position = Vector3.zero;
		transform.rotation = Quaternion.Euler (Vector3.zero);

	}


}







