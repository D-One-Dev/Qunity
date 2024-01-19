using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayOnline()
    {
        SceneManager.LoadScene("Level1");
    }
}
