using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SideGenerator : MonoBehaviour
{
		public GameObject[] spawnableObjectArray;
		public float minPositionChangeAmount = 5.0f;
		float lastPositionSpawn = 0.0f;
		//if we are on the left then we are looking for subtracting values, right we are looking fot growing values
		public bool isRightSide ;
		bool isOccupied = false;
		//global var instance
		//GlobalVarUtil gvuInstance = null;
		//criteria for elapsed time
		//todo - make random
		float spawnWaitTime = 0.5f;
		float spawnTimeWaited = 0.0f;
		//criteria for changed position and distance
		//float lastPositionSpawn; - switch to start using Global vars for this value
		//todo - make random
		List <string>objectsInGenSpace = new List<string> ();



		//setup global vars in the start method
//		void Start ()
//		{
//				gvuInstance = GlobalVarUtil.getInstance ();
////		GameObject globalVarObject = GameObject.Find("globalVarObject");
////		  = globalVarObject.GetComponent<GlobalVarUtil>();
////		playerScript.Health -= 10.0f;
//		}
	
		// Update is called once per frame
		//check collider for other object
		void Update ()
		{

			if (!isOccupied) {

						if (spawnTimeWaited < spawnWaitTime) {
								spawnTimeWaited += Time.deltaTime;
								//Debug.Log ("still waiting, spawnTimeWaited: " + spawnTimeWaited);
						}
						//spawn an object
						else {
								if (isRightSide) {
										if (hasTraveledRight ()) {
												//Debug.Log("SPAWN object!");
												//todo - make this random
												spawnObject ();
										}
								} else {
										if (hasTraveledLeft ()) {
												//Debug.Log("SPAWN object!");
												//todo - make this random
												spawnObject ();
										}
								}				
						}
			}		
		}

		bool hasTraveledRight()
		{
				bool result = false;
				if (GlobalVarUtil.LastSpawnedOrDestroyedRightSide == 0.0f) {
						Debug.Log ("****Setting current x position, going right");
						GlobalVarUtil.LastSpawnedOrDestroyedRightSide = transform.position.x;
						return result;
				}
				//Debug.Log ("****cheching has traveled right, current x: "+ transform.position.x+" is it greater than lastSpawned x: "+GlobalVarUtil.LastSpawnedOrDestroyedRightSide);
				if (Mathf.Abs (transform.position.x - GlobalVarUtil.LastSpawnedOrDestroyedRightSide) > minPositionChangeAmount) {
						if (transform.position.x > GlobalVarUtil.LastSpawnedOrDestroyedRightSide) {
								result = true;
						}
				}

				return result;
		}

		bool hasTraveledLeft ()
		{
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

		//check for objects in the collider
		void OnTriggerEnter2D (Collider2D obj)
		{
				Debug.Log ("** >> OnTriggerEnter2D - object in generator collider space");

				Debug.Log ("** >>isOccupied true name: " + obj.tag);

				objectsInGenSpace.Add (obj.tag);
				isOccupied = true;
		}

		//check for objects leaving the collider
		void OnTriggerExit2D (Collider2D obj)
		{
				Debug.Log ("<< on Exit");
//		if(objectsInGenSpace.Contains(obj.tag))
//		{
//			//int indexToRemove = objectsInGenSpace.FindIndex(x => x.Equals(obj.tag));
//			objectsInGenSpace.Remove(obj.tag);
//		}
//		if(objectsInGenSpace.Count < 1)
//		{
				Debug.Log ("<< all objects gone, setting occupied to false");
				isOccupied = false;
				//}
	
		}

		void spawnObject()
		{
				int index = Random.Range (0, spawnableObjectArray.Length);
				Debug.Log ("^^%>>SPAWN! for index: " + index);
				Instantiate (spawnableObjectArray [index], transform.position, Quaternion.identity);
				//Instantiate(spawnableObjectArray[0], transform.position, Quaternion.identity);
				//should be about to spawn new object
				if (isRightSide) {
						GlobalVarUtil.LastSpawnedOrDestroyedRightSide = transform.position.x;
				} else {
						GlobalVarUtil.LastSpawnedOrDestroyedLeftSide = transform.position.x;
				}
				
				spawnTimeWaited = 0.0f;
		}

}
