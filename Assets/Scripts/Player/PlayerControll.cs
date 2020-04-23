using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour
{
    public static bool canMove;
    public static bool canDraw;
    public GameObject Menu;
    public Slider slider;
    public AudioSource Audio;
    public Rigidbody2D myRGB;

    public float startMovingTriggerOffset = 0.1F; //開始移動 (0~1乘螢幕半寬)
    public float fullSpeedTriggerOffset = 0.3F; //全速移動 (0~1乘螢幕半寬，需大於開始移動)
    public float vaildMovingYMin = 0.3F; //滑鼠最低可觸發移動 (0~1乘螢幕高)
    public float speed = 1;
    public BezierPoint currentPoint;
    public float currentIntervalDistance = 0;
    public static int atPoint = 0;

    private Animator anim;
    public float a = 2;
    public float b = -2;
    public float c = 0;

    public static int TurnAni = 0;
    public static int DrawAni = 0;
    public static int End = 0;

    public static PlayerControll PC;

    // Use this for initialization
    void Start()
    {
        myRGB = GetComponent<Rigidbody2D>();
        Menu.SetActive(false);
        anim = GetComponent<Animator>();

        BezierCurve path = currentPoint.curve;
        currentPoint = path[atPoint];
        transform.position = currentPoint.transform.position;

        if(Stage_level.stage_is_on)
        {
            canMove = true;
            canDraw = true;
        }        
        Debug.Log("START");

        if (!PC)
            PC = this;
        else
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Color_Collect.mouseIsUse == true)
            DoYouWantToDraw();

        if (canMove)
        {
            if (Input.mousePosition.y > Screen.height * vaildMovingYMin)
            {
                BezierCurve path = currentPoint.curve;
                float movingDistance = speed * Time.deltaTime; //這一禎時間的時間的移動距離
                float halfWidth = Screen.width / 2; //螢幕半寬

                if (Input.mousePosition.x > halfWidth * (1 + startMovingTriggerOffset))
                {
                    if (Input.mousePosition.x < halfWidth * (1 + fullSpeedTriggerOffset))
                    {
                        movingDistance *= (Input.mousePosition.x - (halfWidth * (1 + startMovingTriggerOffset))) / (halfWidth * (fullSpeedTriggerOffset - startMovingTriggerOffset)); //線性加速
                    }

                    if (path.close)
                    {
                        //TODO
                    }
                    else
                    {
                        if (currentPoint != path[path.pointCount - 1])
                        {
                            int index = path.GetPointIndex(currentPoint);
                            currentIntervalDistance += movingDistance;
                            while (true)
                            {
                                float currentIntervalLength = BezierCurve.ApproximateLength(currentPoint, path[index + 1], path.resolution);

                                if (currentIntervalDistance < currentIntervalLength)
                                {//移動距離還在點與點之間
                                    transform.position = BezierCurve.GetPoint(path[index], path[index + 1], currentIntervalDistance / currentIntervalLength);
                                    anim.SetFloat("speed", a);
                                    break;
                                }
                                else if (currentIntervalDistance > currentIntervalLength)
                                {//移動距離長到要跨點
                                    if (index < path.pointCount - 2)
                                    {//跨點之後還有點
                                        ++index;
                                        currentPoint = path[index];
                                        if (currentPoint.GetComponent<PointTeleport>() != null)
                                        {
                                            if (currentPoint != currentPoint.GetComponent<PointTeleport>().teleportToDestinationPoint())
                                            {
                                                currentIntervalDistance = 0;
                                                currentPoint = currentPoint.GetComponent<PointTeleport>().teleportToDestinationPoint();
                                            }
                                            else
                                            {
                                                currentIntervalDistance -= currentIntervalLength;
                                                anim.SetFloat("speed", c);
                                            }
                                        }
                                        else
                                        {
                                            currentIntervalDistance -= currentIntervalLength;
                                            anim.SetFloat("speed", c);
                                        }
                                    }
                                    else
                                    {//無法跨點所以到達末端的點
                                        currentPoint = path[path.pointCount - 1];
                                        if (currentPoint.GetComponent<PointTeleport>() != null)
                                        {
                                            currentPoint = currentPoint.GetComponent<PointTeleport>().teleportToDestinationPoint();
                                        }
                                        currentIntervalDistance = 0;
                                        transform.position = currentPoint.transform.position;
                                        anim.SetFloat("speed", a);
                                        break;
                                    }
                                }
                                else
                                {//移動距離正好到下一個點(機率很低)
                                    currentPoint = path[index + 1];
                                    if (currentPoint.GetComponent<PointTeleport>() != null)
                                    {
                                        currentPoint = currentPoint.GetComponent<PointTeleport>().teleportToDestinationPoint();
                                    }
                                    currentIntervalDistance = 0;
                                    transform.position = currentPoint.transform.position;
                                    anim.SetFloat("speed", a);
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (Input.mousePosition.x < halfWidth * (1 - startMovingTriggerOffset))
                {
                    if (Input.mousePosition.x > halfWidth * (1 - fullSpeedTriggerOffset))
                    {
                        movingDistance *= ((halfWidth * (1 - startMovingTriggerOffset)) - Input.mousePosition.x) / (halfWidth * (fullSpeedTriggerOffset - startMovingTriggerOffset));
                    }

                    if (path.close)
                    {
                        //TODO
                    }
                    else
                    {
                        if (currentPoint == path[path.pointCount - 1])
                        { //末端的點轉為前一個點和到末端的點的距離
                            currentIntervalDistance = BezierCurve.ApproximateLength(path[path.pointCount - 2], currentPoint, path.resolution);
                            currentPoint = path[path.pointCount - 2];
                        }
                        currentIntervalDistance -= movingDistance;
                        int index = path.GetPointIndex(currentPoint);
                        while (true)
                        {
                            if (currentIntervalDistance > 0)
                            {//移動距離還在點與點之間
                                transform.position = BezierCurve.GetPoint(currentPoint, path[index + 1], currentIntervalDistance / BezierCurve.ApproximateLength(currentPoint, path[index + 1], path.resolution));
                                anim.SetFloat("speed", b);
                                break;
                            }
                            else if (currentIntervalDistance < 0)
                            {//移動距離長到要跨點
                                if (index >= 1)
                                {//跨點之後還有點
                                    if (currentPoint.GetComponent<PointTeleport>() != null)
                                    {
                                        if (currentPoint != currentPoint.GetComponent<PointTeleport>().teleportToDestinationPoint())
                                        {
                                            currentIntervalDistance = 0;
                                            currentPoint = currentPoint.GetComponent<PointTeleport>().teleportToDestinationPoint();
                                        }
                                        else
                                        {
                                            --index;
                                            currentIntervalDistance += BezierCurve.ApproximateLength(path[index], currentPoint, path.resolution);
                                            currentPoint = path[index];
                                            anim.SetFloat("speed", c);
                                        }
                                    }
                                    else
                                    {
                                        --index;
                                        currentIntervalDistance += BezierCurve.ApproximateLength(path[index], currentPoint, path.resolution);
                                        currentPoint = path[index];
                                        anim.SetFloat("speed", c);
                                    }
                                }
                                else
                                {//無法跨點所以到達原點
                                    currentPoint = path[0];
                                    if (currentPoint.GetComponent<PointTeleport>() != null)
                                    {
                                        currentPoint = currentPoint.GetComponent<PointTeleport>().teleportToDestinationPoint();
                                    }
                                    currentIntervalDistance = 0;
                                    transform.position = currentPoint.transform.position;
                                    anim.SetFloat("speed", b);
                                    break;
                                }
                            }
                            else
                            {//移動距離正好到下一個點(機率很低)
                                currentPoint = path[index];
                                if (currentPoint.GetComponent<PointTeleport>() != null)
                                {
                                    currentPoint = currentPoint.GetComponent<PointTeleport>().teleportToDestinationPoint();
                                }
                                transform.position = currentPoint.transform.position;
                                anim.SetFloat("speed", b);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    anim.SetFloat("speed", c);
                }
            }
            else
            {
                anim.SetFloat("speed", c);
            }
                
        }
        else
        {
            anim.SetFloat("speed", c);
        }
            


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canMove = false;
            canDraw = false;
            NPC_Draw.canDraw_NPC = false;
            第一關騎士心聲.canClick = false;
            Menu.SetActive(true);
        }
    }

    public void DoYouWantToDraw()
    {
        if (canDraw)
        {
            if (TurnAni == 1)
            {
                canMove = false;
                anim.SetBool("StartTurn", true);
            }
            if (DrawAni == 1)
            {
                canMove = false;
                anim.SetBool("Drawing", true);
            }
            if (End == 1)
            {
                anim.SetBool("StartTurn", false);
                anim.SetBool("Drawing", false);
                DrawAni = 0;
                TurnAni = 0;
                canMove = true;
                End = 0;
            }
        }
        else
        {
            anim.SetBool("StartTurn", false);
            anim.SetBool("Drawing", false);
        }

    }

    public void BackToGame()
    {
        Menu.SetActive(false);
        canMove = true;
        canDraw = true;
        NPC_Draw.canDraw_NPC = true;
        第一關騎士心聲.canClick = true;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
