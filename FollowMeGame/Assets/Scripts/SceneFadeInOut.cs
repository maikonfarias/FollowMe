using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneFadeInOut : MonoBehaviour
{
  public Image FadeImg;
  float fadeSpeed = 4f;
  public bool sceneStarting = false;
  public bool sceneEnding = false;

  private int sceneToLoad = 0;
  private float volume = 0;
  private bool fadeSound;


  void Awake()
  {
    //FadeImg.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
    volume = 1;
    //Game.GetSoundManager().SetVolume(volume);
  }

  public bool isFading
  {
    get
    {
      return sceneStarting || sceneEnding;
    }
  }

  void Update()
  {
    /*if (sceneStarting && false)
    {
      StartScene();
    }
    if (sceneEnding)
    {
      EndScene();
    }*/
  }


  void FadeToClear()
  {
    // Lerp the colour of the image between itself and transparent.
    FadeImg.color = Color.Lerp(FadeImg.color, Color.clear, fadeSpeed * Time.deltaTime);
  }


  void FadeToBlack()
  {
    // Lerp the colour of the image between itself and black.
    FadeImg.color = Color.Lerp(FadeImg.color, Color.black, fadeSpeed * Time.deltaTime);

    if (fadeSound) {
      volume -= fadeSpeed * Time.deltaTime;
      //Game.GetSoundManager().SetVolume(volume);
    }
  }


  void StartScene()
  {
    // Fade the texture to clear.
    FadeToClear();

    // If the texture is almost clear...
    if (FadeImg.color.a <= 0.1f)
    {
      // ... set the colour to clear and disable the RawImage.
      FadeImg.color = Color.clear;
      FadeImg.enabled = false;

      // The scene is no longer starting.
      sceneStarting = false;

      //Game.GetSoundManager().SetVolume(1);
    }
  }


  public void EndScene()
  {
    // Make sure the RawImage is enabled.
    FadeImg.enabled = true;

    // Start fading towards black.
    FadeToBlack();

    // If the screen is almost black...
    if (FadeImg.color.a >= 0.9f)
    {
      Application.LoadLevel(sceneToLoad);
    }
  }

  public void LoadScene(int sceneNumber, bool fadeSound = false)
  {
    this.fadeSound = fadeSound;
    sceneToLoad = sceneNumber;
    sceneEnding = true;
    volume = 1;
  }
}
