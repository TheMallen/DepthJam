using UnityEngine;
using System.Collections;

public class Projectile : BaseObject, PoolableTypeInterface
{
	protected void Start () 
	{


	}
	
	protected void Update () 
	{
		spinGraphic();
			
	}

	public void Reset()
	{
		m_Rigidbody2D.isKinematic = true;
		m_Rigidbody2D.gameObject.SetActive(false);
		m_Rigidbody2D.gameObject.SetActive(true);
		m_Rigidbody2D.isKinematic = false;

	}

	private void spinGraphic()
	{
		m_Graphic.transform.Rotate(Vector3.forward*Time.deltaTime*100f);

	}

	private void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject != null)
		{
			gameObject.SetActive(false);

		}
		
	}

}


