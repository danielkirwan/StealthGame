using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour { 
    [SerializeField] Image _progressbar;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadLevelAsync());
    }

    IEnumerator LoadLevelAsync()
    {
        yield return null;

        AsyncOperation async = SceneManager.LoadSceneAsync("Main");

        while (!async.isDone)
        {
            _progressbar.fillAmount = async.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
