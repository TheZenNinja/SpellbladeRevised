using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpellbladeRevised.Buffs;
using System.Collections.Generic;

namespace SpellbladeRevised.Minions
{
	public abstract class SpelldaggerMinionBase : MinionBase
	{
		public virtual int size { get; } = 32;
		public virtual float scale { get; } = 1;
		protected virtual float minionCapacity { get; } = 1;
		public override string GlowTexture => base.GlowTexture;
		protected virtual int buff => mod.BuffType(GetBuffID());
		protected string GetBuffID() => GetType().Name.Replace("Minion", "Buff");
		public override string Texture => GetIDString();
		protected bool foundTarget;
		public string GetIDString()
		{
			Type t = GetType();
			string path = t.ToString();
			path = path.Replace(".", "/");
			path = path.Replace("Minion", "Dagger");
			return path;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault(GetType().Name);

			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = size;
			projectile.height = size;
			projectile.scale = scale;
			// Makes the minion go through tiles freely
			projectile.tileCollide = false;
			// These below are needed for a minion weapon
			// Only controls if it deals damage to enemies on contact (more on that later)
			projectile.friendly = true;
			// Only determines the damage type
			projectile.netImportant = true;
			projectile.minionSlots = minionCapacity;
			projectile.minion = true;
			projectile.magic = true;
			projectile.timeLeft = 60;
			// Amount of slots this minion occupies from the total minion slots available to the player (more on that later)
			// Needed so the minion doesn't despawn on collision with enemies or tiles
			projectile.penetrate = -1;
		}
		// Here you can decide if your minion breaks things like grass or pots
		public override bool? CanCutTiles() => false;

		// This is mandatory if your minion deals contact damage (further related stuff in AI() in the Movement region)
		public override bool MinionContactDamage() => true;
        public override void CheckActive()
        {
			Player player = Main.player[projectile.owner];
			// This is the "active check", makes sure the minion is alive while the player is alive, and despawns if not
			if (player.dead || !player.active)
			{
				player.ClearBuff(buff);
			}
			if (player.HasBuff(buff))
				projectile.timeLeft = 2;

			Main.NewText("Buff: ");
			Main.NewText($"{GetBuffID()}, {buff}");

		}
        public override void AI()
        {
			CheckActive();
			IdleBehavior();
        }
        public override void Behavior()
        {
			IdleBehavior();
        }
        public override void Kill(int timeLeft)
        {
			Main.NewText("Kill");
        }
        protected float maxAngle = 270;
		protected float angleOffset = -90;
		protected float distance = 64;
		public override void IdleBehavior()
		{
			Player player = Main.player[projectile.owner];
			var sp = player.GetModPlayer<SpellbladePlayer>();
			List<Projectile> m = GetAllMinions();
			//List<ModProjectile> m = sp.GetMinionsOfType(projectile.identity);
			int thisIndex = m.IndexOf(projectile);
			//for (var i = 0; i < m.Count; i++)
			{
				//Main.NewText("--");
                //foreach (var i in SpellbladeMod.spelldaggerMinionIDs)
				//	Main.NewText($"{i}: {ModContent.GetModProjectile(i).Name}");
				//Main.NewText("--");
				Main.NewText("Player (p): " + projectile.owner);
				Main.NewText($"Proj who: {projectile.whoAmI}");
				float angle = thisIndex * (maxAngle / m.Count) + angleOffset;
				angle = MathHelper.ToRadians(angle);
				Vector2 pos = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * distance;
				projectile.position = player.headPosition + pos;
			}
			SetIdleRotation();
		}
		public List<Projectile> GetAllMinions()
		{
			var otherMinions = new List<Projectile>();
			for (int i = 0; i < Main.maxProjectiles; i++)
			{
				// Fix overlap with other minions
				Projectile other = Main.projectile[i];
				if (other.active && other.owner == projectile.owner && SpellbladeRevised.spelldaggerMinionIDs.Contains(other.type))
					otherMinions.Add(other);
			}
			//otherMinions.Sort((x, y) => x.minionPos - y.minionPos);
			return otherMinions;
		}
		
