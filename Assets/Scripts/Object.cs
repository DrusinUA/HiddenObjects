using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Object", menuName = "Object")]

public class Object : ScriptableObject
{
    public string objectName;

    public List<GameObject> ObjectList;

    public GameObject GetObjectById(int id)
    {

        return ObjectList[id];
    }

}
