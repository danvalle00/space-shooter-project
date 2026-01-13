using System.Collections;
using UnityEngine;



public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeMagnitude = 0.5f;
    [SerializeField] private float shakeDuration = 0.3f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.localPosition;
    }

    public void PlayShake()
    {
        StartCoroutine(CameraShakeCoroutine());
    }

    private IEnumerator CameraShakeCoroutine()
    {
        float timeElapsed = 0f;
        while (timeElapsed < shakeDuration)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.localPosition = initialPosition;
    }


}
