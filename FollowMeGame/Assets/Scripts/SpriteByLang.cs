using UnityEngine;

public class SpriteByLang : MonoBehaviour
{
  public Sprite spriteForEnglish;
  public Sprite spriteForPortuguese;

  SpriteRenderer myRenderer;

	void Start ()
  {
    myRenderer = GetComponent<SpriteRenderer>();
	}
	
	void Update ()
  {
    if (Application.systemLanguage == SystemLanguage.Portuguese)
    {
      myRenderer.sprite = spriteForPortuguese;
    }
    else
    {
      myRenderer.sprite = spriteForEnglish;
    }
	}
}
