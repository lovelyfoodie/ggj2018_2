using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class Objectives_Collection : MonoBehaviour {

	[SerializeField]
	public Ojbective[] objectives;

	List<int> usedObjectives = new List<int>();

	public Ojbective getRandom() {

		int val = Random.Range (0, 10);
		while (usedObjectives.Contains (val)) {
			val = Random.Range (0, 10);
		}
		usedObjectives.Add (val);
		return objectives[val];
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
