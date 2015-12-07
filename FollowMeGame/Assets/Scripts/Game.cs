using UnityEngine;

public static class Game
{
  public static int score = 0;
  public static int direction = 0;
  public static bool jump = false;
  public static bool canControl = true;
  public static bool isDead = false;

  public static bool Sound
  {
    get
    {
      return PlayerPrefs.GetInt("Sound", 1) == 1;
    }
    set
    {
      PlayerPrefs.SetInt("Sound", 0);
    }
  }

  public static SceneFadeInOut GetScreenFader()
  {
    return GameObject.Find("ScreenFader").GetComponent<SceneFadeInOut>();
  }

  public static SoundScript GetSoundManager()
  {
    return GameObject.Find("SoundManager").GetComponent<SoundScript>();
  }

}
