using UnityEngine;
using System.Collections;
//http://answers.unity3d.com/questions/17916/singletons-with-coroutines.html
//this is a singleton class used to store and update game data and util methods
public class GlobalVarUtil : MonoBehaviour {
	//global game variables
	private static GlobalVarUtil instance;

	//values used for spawned items on all three sides of the game box.
	public static float LastSpawnedOrDestroyedRightSide = 0.0f;
	public static float LastSpawnedOrDestroyedLeftSide = 0.0f;
	public static float LastSpawnedTopSide = 0.0f;
	public static string testMessage = "default text";

	//game score
	public int playerScore = 0;

}
