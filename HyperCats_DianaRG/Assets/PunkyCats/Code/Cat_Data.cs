using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DinoFramework;
using Unity.VisualScripting;

[CreateAssetMenu(menuName = "DinoFramework/Data/Cat", fileName = "CatData")]
public class Cat_Data : ScriptableObject
{
    public Asset_SO catSkin_Data;
    public Asset_SO catEyes_Data;
    public Asset_SO catPants_Data;
    public Asset_SO catChest_Data;
    public Asset_SO catHead_Data;
    public Asset_SO catHair_Data;
    public Asset_SO catTail_Data;
    public Asset_SO catShoes_Data;
    


    public string catSkin_ID
    {
        get
        {
            if (catSkin_Data == null)
            {
                return "";
            }
            return catSkin_Data.ID;
        }
        set => catSkin_ID = value;
    }

    public string catEyes_ID
    {
        get
        {
            if (catEyes_Data==null)
            {
             return   "";
            }

            return catEyes_Data.ID;
        }

        set => catEyes_ID = value;
    }

    public string catPants_ID
    {
        get
        {
            if (catPants_Data==null)
            {
                return "";
            }

            return catPants_Data.ID;
        }
        set => catPants_ID = value;
    }

    public string catChest_ID
    {
        get
        {
            if(catChest_Data == null)
            {
                return "";
            }
            return catChest_Data.ID;
        }
        set => catChest_ID = value;
    }

    public string catHead_ID
    {
        get
        {
            if (catHead_Data == null)
            {
                return "";
            }
            return catHead_Data.ID;
        }   
        
        set => catHead_ID = value;
    }

    public string catHair_ID
    {
        get
        {
            if (catHair_Data == null)
            {
                return "";
            }
            return catHair_Data.ID;
        }
        
        set => catHair_ID = value;
    }

    public string catTail_ID
    {
        get
        {
            if (catTail_Data == null)
            {
                return "";
            }
            return catTail_Data.ID;
        }
        set => catTail_ID = value;
    }

    public string catShoes_ID
    {
        get{
            if (catShoes_Data == null)
            {
                return "";
            }
            return catShoes_Data.ID;
        }
        set => catShoes_ID = value;
    }
    
    private int _catNeeds_Data ;
    private int _catScratch_Data;
    private int _catFood_Data;

   


}
