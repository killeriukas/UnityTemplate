using TMI.Core;
using TMI.Helper;
using TMI.State;
using UnityEngine;

public class SpawnBricksState : BaseStateWithProxy<GameplayItems> {
    
    public SpawnBricksState(IInitializer initializer, GameplayItems proxy) : base(initializer, proxy) {
        
    }

    public override void Enter() {
        base.Enter();

        for(int i = 0; i < 10; ++i) {
            for(int j = 0; j < 22; ++j) {
                Vector3 position = new Vector3(j * 3, -i, 0);
                BrickBehaviour brick = HierarchyHelper.InstantiateAndSetupBehaviour(initializer, proxy.brickPrefab, proxy.brickContainerTransform, false);
                brick.transform.localPosition = position;
            }
        }

        nextState = new WaitBallKickOffState(initializer, proxy);
    }
    
}
