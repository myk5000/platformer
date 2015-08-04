using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeftSidePlatGen : MonoBehaviour {
	public GameObject[] spawnableObjectArray;
	public float minPositionChangeAmount = 5.0f;
	float lastPositionSpawn = 0.0f;

	//global var instance

	//criteria for elapsed time

	//todo - make random
	float spawnWaitTime = 0.5f;
	float spawnTimeWaited = 0.0f;
	//criteria for changed position and distance

	//this list is used in the collider logic.. still not in use
	List <string>objectsInGenSpace = new List<string> ();
	bool isOccupied = false;

	// Use this for initialization
//	void Start () {
//	
//	}
	
	// Update is called once per frame
	void Update () {
//		if(!isOccupied){
//			if(hasTraveled()){
//				if(Random.Range(1,9)<2){
//					bool result = false;
//					if (GlobalVarUtil.LastSpawnedOrDestroyedLeftSide == 0.0f) {
//						GlobalVarUtil.LastSpawnedOrDestroyedLeftSide = transform.position.x;
//						return result;
//					}
//					//Debug.Log ("left side, current generator pos: "+ transform.position.x +", last for left: " + gvuInstance.LastSpawnedOrDestroyedLeftSide);
//					if (Mathf.Abs (transform.position.x - GlobalVarUtil.LastSpawnedOrDestroyedLeftSide) > minPositionChangeAmount) {
//						if (transform.position.x < GlobalVarUtil.LastSpawnedOrDestroyedLeftSide) {
//							
//							result = true;				
//						}			
//					}
//					
//					return result;
//				}
//
//			}
//
//		}
	
	}
	bool hasTraveled(){
		bool result = false;
		if (GlobalVarUtil.LastSpawnedOrDestroyedLeftSide == 0.0f) {
			GlobalVarUtil.LastSpawnedOrDestroyedLeftSide = transform.position.x;
			return result;
		}
		//Debug.Log ("left side, current generator pos: "+ transform.position.x +", last for left: " + gvuInstance.LastSpawnedOrDestroyedLeftSide);
		if (Mathf.Abs (transform.position.x - GlobalVarUtil.LastSpawnedOrDestroyedLeftSide) > minPositionChangeAmount) {
			if (transform.position.x < GlobalVarUtil.LastSpawnedOrDestroyedLeftSide) {
				
				result = true;				
			}			
		}
		
		return result;
	}

}
