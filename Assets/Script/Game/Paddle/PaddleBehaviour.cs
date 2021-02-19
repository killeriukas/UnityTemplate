using TMI.Core;
using UnityEngine;

public class PaddleBehaviour : UnityBehaviour, IUpdatable {

	[SerializeField]
	private Rigidbody2D rigidBody;

	private IExecutionManager executionManager;

	public override void Setup(IInitializer initializer) {
		base.Setup(initializer);
		this.executionManager = initializer.GetManager<IExecutionManager>();
	}

	private ExecutionManager.Result OnUpdate() {

		//change this to input later
		if(Input.GetKey(KeyCode.LeftArrow)) {
			rigidBody.velocity = Vector2.left * 20f;
		} else if(Input.GetKey(KeyCode.RightArrow)) {
			rigidBody.velocity = Vector2.right * 20f;
		} else {
			rigidBody.velocity = Vector2.zero;
		}

		return ExecutionManager.Result.Continue;
	}

	public void Initialize() {
		executionManager.Register(this, OnUpdate);
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		BallBehaviour ballBehaviour = collision.gameObject.GetComponent<BallBehaviour>();

		if(ballBehaviour != null) {
			Vector3 localBallPosition = transform.InverseTransformPoint(ballBehaviour.transform.position);
			Vector3 dir = localBallPosition.normalized;
			ballBehaviour.PushIntoDirection(dir);
		}
		
	}
		
}