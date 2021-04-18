using Terraria.ModLoader;

namespace SpellbladeRevised.Spellblade.Items.Weapons
{
    public abstract class SpellbladeBase : ModItem
    {
        public static readonly int ManaRegenT1 = 8;
        public static readonly int ManaRegenT2 = 12;
        public static readonly int ManaRegenT3 = 20;
        public static readonly int ManaRegenT4 = 30;
        public static readonly int ManaRegenT5 = 40;
        public static readonly int ManaRegenT6 = 50;
        public static readonly int ManaRegenT7 = 75;
        public static readonly int ManaRegenT8 = 100;

        protected abstract int onHitManaRegen { get; }

        /* zombie code
		#region casting attribues
		protected virtual int castUseAnimationTime { get; } = -1;
		protected virtual int castReuseDelay { get; } = -1;
		protected virtual int castUseStyle { get; } = ItemUseStyleID.HoldingOut;
		protected virtual LegacySoundStyle castSound { get; } = SoundID.Item8;
		protected abstract int projectileID { get; }
		protected abstract int projectileSpeed { get; }
		protected virtual int projectileSpread { get; } = 5;
		protected virtual bool autoCast { get; } = true;
		#endregion

		

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine line = new TooltipLine(mod, "Face", SpellbladeRevised.classTitleText)
			{
				overrideColor = SpellbladeRevised.classTextColor
			};
			tooltips.Insert(1, line);

			item.mana = manaCost;
			int cost = p.GetManaCost(item);
			TooltipLine manaData = new TooltipLine(mod, "PrefixUseMana", $"Uses {cost} mana\nRestores {onHitManaRegen} Mana on Melee Hit");
			tooltips.Insert(6, manaData);
		}
        //Set damage bonus
        public override void ModifyWeaponDamage(Player player, ref float add, ref float multi, ref float flat)
        {
			add = player.magicDamage;
			multi = player.magicDamageMult;
		}
        public override bool? PrefixChance(int pre, UnifiedRandom rand)
        {
			if (pre == -1)
				return true;
            return base.PrefixChance(pre, rand);
        }
        protected override void SetBasicCustomDefaults()
		{
			//item.magic = true;
			item.mana = manaCost;

			item.scale = scale;
			item.width = width;
			item.height = height;

			Item.staff[item.type] = true;

			item.value = value;
			item.rare = rarity;

			Item.staff[item.type] = true;

			item.damage = primaryDmg;
			item.knockBack = primaryKnockback;
			item.crit = additiveCritChance;
			//item.magic = true;
			item.useTime = primaryUseTime;
			item.useAnimation = primaryUseTime;
			item.useStyle = ItemUseStyleID.SwingThrow;

			item.shoot = projectileID;
			item.shootSpeed = projectileSpeed;
		}
		
        public override bool CanUseItem(Player player)
		{
			SpellbladePlayer sp = player.GetModPlayer<SpellbladePlayer>();
			SpellbladePlayer.SetItemAltUse(player, Main.myPlayer == player.whoAmI);

			if (sp.altWeaponFunc)
				OnRightClick(player);
			else
				OnLeftClick(player);

			//Main.NewText($"-Spellblade- Player: {Main.player[player.whoAmI].name} AltFunc = {sp.altWeaponFunc}");
			if (player.GetManaCost(item) > player.statMana)
				return false;

			return true;
		}
        public override void OnLeftClick(Player player)
		{
			//Item.staff[item.type] = true;
			item.useStyle = castUseStyle;
			item.useTime = altUseTime;
			item.mana = manaCost;
			if (castUseAnimationTime != -1)
				item.useAnimation = castUseAnimationTime;
			else
				item.useAnimation = altUseTime;

			item.UseSound = primarySound;

			if (castReuseDelay != -1)
				item.reuseDelay = castReuseDelay;
			else
				item.reuseDelay = altUseTime;

			item.noMelee = true;
			item.damage = altDmg;
			item.shoot = projectileID;
			item.useTurn = false;
			item.autoReuse = autoCast;
			
		}
        public override void OnRightClick(Player player)
		{
			//Item.staff[item.type] = false;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTime = primaryUseTime;
			item.useAnimation = primaryUseTime;
			item.UseSound = primarySound;
			item.damage = primaryDmg;
			item.reuseDelay = 0;
			item.noMelee = false;
			item.knockBack = primaryKnockback;
			item.mana = 0;

			item.shoot = ProjectileID.None;
			//item.useTurn = true;
			item.autoReuse = true;

			if (Main.myPlayer == player.whoAmI)
			player.direction = player.Center.X > Main.MouseWorld.X ? -1 : 1;

		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			SpellbladePlayer sp = player.GetModPlayer<SpellbladePlayer>();
			if (sp.altWeaponFunc)
			{
				player.statMana += (int)Math.Round((float)damage / primaryDmg * onHitManaRegen);
			}
			sp.TryToGainArcane();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            Vector2 dir = Vector2.Normalize(Main.MouseWorld - player.position);

			Vector2 speed = dir * projectileSpeed;
			speed = speed.RotatedByRandom(MathHelper.ToRadians(projectileSpread));
			
			speedX = speed.X;
			speedY = speed.Y;

			damage = altDmg;
			
			return true;
		}*/
    }
}