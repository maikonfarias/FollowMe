using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WarpScript : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player")
    {
      //Game.GetScreenFader().LoadScene(2);
      SceneManager.LoadScene(2);
    }
  }
}
