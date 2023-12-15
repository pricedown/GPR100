using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int scoreValue = 1;
    public GameObject circlePrefab;
    public GameObject holePrefab;
    
    public float expandTime = 10f; // Adjust this value to control the expansion time
    private float elapsedTime = 0f;
    private void Start()
    {
        GameObject circle = Instantiate(circlePrefab, transform.position, Quaternion.identity);
        circle.transform.parent = transform;
        elapsedTime = 0f;
    }

    private void FixedUpdate()
    {
        if (elapsedTime < expandTime)
        {
            elapsedTime += Time.fixedDeltaTime;

            float scaleProgress = elapsedTime / expandTime;
            Transform circleTransform = transform.GetChild(0);
            circleTransform.localScale = Vector3.Lerp(Vector3.zero, this.transform.localScale * 0.6f, scaleProgress);
        }
        else
        {
            Instantiate(holePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Score>().addScore(scoreValue);
            Destroy(gameObject);
        }
    }
}