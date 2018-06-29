using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AllStaticObjects
{
	public List<StaticObject> Objects;

	public StaticObject this[string name]
	{
		get
		{
			foreach (StaticObject staticObject in Objects)
			{
				if (staticObject.Name == name)
				{
					return (staticObject);
				}
			}

			throw (new MissingReferenceException("The game object with name -" + name + "- is not found"));
		}
	}
}

[System.Serializable]
public class StaticObject
{
	public string Name;
	public GameObject TheGameObject;
	public AllComponents AllComponents;
}

[System.Serializable]
public class AllComponents
{
	public List<StaticObjectComponent> Components;

	public StaticObjectComponent this[string name]
	{
		get
		{
			foreach (StaticObjectComponent component in Components)
			{
				if (component.Name == name)
				{
					return (component);
				}
			}

			throw (new MissingReferenceException("The component with name -" + name + "- is not found in the game object " + name));
		}
	}
}

[System.Serializable]
public class StaticObjectComponent
{
	public string Name;
	public Component Component;
}

public class StaticObjectsManager : MonoBehaviour
{
	public static StaticObjectsManager Instance;

	#region Singleton
	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
	#endregion

	#region Game Objects
	public AllStaticObjects AllObjects;
	#endregion
}