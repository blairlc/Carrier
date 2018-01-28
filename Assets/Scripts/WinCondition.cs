using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        Inventory inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
        
        if (inventory.GetMoney() >= Inventory.winMoney && inventory.GetNumberOfItems() == 0)
        {
            StartCoroutine(LoadYourAsyncScene("goalScreen"));
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
