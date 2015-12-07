using UnityEngine;

public class FlowerScript : MonoBehaviour
{

  public AudioClip pickUpSound;
  GameObject mainCamera;
  public GameObject renderClone;

  void Start ()
  {
    mainCamera = GameObject.Find("Main Camera");
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player")
    {
      if (Game.Sound)
      {
        mainCamera.GetComponent<AudioSource>().PlayOneShot(pickUpSound, 0.25f);
      }
      Game.score++;

      var spriteImage = GetComponent<SpriteRenderer>().sprite;
      var newObj = (GameObject)Instantiate(renderClone, transform.position, Quaternion.identity);
      newObj.GetComponent<SpriteRenderer>().sprite = spriteImage;

      Destroy(this.gameObject);
    }
  }
}
