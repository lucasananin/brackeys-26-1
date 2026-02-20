using UnityEngine;

public class ParallaxImages : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField, Range(0, 1f)] private float parallexFactor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float positionX;
    private float length;
    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
        positionX = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = cameraTransform.position.x * parallexFactor;
        transform.position = new Vector3(positionX + distance, transform.position.y, transform.position.z);
    }
}
