using UnityEngine;
using System.Collections;

public class WarpScript : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player")
    {
      //Game.GetScreenFader().LoadScene(2);
      Application.LoadLevel(2);
    }
  }
}
