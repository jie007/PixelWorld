using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;

public class Monster : Character {

	public Vector3 BornPosition {get;set;}

	CharacterController characterController;
	BehaviorTree tree;
	NavMeshAgent agent;

	protected override void Awake() {
		base.Awake();

		characterController = GetComponent<CharacterController>();
		tree = GetComponent<BehaviorTree>();
		agent = GetComponent<NavMeshAgent>();
		//agent.enabled = false;
	}

	protected override void Start() {
		base.Start();

		BornPosition = transform.position;
		//agent.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void ActDie() {
		base.ActDie();

		characterController.enabled = false;
		tree.enabled = false;
		agent.Stop();
	}

	void OnTriggerEnter(Collider collider)   { 
		string tag = collider.gameObject.tag;
		Debug.Log("Enemy.OnTriggerEnter " + tag);  
		if (tag == "PlayerWeapon") {
			Player player = collider.transform.parent.GetComponent<Player>();
			Debug.Log("player " + player.ID);
			ActHit();
			Vector3 offset = transform.position - player.transform.position;
			offset.y = 0;
			StartCoroutine(HitBack (offset.normalized));
			BattleManager.GetInstance ().EnemyHit (ID, player.ID);
		} else if (tag == "PlayerMissile") {
			Missile missile = collider.transform.GetComponent<Missile>();
			Debug.Log("missile " + missile.ID);
			ActHit();
			BattleManager.GetInstance ().EnemyHit (ID, missile.ID);
		}
	}
	void OnTriggerExit(Collider collider)  {  
		//Debug.Log("OnTriggerExit");  
	}  
}
