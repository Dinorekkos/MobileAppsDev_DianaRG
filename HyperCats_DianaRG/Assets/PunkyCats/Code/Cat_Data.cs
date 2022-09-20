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
        get => catSkin_Data.ID;
        set => catSkin_ID = value;
    }

    public string catEyes_ID
    {
        get => catEyes_Data.ID;
        set => catEyes_ID = value;
    }

    public string catPants_ID
    {
        get => catPants_Data.ID;
        set => catPants_ID = value;
    }

    public string catChest_ID
    {
        get => catChest_Data.ID;
        set => catChest_ID = value;
    }

    public string catHead_ID
    {
        get => catHead_Data.ID;
        set => catHead_ID = value;
    }

    public string catHair_ID
    {
        get => catHair_Data.ID;
        set => catHair_ID = value;
    }

    public string catTail_ID
    {
        get => catTail_Data.ID;
        set => catTail_ID = value;
    }

    public string catShoes_ID
    {
        get => catShoes_Data.ID;
        set => catShoes_ID = value;
    }
    
    private int _catNeeds_Data ;
    private int _catScratch_Data;
    private int _catFood_Data;

   


}
