using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public SnapLayoutElement ElementPrefab;
    public SnapLayout layout;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            layout.AddElement(ElementPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
