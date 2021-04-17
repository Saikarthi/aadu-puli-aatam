using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_move : MonoBehaviour
{
    [SerializeField]
    private GameObject[] t, g;
    int goatnum = 0,turn = 1;
    int[] completelog = {1,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
    int[] tigerpos = { 1, 4, 5 }, goatpos = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

    int tigernum, tigercupos,tiger_is_clicked=0;
    //to move coin
    int[] zero = { 2, 3, 4, 5};
    int[] zero_next = {8, 9, 10, 11};
    int[] one = {2,7};
    int[] one_next = {3,13};
    int[] two = {0,1,3,8};
    int[] two_next = {-1,-1,4,14};
    int[] three = { 0,2,4,9};
    int[] three_next = { -1,1,5,15};
    int[] four = {0,3,5,10};
    int[] four_next = {-1,2,6,16};
    int[] five = { 0, 4, 6, 11 };
    int[] five_next = {-1,3,-1,17};
    int[] six = {5,12};
    int[] six_next = { 4, 18 };
    int[] seven = { 1, 8, 1};
    int[] seven_next = { -1, 9, -1 };
    int[] nine = { 3,8,10,15};
    int[] nine_next = { 0, 7, 11, 20 };
    int[] ten = {4,9,11,16};
    int[] ten_next = { 0, 8, 12, 21 };
    int[] Eleven = { 5,10,12,17};
    int[] Eleven_next = { 0, 9, -1, 22 };
    int[] Twelve = { 6,11,18 };
    int[] Twelve_next = { -1, 10, -1, };
    int[] Thirteen = {7,14};
    int[] Thirteen_next = {1,15};
    int[] Fourteen = { 8,13,15,19};
    int[] Fourteen_next = { 2,-1, 16, -1 };
    int[] Fifteen = { 9,14,16,20};
    int[] Fifteen_next = { 3,13,17,-1};
    int[] Sixteen = {10,15,17,21};
    int[] Sixteen_next = {4,14,18,-1};
    int[] Seventeen = {11,16,18,22};
    int[] Seventeen_next = { 5,15,-1,-1};
    int[] Eighteen = { 12,17 };
    int[] Eighteen_next = { 6,16 };
    int[] Nineteen = { 14,20 };
    int[] Nineteen_next = { 8, 21 };
    int[] Twenty = { 15,19,21};
    int[] Twenty_next = {9,-1,22};
    int[] Twenty_one = { 16,20,22};
    int[] Twenty_one_next = { 10,19,-1};
    int[] Twenty_two = { 17,21};
    int[] Twenty_two_next = {11,20};


    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void move(int r)
    {
        switch (r)
        {

            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //goat turn
        if (turn % 2 == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit h;
                if (Physics.Raycast(r, out h))
                {
                    Debug.Log(h.transform.name);

                    if (h.transform.tag == "obj")
                    {
                        int log = Int16.Parse(h.transform.name);
                        if (completelog[log] == 0)
                        {
                            float x = h.transform.position.x;
                            float z = h.transform.position.z;
                            float y = g[0].transform.position.y;

                            completelog[log] = 2;
                            g[goatnum].transform.position = new Vector3(x, y, z);
                            goatpos[goatnum] = log;
                          
                            goatnum += 1;
                            turn += 1;
                        }

                    }
                }
            }
        }
        //tiger turn
        if (turn % 2 == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit h;
                if (Physics.Raycast(r, out h))
                {
                    
                    if(h.transform.tag =="tiger")
                    {
                        //find tiger number
                        tigernum = Int16.Parse(h.transform.name);
                        //find tiger cur pos
                        tigercupos = tigerpos[tigernum];
                        tiger_is_clicked = 1;
                        Debug.Log(tigernum);
                    }
                    if (tiger_is_clicked == 1)
                    {
                        if (h.transform.tag == "obj")
                        {
                            int log = Int16.Parse(h.transform.name);
                            if (completelog[log] == 0)
                            {
                                float x = h.transform.position.x;
                                float z = h.transform.position.z;
                                float y = t[0].transform.position.y;

                                completelog[log] = 2;
                                t[tigernum].transform.position = new Vector3(x, y, z);
                                tiger_is_clicked = 0;
                                turn += 1;

                            }

                        }
                    }
                }
            }
        }
    }
}
