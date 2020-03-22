using UnityEngine;
using System.Collections;

public class ObjectTrigger : MonoBehaviour
{
    [SerializeField]
    private int Id;

    public GameObject highlight;

    public GameObject particleSpawn;

    public void SetObject()
    {
        Spawner.instance.ItemTrigger(Id, transform as RectTransform, highlight, particleSpawn);

    }

   
}
