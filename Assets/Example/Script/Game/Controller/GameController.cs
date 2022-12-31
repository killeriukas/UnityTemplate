using TMI.Core;
using TMI.Notification;

public class GameController : BaseNotificationObject {


    public const int STARTING_SCORE = 0;
    public const int STARTING_LIVES = 3;

    private int currentLivesAvailable;
    public int currentScore { get; private set; }

    public bool isAlive => currentLivesAvailable > 0;

    public GameController(IInitializer initializer) : base(initializer) {
        currentLivesAvailable = STARTING_LIVES;
        currentScore = STARTING_SCORE;
    }

    public void RemoveLife() {
        int oldValue = currentLivesAvailable;
        
        if(currentLivesAvailable > 0) {
            --currentLivesAvailable;
        }

        Trigger(new LifeLostNotification(oldValue, currentLivesAvailable));
    }

    public void IncreaseScore() {
        int oldScore = currentScore;
        
        ++currentScore;
        
        Trigger(new ScoreIncreasedNotification(oldScore, currentScore));
    }
}
