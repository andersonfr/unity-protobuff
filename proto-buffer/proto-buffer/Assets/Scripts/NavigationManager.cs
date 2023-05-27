using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager
{
    private Canvas MainCanvas { get; set; }
    
    public NavigationManager(Canvas canvas) {
        this.MainCanvas = canvas;
    }


    public T CreateModal<T>(string path) where T : Component
    {
        var prefab = Resources.Load<T>(path);
        T modal = null;
        if(prefab != null)
        {
            modal = GameObject.Instantiate(prefab.gameObject, MainCanvas.transform).GetComponent<T>();
        }

        return modal;
    }
}
