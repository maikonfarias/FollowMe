using UnityEngine;
using System.Collections;

public class SheepController : MonoBehaviour {

  public AudioClip jumpSound;
  private float movementSpeed = 3f;
  public bool lookingRight = true;
  Animator anim;

  bool grounded = false;
  public Transform groundCheck;
  public Transform groundCheck2;
  float groundRadius = .5f;
  public LayerMask whatIsGround;
  public float jumpForce = 70;
  GameObject mainCamera;
  float lastJump = 0f;

  void Start () {
    mainCamera = GameObject.Find("Main Camera");
    anim = GetComponent<Animator>();
    anim.SetFloat("Speed", 0);
  }
	
	void Update () {
    UpdatePhysics();
  }

  void UpdatePhysics()
  {

    grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround) || Physics2D.OverlapCircle(groundCheck2.position, groundRadius, whatIsGround);

    anim.SetBool("Ground", grounded);
    anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

    if (Game.direction == -1 && Game.canControl)
    {
      GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed*-1, GetComponent<Rigidbody2D>().velocity.y);
      anim.SetFloat("Speed", Mathf.Abs(movementSpeed));

    }
    else if (Game.direction == 1 && Game.canControl)
    {
      GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
      anim.SetFloat("Speed", Mathf.Abs(movementSpeed));

    }
    else
    {
      GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
      anim.SetFloat("Speed", 0);
    }

    if (((Game.direction > 0 && !lookingRight) || (Game.direction < 0 && lookingRight)) && Game.canControl)
    {
      Flip();
    }

    if (Game.jump && Game.canControl)
    {
      Game.jump = false;
      if(grounded)
      {
        Jump();
      }
      
    }
    if (Game.isDead)
    {
      anim.SetBool("Dead", true);
    }
      
  }

  void Jump()
  {
    if (lastJump + 0.5f < Time.time)
    {
      PlaySound(jumpSound);
      grounded = false;
      anim.SetBool("Ground", false);
      GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
      GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
      //ForceJump = false;
      lastJump = Time.time;
    }

  }

  void PlaySound(AudioClip clip, float volume = 0.25f)
  {
    if (Game.Sound)
    {
      mainCamera.GetComponent<AudioSource>().PlayOneShot(clip, volume);
    }
  }

  public void Flip()
  {
    lookingRight = !lookingRight;
    Vector3 myScale = transform.localScale;
    myScale.x *= -1;
    transform.localScale = myScale;
  }
}
