using System;
using Lain;
using Lain.Geometry;
using Lain.Utils;
using Microsoft.Xna.Framework;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.Objects;
using SadConsole;

namespace RnR.Systems.D20
{
	// XXX: Put here delegation instead of inheritance?
	public class GameCharacter : IGameActor, Positionable, Drawable
	{
		protected IGameActor innerActor;
		Point2D position;
		Color color;

		public GameCharacter (string name, GameActor gameActor)
		{
			Name = name;
			innerActor = gameActor;
			color = MaterialColors.RandomMaterialColor ();
		}

		public string Name { get; private set; }

		public AbstractArmor EquipedArmor {
			get {
				return innerActor.EquipedArmor;
			}

			set {
				innerActor.EquipedArmor = value;
			}
		}

		public AbstractEarring EquipedEarring {
			get {
				return innerActor.EquipedEarring;
			}

			set {
				innerActor.EquipedEarring = value;
			}
		}

		public AbstractNecklace EquipedNecklace {
			get {
				return innerActor.EquipedNecklace;
			}

			set {
				innerActor.EquipedNecklace = value;
			}
		}

		public AbstractRing EquipedRing {
			get {
				return innerActor.EquipedRing;
			}

			set {
				innerActor.EquipedRing = value;
			}
		}

		public AbstractWeapon EquipedWeapon {
			get {
				return innerActor.EquipedWeapon;
			}

			set {
				innerActor.EquipedWeapon = value;
			}
		}

		public int HitPoints {
			get {
				return innerActor.HitPoints;
			}

			set {
				innerActor.HitPoints = value;
			}
		}

		public int MaxHunger {
			get {
				return innerActor.MaxHunger;
			}
		}

		public int Hunger {
			get {
				return innerActor.Hunger;
			}

			set {
				innerActor.Hunger = value;
			}
		}

		public int MaxHitPoints {
			get {
				return innerActor.MaxHitPoints;
			}
		}

		public int Money {
			get {
				return innerActor.Money;
			}

			set {
				innerActor.Money = value;
			}
		}

		public bool IsDead {
			get {
				return innerActor.IsDead;
			}
		}

		public int CA {
			get {
				return innerActor.CA;
			}
		}

		public Point2D Position {
			get {
				return position;
			}

			set {
				position = value;
			}
		}

		public bool CanParticipate (Challenger challenger)
		{
			return innerActor.CanParticipate (challenger);
		}

		public Base.Actors.Attribute CHA ()
		{
			return innerActor.CHA ();
		}

		public Base.Actors.Attribute CON ()
		{
			return innerActor.CON ();
		}

		public void ContestFinished (Challenger challenger, bool challengerWon)
		{
			innerActor.ContestFinished (challenger, challengerWon);
		}

		public Base.Actors.Attribute DEX ()
		{
			return innerActor.DEX ();
		}

		public GameActor Equip (EquipableObject obj)
		{
			return this.Equip (obj);  // CHECK
		}

		public int GetChallengeRate ()
		{
			return innerActor.GetChallengeRate ();
		}

		public SkillType GetSkillType ()
		{
			return innerActor.GetSkillType ();
		}

		public Skill GetSkill (SkillType type)
		{
			return innerActor.GetSkill (type);
		}

		public Base.Actors.Attribute INT ()
		{
			return innerActor.INT ();
		}

		public Base.Actors.Attribute STR ()
		{
			return innerActor.STR ();
		}

		public Base.Actors.Attribute WIS ()
		{
			return innerActor.WIS ();
		}

		IGameActor IGameActor.Equip (EquipableObject obj)
		{
			return obj.OnEquip (this);
		}

		public void AddEffect (GameActorDecorator effect)
		{
			effect.Target = innerActor;
			innerActor = effect;

		}

		public void RemoveEffect (GameActorDecorator effect)
		{
			GameActorDecorator.Remove (innerActor, effect);
		}

		public CellAppearance Appearance (bool inFov)
		{
			return new CellAppearance (color, Color.Transparent, Name [0]);
		}
	}
}
