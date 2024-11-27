using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dungeondelvers.Content.DamageTypes;
using dungeondelvers.Core;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace dungeondelvers.Content.Items.Core
{
    public abstract class ModifiedItem : ModItem
    {
        /// <summary>
        /// If true, when attacking a non-mechanical monster, it will apply %20 of the items damage again
        /// bypassing all armor,
        /// Default <see langword="false"/>.<br/>
        /// </summary>
        public bool Bleed = false;

        public virtual void HitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            HitNPC(player, target, hit, damageDone);
            BleedNPC(player, target, hit, damageDone);
        }

        private void BleedNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Bleed || ModContent.GetInstance<dungeondelversPlayer>().PiercingBlow && Item.damage != 0)
            {
                target.SimpleStrikeNPC(Item.damage * (20 / 100), player.direction, false, 0, ModContent.GetInstance<BleedDamage>());
                CombatText.NewText(new Rectangle((int)target.position.X, (int)target.position.Y, 0, 0), Color.DarkRed,
                    Item.damage * (20 / 100));
            }
        }
    }
}
