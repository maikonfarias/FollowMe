using UnityEngine;
using System.Collections;

public class BackgroundMovementScript : MonoBehaviour
{
  public float speed = 1;
  GameObject mainCamera;

  void Start ()
  {
    mainCamera = GameObject.Find("Main Camera");
  }
	
	void Update ()
  {
    this.transform.position = new Vector3(mainCamera.transform.position.x / speed, this.transform.position.y, this.transform.position.z);
	}
}
