using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DinoFramework;

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
        get => String.IsNullOrEmpty(catSkin_Data.ID) ? "" : catSkin_Data.ID;
        set => catSkin_ID = value;
    }

    public string catEyes_ID
    {
        get => String.IsNullOrEmpty(catEyes_Data.ID)? "" : catEyes_Data.ID;
        set => catEyes_ID = value;
    }

    public string catPants_ID
    {
        get => String.IsNullOrEmpty(catPants_Data.ID)? "": catPants_Data.ID;
        set => catPants_ID = value;
    }

    public string catChest_ID
    {
        get => String.IsNullOrEmpty(catChest_Data.ID)? "": catChest_Data.ID;
        set => catChest_ID = value;
    }

    public string catHead_ID
    {
        get => String.IsNullOrEmpty(catHead_Data.ID)?"" : catHead_Data.ID;
        set => catHead_ID = value;
    }

    public string catHair_ID
    {
        get => String.IsNullOrEmpty(catHair_Data.ID)? "" : catHair_Data.ID;
        set => catHair_ID = value;
    }

    public string catTail_ID
    {
        get => String.IsNullOrEmpty(catTail_Data.ID)? "": catTail_Data.ID;
        set => catTail_ID = value;
    }

    public string catShoes_ID
    {
        get => String.IsNullOrEmpty(catShoes_Data.ID) ? "":catShoes_Data.ID;
        set => catShoes_ID = value;
    }
    
    private int _catNeeds_Data ;
    private int _catScratch_Data;
    private int _catFood_Data;

   


}
