using UnityEngine;
using System.Collections;

public class FollowWithdropstop : MonoBehaviour {
	public GameObject player;
	bool isNotFalling = true;


	
	// Update is called once per frame
	void Update () {
		if(isNotFalling){
			this.transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-2.0f);

			//check if player is falling by the velocity value, if so stop the camera from following the player


		}
		if(player.transform.GetComponent<Rigidbody2D>().velocity.y < -45)
		{
			isNotFalling = false;
		}
		else
		{
			isNotFalling = true;
		}
	
	}
}
