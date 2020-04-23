using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess : MonoBehaviour {

    public static Princess instance;
    public Transform target;//目标位置
    public float distance;//两个物体的距离

    public static bool RunAway =false;

    // Use this for initialization
    void Start () {
		if(!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        distance = Vector2.Distance(transform.position, target.position);
    }

    // Update is called once per frame
    private void Update()
    {
        if(RunAway)
        {
            StaticValue.StartTalk = false;
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = Vector2.MoveTowards(transform.position, target.position, (distance / 1.5f) * Time.deltaTime);
            if (this.gameObject.transform.position == target.transform.position)
            {
                Destroy(this.gameObject);
                StaticValue.StartTalk = true;
            }
            else
            {
                if (Stage_level.stage_is_on)
                {
                    Destroy(this.gameObject);
                }
            }
        }       
    }
}
