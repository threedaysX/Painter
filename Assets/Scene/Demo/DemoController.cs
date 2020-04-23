using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoController : MonoBehaviour {
	public BezierCurve path;
	public int movingTriggerOffset = 10;
	public float speed = 1;
	public float interval = 0;
	private Animator anim;
	public float a = 2;
	public float b= -2;
	public float c=0;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		int halfWidth = Screen.width / 2;
		if (Input.mousePosition.x > (halfWidth + movingTriggerOffset)) {
			float distance = speed * Time.deltaTime;
			if (path.close) {
				distance %= path.length;

			}
			else {
				if (distance < path.length) {
					int pointIndex = Mathf.FloorToInt(interval);
					for (int i = pointIndex; i < path.pointCount - 1; i++) {
						float currentIntervalLength = BezierCurve.ApproximateLength(path[i], path[i + 1], path.resolution);
						if (i == pointIndex) {
							float acc = currentIntervalLength * (1 - (interval % 1));
							if (distance < acc) {
								interval += distance / currentIntervalLength;
								transform.position = BezierCurve.GetPoint(path[i], path[i + 1], interval % 1);
								anim.SetFloat ("speed", a);
								break;
							}
							else {
								distance -= acc;
								anim.SetFloat ("speed", c);
							}
						}
						else {
							if (distance < currentIntervalLength) {
								float acc = distance / currentIntervalLength;
								interval = i + acc;
								transform.position = BezierCurve.GetPoint(path[i], path[i + 1], acc);
								anim.SetFloat ("speed", a);
								break;
							}
							else {
								distance -= currentIntervalLength;
								anim.SetFloat ("speed", c);
							}
						}
					}
				}
				else {
					interval = path.pointCount;
					transform.position = path[path.pointCount].position;
					anim.SetFloat ("speed", c);
				}
			}
		}
		else if (Input.mousePosition.x < (halfWidth - movingTriggerOffset)) {
			float distance = speed * Time.deltaTime;
			if (path.close) {

			}
			else {
				if (distance < path.length) {
					int pointIndex = Mathf.CeilToInt(interval);
					for (int i = pointIndex; i > 0; i--) {
						float currentIntervalLength = BezierCurve.ApproximateLength(path[i - 1], path[i], path.resolution);
						if (i == pointIndex) {
							float acc = currentIntervalLength * (interval % 1);
							if (distance < acc) {
								interval -= distance / currentIntervalLength;
								transform.position = BezierCurve.GetPoint(path[i - 1], path[i], interval % 1);
								anim.SetFloat ("speed", b);
								break;
							}
							else {
								distance -= acc;
								anim.SetFloat ("speed", c);
							}
						}
						else {
							if (distance < currentIntervalLength) {
								float acc = distance / currentIntervalLength;
								interval = i - acc;
								transform.position = BezierCurve.GetPoint(path[i - 1], path[i], 1 - acc);
								anim.SetFloat ("speed", b);
								break;
							}
							else {
								distance -= currentIntervalLength;
								anim.SetFloat ("speed", c);
							}
						}
					}
				}
				else {
					interval = 0;
					transform.position = path[0].position;
					anim.SetFloat ("speed", c);
				}
			}
		}

	}
}
