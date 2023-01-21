using UnityEngine;
using UnityEngine.SceneManagement;

public class BGSoundBehaviour : MonoBehaviour
{
    static BGSoundBehaviour instance;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
