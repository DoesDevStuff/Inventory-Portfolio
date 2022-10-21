using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;


public class SpriteAtlasScript : MonoBehaviour
{
    [SerializeField] private SpriteAtlas _mainAtlas;
    [SerializeField] private string _individualSprite_name;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = _mainAtlas.GetSprite(_individualSprite_name);
        GetComponent<Image>().preserveAspect = true;
    }
}
