using UnityEngine;

public class ObjectFade : MonoBehaviour
{
    public static float fadeDuration = 2f;

    private float fadeTimer;
    private SpriteRenderer objectSpriteRenderer;
    private bool isFading;
    private bool fadingIn = false;

    private void Start()
    {
        objectSpriteRenderer = transform.Find("COVER").GetComponent<SpriteRenderer>();
        Debug.Log(objectSpriteRenderer);
    }

    private void Update()
    {
        if (isFading)
        {
            fadeTimer += Time.deltaTime;
            float alpha;
            if (fadingIn)
            {
                alpha = 1f - (fadeTimer / fadeDuration);
            }
            else
            {
                alpha = fadeTimer / fadeDuration;
            }
            objectSpriteRenderer.material.color = new Color(objectSpriteRenderer.material.color.r, objectSpriteRenderer.material.color.g, objectSpriteRenderer.material.color.b, alpha);

            if (fadeTimer >= fadeDuration)
            {
                isFading = false;
                fadeTimer = 0f;
            }
        }
    }

    public void StartFadeOut()
    {
        if (!isFading)
        {
            fadingIn= false;
            isFading = true;
            fadeTimer = 0f;
        }
    }

    public void StartFadeIn()
    {
        if (!isFading)
        {
            fadingIn = true;
            isFading = true;
            fadeTimer = 0f;
        }
    }
}
