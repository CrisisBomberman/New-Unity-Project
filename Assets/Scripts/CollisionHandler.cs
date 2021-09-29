using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    int currentSceneIndex;
    private void Start()
    {

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        switch (collisionInfo.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This Thing is friendly");
                break;

            case "Finish":
                LoadNextLevel(currentSceneIndex);
                break;
            case "ReloadFirst":
                SceneManager.LoadScene(0);
                break;
            case "Fuel":
                Debug.Log("U picked up fuel");
                break;
            default:
                ReloadLevel();
                break;

        }
    }
    void LoadNextLevel(int LNL)
    {
        SceneManager.LoadScene(LNL+1);
    }
    void ReloadLevel()
    {
        //SceneManager.LoadScene(0); belirli bir indexi çağırırken alttaki o an aktif olanı çağırıyor
        SceneManager.LoadScene(currentSceneIndex);
    }
}
