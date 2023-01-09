using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    private GameEngine _gameEngine;
    // Start is called before the first frame update
    void Start() {
        _gameEngine = GameEngine.Inst;

    }

    // Update is called once per frame
    void Update()
    {
        ESC_Check();
    }

    private void ESC_Check() {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            _gameEngine.SetPause(!_gameEngine.IsPause);
            // SceneManager.LoadScene("GameMenu");
        }
    }
}
