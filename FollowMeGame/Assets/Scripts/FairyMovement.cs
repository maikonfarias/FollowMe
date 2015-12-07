using System;
using UnityEngine;

public class FairyMovement : MonoBehaviour
{
  public GameObject dialogFollowMe;
  public GameObject dialogBye;

  public GameObject stake;

  public float movementSpeed = 3f;
  int state = 0; //0 = free, 1 = busy
  int phase = 0; // phase of her movement, 1-7 = movement, 8 = gameover

  public bool lookingRight = false;

  GameObject player;
  float timeToDie = 0;

  void Start()
  {
    player = GameObject.Find("Sheep");
    dialogBye.GetComponent<SpriteRenderer>().enabled = false;
    stake.GetComponent<SpriteRenderer>().enabled = false;
  }

	void Update()
  {

    //TODO: create a state machine for the fairy
    if(timeToDie < Time.time && timeToDie != 0)
    {
      timeToDie = 0;
      Game.isDead = true;
      Game.GetSoundManager().PlayGameOverMusic();
      stake.GetComponent<SpriteRenderer>().enabled = true;
    }

    if (state == 0)
    {
      if (phase == 0)
      {
        if (player.transform.position.x > -19)
        {
          phase = 1;
          state = 1;
          Flip();
        }
      }
      if (phase == 1)
      {
        if (player.transform.position.x > -10)
        {
          phase = 2;
          state = 1;
          Flip();
        }
      }
      if (phase == 2)
      {
        if (player.transform.position.x > -1.5)
        {
          phase = 3;
          state = 1;
          Flip();
        }
      }

      if (phase == 3)
      {
        if (player.transform.position.x > 7)
        {
          phase = 4;
          state = 1;
          Flip();
        }
      }

      if (phase == 4)
      {
        if (player.transform.position.x > 15)
        {
          phase = 5;
          state = 1;
          Flip();
        }
      }

      if (phase == 5)
      {
        if (player.transform.position.x > 24)
        {
          phase = 6;
          state = 1;
          Flip();
        }
      }

      if (phase == 6)
      {
        if (player.transform.position.x > 39)
        {
          phase = 7;
          state = 1;
          Flip();
        }
      }

      if (phase == 7)
      {
        if (player.transform.position.x > 55)
        {
          phase = 8;
          state = 1;
          Flip();
        }
      }

      if (phase == 8)
      {
        if (player.transform.position.x > 63.8)
        {
          phase = 9;
          state = 1;
          Flip();
        }
      }

      if (phase == 9)
      {
        if (player.transform.position.x > 68.3)
        {
          phase = 10;
          state = 1;
          Flip();
        }
      }

      if (phase == 10)
      {
        if (player.transform.position.x > 71.2)
        {
          phase = 11;
          state = 1;
          Flip();
        }
      }

      if (phase == 11)
      {
        if (player.transform.position.x > 79)
        {
          phase = 12;
          state = 1;
          Flip();
        }
      }

      if (phase == 12)
      {
        if (player.transform.position.x > 81.6)
        {
          phase = 13;
          state = 1;
          Flip();
        }
      }

      if (phase == 13)
      {
        if (player.transform.position.x > 87.7)
        {
          phase = 14;
          state = 1;
          Flip();
        }
      }

      if (phase == 14)
      {
        if (player.transform.position.x > 93)
        {
          //FINAL, KILL
          phase = 15;
          state = 1;
          ShowFairyDialog();
          Game.canControl = false;
          timeToDie = Time.time + 3;
          Game.GetSoundManager().StopAllMusic();
          //Game.isDead = true;
          //Flip();
        }
      }

    }
    else if (state == 1)
    {
      if (phase == 1)
      {
        if(transform.position.x < -10)
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
          HideFollowMe();
          state = 0;
          Flip();
        }
      }

      if (phase == 2)
      {
        if (transform.position.x < -1.5)
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
          state = 0;
          Flip();
        }
      }

      if (phase == 3)
      {
        if (transform.position.x < 7)
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
          state = 0;
          Flip();
        }
      }
      if (phase == 4)
      {
        if (transform.position.x < 15)
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
          state = 0;
          Flip();
        }
      }

      if (phase == 5)
      {
        if (transform.position.x < 25)
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
          state = 0;
          Flip();
        }
      }

      if (phase == 6)
      {
        if (transform.position.x < 39)
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
          state = 0;
          Flip();
        }
      }

      if (phase == 7)
      {
        if (transform.position.x < 55.5)
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
          state = 0;
          Flip();
        }
      }


      if (phase == 8)
      {
        if (transform.position.x < 63.8)
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
          state = 0;
          Flip();
        }
      }


      if (phase == 9)
      {
        if (transform.position.x < 68.3)
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
          state = 0;
          Flip();
        }
      }


      if (phase == 10)
      {
        if (transform.position.x < 71.2)
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
          state = 0;
          Flip();
        }
      }


      if (phase == 11)
      {
        if (transform.position.x < 79)
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
          state = 0;
          Flip();
        }
      }


      if (phase == 12)
      {
        if (transform.position.x < 81.6)
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
          state = 0;
          Flip();
        }
      }


      if (phase == 13)
      {
        if (transform.position.x < 87.7)
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
          state = 0;
          Flip();
        }
      }


      if (phase == 14)
      {
        if (transform.position.x < 96.2)
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
          state = 0;
          Flip();
        }
      }

      if (phase == 15)
      {
        //fairy does nothing
        state = 0;
      }
    }
	}

  private void HideFollowMe()
  {
    dialogFollowMe.GetComponent<SpriteRenderer>().enabled = false;
  }

  private void ShowFairyDialog()
  {
    dialogBye.GetComponent<SpriteRenderer>().enabled = true;
  }

  public void Flip()
  {
    lookingRight = !lookingRight;
    Vector3 myScale = transform.localScale;
    myScale.x *= -1;
    transform.localScale = myScale;

    /*Vector3 dialogScale = dialog1.transform.localScale;
    dialogScale.x *= -1;
    dialog1.transform.localScale = dialogScale;*/

  }
}
