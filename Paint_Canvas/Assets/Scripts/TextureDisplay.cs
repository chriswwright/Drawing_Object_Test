using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;

public class TextureDisplay : MonoBehaviour
{
    public string filePath = "Assets/Textures/Concept_Sketch.png";
    public GraphicRaycaster m_Raycaster;
    public GameObject panel;
    private PointerEventData m_PointerEventData;
    public  EventSystem m_EventSystem;
    private Texture2D test_texture;
    // Start is called before the first frame update
    void Start()
    {

        byte[] fileData = File.ReadAllBytes(filePath);
        test_texture = new Texture2D(2, 2);
        test_texture.LoadImage(fileData);
        Sprite test_sprite = Sprite.Create(test_texture, new Rect(new Vector2(0, 0), new Vector2(test_texture.width, test_texture.height)), new Vector2(0, 0));
        panel.GetComponent<Image>().sprite = test_sprite;
    }

    // Update is called once per frame
    void Update()
    {
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = this.transform.localPosition;

        List<RaycastResult> results = new List<RaycastResult>();

        m_Raycaster.Raycast(m_PointerEventData, results);

        if (results.Count > 0) Debug.Log("Hit " + results[0].screenPosition);

    }
}
