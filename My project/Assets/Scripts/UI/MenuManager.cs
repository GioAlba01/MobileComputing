using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Game Over")]
    [SerializeField] private GameObject menuScreen;
    [SerializeField] private AudioClip menuSound;

    private void Awake()
    {
        menuScreen.SetActive(true);
    }

    #region Menu

    public void Menu()
    {
        menuScreen.SetActive(true);
        SoundManager.instance.PlaySound(menuSound);
    }

    public void Play()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level1", 1));
    }

    public void Settings()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Settings", 3));
    }

    public void Credits()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level1", 4));
    }

    public void Quit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //Exits play mode (will only be executed in the editor)
#endif
    }
    #endregion

    #region Settings

    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }
    public void MusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }

    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("_MainMenu", 0));
    }
    #endregion
}
