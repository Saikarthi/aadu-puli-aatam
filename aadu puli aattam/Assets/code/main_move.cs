using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_move : MonoBehaviour
{
    [SerializeField]
    private GameObject[] t, g,pos;
    int goatcount = 0,turn = 1;
    [SerializeField]
    int[] completelog = {1,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
    [SerializeField]
    int[] tigerpos = { 0, 3, 4 }, goatpos = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

    int tigernum, tigercupos,tiger_is_clicked=0;
    int goatnum, goatcupos, goat_is_clicked = 0;
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
    int[] seven = { 1, 8, 13};
    int[] seven_next = { -1, 9, -1 };
    int[] eight = { 2, 7, 9,14 };
    int[] eight_next = { 0,-1,10,19 };
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
   
    // Update is called once per frame
    void Update()
    {

        //goat turn
        if (turn % 2 == 1)
        {
            if (goatcount < 15)
            {
                Enable_colider_all();

                Enable_highlight();
            }
            if (Input.GetMouseButtonDown(0) && goatcount < 15)
            {

                Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit h;
                if (Physics.Raycast(r, out h))
                {

                    if (h.transform.tag == "obj")
                    {
                        int log = Int16.Parse(h.transform.name);
                        if (completelog[log] == 0)
                        {
                            float x = h.transform.position.x;
                            float z = h.transform.position.z;
                            float y = g[0].transform.position.y;

                            completelog[log] = 2;
                            g[goatcount].transform.position = new Vector3(x, y, z);
                            goatpos[goatcount] = log;

                            goatcount += 1;
                            disable_colider_all();
                            disable_highlight();
                            turn += 1;
                        }

                    }
                }
            }//after placeing goat: goat turn
            else if(goatcount >= 15 )
            {

              
                if (Input.GetMouseButtonDown(0))
                {
                    Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit h;
                    if (Physics.Raycast(r, out h))
                    {
                        if (h.transform.tag == "goat")
                        {

                            //find goat number
                            goatnum = Int16.Parse(h.transform.name);
                            goatcupos = goatpos[goatnum];
                            move(goatcupos);
                            goat_is_clicked = 1;

                        }
                        if (goat_is_clicked == 1)
                        {
                            if (h.transform.tag == "obj")
                            {

                                int log = Int16.Parse(h.transform.name);
                                if (completelog[log] == 0)
                                {
                                    float x = h.transform.position.x;
                                    float z = h.transform.position.z;
                                    //y no change because of 2d
                                    float y = t[0].transform.position.y;
                                    goatpos[goatnum] = log;
                                    completelog[goatcupos] = 0;
                                    completelog[log] = 2;
                                    g[goatnum].transform.position = new Vector3(x, y, z);
                                    goat_is_clicked= 0;
                                    turn += 1;
                                    disable_colider_all();
                                    disable_highlight();

                                }

                            }
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
                        move(tigercupos);
                        tiger_is_clicked = 1;
                     
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
                                tigerpos[tigernum] = log;
                                completelog[tigercupos] = 0;
                                completelog[log] = 1;
                                t[tigernum].transform.position = new Vector3(x, y, z);
                                tiger_is_clicked = 0;
                                turn += 1;
                                disable_colider_all();
                            }

                        }
                    }
                }
            }
        }
    }
    public void Enable_colider_all()
    {
        for(int i=0;i<pos.Length; i++)
        {
            if(completelog[i] == 0)
            {
                pos[i].GetComponent<Collider>().enabled = true;
            }
        }
    }

    public void disable_colider_all()
    {
        for (int i = 0; i < pos.Length; i++)
        {
           
                pos[i].GetComponent<Collider>().enabled = false;
            
        }
    }
    public void Enable_colider(int r)
    {
        pos[r].GetComponent<Collider>().enabled = true;
    }
    public void disable_colider(int r)
    {
        pos[r].GetComponent<Collider>().enabled = false;
    }
    public void disable_highlight()
    {
        for (int i = 0; i < pos.Length; i++)
        {

            pos[i].GetComponentInChildren<Renderer>().enabled = false;

        }
       
    }
    public void Enable_highlight()
    {
        for (int i = 0; i < pos.Length; i++)
        {
            if (completelog[i] == 0)
            {
                pos[i].GetComponentInChildren<Renderer>().enabled = true;

            }
        }
    }
    public void move(int current)
    {
        switch (current)
        {
            case 0:
                for (int i = 0; i < zero.Length; i++)
                {
                    if (completelog[zero[i]] == 0)
                    {
                        pos[zero[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(zero[i]);
                    }
                    else if (completelog[zero[i]] == 2)
                    {
                        pos[zero_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(zero_next[i]);

                    }
                }

                break;
            case 1:
                for (int i = 0; i < one.Length; i++)
                {
                    if (completelog[one[i]] == 0)
                    {
                        pos[one[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(one[i]);
                    }
                    else if (completelog[one[i]] == 2)
                    {
                        pos[one_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(one_next[i]);

                    }
                }
                break;
            case 2:
                for (int i = 0; i < two.Length; i++)
                {
                    if (completelog[two[i]] == 0)
                    {
                        pos[two[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(two[i]);
                    }
                    else if (completelog[two[i]] == 2)
                    {
                        pos[two_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(two_next[i]);

                    }
                }
                break;
            case 3:
                for (int i = 0; i < three.Length; i++)
                {
                    if (completelog[three[i]] == 0)
                    {
                        pos[three[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(three[i]);
                    }
                    else if (completelog[three[i]] == 2)
                    {
                        pos[three_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(three_next[i]);

                    }
                }
                break;
            case 4:
                for (int i = 0; i < four.Length; i++)
                {
                    if (completelog[four[i]] == 0)
                    {
                        pos[four[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(four[i]);
                    }
                    else if (completelog[four[i]] == 2)
                    {
                        pos[four_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(four_next[i]);

                    }
                }
                break;
            case 5:
                for (int i = 0; i < five.Length; i++)
                {
                    if (completelog[five[i]] == 0)
                    {
                        pos[five[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(five[i]);
                    }
                    else if (completelog[five[i]] == 2 && five_next[i]!=-1)
                    {
                        pos[five_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(five_next[i]);

                    }
                }
                break;
            case 6:
                for (int i = 0; i < six.Length; i++)
                {
                    if (completelog[six[i]] == 0)
                    {
                        pos[six[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(six[i]);
                    }
                    else if (completelog[six[i]] == 2)
                    {
                        pos[six_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(six_next[i]);

                    }
                }
                break;
            case 7:
                for (int i = 0; i < seven.Length; i++)
                {
                    if (completelog[seven[i]] == 0)
                    {
                        pos[seven[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(seven[i]);
                    }
                    else if (completelog[seven[i]] == 2)
                    {
                        pos[seven_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(seven_next[i]);

                    }
                }
                break;
            case 8:
                for (int i = 0; i < eight.Length; i++)
                {
                    if (completelog[eight[i]] == 0)
                    {
                        pos[eight[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(eight[i]);
                    }
                    else if (completelog[eight[i]] == 2)
                    {
                        pos[eight_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(eight_next[i]);

                    }
                }
                break;
            case 9:
                for (int i = 0; i < nine.Length; i++)
                {
                    if (completelog[nine[i]] == 0)
                    {
                        pos[nine[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(nine[i]);
                    }
                    else if (completelog[nine[i]] == 2)
                    {
                        pos[nine_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(nine_next[i]);

                    }
                }
                break;
            case 10:
                for (int i = 0; i < ten.Length; i++)
                {
                    if (completelog[ten[i]] == 0)
                    {
                        pos[ten[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(ten[i]);
                    }
                    else if (completelog[ten[i]] == 2)
                    {
                        pos[ten_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(ten_next[i]);

                    }
                }
                break;
            case 11:
                for (int i = 0; i < Eleven.Length; i++)
                {
                    if (completelog[Eleven[i]] == 0)
                    {
                        pos[Eleven[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Eleven[i]);
                    }
                    else if (completelog[Eleven[i]] == 2)
                    {
                        pos[Eleven_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Eleven_next[i]);

                    }
                }
                break;
            case 12:
                for (int i = 0; i < Twelve.Length; i++)
                {
                    if (completelog[Twelve[i]] == 0)
                    {
                        pos[Twelve[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Twelve[i]);
                    }
                    else if (completelog[Twelve[i]] == 2)
                    {
                        pos[Twelve_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Twelve_next[i]);

                    }
                }
                break;
            case 13:
                for (int i = 0; i < Thirteen.Length; i++)
                {
                    if (completelog[Thirteen[i]] == 0)
                    {
                        pos[Thirteen[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Thirteen[i]);
                    }
                    else if (completelog[Thirteen[i]] == 2)
                    {
                        pos[Thirteen_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Thirteen_next[i]);

                    }
                }
                break;
            case 14:
                for (int i = 0; i < Fourteen.Length; i++)
                {
                    if (completelog[Fourteen[i]] == 0)
                    {
                        pos[Fourteen[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Fourteen[i]);
                    }
                    else if (completelog[Fourteen[i]] == 2)
                    {
                        pos[Fourteen_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Fourteen_next[i]);

                    }
                }
                break;
            case 15:
                for (int i = 0; i < Fifteen.Length; i++)
                {
                    if (completelog[Fifteen[i]] == 0)
                    {
                        pos[Fifteen[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Fifteen[i]);
                    }
                    else if (completelog[Fifteen[i]] == 2)
                    {
                        pos[Fifteen_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Fifteen_next[i]);

                    }
                }
                break;
            case 16:
                for (int i = 0; i < Sixteen.Length; i++)
                {
                    if (completelog[Sixteen[i]] == 0)
                    {
                        pos[Sixteen[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Sixteen[i]);
                    }
                    else if (completelog[Sixteen[i]] == 2)
                    {
                        pos[Sixteen_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Sixteen_next[i]);

                    }
                }
                break;
            case 17:
                for (int i = 0; i < Seventeen.Length; i++)
                {
                    if (completelog[Seventeen[i]] == 0)
                    {
                        pos[Seventeen[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Seventeen[i]);
                    }
                    else if (completelog[Seventeen[i]] == 2)
                    {
                        pos[Seventeen_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Seventeen_next[i]);

                    }
                }
                break;
            case 18:
                for (int i = 0; i < Eighteen.Length; i++)
                {
                    if (completelog[Eighteen[i]] == 0)
                    {
                        pos[Eighteen[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Eighteen[i]);
                    }
                    else if (completelog[Eighteen[i]] == 2)
                    {
                        pos[Eighteen_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Eighteen_next[i]);

                    }
                }
                break;
            case 19:
                for (int i = 0; i < Nineteen.Length; i++)
                {
                    if (completelog[Nineteen[i]] == 0)
                    {
                        pos[Nineteen[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Nineteen[i]);
                    }
                    else if (completelog[Nineteen[i]] == 2)
                    {
                        pos[Nineteen_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Nineteen_next[i]);

                    }
                }
                break;
            case 20:
                for (int i = 0; i < Twenty.Length; i++)
                {
                    if (completelog[Twenty[i]] == 0)
                    {
                        pos[Twenty[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Twenty[i]);
                    }
                    else if (completelog[Twenty[i]] == 2)
                    {
                        pos[Twenty_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Twenty_next[i]);

                    }
                }
                break;
            case 21:
                for (int i = 0; i < Twenty_one.Length; i++)
                {
                    if (completelog[Twenty_one[i]] == 0)
                    {
                        pos[Twenty_one[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Twenty_one[i]);
                    }
                    else if (completelog[Twenty_one[i]] == 2)
                    {
                        pos[Twenty_one_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Twenty_one_next[i]);

                    }
                }
                break;
            case 22:
                for (int i = 0; i < Twenty_two.Length; i++)
                {
                    if (completelog[Twenty_two[i]] == 0)
                    {
                        pos[Twenty_two[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Twenty_two[i]);
                    }
                    else if (completelog[Twenty_two[i]] == 2)
                    {
                        pos[Twenty_two_next[i]].GetComponentInChildren<Renderer>().enabled = true;
                        Enable_colider(Twenty_two_next[i]);

                    }
                }
                break;
        }
    }
}
