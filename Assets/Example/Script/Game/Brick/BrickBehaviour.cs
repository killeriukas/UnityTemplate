using TMI.Core;
using UnityEngine;

public class BrickBehaviour : UnityBehaviour {

	private void OnCollisionEnter2D(Collision2D collision) {
//		Debug.LogError("On collided!!!");
		Destroy(gameObject);
	}

}
