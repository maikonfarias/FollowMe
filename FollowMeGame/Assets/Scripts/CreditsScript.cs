using UnityEngine;

public class CreditsScript : MonoBehaviour
{
	
	void Update()
  {
    if (Game.isDead)
    {
      if(transform.position.y < -1)
      {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 2f);
      } else
      {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
      }
    }
	}
}
