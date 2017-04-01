using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace AISystem
{
	public class Wander : Action 
	{
		public SharedVector3 target;

		private Monster _owner;
		private Animator animator;
       		private NavMeshAgent agent;

       		private System.Random random;

		public override void OnAwake ()
		{
			_owner = gameObject.GetComponent<Monster>();
			random = new System.Random();
			target.Value = transform.position;
		}

		public override void OnStart()
	    	{
			animator = GetComponent<Animator>();
			agent = GetComponent<NavMeshAgent>();
	   	}
		
		public override TaskStatus OnUpdate ()
		{
			if(_owner.HP <= 0) {
				return TaskStatus.Failure;
			}

			Vector3 offset = target.Value - transform.position;
	           	offset.y = 0;

			if (offset.magnitude > 1) {
				animator.SetBool("bMoving", true);

				if (agent.isOnNavMesh) {
					transform.forward = offset.normalized;
					bool moveable = agent.SetDestination(target.Value);
					if (moveable == false) {
						target.Value = transform.position;
					}
				}
			} else {

				if (agent.isOnNavMesh) {
					agent.ResetPath();
				}
				animator.SetBool("bMoving", false);
				float randomValue = (float)random.NextDouble();
				if (randomValue < 0.2f) {
					target.Value = _owner.BornPosition + new Vector3(random.Next(-2, 2), 0, random.Next(-2, 2));
				}

				return TaskStatus.Failure;

			}
		
			return TaskStatus.Success;
		}
	}
}
