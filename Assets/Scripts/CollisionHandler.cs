using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField]float invokeTimer=1f;
    void OnCollisionEnter(Collision collisionInfo)
    {
        switch (collisionInfo.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This Thing is friendly");
                break;

            case "Finish":
                StartSuccessSequence();
                break;
            case "Fuel":
                Debug.Log("U picked up fuel");
                break;
            default:
                StartCrashSequence();
                break;

        }
    }

     void StartSuccessSequence()
    {
        //vfx and sfx to be added further
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel",invokeTimer);
    }

    void StartCrashSequence()
    {
        //vfx and sfx to be added further
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", invokeTimer);
    }
    // void DelayMethod(string dWord)
    // {
    //     Invoke(dWord,1f);
    // }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    void ReloadLevel()
    {
        //SceneManager.LoadScene(0); belirli bir indexi çağırırken alttaki o an aktif olanı çağırıyor
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
