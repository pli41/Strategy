using UnityEngine;
using System.Collections;

public class MinionSystem : MonoBehaviour {




	public enum minionType{INFANTRY, ARCHER, CAVALRY};
	public minionType type;
	public Minion minion;

	public void init(){
		switch(type){
			case minionType.INFANTRY:
				minion = new Infantry();
				break;
			case minionType.ARCHER:
				minion = new Archer();
				break;
			case minionType.CAVALRY:
				minion = new Cavalry();
				break;
		}
	}

	public class Minion{
		public float hp;
		public float speed;
		public float damage;
		public float range;
		public float atkSpd;

		public Minion(){

		}

		public Minion(float hp, float speed, float damage, float range, float atkSpd){
			this.hp = hp;
			this.speed = speed;
			this.damage = damage;
			this.range = range;
			this.atkSpd = atkSpd;
		}
	}

	public class Infantry : Minion{

		public static readonly float _hp = 120f;
		public static readonly float _speed = 0.8f;
		public static readonly float _damage = 10f;
		public static readonly float _range = 0.5f;
		public static readonly float _atkSpd = 1f;

		public Infantry() : base(_hp, _speed, _damage, _range, _atkSpd){

		}
	}

	public class Archer : Minion{
		public static readonly float _hp = 80f;
		public static readonly float _speed = 0.5f;
		public static readonly float _damage = 20f;
		public static readonly float _range = 5f;
		public static readonly float _atkSpd = 3f;
		
		public Archer() : base(_hp, _speed, _damage, _range, _atkSpd){
			
		}
	}

	public class Cavalry : Minion{
		public static readonly float _hp = 200f;
		public static readonly float _speed = 2f;
		public static readonly float _damage = 15f;
		public static readonly float _range = 1f;
		public static readonly float _atkSpd = 2f;
		
		public Cavalry() : base(_hp, _speed, _damage, _range, _atkSpd){
			
		}
	}

}
