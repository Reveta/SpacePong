using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Controllers {
    public class MenuController : MonoBehaviour {
        public static MenuController Inst;

        public GameObject panel;
        public TMP_Text cooldownText;
        private int _cooldownCount = 3;

        private void Awake() {
            if (Inst == null) {
                Inst = this;
            }
        }

        // Start is called before the first frame update
        void Start() {
            panel.SetActive(false);

        }

        public void ChangeHideEscPanel() {
            panel.SetActive(!panel.activeSelf);
        }

        // Update is called once per frame
        public void OpenStartMenu() {
            SceneManager.LoadScene("GameMenu");
        }
        public void CooldownStep() {
            switch (_cooldownCount) {
                case 3: cooldownText.text = "3"; break;
                case 2: cooldownText.text = "2"; break;
                case 1: cooldownText.text = "1"; break;
                case 0: cooldownText.text = "START!"; break;
                default: cooldownText.text = ""; break;
            }
            _cooldownCount--;
        }
    }
}
