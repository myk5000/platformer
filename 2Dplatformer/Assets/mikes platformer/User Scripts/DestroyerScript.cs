using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour
{
		public string sideName = "";
		//GlobalVarUtil gvuInstance = null;
		//get Global object instanse


//		void Start ()
//		{
//				gvuInstance = GlobalVarUtil.getInstance ();
//		}


		void OnTriggerEnter2D (Collider2D obj)
		{

				if (obj != null) {
						if (obj.tag == "Player") {
								Debug.Log ("Game Over mofo");
								Debug.Break ();
								return;
						}
						
						killObject (obj);
				}

		}

		void killObject (Collider2D obj)
		{
		Debug.Log ("<>Destroyed Object, tag: "+obj.gameObject.tag);
				if (sideName.Equals ("left")) {	
						//Debug.Log("updating left side on delete");
			GlobalVarUtil.LastSpawnedOrDestroyedLeftSide = obj.transform.position.x;
				}
				if (sideName.Equals ("right")) {
						//Debug.Log("updating right side on delete");
			GlobalVarUtil.LastSpawnedOrDestroyedRightSide = obj.transform.position.x;
				}
				if (obj && obj.gameObject.transform.parent) {
						Destroy (obj.gameObject.transform.parent.gameObject);
				} else {
						Destroy (obj.gameObject);
				}	


		}

}
