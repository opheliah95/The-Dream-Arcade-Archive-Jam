﻿using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

using UnityConstants;

public class CaseProgress
{
    /// Array of set of unlocked scene enums, index by SceneType enum as integer
    private readonly HashSet<ScenesEnum>[] m_UnlockedSceneEnumsSetBySceneType = {new HashSet<ScenesEnum>(), new HashSet<ScenesEnum>()};
    
    /// Set of found clues
    private HashSet<string> m_FoundClues = new HashSet<string>();
    
    public bool HasUnlockedScene(CaseSceneType sceneType, ScenesEnum sceneEnum)
    {
        return m_UnlockedSceneEnumsSetBySceneType[(int) sceneType].Contains(sceneEnum);
    }
    
    public void UnlockScene(CaseSceneType sceneType, ScenesEnum sceneEnum)
    {
        m_UnlockedSceneEnumsSetBySceneType[(int) sceneType].Add(sceneEnum);
        Debug.LogFormat("Unlock scene: type {0}, enum {1}", sceneType, sceneEnum);
    }
    
    public bool HasFoundClue(string clueStringID)
    {
        return m_FoundClues.Contains(clueStringID);
    }
    
    public void FindClue(string clueStringID)
    {
        m_FoundClues.Add(clueStringID);
        Debug.LogFormat("Found clue: {0}", clueStringID);
    }
}
