using UnityEngine;
using System.Collections;

public class Coin : BaseObject, PoolableTypeInterface
{
	private const float c_Offset = 0.25f;
	private const float c_SpinSpeed = 5f;

	// Use this for initialization
	void Start () 
	{

	
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_Graphic.material.SetTextureOffset("_MainTex", new Vector2(0.1f + c_Offset * (Mathf.Floor(Time.time*c_SpinSpeed)), 0.5f));

		m_Graphic.transform.localPosition = new Vector3(0,Mathf.Abs(Mathf.Sin(Time.time*5)/5f));

	}

	public void Reset()
	{


	}

}



