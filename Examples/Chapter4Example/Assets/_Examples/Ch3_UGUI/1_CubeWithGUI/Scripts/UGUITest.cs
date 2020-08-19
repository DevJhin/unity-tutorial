using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// UGUI 컴포넌트를 사용해서 Cube 오브젝트를 컨트롤 하는 Class.
/// </summary>
public class UGUITest : MonoBehaviour
{
    private float rotSpeed = 90;
    
    private MeshRenderer meshRenderer;

    private static Color[] ColorPresets = new Color[4]
    {
        Color.white, Color.red,Color.green, Color.blue
    };
    
    // Start is called before the first frame update
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    
    void Update()
    {
        transform.Rotate(Vector3.up, rotSpeed*Time.deltaTime);
    }

    /// <summary>
    /// Slider의 값에 따라서 Cube의 회전 속도를 변경합니다.
    /// </summary>
    /// <param name="value"></param>
    public void OnSliderValueChange(float value)
    {
        rotSpeed = value;
    }

    /// <summary>
    /// 선택한 Dropdown 메뉴의 index에 따라서 Cube의 색을 설정합니다.
    /// </summary>
    /// <param name="index"></param>
    public void OnDropdownValueChange(int index)
    {
        meshRenderer.material.color= ColorPresets[index];
    }
}
