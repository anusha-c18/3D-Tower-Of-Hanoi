using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class drag : MonoBehaviour
{
    #region Private Properties
    float ZPosition;
    Vector3 OffSet;
    Vector3 InitialP;
    bool Dragging;
    #endregion

    #region Inspector Variables
    public Camera MainCamera;
    [SerializeField]
    Transform transtarget1;
    [SerializeField]
    Transform transtarget2;
    [Space]
    [SerializeField]
    public UnityEventQueueSystem OnBeginDrag;
    [SerializeField]
    public UnityEventQueueSystem OnEndDrag;
    public int[] posbox = { 3, 0, 0 };
    public int InitialIceBlock;
    #endregion

    #region Unity Functions
    // Start is called before the first frame update
    void Start()
    {
        ZPosition = MainCamera.WorldToScreenPoint(transform.position).z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Dragging)
        {
            Vector3 positon = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ZPosition);
            transform.position = MainCamera.ScreenToWorldPoint(positon + new Vector3(OffSet.x, OffSet.y));
        }
    }

    void OnMouseDown()
    {
        if (!Dragging)
        {
            InitialP = transform.position;
            if (-16.25 < transform.position.x && transform.position.x < -10.57) //left ice block
            {
                InitialIceBlock = 0;
            }
            else if (-4.570001 < transform.position.x && transform.position.x < 1.11000) //middle ice block
            {
                InitialIceBlock = 1;
            }
            else if (6.43 < transform.position.x && transform.position.x < 12.11) //right ice block
            {
                InitialIceBlock = 2;
            }
            if (transform.position.x == transtarget1.position.x && transform.position.x != transtarget2.position.x)
            {
                if (transform.localScale.x < transtarget1.localScale.x)
                    goto Begin;
                else
                    goto Display;
            }
            else if (transform.position.x == transtarget2.position.x && transform.position.x != transtarget1.position.x)
            {
                if (transform.localScale.x < transtarget2.localScale.x)
                    goto Begin;
                else
                    goto Display;
            }
            else if(transform.position.x == transtarget2.position.x && transform.position.x == transtarget1.position.x)
            {
                if (transform.localScale.x < transtarget1.localScale.x && transform.localScale.x < transtarget2.localScale.x)
                    goto Begin;
                else
                    goto Display;
            }
            else
            {
                goto Begin; 
            }

        Display:
            Debug.Log("only pick  the top most box");
            goto bye;
        Begin:
            BeginDrag();
           
        bye:
            Debug.Log("");
        }
    }
    void OnMouseUp()
    {
        EndDrag();
    }
    #endregion
    #region User Interface
    public void BeginDrag()
    {
        //OnBeginDrag.Invoke();
        Dragging = true;
        OffSet = MainCamera.WorldToScreenPoint(transform.position) - Input.mousePosition;
    }
    public void EndDrag()
    {
            Transform transtargetfinal = transtarget1;
            if ( -4.570001 < transform.position.x && transform.position.x < 1.11000) //middle ice block
            {
                if (InitialIceBlock == 1)
                    transform.position = InitialP;
                else
                {
                    float height = 3.46f;
                    if (transtarget1.position.x == -1.94567f)
                    {
                        height += 2.54f;
                        transtargetfinal = transtarget1;
                    }
                    if (transtarget2.position.x == -1.94567f)
                    {
                        height += 2.54f;
                        transtargetfinal = transtarget2;
                    }
                    if (transform.position.y - height < 5)
                    { 
                        if(height==3.46f)
                            goto NewPositionAllocation1;
                        else
                        {
                             if (transform.localScale.x > transtargetfinal.localScale.x)
                             {
                                 transform.position = InitialP;
                                 Debug.Log("You can only place a smaller box on top of a bigger box.");
                                 goto End;
                             }
                             else
                             {
                                 goto NewPositionAllocation1;
                             }
                        }
                NewPositionAllocation1:
                    Debug.Log(height + " ");
                    transform.position = new Vector3(-1.94567f, height, 15.32f);
                }
                else
                    transform.position = InitialP;
                }
            }
            else if (6.43 < transform.position.x && transform.position.x < 12.11) //right ice block
            { 
            if (InitialIceBlock == 2)
                transform.position = InitialP;
            else
            {
                float height = 3.46f;
                if (transtarget1.position.x == 9.31f)
                {
                    height += 2.54f;
                    transtargetfinal = transtarget1;
                }
                if (transtarget2.position.x == 9.31f)
                {
                    height += 2.54f;
                    transtargetfinal = transtarget2;
                }
                if ((transform.position.y - height < 5))
                {
                    if (height == 3.46f)
                    {
                        goto NewPositionAllocation2;
                    }
                    else
                    {
                        if (transform.localScale.x > transtargetfinal.localScale.x)
                        {
                            transform.position = InitialP;
                            Debug.Log("You can only place a smaller box on top of a bigger box.");
                            goto End;
                        }
                        else
                        {
                            goto NewPositionAllocation2;
                        }
                    }
                NewPositionAllocation2:
                    Debug.Log(height + " ");
                    transform.position = new Vector3(9.31f, height, 15.32f);
                }
                else
                    transform.position = InitialP;
                }
            }
            else if (-16.25 < transform.position.x && transform.position.x < -10.57)                 
            {
                if (InitialIceBlock == 0)
                    transform.position = InitialP;
                else
                {
                    float height = 3.46f;
                    if (transtarget1.position.x == -13.38f)
                    {
                        height += 2.54f;
                        transtargetfinal = transtarget1; 
                    }
                    if (transtarget2.position.x == -13.38f)
                    {
                        height += 2.54f;
                        transtargetfinal = transtarget2;
                    }
                    if (transform.position.y - height < 5)
                    {
                        if (height == 3.46f)
                        {
                            goto NewPositionAllocation0;
                        }
                        else
                        {
                            if (transform.localScale.x > transtargetfinal.localScale.x)
                            {
                                transform.position = InitialP;
                                Debug.Log("You can only place a smaller box on top of a bigger box.");
                                goto End;
                            }
                            else
                            {
                                goto NewPositionAllocation0;
                            }
                        }
                     NewPositionAllocation0:
                         Debug.Log(height + " ");
                         transform.position = new Vector3(-13.38f, height, 15.32f);
                }
                else
                    transform.position = InitialP;
                }
            }
            else
            {
                transform.position = InitialP;
                Debug.Log("Place the box on one of the three ice blocks");
            }
        End:
            Dragging = false;
            if (transform.position.x == 9.31f && transtarget1.position.x == 9.31f && transtarget2.position.x == 9.31f)
            {
                SceneManager.LoadScene(sceneName: "GameOver");
            }
        }
   
    #endregion
}




