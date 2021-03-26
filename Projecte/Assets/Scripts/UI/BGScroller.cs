using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {
    public Renderer background;
    public float scrollSpeed;
    
    void Update() {
        background.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0f);
    }
    
}
