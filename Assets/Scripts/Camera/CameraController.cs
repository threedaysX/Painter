using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {

    public GameObject followTarget;
    private Vector3 targetPos;
    public float moveSpeed;

    public bool Shake;

    public float ShakePower = 20;
    public float ShakeTime =  5;

    public float x_left;
    public float x_right;

	// Use this for initialization
	void Start () {
        Scene nowScene = SceneManager.GetActiveScene();
        Debug.Log("Scene:" + nowScene.name);
	}
	
	// Update is called once per frame
	void Update () {
        if (followTarget.transform.position.x <= x_left)
        {
            targetPos = new Vector3(x_left, followTarget.transform.position.y, -10);
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }

        else if (followTarget.transform.position.x >= x_right)
        {
            targetPos = new Vector3(x_right, followTarget.transform.position.y, -10);
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }

        else
        {
            targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, -10);
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }

        if (Shake)
            StartCoroutine(Shakeing());
	}

    public IEnumerator Shakeing()
    {
        if (Shake)
        {
            transform.Translate(Vector3.up * ShakePower);
            yield return new WaitForSeconds(ShakeTime);
            transform.Translate(Vector3.up * -ShakePower);
        }
    }
}
