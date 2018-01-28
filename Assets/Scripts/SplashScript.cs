using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        //Press the space key to start coroutine
        if (Input.GetKey(KeyCode.Space))
        {
            //Use a coroutine to load the Scene in the background
            StartCoroutine(LoadYourAsyncScene("MainScene"));
        }
    }

    IEnumerator LoadYourAsyncScene(string sceneName)
    {
        // The Application loads the Scene in the background at the same time as the current Scene.
        //This is particularly good for creating loading screens. You could also load the Scene by build //number.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        //Wait until the last operation fully loads to return anything
        while (asyncLoad != null && !asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
