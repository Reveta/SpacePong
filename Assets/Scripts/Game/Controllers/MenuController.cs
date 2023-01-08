using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ESC_Check();
    }

    private void ESC_Check() {
        // print("Test");

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("GameMenu");
        }
    }
}
