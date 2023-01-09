using UnityEngine;

public class GameEngine : MonoBehaviour {
    public static GameEngine Inst;

    public bool IsPause = false;
    public bool BallMoving = true;
    private void Awake() {
        if (Inst == null) {
            Inst = this;
        }
    }

    public void SetPause(bool isPause) {
        IsPause = isPause;
        
        switch (isPause) {
            
            case true:
                BallMoving = false;
                break;
            
            case false:
                BallMoving = true;
                break;
        }
    }
    void Start()
    {

    }

    void Update()
    {
        
    }
}
