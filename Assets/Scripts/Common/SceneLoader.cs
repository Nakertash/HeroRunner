using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    //private static SceneLoader instance; 

    public Scrollbar progressBar;
    public string scene_name;

    private void Start()
    {
        StartCoroutine(AsyncLoad());
    }

    public static void LoadScene(string sceneName)
    {
        GameObject sceneLoaderObject = Instantiate(new GameObject(),new Vector3(0,0,0),Quaternion.identity);

        SceneLoader sceneLoader= sceneLoaderObject.AddComponent<SceneLoader>();

        sceneLoader.scene_name = sceneName;
    }

    private IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene_name);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            if(progressBar!=null)
            {
                progressBar.size = progress;
            }
           
            //progresstext.text = (int)(progress * 100) + "%";
            Time.timeScale = 1;
            yield return null;
        }
        Destroy(gameObject);
    }
}
