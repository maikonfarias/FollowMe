using UnityEngine;
using System.Collections;

public class StartScreenScript : MonoBehaviour {

  public Texture2D startButton;
  public Texture2D optionsButton;
  public Texture2D exitButton;

  void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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

    if (GUI.Button(buttonPos, "", new GUIStyle()))
    {
      //Game.GetScreenFader().LoadScene(1, true);
      Application.LoadLevel(1);
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
