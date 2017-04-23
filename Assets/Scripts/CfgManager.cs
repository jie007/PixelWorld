/// <summary>
/// CfgManager
/// 管理所有配置
/// </summary>
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;


public struct CfgMonster {
	public int id;
	public string name;
	public string prefab;
	public string bornSound;
	public string deathSound;
}

public struct CfgSkill {
	public int id;
	public string name;
	public string desc;
	public string animation;
	public string effect;
	public string sound;
	public int[] skilleffects;
	public string hiteffect;
	public byte targettype;		// 施法对象
	public byte aoe;			// aoe范围
	public byte aoetype;		// aoe形状 0:圆形 1:扇形
	public byte aoeangle;		// 扇形时角度
}

public enum SkillEffectTrigger {
	SKILL_EFFECT_TRIGGER_START=0,		// 播放开始时
	SKILL_EFFECT_TRIGGER_HITPOINT,		// 打击点
	SKILL_EFFECT_TRIGGER_HIT,			// 击中时
	SKILL_EFFECT_TRIGGER_END,			// 播放结束时
}

public enum SkillEffectOperation {
	SKILL_OPERATION_HP=0,			// add/reduce hp
	SKILL_OPERATION_SP,				// add/reduce sp
	SKILL_OPERATION_ADDBUFF,		// add buff
	SKILL_OPERATION_SUMMON,			// 召唤		
}

public struct CfgSkillEffect {
	public int id;
	public string name;
	public SkillEffectTrigger trigger;
	public SkillEffectOperation operation;
	public int[] args;
}

public class CfgManager {
	private static CfgManager _instance;
	public static CfgManager GetInstance() {
		if (_instance == null) _instance = new CfgManager();
		return _instance;
	}

	public void Clear() {
		_instance = null;
	}
		
	// 地图配置
	private Dictionary<int, CfgMonster> m_Monsters = new Dictionary<int, CfgMonster>();
	public Dictionary<int, CfgMonster> Monsters {get {return m_Monsters;}}


	public void Init() {

		// monster
		TextAsset asset = Resources.Load("cfg/monster") as TextAsset;
		JsonData data = JsonMapper.ToObject(asset.text);
		foreach (string key in data.Keys) {
			JsonData value = data [key];
			CfgMonster cfg = new CfgMonster();
			cfg.id = int.Parse (key);
			cfg.name = (string)value["name"];
			cfg.prefab = (string)value["prefab"];

			m_Monsters.Add(cfg.id, cfg);
		}

	}
}
