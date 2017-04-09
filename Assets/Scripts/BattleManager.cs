using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour {

	private static BattleManager instance;
	public static BattleManager GetInstance() {
		GameObject main = GameObject.Find("Main");
		if (main == null) {
			main = new GameObject("Main");
			DontDestroyOnLoad(main);
		}
	
		if (instance == null) {
			instance = main.AddComponent<BattleManager>();
		}
		return instance;
	}

	public object[] CallMethod(string func, params object[] args) {
		return Util.CallMethod("battle", func, args);
	}

	public void PlayerEnterNpc(int id, int attackid){
		CallMethod("player_enter_npc", id, attackid);
	}

	public void PlayerHit(int id, int attackid){
		CallMethod("player_hit", id, attackid);
	}

	public void EnemyHit(int id, int attackid){
		CallMethod("enemy_hit", id, attackid);
	}

	public void PlayerBreak(int id, Vector3 pos){
		CallMethod("player_break", id, pos);
	}

	public void PlayerTakeItem(int id, int attackid){
		CallMethod("player_take_item", id, attackid);
	}

	public Monster SpawnEnemy(int id, Vector3 pos, Quaternion rot){
		Monster monster = CharacterManager.GetInstance ().AddEnemy (id, pos, rot);
		CallMethod("enemy_spawn", monster);
		return monster;
	}
}