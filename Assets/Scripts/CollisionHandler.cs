using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        switch (collisionInfo.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This Thing is friendly");
                break;

            case "Finish":
                LoadNextLevel();
                break;
            case "Fuel":
                Debug.Log("U picked up fuel");
                break;
            default:
                ReloadLevel();
                break;

        }
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex+1;
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
