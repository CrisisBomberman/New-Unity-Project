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
                Debug.Log("Finished");
                break;
            case "Fuel":
                Debug.Log("U picked up fuel");
                break;
            default:
            ReloadLevel();
                break;

        }
    }
    void ReloadLevel()
    {
        //SceneManager.LoadScene(0); belirli bir indexi çağırırken alttaki o an aktif olanı çağırıyor
        int currentSceneIndex =SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
