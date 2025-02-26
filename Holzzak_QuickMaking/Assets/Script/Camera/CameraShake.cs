using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    [SerializeField]
    private float shakeDuration = 0.1f;

    [SerializeField]
    private float shakeAmount = 0.2f;

    private bool isShaking = false;

    private void Update()
    {
        if(GameManager.instance.bShake)
        {
            ShakeIt();
        }
    }

    private IEnumerator Shake()
    {
        if(GameManager.instance.bShake)
        {
            yield return null;
        }

        //isShaking = true;
        GameManager.instance.bShake = true;

        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f; 

        while(elapsed < shakeDuration)
        {
            float x = Random.Range(-1.0f, 1.0f) * shakeAmount;
            float y = Random.Range(-1.0f, 1.0f) * shakeAmount;

            transform.localPosition = new Vector3(originalPos.x + x,
                originalPos.y + y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
        //isShaking = false;
        GameManager.instance.bShake = false;

    }

    public void ShakeIt()
    {
        StartCoroutine(Shake());
    }

}
