using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScreenScript : MonoBehaviour {
  public Texture2D startENButton;
  public Texture2D startPTButton;
  public Texture2D exitENButton;
  public Texture2D exitPTButton;

  private Texture2D startButton;
  public Texture2D optionsButton;
  private Texture2D exitButton;


  void Start () {
	
	}
	
	void Update ()
  {
    if (Application.systemLanguage == SystemLanguage.Portuguese)
    {
      startButton = startPTButton;
      exitButton = exitPTButton;
    }
    else
    {
      startButton = startENButton;
      exitButton = exitENButton;
    }

  }

  void OnGUI()
  {
    //if (Game.GetScreenFader().isFading)
    {
      //return;
    }
    var buttonSize = Screen.height * 0.16f;
    var buttonPos = new Rect((Screen.width / 2) + buttonSize * .5f, (Screen.height /2) - buttonSize*1f, buttonSize*3, buttonSize);
    GUI.DrawTexture(buttonPos, startButton);

    if (GUI.Button(buttonPos, "", new GUIStyle()) || Input.GetButton("Fire3"))
    {
      //Game.GetScreenFader().LoadScene(1, true);
      SceneManager.LoadScene(1);
    }

    /*buttonPos = new Rect((Screen.width / 2) + buttonSize * .5f, (Screen.height / 2) - buttonSize * .5f, buttonSize*3, buttonSize);
    GUI.DrawTexture(buttonPos, optionsButton);

    if (GUI.Button(buttonPos, "", new GUIStyle()))
    {
      //
    }*/

    buttonPos = new Rect((Screen.width / 2) + buttonSize * .5f, (Screen.height / 2) + buttonSize * 0f, buttonSize*3, buttonSize);
    GUI.DrawTexture(buttonPos, exitButton);

    if (GUI.Button(buttonPos, "", new GUIStyle()))
    {
      Application.Quit();
    }
  }

}
