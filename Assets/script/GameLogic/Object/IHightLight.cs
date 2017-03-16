using UnityEngine;
using System.Collections;
using HighlightingSystem;

/// <summary>
/// 用来实现高亮效果接口
/// </summary>
public interface IHightLight
{
    Highlighter Light { get; }
   
    void HightLight(Color color);
    
}
