using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour {
    private GameEngine _gameEngine;
    public GameObject panel;
    // Start is called before the first frame update
    void Start() {
        _gameEngine = GameEngine.Inst;
        panel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        ESC_Check();
    }

    public void OpenStartMenu() {
        SceneManager.LoadScene("GameMenu");
    }

    private void ESC_Check() {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            _gameEngine.SetPause(!_gameEngine.IsPause);
            panel.SetActive(!panel.activeSelf);
        }
    }
}
