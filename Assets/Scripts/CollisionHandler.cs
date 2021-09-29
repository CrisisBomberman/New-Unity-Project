using UnityEngine;

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
                Debug.Log("You Blew Up");
                break;

        }
    }
}
