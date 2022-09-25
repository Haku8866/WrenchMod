using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace WrenchMod.NPCs
{
    class DFlipFlop : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("D flip-flop");
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Mimic);
            NPC.damage = 40;
            NPC.lifeMax = 300;
            NPC.aiStyle = NPCID.Mimic;
            NPC.width = 48;
            NPC.height = 112;
            NPC.value = 200f;

        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (NPC.downedMechBossAny)
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.1f;
            }
            else
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.0f;
            }
        }
        public override void OnKill()
        {
            if (Main.rand.NextBool(3))
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.LogicGateLamp_On, 4);
            }
            else
            {
                if (Main.rand.NextBool(2))
                {
                    Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.LogicGateLamp_Off, 4);
                }
                else
                {
                    Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.LogicGate_NAND, 4);
                }
            }
        }
    }
}