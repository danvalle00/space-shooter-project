using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private Vector2 scrollSpeed;
    private Material backgroundMaterial;
    private Vector2 materialOffset;

    private void Start()
    {
        backgroundMaterial = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        materialOffset += scrollSpeed * Time.deltaTime;
        backgroundMaterial.mainTextureOffset = materialOffset;
    }
}
