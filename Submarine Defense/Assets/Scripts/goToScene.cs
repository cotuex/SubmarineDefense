using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class goToScene : MonoBehaviour {

    public void goTo(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void goTo(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
