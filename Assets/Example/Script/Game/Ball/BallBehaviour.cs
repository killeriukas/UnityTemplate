using System;
using System.Collections;
using System.Collections.Generic;
using TMI.Core;
using UnityEngine;

public class BallBehaviour : UnityBehaviour, IUpdatable {

	[SerializeField]
	private Rigidbody2D rigidBody;

	//private ExecutionManager.Result OnUpdate() {

	//	//change this to input later
	//	if(Input.GetKey(KeyCode.LeftArrow)) {
	//		rigidBody.velocity = Vector2.left * 10f;
	//	} else if(Input.GetKey(KeyCode.RightArrow)) {
	//		rigidBody.velocity = Vector2.right * 10f;
	//	} else {
	//		rigidBody.velocity = Vector2.zero;
	//	}

	//	return ExecutionManager.Result.Continue;
	//}

	public void Initialize() {
		//Vector2 randomDirection = UnityEngine.Random.insideUnitCircle.normalized;

		rigidBody.velocity = Vector2.up * 30f;

	//	executionManager.Register(this, OnUpdate);
	}

	public void PushIntoDirection(Vector2 direction) {
	//	Vector2 currentDirection = rigidBody.velocity.normalized;
		rigidBody.velocity = direction * 30f;
	}
}