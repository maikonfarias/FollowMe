using UnityEngine;

public class DelayToShow : MonoBehaviour
{

  public float delayInSeconds = 1;
  float timeToShow;

  SpriteRenderer rendererToShow;

	void Start() {
    timeToShow = Time.time + delayInSeconds;
    rendererToShow = GetComponent<SpriteRenderer>();
    rendererToShow.enabled = false;
	}

	void Update()
  {
    if (timeToShow < Time.time)
    {
      rendererToShow.enabled = true;
    }
	}
}
