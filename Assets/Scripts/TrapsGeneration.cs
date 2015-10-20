﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TrapsGeneration : MonoBehaviour {

	public int probability_room;
	public List<GameObject> traps = new List<GameObject>();
	private bool flag=true;

	public void generateTraps(Dictionary<Point, Chunk> map){
		Debug.Log ("generate trap");
		foreach (KeyValuePair<Point, Chunk> kvp in map) {
			Chunk value = kvp.Value;
			int i = Random.Range (0,traps.Count);
			while(i>=0){
				if(Random.value < probability_room){
					Debug.Log (value);
					List<Vector3> possibleTraps = value.returnPossibleTraps();
					Vector3 trapPosition = possibleTraps[Random.Range(0,possibleTraps.Count)]; //- new Vector3(kvp.Key.X, 0); 
					Debug.Log (trapPosition);
					GameObject p = traps[Random.Range(0,traps.Count-1)];
					Object o = Instantiate(p,Vector3.zero,p.transform.rotation);
					((GameObject)o).gameObject.transform.parent=value.gameObject.transform;
					((GameObject)o).gameObject.transform.localPosition=trapPosition;
				}
				i++;
			}
		}
	}

}