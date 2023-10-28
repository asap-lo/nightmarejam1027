using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Shake : MonoBehaviour
{

    public IEnumerator Shake(float duration, float magnitude)
    {
        Debug.Log("Shake");
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;
            yield return null;

        }

        transform.localPosition = originalPos;

    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Shak start e");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(Shake(0.1f, 0.05f));
        }
    }

}
