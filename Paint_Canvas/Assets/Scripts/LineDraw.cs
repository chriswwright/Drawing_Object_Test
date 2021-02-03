using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    public Camera draw_camera;
    public float line_width = 1f;
    public Material line_material;
    public GameObject prefab;
    public List<Vector3> line_points = new List<Vector3>();
    private Vector3 line_start_point;
    public List<GameObject> line_displays = new List<GameObject>();

    public bool isMouseDown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject line_display = Instantiate(prefab);
            //LineRenderer line = line_display.AddComponent<LineRenderer>();
            line_display.GetComponent<LineRenderer>().widthMultiplier = line_width;
            line_displays.Add(line_display);
            isMouseDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            line_displays[line_displays.Count - 1].AddComponent<MeshFilter>();
            line_displays[line_displays.Count - 1].GetComponent<LineRenderer>().BakeMesh(line_displays[line_displays.Count - 1].GetComponent<MeshFilter>().mesh, true);
            line_points = new List<Vector3>();
            isMouseDown = false;
            
        }
        if (isMouseDown)
        {
            
            line_points.Add(GetMouseCameraPoint());
            Debug.Log("line_displays: " + line_displays.Count);
            line_displays[line_displays.Count-1].GetComponent<LineRenderer>().positionCount = line_points.Count;
            line_displays[line_displays.Count - 1].GetComponent<LineRenderer>().SetPosition(line_points.Count - 1, line_points[line_points.Count - 1]);

        }
    }

    private Vector3 GetMouseCameraPoint()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        return draw_camera.ScreenToWorldPoint(mousePos); 
    }
}
