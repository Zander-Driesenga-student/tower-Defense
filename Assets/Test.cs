using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public DynamicArray<int> dynamicArray;
    public DynamicArray<string> words = new DynamicArray<string>();
    // Start is called before the first frame update
    void Start()
    {
        dynamicArray = new DynamicArray<int>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            dynamicArray.Add(Random.Range(0, 1));
            words.Add("Hello");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            dynamicArray.Add(Random.Range(0, 1));
            words.Add("Hello");
        }
    }
}
