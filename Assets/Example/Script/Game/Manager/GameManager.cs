using TMI.Core;
using TMI.Helper;
using TMI.State;

public class GameManager : BaseNotificationManager, IGameManager {

	private IStateMachine stateMachine;


	public void Initialize() {
		stateMachine = StateMachine.Create(new LoadGameAssetsState(initializer));
		RegisterUpdate();
	}

	protected override ExecutionManager.Result OnUpdate() {
		stateMachine.Update();
		return ExecutionManager.Result.Continue;
	}

	protected override void OnDestroy() {
		GeneralHelper.DisposeAndMakeDefault(ref stateMachine);
		base.OnDestroy();
	}

}
