using UnityEngine;
using System.Collections;

/// <summary>
/// Buff.
/// buff实体（单体or群体）
/// </summary>
public class Buff
{
	private int id;

	CfgBuff cfg;

	private float timer;

	private Character owner;
	private GameObject effect;
	private bool isDead = false;

	public void SetOwner(Character actor) {
		owner = actor;
	}
	public bool IsDead() {
		return isDead;	
	}

	public static Buff CreateBuff(int id) {
		if (CfgManager.GetInstance().Buffs.ContainsKey(id)) {
			return new Buff(id);
		}
		return null;
	}

	public Buff(int id) {
		if (CfgManager.GetInstance().Buffs.ContainsKey(id) == false) {
			Debug.LogErrorFormat("buff cfg not found: {0}", id);
			return;
		}

		cfg = CfgManager.GetInstance().Buffs[id];
		this.id = cfg.id;
		
	}


	public void Start() {
		if (cfg.prefab != null && cfg.prefab.Length > 0) {
			owner.AttackEffect(cfg.prefab, cfg.life, Vector3.zero);
		}
	}

	public void Update () {

		timer += Time.deltaTime;
		if (timer > cfg.life) {
			End();
		}

	}


	// 攻击
	void OnAttack(Character actor) {
	}

	// 攻击结束
	void OnAttackEnd(Character actor) {
	}

	void End() {
		Debug.Log("End");
		isDead = true;
		if (effect != null) {
			GameObject.Destroy(effect);
		}
	}
}