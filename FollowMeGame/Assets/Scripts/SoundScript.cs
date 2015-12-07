using UnityEngine;

public class SoundScript : MonoBehaviour {

  public AudioSource startMusic;
  public AudioSource gameplayMusic;
  public AudioSource gameoverMusic;

  private static SoundScript instance;

  public static SoundScript GetInstance()
  {
    return instance;
  }

  void Awake() {
    if (instance != null && instance != this)
    {
      instance.UpdateMusic();
      Destroy(this.gameObject); return;
    }
    else
    {
      instance = this;
      UpdateMusic();
    }

    DontDestroyOnLoad(this.gameObject);
  }

  private void UpdateMusic()
  {
    /*if (Application.loadedLevel == 0)
    {
      if (!startMusic.isPlaying)
      {
        startMusic.Play();
      }
    }
    else
    {
      if (startMusic.isPlaying)
      {
        startMusic.Stop();
      }
    }

    if (Application.loadedLevel == 1 || Application.loadedLevel == 2)
    {
      if (!gameplayMusic.isPlaying)
      {
        gameplayMusic.Play();
      }
    }
    else
    {
      if (gameplayMusic.isPlaying)
      {
        gameplayMusic.Stop();
      }
    }
    */

    if (!gameplayMusic.isPlaying)
    {
      gameplayMusic.Play();
    }

    if (gameoverMusic.isPlaying)
    {
      gameoverMusic.Stop();
    }

  }

  public void StopAllMusic()
  {
    if (gameplayMusic.isPlaying)
    {
      gameplayMusic.Stop();
    }
    if (startMusic.isPlaying)
    {
      startMusic.Stop();
    }
    if (gameoverMusic.isPlaying)
    {
      gameoverMusic.Stop();
    }
  }

  public void PlayGameOverMusic()
  {
    if (!gameoverMusic.isPlaying)
    {
      gameoverMusic.Play();
    }
  }

  /*public void SetVolume(float volume)
  {
    startMusic.volume = volume;
    gameplayMusic.volume = volume;
    gameoverMusic.volume = volume;
  }*/
}
