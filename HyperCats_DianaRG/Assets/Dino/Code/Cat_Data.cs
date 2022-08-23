using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DinoFramework;

[CreateAssetMenu(menuName = "DinoFramework/Data/Cat", fileName = "CatData")]
public class Cat_Data : ScriptableObject
{
    public Asset_SO catSkin;
    public Asset_SO catPants;
    public Asset_SO catChest;
    public Asset_SO catHead;
    public Asset_SO catTail;
    
}
