using UnityEngine;
using System.Collections.Generic;

public abstract class SceneManager<T> : Singleton<T> where T: SceneManager<T>
{
	//**********
	// Constants
	//**********
	private const string c_GlobalObjectName = "Global";
	private const string c_GlobalObjectPrefabPath = "Global/Prefabs/Global";

	//*************
	// Data members
	//*************
	[SerializeField]private bool      m_PixelateText = true;

	//**********
	// Accessors
	//**********


	//****************
	// Unity Interface
	//****************
	protected override void Start()
	{
		base.Start ();
		
		if (m_PixelateText)
			forcePointModeOnChildTextMeshMaterial (transform);

		guaranteeGlobal();

	}

	protected virtual void FixedUpdate()
	{
		if (Input.GetKey (KeyCode.Escape))
			Application.LoadLevel("MainMenu");

	}
	
	//*****************
	// Member functions
	//*****************	
	private void forcePointModeOnChildTextMeshMaterial(Transform aTransform)
	{
		Transform child    = null;
		TextMesh  textMesh = null;
		
		for (int i = 0; i < aTransform.childCount; i++)
		{
			child    = aTransform.GetChild(i);
			textMesh = child.GetComponent<TextMesh>();
			
			if (textMesh != null)
				textMesh.font.material.mainTexture.filterMode = FilterMode.Point;
			
			forcePointModeOnChildTextMeshMaterial(child);
			
		}
		
	}

	private void guaranteeGlobal()
	{
		if (!GameObject.Find(c_GlobalObjectName))
			Instantiate (Resources.Load (c_GlobalObjectPrefabPath));


	}
	
}









