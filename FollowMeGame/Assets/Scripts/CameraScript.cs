using UnityEngine;
using System.Collections;
using System;

public class CameraScript : MonoBehaviour {

  public Texture2D arrowLeftButton;
  public Texture2D arrowRightButton;
  public Texture2D jumpButton;
  public Texture2D exitButton;

  public Texture2D deathAnimationTexture;

  public Texture2D flowerTexture;
  public Texture2D colonTexture;
  public Texture2D[] numbersTexture;

  public AudioClip deathSound;
  public Transform player;
  bool showedDeathAnimation;
  float deathAnimationTime = 0;

  void Start()
  {
    Game.score = 0;
    Game.canControl = true;
    Game.isDead = false;
  }

  void OnGUI()
  {
    ShowDeathAnimation();

    bool didPress = false;
    var buttonSize = Screen.height * 0.3f;
    Rect buttonPos;

    if (!Game.isDead)
    {
      if (Application.loadedLevel == 2)
      {
        ShowScore();
      }

      buttonPos = new Rect(0, Screen.height - buttonSize, buttonSize, buttonSize);
      

      GUI.DrawTexture(buttonPos, arrowLeftButton);
      for (int i = 0; i < Input.touchCount; ++i)
      {
        var touchPos = Input.GetTouch(i).position;
        if (buttonPos.Contains(new Vector2(touchPos.x, Screen.height - touchPos.y)))
        {
          Game.direction = -1;
          didPress = true;
        }
      }

      buttonPos = new Rect(buttonSize, Screen.height - buttonSize, buttonSize, buttonSize);

      GUI.DrawTexture(buttonPos, arrowRightButton);
      for (int i = 0; i < Input.touchCount; ++i)
      {
        var touchPos = Input.GetTouch(i).position;
        if (buttonPos.Contains(new Vector2(touchPos.x, Screen.height - touchPos.y)))
        {
          Game.direction = 1;
          didPress = true;
        }
      }
    }
    if (Input.GetKey(KeyCode.A))
    {
      Game.direction = -1;
      didPress = true;
    }
    else if (Input.GetKey(KeyCode.D))
    {
      Game.direction = 1;
      didPress = true;
    }

    if (!didPress)
    {
      Game.direction = 0;
    }

    buttonPos = new Rect((Screen.width) - (buttonSize*1.5f), 0, buttonSize * 2, buttonSize*0.5f);
    GUI.DrawTexture(buttonPos, exitButton);

    if (GUI.Button(buttonPos, "", new GUIStyle()))
    {
      Application.LoadLevel(0);
    }

    if (!Game.isDead)
    {
      buttonPos = new Rect((Screen.width) - (buttonSize * 0.9f), Screen.height - buttonSize * 0.9f, buttonSize * 0.7f, buttonSize * 0.7f);
      GUI.DrawTexture(buttonPos, jumpButton);

      for (int i = 0; i < Input.touchCount; ++i)
      {
        if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
        {
          var touchPos = Input.GetTouch(i).position;
          if (buttonPos.Contains(new Vector2(touchPos.x, Screen.height - touchPos.y)))
          {
            Game.jump = true;
          }
        }
      }
    }
    if (Input.GetKeyDown(KeyCode.Space))
    {
      Game.jump = true;
    }
  }

  private void ShowDeathAnimation()
  {
    if (Game.isDead && !showedDeathAnimation)
    {
      deathAnimationTime = Time.time + 1;
      showedDeathAnimation = true;
      GetComponent<AudioSource>().PlayOneShot(deathSound, 1);
    }
    

    if (Game.isDead && deathAnimationTime > Time.time)
    {
      GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), deathAnimationTexture);
    }
  }

  private void ShowScore()
  {
    var buttonSize = Screen.height * 0.2f;
    var letterWidth = buttonSize ;
    var leterHeight = buttonSize;
    var marginTop = buttonSize * .1f;

    var buttonPos = new Rect(marginTop, marginTop, buttonSize, buttonSize);
    GUI.DrawTexture(buttonPos, flowerTexture);

    buttonPos = new Rect(buttonSize, 0, buttonSize, buttonSize);
    GUI.DrawTexture(buttonPos, colonTexture);

    string stringScore = Game.score.ToString();
    char[] letters = stringScore.ToCharArray();
    //Array.Reverse(letters);

    float marginRight = buttonSize * 1f + letterWidth * 1;
    //GUI.DrawTexture(new Rect(marginRight - letterWidth * 6, marginTop, letterWidth * 6 + buttonSize * .3f, leterHeight + buttonSize * .13f), scoreFrameTexture);
    foreach (var letter in letters)
    {
      buttonPos = new Rect(marginRight, marginTop, letterWidth, leterHeight);
      GUI.DrawTexture(buttonPos, numbersTexture[(int)Char.GetNumericValue(letter)]);
      marginRight += letterWidth;
    }
  }

  void Update()
  {
    if (player)
    {
      if (player.position.x > -22 && player.position.x < 90.5)
      {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
      }
    }
  }
}
