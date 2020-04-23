using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureShake : MonoBehaviour {

    public float Magnitude = 0.5f;
    public Image image;

    private Vector3 m_startPos;

    private void Start()
    {
        m_startPos = transform.localPosition;
    }

    private void Update()
    {
        float x = Random.Range(-Magnitude, Magnitude);
        float y = Random.Range(-Magnitude, Magnitude);
        transform.localPosition = m_startPos + new Vector3(x, y, 0.0f);
    }

    void OnMouseEnter()
    {
        var render = gameObject.GetComponent<Renderer>();

        Destroy(image);
    }
}
