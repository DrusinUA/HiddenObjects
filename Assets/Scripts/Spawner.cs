using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Spawner : MonoBehaviour
{
    public Object obj;

    public static Spawner instance;

   

    private void Awake()
    {
        instance = this;
    }

    public void ItemTrigger(int id, RectTransform target, GameObject highlight, GameObject particleSpawn)
    {
        GameObject temp = Instantiate(obj.GetObjectById(id), target.position, Quaternion.identity);

        temp.transform.SetParent(target, false);

        _ = Instantiate(particleSpawn, target.position, Quaternion.identity);

        LeanTween.scale(temp, temp.GetComponent<RectTransform>().localScale * 2f, 0.2f).setDelay(0f);

        LeanTween.move(temp, new Vector3(0f, 5f, 0f), 0.8f).setDelay(0.8f);

        Destroy(temp, 1.4f);

        target.gameObject.GetComponent<Button>().enabled = false;

        highlight.gameObject.GetComponent<Image>().enabled = true;
    }

}