		public List<Projectile> GetOtherMinions()
		{
			var otherMinions = new List<Projectile>();
			for (int i = 0; i < Main.maxProjectiles; i++)
			{
				// Fix overlap with other minions
				Projectile other = Main.projectile[i];
				if (other.active && other.owner == projectile.owner && other.type == projectile.type)
					otherMinions.Add(other);
			}
			//otherMinions.Sort((x, y) => x.minionPos - y.minionPos);
			return otherMinions;
		}
		public override void AttackBehavior()
        {
			Player player = Main.player[projectile.owner];

			#region General behavior
			Vector2 idlePosition = player.Center;
			idlePosition.Y -= 48f; // Go up 48 coordinates (three tiles from the center of the player)

			// If your minion doesn't aimlessly move around when it's idle, you need to "put" it into the line of other summoned minions
			// The index is projectile.minionPos
			float minionPositionOffsetX = (10 + projectile.minionPos * 40) * -player.direction;
			idlePosition.X += minionPositionOffsetX; // Go behind the player

			// All of this code below this line is adapted from Spazmamini code (ID 388, aiStyle 66)

			// Teleport to player if distance is too big
			Vector2 vectorToIdlePosition = idlePosition - projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 2000f)
			{
				// Whenever you deal with non-regular events that change the behavior or position drastically, make sure to only run the code on the owner of the projectile,
				// and then set netUpdate to true
				projectile.position = idlePosition;
				projectile.velocity *= 0.1f;
				projectile.netUpdate = true;
			}

			// If your minion is flying, you want to do this independently of any conditions
			float overlapVelocity = 0.04f;
			for (int i = 0; i < Main.maxProjectiles; i++)
			{
				// Fix overlap with other minions
				Projectile other = Main.projectile[i];
				if (i != projectile.whoAmI && other.active && other.owner == projectile.owner && Math.Abs(projectile.position.X - other.position.X) + Math.Abs(projectile.position.Y - other.position.Y) < projectile.width)
				{
					if (projectile.position.X < other.position.X) projectile.velocity.X -= overlapVelocity;
					else projectile.velocity.X += overlapVelocity;

					if (projectile.position.Y < other.position.Y) projectile.velocity.Y -= overlapVelocity;
					else projectile.velocity.Y += overlapVelocity;
				}
			}
			#endregion

			#region Find target
			// Starting search distance
			float distanceFromTarget = 700f;
			Vector2 targetCenter = projectile.position;
			foundTarget = false;

			// This code is required if your minion weapon has the targeting feature
			if (player.HasMinionAttackTargetNPC)
			{
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, projectile.Center);
				// Reasonable distance away so it doesn't target across multiple screens
				if (between < Main.screenWidth / 2)
				{
					distanceFromTarget = between;
					targetCenter = npc.Center;
					foundTarget = true;
				}
			}
			if (!foundTarget)
			{
				// This code is required either way, used for finding a target
				for (int i = 0; i < Main.maxNPCs; i++)
				{
					NPC npc = Main.npc[i];
					if (npc.CanBeChasedBy())
					{
						float between = Vector2.Distance(npc.Center, projectile.Center);
						bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
						// Additional check for this specific minion behavior, otherwise it will stop attacking once it dashed through an enemy while flying though tiles afterwards
						// The number depends on various parameters seen in the movement code below. Test different ones out until it works alright
						bool closeThroughWall = between < 100f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall))
						{
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}

			projectile.friendly = foundTarget;
			#endregion

			#region Movement

			// Default movement parameters (here for attacking)
			float speed = 8f;
			float inertia = 20f;

			if (foundTarget)
			{
				// Minion has a target: attack (here, fly towards the enemy)
				if (distanceFromTarget > 40f)
				{
					// The immediate range around the target (so it doesn't latch onto it when close)
					Vector2 direction = targetCenter - projectile.Center;
					direction.Normalize();
					direction *= speed;
					projectile.velocity = (projectile.velocity * (inertia - 1) + direction) / inertia;
				}
			}
			else
			{
				// Minion doesn't have a target: return to player and idle
				if (distanceToIdlePosition > 600f)
				{
					// Speed up the minion if it's away from the player
					speed = 12f;
					inertia = 60f;
				}
				else
				{
					// Slow down the minion if closer to the player
					speed = 4f;
					inertia = 80f;
				}
				if (distanceToIdlePosition > 20f)
				{
					// The immediate range around the player (when it passively floats about)

					// This is a simple movement formula using the two parameters and its desired direction to create a "homing" movement
					vectorToIdlePosition.Normalize();
					vectorToIdlePosition *= speed;
					projectile.velocity = (projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
				}
				else if (projectile.velocity == Vector2.Zero)
				{
					// If there is a case where it's not moving at all, give it a little "poke"
					projectile.velocity.X = -0.15f;
					projectile.velocity.Y = -0.05f;
				}
			}
			#endregion

			#region Animation and visuals
			// So it will lean slightly towards the direction it's moving
			SetAttackRotation();
			// This is a simple "loop through all frames from top to bottom" animation

			Lighting.AddLight(projectile.Center, Color.White.ToVector3() * 0.1f);
			#endregion
		}
		public virtual void SetIdleRotation() => projectile.rotation = MathHelper.ToRadians(-45);
		public virtual void SetAttackRotation() => projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(45);

	}
}
