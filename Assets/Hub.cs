using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hub : MonoBehaviour
{
    [Header("공통 파트")]

    static PlayerStatus _PlayerStatus;
    static UIManager _UIManager;
    static SoundManager _SoundManager;
    static GameManager _GameManager;
    static StageManager _StageManager;
    static InputManager _InputManager;
    static SkillManager _SkillManager;

    public static PlayerStatus PlayerStatus { get { if (_PlayerStatus == null) _PlayerStatus = FindObjectOfType<PlayerStatus>(); return _PlayerStatus; } }
    public static UIManager UIManager { get { if (_UIManager == null) _UIManager = FindObjectOfType<UIManager>(); return _UIManager; } }
    public static SoundManager SoundManager { get { if (_SoundManager == null) _SoundManager = FindObjectOfType<SoundManager>(); return _SoundManager; } }
    public static GameManager GameManager { get { if (_GameManager == null) _GameManager = FindObjectOfType<GameManager>(); return _GameManager; } }
    public static StageManager StageManager { get { if (_StageManager == null) _StageManager = FindObjectOfType<StageManager>(); return _StageManager; } }
    public static InputManager InputManager { get { if (_InputManager == null) _InputManager = FindObjectOfType<InputManager>(); return _InputManager; } }
    public static SkillManager SkillManager { get { if (_SkillManager == null) _SkillManager = FindObjectOfType<SkillManager>(); return _SkillManager; } }

    [Header("황준 파트")]

    static PlayerController _PlayerController;
    public static PlayerController PlayerController { get { if (_PlayerController == null) _PlayerController = FindObjectOfType<PlayerController>(); return _PlayerController; } }



}
