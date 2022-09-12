using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
public class MemoryManager : MonoBehaviour
{
    public SaveManager saveManager;
    
    // Start is called before the first frame update
    void Start()
    {

        saveManager = gameObject.GetComponent<SaveManager>();
        
        
        print(Application.streamingAssetsPath);
        string path = Application.streamingAssetsPath + "/SaveCats.json";
        print(path);

        //CatObject catObject = new CatObject("Garfield", 15, false, "Me cagan los lunes");
        string assetReference = JsonHelper.ToJson(saveManager.assetReferenceManager._assetReferenceData.AllAssets, true);
        print(assetReference);

        File.WriteAllText(path, assetReference);

        /*string json = File.ReadAllText(path);

        CatObject catObject = JsonUtility.FromJson<CatObject>(json);

        print(catObject.description);*/

        // CatObject[] catObjects; /*= new CatObject[2];*/

        /*catObjects[0] = new CatObject("Garfield", 15, false, "Me cagan los lunes");
        catObjects[1] = new CatObject("Scratchy", 4, true, "Muere!!!!!!");

        string json = JsonHelper.ToJson(catObjects, true);*/

        //print(json);

        //File.WriteAllText(path, json);

        string json = File.ReadAllText(path);

        // catObjects = JsonHelper.FromJson<CatObject>(json);

        // print (catObjects[1].name);



    }

  
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}


