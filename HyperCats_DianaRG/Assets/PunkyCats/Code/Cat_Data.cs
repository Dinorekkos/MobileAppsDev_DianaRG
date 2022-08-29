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


    private int _catNeeds_Data ;
    private int _catScratch_Data;
    private int _catFood_Data;

   


}
