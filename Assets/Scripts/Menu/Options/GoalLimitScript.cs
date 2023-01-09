using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Game.Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GoalLimitScript : MonoBehaviour
{
    private TMP_InputField _inputField;
    private GameController _gameController;
    void Start()
    {
        _gameController = GameController.Inst;

        _inputField = gameObject.GetComponent<TMP_InputField>();
        if (_inputField != null) {
            _inputField.text = System.Environment.MachineName;
            _inputField.onValueChanged.AddListener(delegate { SubmitGoalLimit(); });
            _inputField.text = _gameController.GoalLimit.ToString();
        }

        
    }
    private void SubmitGoalLimit() {
        var newGoalLimit = _inputField.text;

        int result;
        if (!int.TryParse(newGoalLimit, out result)) {
            _inputField.text = "";
        }
        print(result);

        _gameController.GoalLimit = result;    }
}
