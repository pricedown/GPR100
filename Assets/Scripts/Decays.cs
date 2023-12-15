using UnityEngine;

public class Decays : MonoBehaviour
{
    public float lifetime = 5.0f; 
    private float currentLifetime;
    private Renderer objectRenderer;

    void Start()
    {
        currentLifetime = lifetime;

        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null)
        {
            Debug.LogError("Decays script requires a Renderer component on the GameObject.");
            enabled = false; 
        }
    }

    void Update()
    {
        currentLifetime -= Time.deltaTime;

        float normalizedOpacity = Mathf.Clamp01(currentLifetime / lifetime);
        UpdateOpacity(normalizedOpacity);

        if (currentLifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    void UpdateOpacity(float opacity)
    {
        if (objectRenderer.material.HasProperty("_Color"))
        {
            Color currentColor = objectRenderer.material.color;

            currentColor.a = opacity;

            objectRenderer.material.color = currentColor;
        }
        else
        {
            Debug.LogError("The material of the Renderer does not have a color property.");
        }
    }
}
