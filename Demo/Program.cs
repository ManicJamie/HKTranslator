﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HKTranslator;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string xmlOut = "<Dictionary>\r\n";
            foreach (string line in RoomDictionary.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                string[] lineArray = line.Split(':');
                xmlOut += "\t<Entry>\r\n\t<oldName>" + lineArray[0] + "</oldName>\r\n\t<newName>" + lineArray[1] + "</newName>\r\n</Entry>\r\n";
            }
            xmlOut += "</Dictionary>";
            Console.WriteLine(xmlOut);
            Console.ReadLine();
        }

        static void TranslateDemo()
        {
            string input;
            while (true)
            {
                Console.WriteLine("Enter a scene or transition name:");
                input = Console.ReadLine();
                if (input.Contains("[")) Console.WriteLine("-> " + Translator.TranslateTransitionName(input));
                else Translator.TranslateSceneName(input);
            }
        }

        static string RoomDictionary = "Tutorial_01:King's_Pass\r\nTown:Dirtmouth\r\nRoom_Shop:Sly\r\nRoom_Sly_Storeroom:Sly_Basement\r\nRoom_Town_Stag_Station:Dirtmouth_Stag\r\nRoom_Mapper:Iselda\r\nRoom_Bretta:Bretta\r\nRoom_Bretta_Basement:Bretta_Basement\r\nRoom_Ouiji:Jiji\r\nRoom_Jinn:Jinn\r\nRoom_Tram_RG:Upper_Tram\r\nRoom_Tram:Lower_Tram\r\nCrossroads_01:Crossroads_Well\r\nCrossroads_02:Crossroads_Outside_Temple\r\nCrossroads_03:Crossroads_Outside_Stag\r\nCrossroads_04:Crossroads_Gruz_Mother\r\nCrossroads_05:Crossroads_Central_Grub\r\nCrossroads_06:Crossroads_Outside_Mound\r\nCrossroads_07:Crossroads_Gruzzer\r\nCrossroads_08:Crossroads_Aspid_Arena\r\nCrossroads_09:Crossroads_Mawlek_Boss\r\nCrossroads_10:Crossroads_False_Knight_Arena\r\nCrossroads_11_Alt:Crossroads_Greenpath_Entrance\r\nCrossroads_12:Crossroads_Corridor_to_Acid_Grub\r\nCrossroads_13:Crossroads_Goam_Mask_Shard\r\nCrossroads_14:Crossroads_Outside_Myla\r\nCrossroads_15:Crossroads_Corridor_to_Tram\r\nCrossroads_16:Crossroads_Above_Lever\r\nCrossroads_18:Crossroads_Fungal_Entrance\r\nCrossroads_19:Crossroads_Before_Gruz_Mother\r\nCrossroads_21:Crossroads_Outside_False_Knight\r\nCrossroads_22:Crossroads_Glowing_Womb_Arena\r\nCrossroads_25:Crossroads_Mawlek_Entrance\r\nCrossroads_27:Crossroads_Outside_Tram\r\nCrossroads_30:Crossroads_Hot_Spring\r\nCrossroads_31:Crossroads_Spike_Grub\r\nCrossroads_33:Crossroads_Cornifer\r\nCrossroads_35:Crossroads_Acid_Grub\r\nCrossroads_36:Crossroads_Mawlek_Middle\r\nCrossroads_37:Crossroads_Vessel_Fragment\r\nCrossroads_38:Crossroads_Grubfather\r\nCrossroads_39:Crossroads_Corridor_Right_of_Temple\r\nCrossroads_40:Crossroads_Corridor_Right_of_Central_Grub\r\nCrossroads_42:Crossroads_Right_Of_Mask_Shard\r\nCrossroads_43:Crossroads_Corridor_to_Elevator\r\nCrossroads_45:Crossroads_Myla\r\nCrossroads_46:Crossroads_Tram\r\nCrossroads_47:Crossroads_Stag\r\nCrossroads_48:Crossroads_Guarded_Grub\r\nCrossroads_49:Crossroads_Elevator\r\nCrossroads_52:Crossroads_Goam_Journal\r\nCrossroads_ShamanTemple:Crossroads_Ancestral_Mound\r\nRoom_Mender_House:Crossroads_Menderbug\r\nRoom_Charm_Shop:Crossroads_Salubra\r\nRoom_ruinhouse:Crossroads_Rescue_Sly\r\nRoom_Temple:Crossroads_Inside_Temple\r\nFungus1_01:Greenpath_Entrance\r\nFungus1_01b:Greenpath_Waterfall_Bench\r\nFungus1_02:Greenpath_First_Hornet_Sighting\r\nFungus1_03:Greenpath_Storerooms\r\nFungus1_04:Greenpath_Hornet\r\nFungus1_05:Greenpath_Outside_Thorns\r\nFungus1_06:Greenpath_Cornifer\r\nFungus1_07:Greenpath_Outside_Hunter\r\nFungus1_08:Greenpath_Hunter\r\nFungus1_09:Greenpath_Sheo_Gauntlet\r\nFungus1_10:Greenpath_Acid_Bridge\r\nFungus1_11:Greenpath_Above_Fog_Canyon\r\nFungus1_12:Greenpath_MMC_Corridor\r\nFungus1_13:Greenpath_Whispering_Root\r\nFungus1_14:Greenpath_Thorns_of_Agony\r\nFungus1_15:Greenpath_Outside_Sheo\r\nFungus1_16_alt:Greenpath_Stag\r\nFungus1_17:Greenpath_Left_of_First_Hornet_Sighting\r\nFungus1_19:Greenpath_Above_Sanctuary_Bench\r\nFungus1_20_v02:Greenpath_Vengefly_King\r\nFungus1_21:Greenpath_Outside_Hornet\r\nFungus1_22:Greenpath_Outside_Stag\r\nFungus1_25:Greenpath_Corridor_to_Unn\r\nFungus1_26:Greenpath_Lake_Of_Unn\r\nFungus1_29:Greenpath_Massive_Moss_Charger\r\nFungus1_30:Greenpath_Below_Toll_Bench\r\nFungus1_31:Greenpath_Toll\r\nFungus1_32:Greenpath_Moss_Knight_Arena\r\nFungus1_34:Greenpath_Stone_Sanctuary_Entrance\r\nFungus1_35:Greenpath_Stone_Sanctuary\r\nFungus1_36:Greenpath_Stone_Sanctuary_Mask_Shard\r\nFungus1_37:Greenpath_Sanctuary_Bench\r\nFungus1_Slug:Greenpath_Unn\r\nRoom_Nailmaster_02:Greenpath_Sheo\r\nRoom_Slug_Shrine:Greenpath_Unn_Bench\r\nDeepnest_01:Fungal_Deepnest_Fall\r\nFungus2_01:Fungal_Queen's_Station\r\nFungus2_02:Fungal_Queen's_Stag\r\nFungus2_03:Fungal_Outside_Queen's\r\nFungus2_04:Fungal_Below_Ogres\r\nFungus2_05:Fungal_Shrumal_Ogres\r\nFungus2_06:Fungal_Outside_Leg_Eater\r\nFungus2_07:Fungal_Shrumal_Warrior_Acid_Bridge\r\nFungus2_08:Fungal_Outside_Elder_Hu\r\nFungus2_09:Fungal_Cloth_Corridor\r\nFungus2_10:Fungal_Left_Of_Pilgrim's_Way\r\nFungus2_11:Fungal_Right_of_Bouncy_Grub\r\nFungus2_12:Fungal_Mantis_Corridor\r\nFungus2_13:Fungal_Bretta_Bench\r\nFungus2_14:Fungal_Mantis_Village\r\nFungus2_15:Fungal_Mantis_Lords\r\nFungus2_17:Fungal_Above_Mantis_Village\r\nFungus2_18:Fungal_Cornifer\r\nFungus2_19:Fungal_Right_Of_Spore_Shroom\r\nFungus2_20:Fungal_Spore_Shroom\r\nFungus2_21:Fungal_Pilgrim's_Way\r\nFungus2_23:Fungal_Dashmaster\r\nFungus2_26:Fungal_Leg_Eater\r\nFungus2_28:Fungal_Shrumal_Warrior_Loop\r\nFungus2_29:Fungal_Core_Upper\r\nFungus2_30:Fungal_Core_Lower\r\nFungus2_31:Fungal_Mantis_Rewards\r\nFungus2_32:Fungal_Elder_Hu\r\nFungus2_33:Fungal_Leg_Eater_Root\r\nFungus2_34:Fungal_Willoh\r\nFungus3_01:Fog_Upper_West_Tall\r\nFungus3_02:Fog_Lower_West_Tall\r\nFungus3_03:Fog_Queen's_Gardens_Acid_Entrance\r\nFungus3_24:Fog_Corridor_to_Overgrown_Mound\r\nFungus3_25:Fog_Cornifer\r\nFungus3_25b:Fog_Corridor_to_Cornifer\r\nFungus3_26:Fog_East_Tall\r\nFungus3_27:Fog_Corridor_to_Archives\r\nFungus3_28:Fog_Charm_Notch\r\nFungus3_30:Fog_Lifeblood\r\nFungus3_35:Fog_Millibelle\r\nFungus3_44:Fog_Overgrown_Mound_Entrance\r\nFungus3_47:Fog_Archives_Entrance\r\nFungus3_Archive:Fog_Archives_Bench\r\nFungus3_Archive_02:Fog_Uumuu_Arena\r\nRoom_Fungus_Shaman:Fog_Overgrown_Mound\r\nCliffs_01:Cliffs_Main\r\nCliffs_02:Cliffs_Gorb\r\nCliffs_03:Cliffs_Stag_Nest\r\nCliffs_04:Cliffs_Joni's_Dark\r\nCliffs_05:Cliffs_Joni's_Pickup\r\nCliffs_06:Cliffs_Grimm_Lantern\r\nFungus1_28:Cliffs_Baldur's_Shell\r\nRoom_Nailmaster:Cliffs_Mato\r\nMines_01:Crystal_Dive_Entrance\r\nMines_02:Crystal_Dark_Entrance\r\nMines_03:Crystal_Spike_Grub\r\nMines_04:Crystal_Entrance_Conveyors\r\nMines_05:Crystal_Above_Spike_Grub\r\nMines_06:Crystal_Deep_Focus_Gauntlet\r\nMines_07:Crystal_Dark_Room\r\nMines_10:Crystal_Elevator_Entrance\r\nMines_11:Crystal_Left_Of_Guardian\r\nMines_13:Crystal_Top_Corridor\r\nMines_16:Crystal_Mimic\r\nMines_17:Crystal_Corridor_to_Spike_Grub\r\nMines_18:Crystal_Guardian_Bench\r\nMines_19:Crystal_Grub_Crushers\r\nMines_20:Crystal_East_Tall\r\nMines_23:Crystal_Crown_Whispering_Root\r\nMines_24:Crystal_Crown_Grub\r\nMines_25:Crystal_Crown_Climb\r\nMines_28:Crystal_Outside_Mound\r\nMines_29:Crystal_Dark_Bench\r\nMines_30:Crystal_Cornifer\r\nMines_31:Crystal_Crystal_Heart_Gauntlet\r\nMines_32:Crystal_Enraged_Guardian_Arena\r\nMines_33:Crossroads_Peak_Dark_Toll\r\nMines_34:Crystal_Crown_Peak\r\nMines_35:Crystal_Mound\r\nMines_36:Crystal_Deep_Focus\r\nMines_37:Crystal_Chest_Crushers\r\nAbyss_02:Basin_Broken_Bridge\r\nAbyss_03:Basin_Tram\r\nAbyss_04:Basin_Fountain\r\nAbyss_05:Basin_Palace_Grounds\r\nAbyss_17:Basin_Cloth\r\nAbyss_18:Basin_Corridor_to_Broken_Vessel\r\nAbyss_19:Basin_Broken_Vessel_Grub\r\nAbyss_20:Basin_Simple_Key\r\nAbyss_21:Basin_Monarch_Wings\r\nAbyss_22:Basin_Hidden_Station\r\nAbyss_06_Core:Abyss_Core\r\nAbyss_08:Abyss_Lifeblood_Core\r\nAbyss_09:Abyss_Lighthouse_Climb\r\nAbyss_10:Abyss_Shade_Cloak\r\nAbyss_12:Abyss_Shriek\r\nAbyss_15:Abyss_Birthplace\r\nAbyss_16:Abyss_Corridor_to_Lighthouse\r\nAbyss_Lighthouse_Room:Abyss_Lighthouse\r\nCrossroads_46b:Grounds_Tram\r\nCrossroads_50:Grounds_Blue_Lake\r\nRestingGrounds_02:Grounds_Xero\r\nRestingGrounds_04:Grounds_Dream_Nail_Entrance\r\nRestingGrounds_05:Grounds_Whispering_Root\r\nRestingGrounds_06:Grounds_Corridor_Below_Xero\r\nRestingGrounds_07:Grounds_Seer\r\nRestingGrounds_08:Grounds_Spirit's_Glade\r\nRestingGrounds_09:Grounds_Stag\r\nRestingGrounds_10:Grounds_Crypts\r\nRestingGrounds_12:Grounds_Outside_Grey_Mourner\r\nRestingGrounds_17:Grounds_Dreamshield\r\nRoom_Mansion:Grounds_Grey_Mourner\r\nRuins2_10:Grounds_Elevator\r\nAbyss_03_c:Edge_Tram\r\nDeepnest_East_01:Edge_Left_Of_Hive\r\nDeepnest_East_02:Edge_Above_Hive\r\nDeepnest_East_03:Edge_Entrance\r\nDeepnest_East_04:Edge_Bardoon\r\nDeepnest_East_06:Edge_Outside_Oro\r\nDeepnest_East_07:Edge_Whispering_Root\r\nDeepnest_East_08:Edge_Great_Hopper_Idol\r\nDeepnest_East_09:Edge_Corridor_Outside_Colosseum\r\nDeepnest_East_10:Edge_Markoth_Arena\r\nDeepnest_East_11:Edge_Below_Camp_Bench\r\nDeepnest_East_12:Edge_Hornet_Sentinel_Corridor\r\nDeepnest_East_13:Edge_Camp_Bench\r\nDeepnest_East_14:Edge_Below_Oro\r\nDeepnest_East_14b:Edge_Quick_Slash\r\nDeepnest_East_15:Edge_Lifeblood\r\nDeepnest_East_16:Edge_Oro_Scarecrow\r\nDeepnest_East_17:Edge_420_Geo_Rock\r\nDeepnest_East_18:Edge_Outside_Markoth\r\nDeepnest_East_Hornet:Edge_Hornet_Sentinel_Arena\r\nGG_Lurker:Edge_Pale_Lurker\r\nRoom_Colosseum_01:Edge_Colo_Entrance\r\nRoom_Colosseum_02:Edge_Colo_Bench\r\nRoom_Colosseum_Bronze:Edge_Colo_1_Arena\r\nRoom_Colosseum_Gold:Edge_Colo_3_Arena\r\nRoom_Colosseum_Silver:Edge_Colo_2_Arena\r\nRoom_Colosseum_Spectate:Edge_Colo_Spectate\r\nRoom_nailmaster_03:Edge_Oro\r\nRoom_Wyrm:Edge_Cast-Off_Shell\r\nAbyss_01:City_Broken_Elevator\r\nCrossroads_49b:City_Left_Elevator\r\nRoom_Nailsmith:City_Nailsmith\r\nRuins_Bathhouse:City_Pleasure_House_Bench\r\nRuins_Elevator:City_Pleasure_House_Elevator\r\nRuins_House_01:City_Guarded_Grub\r\nRuins_House_02:City_Gorgeous_Husk\r\nRuins_House_03:City_Emilitia\r\nRuins1_01:City_Pilgrim's_Entrance\r\nRuins1_02:City_Quirrel_Bench\r\nRuins1_03:City_Rafters\r\nRuins1_04:City_Outside_Nailsmith\r\nRuins1_05:City_Grub_Above_Lemm\r\nRuins1_05b:City_Lemm\r\nRuins1_05c:City_Egg_Above_Lemm\r\nRuins1_06:City_Corridor_to_Storerooms\r\nRuins1_09:City_Soul_Twister_Arena\r\nRuins1_17:City_Whispering_Root\r\nRuins1_18:City_Corridor_to_Spire\r\nRuins1_23:City_Sanctum_Entrance\r\nRuins1_24:City_Soul_Master_Arena\r\nRuins1_25:City_Sanctum_East_Elevators\r\nRuins1_27:City_Hollow_Knight_Fountain\r\nRuins1_28:City_Storerooms\r\nRuins1_29:City_Storerooms_Stag\r\nRuins1_30:City_Sanctum_Spell_Twister\r\nRuins1_31:City_Toll_Bench\r\nRuins1_31b:City_Shade_Soul_Arena\r\nRuins1_32:City_Soul_Master_Rewards\r\nRuins2_01:City_Spire_Second_Floor\r\nRuins2_01_b:City_Spire_First_Floor\r\nRuins2_03:City_Spire_Fourth_Floor\r\nRuins2_03b:City_Spire_Third_Floor\r\nRuins2_04:City_Right_Hub\r\nRuins2_05:City_Above_King's\r\nRuins2_06:City_King's_Station\r\nRuins2_07:City_Grub_Below_King's\r\nRuins2_08:City_King's_Stag\r\nRuins2_09:City_King's_Vessel_Fragment\r\nRuins2_10b:City_Right_Elevator\r\nRuins2_11:City_Collector_Arena\r\nRuins2_11_b:City_Tower_of_Love\r\nRuins2_Watcher_Room:City_Lurien_Elevator\r\nHive_01:Hive_Entrance\r\nHive_02:Hive_Whispering_Root\r\nHive_03:Hive_Outside_Grub\r\nHive_03_c:Hive_Outside_Shortcut\r\nHive_04:Hive_Mask_Shard\r\nHive_05:Hive_Hive_Knight_Arena\r\nGG_Pipeway:Waterways_Flukemunga_Corridor\r\nGG_Waterways:Waterways_Junk_Pit\r\nRoom_GG_Shortcut:Waterways_Fluke_Hermit\r\nWaterways_01:Waterways_Entrance\r\nWaterways_02:Waterways_Main_Bench\r\nWaterways_03:Waterways_Tuk\r\nWaterways_04:Waterways_Hidden_Grub\r\nWaterways_04b:Waterways_Mask_Shard\r\nWaterways_05:Waterways_Dung_Defender_Arena\r\nWaterways_06:Waterways_Corridor_to_Broken_Elevator\r\nWaterways_07:Waterways_Left_Of_Isma's_Grove\r\nWaterways_08:Waterways_Outside_Flukemarm\r\nWaterways_09:Waterways_Cornifer\r\nWaterways_12:Waterways_Flukemarm_Arena\r\nWaterways_13:Waterways_Isma's_Grove\r\nWaterways_14:Waterways_Edge_Acid_Corridor\r\nWaterways_15:Waterways_Dung_Defender's_Cave\r\nAbyss_03_b:Deepnest_Tram\r\nDeepnest_01b:Deepnest_Upper_Cornifer\r\nDeepnest_02:Deepnest_Outside_Mimics\r\nDeepnest_03:Deepnest_Left_Of_Hot_Spring\r\nDeepnest_09:Deepnest_Distant_Village_Stag\r\nDeepnest_10:Deepnest_Distant_Village\r\nDeepnest_14:Deepnest_Failed_Tramway_Bench\r\nDeepnest_16:Deepnest_After_Lower_Cornifer\r\nDeepnest_17:Deepnest_Garpede_Corridor_Below_Cornifer\r\nDeepnest_26:Deepnest_Failed_Tramway_Lifeblood\r\nDeepnest_26b:Deepnest_Tram_Pass\r\nDeepnest_30:Deepnest_Hot_Spring\r\nDeepnest_31:Deepnest_Nosk_Corridor\r\nDeepnest_32:Deepnest_Nosk_Arena\r\nDeepnest_33:Deepnest_Zote_Arena\r\nDeepnest_34:Deepnest_First_Devout\r\nDeepnest_35:Deepnest_Outside_Galien\r\nDeepnest_36:Deepnest_Mimics\r\nDeepnest_37:Deepnest_Corridor_to_Tram\r\nDeepnest_38:Deepnest_Vessel_Fragment\r\nDeepnest_39:Deepnest_Whispering_Root\r\nDeepnest_40:Deepnest_Galien_Arena\r\nDeepnest_41:Deepnest_Midwife\r\nDeepnest_42:Deepnest_Outside_Mask_Maker\r\nDeepnest_44:Deepnest_Sharp_Shadow\r\nDeepnest_45_v02:Deepnest_Weaver's_Den\r\nDeepnest_Spider_Town:Deepnest_Beast's_Den\r\nFungus2_25:Deepnest_Lower_Cornifer\r\nRoom_Mask_Maker:Deepnest_Mask_Maker\r\nRoom_spider_small:Deepnest_Brumm\r\nDeepnest_43:Gardens_Corridor_To_Deepnest\r\nFungus1_23:Gardens_First_Loodle_Corridor\r\nFungus1_24:Gardens_Cornifer\r\nFungus3_04:Gardens_Before_Petra_Arena\r\nFungus3_05:Gardens_Petra_Arena\r\nFungus3_08:Gardens_Lower_Petra_Corridor\r\nFungus3_10:Gardens_Main_Arena\r\nFungus3_11:Gardens_Whispering_Root\r\nFungus3_13:Gardens_Outside_Stag\r\nFungus3_21:Gardens_Corridor_to_Traitor_Lord\r\nFungus3_22:Gardens_Upper_Grub\r\nFungus3_23:Gardens_Traitor_Lord_Arena\r\nFungus3_34:Gardens_Entrance\r\nFungus3_39:Gardens_Moss_Prophet\r\nFungus3_49:Gardens_Traitor's_Child's_Grave\r\nFungus3_40:Gardens_Gardens_Stag\r\nFungus3_48:Gardens_Outside_White_Lady\r\nFungus3_50:Gardens_Toll_Bench\r\nRoom_Queen:Gardens_White_Lady\r\nWhite_Palace_01:Palace_Entrance\r\nWhite_Palace_02:Palace_First_Mold\r\nWhite_Palace_03_hub:Palace_Hub\r\nWhite_Palace_04:Palace_Left_Of_Hub\r\nWhite_Palace_05:Palace_Saw_Room\r\nWhite_Palace_06:Palace_Balcony\r\nWhite_Palace_07:Palace_Lamp_Pogo\r\nWhite_Palace_08:Palace_Workshop\r\nWhite_Palace_09:Palace_Throne\r\nWhite_Palace_11:Palace_Outside\r\nWhite_Palace_12:Palace_Spike_Drop\r\nWhite_Palace_13:Palace_Thorn_Jump\r\nWhite_Palace_14:Palace_Hell_Corridor\r\nWhite_Palace_15:Palace_Caged_Lever\r\nWhite_Palace_16:Palace_Saw_Climb\r\nWhite_Palace_17:POP_Lever\r\nWhite_Palace_18:POP_Entrance\r\nWhite_Palace_19:POP_Vertical\r\nWhite_Palace_20:POP_Final\r\nDream_Final_Boss:Egg_Radiance\r\nRoom_Final_Boss_Atrium:Egg_Bench\r\nRoom_Final_Boss_Core:Egg_Hollow_Knight\r\nGrimm_Divine:Grimm_Divine\r\nGrimm_Main_Tent:Grimm_Tent\r\nGrimm_Nightmare:Grimm_NKG\r\nDream_01_False_Knight:Dream_Failed_Champion\r\nDream_02_Mage_Lord:Dream_Soul_Tyrant\r\nDream_03_Infected_Knight:Dream_Lost_Kin\r\nDream_04_White_Defender:Dream_White_Defender\r\nDream_Abyss:Dream_Abyss\r\nDream_Backer_Shrine:Dream_Outside_Shrine\r\nDream_Guardian_Hegemol:Dream_Herrah\r\nDream_Guardian_Lurien:Dream_Lurien\r\nDream_Guardian_Monomon:Dream_Monomon\r\nDream_Mighty_Zote:Dream_Grey_Prince_Zote\r\nDream_Nailcollection:Dream_Nail\r\nDream_Room_Believer_Shrine:Dream_Shrine_of_Believers\r\nGG_Atrium:Godhome_Atrium\r\nGG_Atrium_Roof:Godhome_Roof\r\nGG_Blue_Room:Godhome_Lifeblood\r\nGG_Land_Of_Storms:Godhome_Land_Of_Storms\r\nGG_Mighty_Zote:GG_Enchanting_Vigorous_Diligent_Overwhelming_Gorgeous_Passionate_Terrifying_Beautiful_Zote\r\nGG_Unlock_Wastes:Godhome_Godtuner\r\nGG_Workshop:Godhome_Hall_Of_Gods";
    }
}
