using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Common
{
    public class LoadingMainScene : MonoBehaviour
    {
        [SerializeField] private Slider _progressBar;
        [SerializeField] private TextMeshProUGUI _progressText;
        [SerializeField] private string _sceneToLoad;

        private void Awake()
        {
            StartCoroutine(LoadAsyncOperation());
        }

        IEnumerator LoadAsyncOperation()
        {
            AsyncOperation gameLevel = SceneManager.LoadSceneAsync(_sceneToLoad);

            while (!gameLevel.isDone)
            {
                float progress = Mathf.Clamp01(gameLevel.progress / 0.9f);
                _progressBar.value = progress;

                _progressText.text = (progress * 100f).ToString("F0") + "%";

                yield return null;
            }
        }
    }
}