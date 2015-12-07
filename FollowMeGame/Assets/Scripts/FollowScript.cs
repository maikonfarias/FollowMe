using UnityEngine;

public class FollowScript : MonoBehaviour
{
  public GameObject objectToFollow;

	void Update()
  {
    transform.position = objectToFollow.transform.position;
	}
}
