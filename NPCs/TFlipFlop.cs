using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace WrenchMod.NPCs
{
    class TFlipFlop : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("T flip-flop");
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.DemonEye);
            NPC.damage = 20;
            NPC.lifeMax = 50;
            NPC.aiStyle = NPCID.DemonEye;
            NPC.width = 16;
            NPC.height = 48;
            NPC.value = 0f;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (NPC.downedBoss3)
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
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.LogicGateLamp_Faulty);
            }
            else
            {
                if (Main.rand.NextBool(2))
                {
                    Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.LogicGateLamp_Off);
                }
                else
                {
                    Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.LogicGate_AND);
                }
            }
        }
    }
}