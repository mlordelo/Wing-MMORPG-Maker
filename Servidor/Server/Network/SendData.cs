using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACESERVER
{
    class SendData
    {
        public static void SendToAll(string packet)
        {
            for (int i = 0; i < WinsockAsync.Clients.Count; i++)
            {
                WinsockAsync.Send(i, packet);
            }
        }

        public static void SendToMap(int map, string packet)
        {
            for (int i = 0; i <= Globals.Player_HighIndex; i++)
            {
                if ((PStruct.character[i, PStruct.player[i].SelectedChar].Map == map) && (PStruct.tempplayer[i].ingame == true))
                {
                    SendToUser(i, packet);
                }
            }
        }

        public static void SendToGuild(int guild, string packet)
        {
            for (int i = 0; i <= Globals.Player_HighIndex; i++)
            {
                if ((PStruct.character[i, PStruct.player[i].SelectedChar].Guild == guild) && (PStruct.tempplayer[i].ingame == true))
                {
                    SendToUser(i, packet);
                }
            }
        }

        public static void SendToParty(int partynum, string packet)
        {
            for (int i = 0; i <= Globals.Player_HighIndex; i++)
            {
                if ((PStruct.tempplayer[i].Party == partynum) && (PStruct.tempplayer[i].ingame == true))
                {
                    SendToUser(i, packet);
                }
            }
        }

        public static void SendToMapBut(int index, int map, string packet)
        {
            for (int i = 0; i <= Globals.Player_HighIndex; i++)
            {
                if (i != index)
                {
                    if ((PStruct.character[i, PStruct.player[i].SelectedChar].Map == map)  && (PStruct.tempplayer[i].ingame == true))
                    {
                        SendToUser(i, packet);
                    }
                }
            }
        }

        public static void SendToUser(int clientid, string packet)
        {
            for (int i = 0; i < WinsockAsync.Clients.Count; i++)
            {
                if (WinsockAsync.Clients[i].Index == clientid)
                {
                    WinsockAsync.Send(i, packet);
                }
            }
        }

        public static void Send_PlayerDataToMapBut(int Index, string username, int charId)
        {
                {
                    string charName = (PStruct.character[Index, PStruct.player[Index].SelectedChar].CharacterName);
                    int charSpriteIndex = (PStruct.character[Index, PStruct.player[Index].SelectedChar].SpriteIndex);
                    int charClass = (PStruct.character[Index, PStruct.player[Index].SelectedChar].ClassId);
                    string charSprite = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Sprite);
                    int charLevel = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Level);
                    int charExp = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Exp);
                    int charFire = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Fire);
                    int charEarth = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Earth);
                    int charWater = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Water);
                    int charWind = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Wind);
                    int charDark = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Dark);
                    int charLight = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Light);
                    int charPoints = PStruct.character[Index, PStruct.player[Index].SelectedChar].Points;
                    int charMap = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Map);
                    byte charX = (PStruct.character[Index, PStruct.player[Index].SelectedChar].X);
                    byte charY = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Y);
                    byte charDir = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Dir);
                    int charVitality = PStruct.tempplayer[Index].Vitality;
                    int charSpirit = PStruct.tempplayer[Index].Spirit;
                    int charAccess = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Access);
                    int SkillPoints = PStruct.character[Index, PStruct.player[Index].SelectedChar].SkillPoints;
                    int charHue = PStruct.character[Index, PStruct.player[Index].SelectedChar].Hue;
                    int charGender = PStruct.character[Index, PStruct.player[Index].SelectedChar].Gender;
                    string Equipment = PStruct.character[Index, PStruct.player[Index].SelectedChar].Equipment;
                    int extra_vitality = PStruct.GetExtraVitality(Index);
                    int extra_spirit = PStruct.GetExtraVitality(Index);

                    string packet = "";
                    packet = packet + Index + ";";
                    packet = packet + charName + ";"; packet = packet + charSpriteIndex + ";"; packet = packet + charClass + ";"; packet = packet + charSprite + ";"; packet = packet + charLevel + ";";
                    packet = packet + charExp + ";"; packet = packet + charFire + ";"; packet = packet + charEarth + ";"; packet = packet + charWater + ";"; packet = packet + charWind + ";";
                    packet = packet + charDark + ";"; packet = packet + charLight + ";"; packet = packet + charPoints + ";"; packet = packet + charMap + ";"; packet = packet + charX + ";";
                    packet = packet + charY + ";"; packet = packet + charDir + ";"; packet = packet + charVitality + ";"; packet = packet + charSpirit + ";"; packet = packet + charAccess + ";";
                    packet = packet + charHue + ";"; packet = packet + charGender + ";"; packet = packet + SkillPoints + ";"; packet = packet + Equipment + ";"; packet = packet + extra_vitality + ";";
                    packet = packet + extra_spirit + ";";

                    SendToMapBut(Index, charMap, String.Format("<8>{0}></8>\n", packet));
                }
        }

        public static void Send_PlayerDataTo(int Receiver, int Index, string username, int charId)
        {
            {
                string charName = PStruct.character[Index, PStruct.player[Index].SelectedChar].CharacterName;
                int charSpriteIndex = PStruct.character[Index, PStruct.player[Index].SelectedChar].SpriteIndex;
                int charClass = PStruct.character[Index, PStruct.player[Index].SelectedChar].ClassId;
                string charSprite = PStruct.character[Index, PStruct.player[Index].SelectedChar].Sprite;
                int charLevel = PStruct.character[Index, PStruct.player[Index].SelectedChar].Level;
                int charExp = PStruct.character[Index, PStruct.player[Index].SelectedChar].Exp;
                int charFire = PStruct.character[Index, PStruct.player[Index].SelectedChar].Fire;
                int charEarth = PStruct.character[Index, PStruct.player[Index].SelectedChar].Earth;
                int charWater = PStruct.character[Index, PStruct.player[Index].SelectedChar].Water;
                int charWind = PStruct.character[Index, PStruct.player[Index].SelectedChar].Wind;
                int charDark = PStruct.character[Index, PStruct.player[Index].SelectedChar].Dark;
                int charLight = PStruct.character[Index, PStruct.player[Index].SelectedChar].Light;
                int charPoints = PStruct.character[Index, PStruct.player[Index].SelectedChar].Points;
                int charMap = PStruct.character[Index, PStruct.player[Index].SelectedChar].Map;
                byte charX = PStruct.character[Index, PStruct.player[Index].SelectedChar].X;
                byte charY = PStruct.character[Index, PStruct.player[Index].SelectedChar].Y;
                byte charDir = PStruct.character[Index, PStruct.player[Index].SelectedChar].Dir;
                int charVitality = PStruct.tempplayer[Index].Vitality;
                int charSpirit = PStruct.tempplayer[Index].Spirit;
                int charAccess = PStruct.character[Index, PStruct.player[Index].SelectedChar].Access;
                int charHue = PStruct.character[Index, PStruct.player[Index].SelectedChar].Hue;
                int charGender = PStruct.character[Index, PStruct.player[Index].SelectedChar].Gender;
                int SkillPoints = PStruct.character[Index, PStruct.player[Index].SelectedChar].SkillPoints;
                string Equipment = PStruct.character[Index, PStruct.player[Index].SelectedChar].Equipment;

                string packet = "";
                packet = packet + Index + ";";
                packet = packet + charName + ";"; packet = packet + charSpriteIndex + ";"; packet = packet + charClass + ";"; packet = packet + charSprite + ";"; packet = packet + charLevel + ";";
                packet = packet + charExp + ";"; packet = packet + charFire + ";"; packet = packet + charEarth + ";"; packet = packet + charWater + ";"; packet = packet + charWind + ";";
                packet = packet + charDark + ";"; packet = packet + charLight + ";"; packet = packet + charPoints + ";"; packet = packet + charMap + ";"; packet = packet + charX + ";";
                packet = packet + charY + ";"; packet = packet + charDir + ";"; packet = packet + charVitality + ";"; packet = packet + charSpirit + ";"; packet = packet + charAccess + ";";
                packet = packet + charHue + ";"; packet = packet + charGender + ";"; packet = packet + SkillPoints + ";"; packet = packet + Equipment + ";";

                SendToUser(Receiver, String.Format("<8>{0}</8>\n", packet));
            }
        }


        public static void Send_UpdatePlayerHighIndex()
        {
            {
                SendToAll(String.Format("<9>{0}</9>\n", Globals.Player_HighIndex));
            }
        }
        public static void Send_PlayerXY(int Index)
        {
            {
                int charX = (PStruct.character[Index, Convert.ToInt32(PStruct.player[Index].SelectedChar)].X);
                int charY = (PStruct.character[Index, Convert.ToInt32(PStruct.player[Index].SelectedChar)].Y);
                SendToMap(PStruct.character[Index, PStruct.player[Index].SelectedChar].Map, String.Format("<10>{0}</10>\n", Index + ";" + charX + ";" + charY));
            }
        }
        public static void Send_MsgToAll(string msg, int color, int type)
        {
            {
                byte[] databyte = Encoding.Unicode.GetBytes(msg);
                string output = Encoding.Unicode.GetString(databyte);

                SendToAll(String.Format("<11 {0};{1}>{2}</11>\n", output, color, type));
            }
        }
        public static void Send_MsgToMap(int Index, string msg, int color, int type)
        {
            {
                byte[] databyte = Encoding.Unicode.GetBytes(msg);
                string output = Encoding.Unicode.GetString(databyte);
                
                SendToMap(PStruct.character[Index, PStruct.player[Index].SelectedChar].Map, String.Format("<11 {0};{1}>{2}</11>\n", output, color, type));
            }
        }
        public static void Send_MsgToPlayer(int Index, string msg, int color, int type)
        {
            {
                SendToUser(Index, String.Format("<11 {0};{1}>{2}</11>\n", msg, color, type));
            }
        }
        public static void Send_MsgToParty(int party, string msg, int color, int type)
        {
            {
                byte[] databyte = Encoding.Unicode.GetBytes(msg);
                string output = Encoding.Unicode.GetString(databyte);

                SendToParty(party, String.Format("<11 {0};{1}>{2}</11>\n", output, color, type));
            }
        }
        public static void Send_MsgToGuild(int guild, string msg, int color, int type)
        {
            {
                byte[] databyte = Encoding.Unicode.GetBytes(msg);
                string output = Encoding.Unicode.GetString(databyte);

                SendToGuild(guild, String.Format("<11 {0};{1}>{2}</11>\n", output, color, type));
            }
        }
        public static void Send_InvSlots(int Index, int characterslot)
        {
            {
                string packet = "";

                packet = packet + (Globals.MaxInvSlot - 1) + ";";

                for (int i = 1; i < Globals.MaxInvSlot; i++)
                {
                    packet = packet + i + ";";
                    packet = packet + Index + ";";
                    packet = packet + PStruct.invslot[Index, i].item + ";";
                }

                SendToUser(Index, String.Format("<12>{0}</12>\n", packet));
            }
        }
        public static void Send_NpcTo(int index, int map, int id)
        {
            {
                string name = NStruct.npc[map, id].Name;
                string sprite = NStruct.npc[map, id].Sprite;
                int npcindex = NStruct.npc[map, id].Index;
                int x = NStruct.tempnpc[map, id].X;
                int y = NStruct.tempnpc[map, id].Y;
                int vitality = NStruct.npc[map, id].Vitality;
                int dir = NStruct.tempnpc[map, id].Dir;

                SendToUser(index, String.Format("<14 {0};{1};{2};{3};{4};{5};{6}>{7}</14>\n", id, name, sprite, npcindex, x, y, vitality, dir));
            }
        }
        public static void Send_NpcToMap(int map, int id)
        {
            {
                if (NStruct.tempnpc[map, id].Dead == true) { return; }

                string packet = "";
                packet += id + ";";
                packet += NStruct.npc[map, id].Name + ";";
                packet += NStruct.npc[map, id].Sprite + ";";
                packet += NStruct.npc[map, id].Index + ";";
                packet += NStruct.tempnpc[map, id].X + ";";
                packet += NStruct.tempnpc[map, id].Y + ";";
                packet += NStruct.npc[map, id].Vitality + ";";
                packet += NStruct.tempnpc[map, id].Dir + ";";

                packet = "1" + ";" + packet;

                SendToMap(map, String.Format("<14>{0}</14>\n", packet));
            }
        }
        public static void Send_MapNpcsTo(int index)
        {
            {
                int map = Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Map);

                if (MStruct.tempmap[map].NpcCount == 0) { return; }

                string packet = "";
                int count = 0;

                for (int i = 1; i <= MStruct.tempmap[map].NpcCount; i++)
                {
                    if (!NStruct.tempnpc[map, i].Dead)
                    {
                        packet += i + ";";
                        packet += NStruct.npc[map, i].Name + ";";
                        packet += NStruct.npc[map, i].Sprite + ";";
                        packet += NStruct.npc[map, i].Index + ";";
                        packet += NStruct.tempnpc[map, i].X + ";";
                        packet += NStruct.tempnpc[map, i].Y + ";";
                        packet += NStruct.npc[map, i].Vitality + ";";
                        packet += NStruct.tempnpc[map, i].Dir + ";";
                        count += 1;
                    }
                }

                packet = count + ";" + packet;

                SendToMap(map, String.Format("<14>{0}</14>\n", packet));
            }
        }
        public static void Send_NpcMove(int map, int id)
        {
            {
                string packet = "";
                packet += id + ";"; packet += NStruct.tempnpc[map, id].X + ";"; packet += NStruct.tempnpc[map, id].Y + ";";
                SendToMap(map, String.Format("<15>{0}</15>\n", packet));
            }
        }
        public static void Send_PlayerLeft(int map, int index)
        {
            {
                SendToMapBut(index, map, String.Format("<16>{0}</16>\n", index));
            }
        }
        public static void Send_PlayerEquipmentToMap(int index)
        {
            {
                SendToMap(PStruct.character[index, PStruct.player[index].SelectedChar].Map, String.Format("<17 {0}>{1}</17>\n", index, PStruct.character[index, PStruct.player[index].SelectedChar].Equipment));
            }
        }
        public static void Send_PlayerEquipmentTo(int index, int playerindex)
        {
            {
                SendToUser(index, String.Format("<17 {0}>{1}</17>\n", playerindex, PStruct.character[playerindex, PStruct.player[playerindex].SelectedChar].Equipment));
            }
        }
        public static void Send_PlayerSkills(int index)
        {
            {
                string packet = "";

                packet = packet + (Globals.MaxPlayer_Skills - 1) + ";";

                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    packet = packet + i + ";";
                    packet = packet + PStruct.skill[index, i].num + ";";
                    packet = packet + PStruct.skill[index, i].level + ";";
                }

                SendToUser(index, String.Format("<18>{0}</18>\n", packet));
            }
        }
        public static void Send_PlayerFriends(int index)
        {
            string packet = "";

            int friendscount = PStruct.GetPlayerFriendsCount(index);
            Console.WriteLine(friendscount);


            packet = packet + friendscount + ";";

            //PStruct.AddFriend(index, index);

            for (int i = 1; i <= friendscount; i++)
            {
                packet = packet + i + ";";
                packet = packet + PStruct.player[index].friend[i].name + ";";
                packet = packet + PStruct.player[index].friend[i].sprite + ";";
                packet = packet + PStruct.player[index].friend[i].sprite_index + ";";
                packet = packet + PStruct.player[index].friend[i].classid + ";";
                packet = packet + PStruct.player[index].friend[i].level + ";";
                packet = packet + PStruct.player[index].friend[i].guildname + ";";
                if (PStruct.FriendIsOnline(index, i)) { packet = packet + "1" + ";"; } else { packet = packet + "0" + ";"; }
            }

            SendToUser(index, String.Format("<87>{0}</87>\n", packet));
        }
        public static void Send_PlayerWarp(int index)
        {
            {
                SendToUser(index, String.Format("<19>{0}</19>\n", PStruct.character[index, PStruct.player[index].SelectedChar].Map + ";" + PStruct.character[index, PStruct.player[index].SelectedChar].X + ";" + PStruct.character[index, PStruct.player[index].SelectedChar].Y + ";" + PStruct.character[index, PStruct.player[index].SelectedChar].Dir));
            }
        }
        public static void Send_PlayerDir(int index, int ToMap = 0)
        {
            {
                if (ToMap == 0)
                {
                    SendToUser(index, String.Format("<20 {0}>{1}</20>\n", index, PStruct.character[index, PStruct.player[index].SelectedChar].Dir));
                }
                else
                {
                    SendToMapBut(index, PStruct.character[index, PStruct.player[index].SelectedChar].Map, String.Format("<20 {0}>{1}</20>\n", index, PStruct.character[index, PStruct.player[index].SelectedChar].Dir));
                }
            }
        }
        public static void Send_ActionMsg(int index, string msg, int color, int x, int y, int type, int dir, int ToMap = 0)
        {
            {
                if (ToMap == 0)
                {
                    SendToUser(index, String.Format("<21>{0}</21>\n", msg + ";" + color + ";" + x + ";" + y + ";" + type + ";" + dir));
                }
                else
                {
                    SendToMap(ToMap, String.Format("<21>{0}</21>\n", msg + ";" + color + ";" + x + ";" + y + ";" + type + ";" + dir));
                }
            }
        }
        public static void Send_Animation(int map, int targettype, int target, int animid)
        {
            {
                    SendToMap(map, String.Format("<22 {0};{1}>{2}</22>\n", targettype, target, animid));
            }
        }
        public static void Send_NpcLeft(int map, int id)
        {
            {
                SendToMap(map, String.Format("<23>{0}</23>\n", id));
            }
        }
        public static void Send_NpcVitality(int map, int id, int vitality)
        {
            {
                SendToMap(map, String.Format("<24 {0}>{1}</24>\n", id, vitality));
            }
        }
        public static void Send_PlayerVitalityToMap(int map, int index, int vitality)
        {
            {
                SendToMap(map, String.Format("<25 {0}>{1}</25>\n", index, vitality));
            }
        }
        public static void Send_PlayerVitalityToParty(int partynum, int index, int vitality)
        {
            {
                SendToParty(partynum, String.Format("<25 {0}>{1}</25>\n", index, vitality));
            }
        }
        public static void Send_PlayerSpiritToMap(int map, int index, int spirit)
        {
            {
                SendToMap(map, String.Format("<30 {0}>{1}</30>\n", index, spirit));
            }
        }
        public static void Send_PlayerSpiritToParty(int partynum, int index, int spirit)
        {
            {
                SendToParty(partynum, String.Format("<30 {0}>{1}</30>\n", index, spirit));
            }
        }
        public static void Send_NpcDir(int map, int id, int dir)
        {
            {
                SendToMap(map, String.Format("<26 {0}>{1}</26>\n", id, dir));
            }
        }

        public static void Send_MapItems(int index)
        {
            {
                int ItemNum;
                int ItemType;
                int Value;
                int X;
                int Y;
                int count = 0;

                string packet = "";

                for (int i = 1; i <= MStruct.GetMapItemMaxIndex(Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Map)); i++)
                {
                    if (MStruct.mapitem[PStruct.character[index, PStruct.player[index].SelectedChar].Map, i].ItemNum > 0)
                    {
                        ItemNum = MStruct.mapitem[PStruct.character[index, PStruct.player[index].SelectedChar].Map, i].ItemNum;
                        ItemType = MStruct.mapitem[PStruct.character[index, PStruct.player[index].SelectedChar].Map, i].ItemType;
                        Value = MStruct.mapitem[PStruct.character[index, PStruct.player[index].SelectedChar].Map, i].Value;
                        X = MStruct.mapitem[PStruct.character[index, PStruct.player[index].SelectedChar].Map, i].X;
                        Y = MStruct.mapitem[PStruct.character[index, PStruct.player[index].SelectedChar].Map, i].Y;

                        packet = packet + i + ";";
                        packet = packet + ItemNum + ";"; packet = packet + ItemType + ";"; packet = packet + Value + ";";
                        packet = packet + X + ";"; packet = packet + Y + ";";
                        count += 1;
                    }
                }

                packet = packet + count;

                SendToUser(index, String.Format("<28>{0}</28>\n", packet));
            }
        }

        public static void Send_MapItem(int map, int mapitemnum)
        {
            {
                int ItemNum = MStruct.mapitem[map, mapitemnum].ItemNum;
                int ItemType = MStruct.mapitem[map, mapitemnum].ItemType;
                int Value = MStruct.mapitem[map, mapitemnum].Value;
                int X = MStruct.mapitem[map, mapitemnum].X;
                int Y = MStruct.mapitem[map, mapitemnum].Y;

                string packet = "";
                packet = packet + mapitemnum + ";";
                packet = packet + ItemNum + ";"; packet = packet + ItemType + ";"; packet = packet + Value + ";";
                packet = packet + X + ";"; packet = packet + Y + ";";
                packet = packet + "1" + ";";

                SendToMap(map, String.Format("<28>{0}</28>\n", packet));
            }
        }

        public static void Send_ClearMapItem(int map, int mapitemnum)
        {
            {
                SendToMap(map, String.Format("<29>{0}</29>\n", mapitemnum));
            }
        }

        public static void Send_PlayerHotkeys(int index)
        {
            {
              string packet = "";
              for (int i = 1; i < Globals.MaxHotkeys; i++)
              {
                 packet = packet + PStruct.hotkey[index, i].type + "," + PStruct.hotkey[index, i].num + ",";
              }
                 SendToUser(index, String.Format("<31>{0}</31>\n", packet));                  
            }
        }


        public static void Send_PlayerAttack(int index)
        {
            {
                SendToMap(PStruct.character[index, PStruct.player[index].SelectedChar].Map, String.Format("<32>{0}</32>\n", index));
            }
        }

        public static void Send_Frozen(int type, int index, int map = 0)
        {
            int value = 0;
            if (type == Globals.Target_Player)
            {
                if (PStruct.tempplayer[index].isFrozen) { value = 1; }
                SendToMap(PStruct.character[index, PStruct.player[index].SelectedChar].Map, String.Format("<84>{0}</84>\n", type + ";" + index + ";" + value));
            }
            else
            {
                if (NStruct.tempnpc[map, index].isFrozen) { value = 1; }
                SendToMap(map, String.Format("<84>{0}</84>\n", type + ";" + index + ";" + value));
            }
        }

        public static void Send_MoveSpeed(int type, int index, int map = 0)
        {
            {
                if (type == 1)
                {
                    SendToMap(PStruct.character[index, PStruct.player[index].SelectedChar].Map, String.Format("<33>{0}</33>\n", type + ";" + index + ";" + PStruct.tempplayer[index].movespeed));
                }
                else
                {
                    SendToMap(map, String.Format("<33>{0}</33>\n", type + ";" + index + ";" + NStruct.tempnpc[map, index].movespeed));
                }
            }
        }
        public static void Send_PlayerAtrToMapBut(int Index, string username, string charId)
        {
            {

                int charMap = PStruct.character[Index, PStruct.player[Index].SelectedChar].Map;
                int charFire = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Fire);
                int charEarth = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Earth);
                int charWater = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Water);
                int charWind = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Wind);
                int charDark = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Dark);
                int charLight = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Light);
                int charPoints = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Points);

                string packet = "";
                packet += Index + ";"; packet += charFire + ";"; packet += charEarth + ";";
                packet += charWater + ";"; packet += charWind + ";";
                packet += charDark + ";"; packet += charLight + ";"; packet += charPoints + ";";

                SendToMapBut(Index, charMap, String.Format("<34>{0}</34>\n", packet));
            }
        }
        public static void Send_MapGuildTo(int Index)
        {
            {

                int charMap = PStruct.character[Index, PStruct.player[Index].SelectedChar].Map;
                int MapGuild = MStruct.map[charMap].guildnum;

                string packet = "";
                packet += GStruct.guild[MapGuild].name + ";"; packet += GStruct.guild[MapGuild].shield + ";"; packet += GStruct.guild[MapGuild].hue + ";";

                SendToUser(Index, String.Format("<83>{0}</83>\n", packet));
            }
        }
        public static void Send_MapGuildToMap(int map)
        {
            {
                int MapGuild = MStruct.map[map].guildnum;

                string packet = "";
                packet += GStruct.guild[MapGuild].name + ";"; packet += GStruct.guild[MapGuild].shield + ";"; packet += GStruct.guild[MapGuild].hue + ";";

                SendToMap(map, String.Format("<83>{0}</83>\n", packet));
            }
        }
        public static void Send_PlayerAtrTo(int Index)
        {
            {

                int charMap = PStruct.character[Index, PStruct.player[Index].SelectedChar].Map;
                int charFire = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Fire);
                int charEarth = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Earth);
                int charWater = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Water);
                int charWind = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Wind);
                int charDark = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Dark);
                int charLight = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Light);
                int charPoints = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Points);

                string packet = "";
                packet += Index + ";";packet += charFire + ";";packet += charEarth + ";";
                packet += charWater + ";";packet += charWind + ";";
                packet += charDark + ";";packet += charLight + ";";packet += charPoints + ";";

                SendToUser(Index, String.Format("<34>{0}</34>\n", packet));
            }
        }
        public static void Send_PlayerExtraVitalityTo(int user, int Index)
        {
            {
                int extra_vitality = PStruct.GetExtraVitality(Index);

                string packet = "";
                packet += Index + ";"; packet += extra_vitality + ";";

                SendToUser(user, String.Format("<79>{0}</79>\n", packet));
            }
        }
        public static void Send_PlayerExtraVitalityToMap(int Index)
        {
            {
                int map = PStruct.character[Index, PStruct.player[Index].SelectedChar].Map;
                int extra_vitality = PStruct.GetExtraVitality(Index);

                string packet = "";
                packet += Index + ";"; packet += extra_vitality + ";";

                SendToMap(map, String.Format("<79>{0}</79>\n", packet));
            }
        }
        public static void Send_PlayerExtraVitalityToParty(int partynum, int Index)
        {
            {
                int extra_vitality = PStruct.GetExtraVitality(Index);

                string packet = "";
                packet += Index + ";"; packet += extra_vitality + ";";

                SendToParty(partynum, String.Format("<79>{0}</79>\n", packet));
            }
        }
        public static void Send_PlayerExtraSpiritTo(int user, int Index)
        {
            {
                int extra_vitality = PStruct.GetExtraSpirit(Index);

                string packet = "";
                packet += Index + ";"; packet += extra_vitality + ";";

                SendToUser(user, String.Format("<80>{0}</80>\n", packet));
            }
        }
        public static void Send_PlayerExtraSpiritToMap(int Index)
        {
            {
                int map = PStruct.character[Index, PStruct.player[Index].SelectedChar].Map;
                int extra_vitality = PStruct.GetExtraSpirit(Index);

                string packet = "";
                packet += Index + ";"; packet += extra_vitality + ";";

                SendToMap(map, String.Format("<80>{0}</80>\n", packet));
            }
        }
        public static void Send_PlayerExtraSpiritToParty(int partynum, int Index)
        {
            {
                int extra_vitality = PStruct.GetExtraSpirit(Index);

                string packet = "";
                packet += Index + ";"; packet += extra_vitality + ";";

                SendToParty(partynum, String.Format("<80>{0}</80>\n", packet));
            }
        }
        public static void Send_PlayerAtrToMap(int Index)
        {
            {

                int charMap = PStruct.character[Index, PStruct.player[Index].SelectedChar].Map;
                int charFire = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Fire);
                int charEarth = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Earth);
                int charWater = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Water);
                int charWind = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Wind);
                int charDark = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Dark);
                int charLight = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Light);
                int charPoints = (PStruct.character[Index, PStruct.player[Index].SelectedChar].Points);
                
                string packet = "";
                packet += Index + ";"; packet += charFire + ";"; packet += charEarth + ";";
                packet += charWater + ";"; packet += charWind + ";";
                packet += charDark + ";"; packet += charLight + ";"; packet += charPoints + ";";

                SendToMap(charMap, String.Format("<34>{0}</34>\n", packet));
            }
        }
        public static void Send_PlayerExp(int index)
        {
            {
                SendToUser(index, String.Format("<35>{0}</35>\n", PStruct.character[index, PStruct.player[index].SelectedChar].Exp));
            }
        }
        public static void Send_PlayerSkillPoints(int index)
        {
            {
                SendToUser(index, String.Format("<36>{0}</36>\n", PStruct.character[index, PStruct.player[index].SelectedChar].SkillPoints));
            }
        }
        public static void Send_PlayerLevel(int index, int user)
        {
            {
                SendToUser(user, String.Format("<37 {0}>{1}</37>\n", index, PStruct.character[index, PStruct.player[index].SelectedChar].Level));
            }
        }
        public static void Send_PartyRequest(int index, int user)
        {
            {
                SendToUser(user, String.Format("<38>{0}</38>\n", index));
            }
        }
        public static void Send_PartyDataTo(int partynum, int index)
        {
            {
                string packet = "";
                int partymemberscount = PStruct.GetPartyMembersCount(partynum);
                packet = packet + (partymemberscount) + ",";
                packet = packet + PStruct.party[partynum].leader + ",";
                for (int i = 1; i <= partymemberscount; i++)
                {
                        packet = packet + PStruct.partymembers[partynum, i].index + ",";
                }
                SendToUser(index, String.Format("<39>{0}</39>\n", packet));
            }
        }
        public static void Send_PartyDataToParty(int partynum)
        {
            {
                string packet = "";
                int partymemberscount = PStruct.GetPartyMembersCount(partynum);
                packet = packet + (partymemberscount) + ",";
                packet = packet + PStruct.party[partynum].leader + ",";
                for (int i = 1; i <= partymemberscount; i++)
                {
                    packet = packet + PStruct.partymembers[partynum, i].index + ",";
                }
                SendToParty(partynum, String.Format("<39>{0}</39>\n", packet));
            }
        }
        public static void Send_PartyKick(int index)
        {
            {
                SendToUser(index, String.Format("<40></40>\n"));
            }
        }
        public static void Send_PartyVital(int partynum, int index)
        {
            {
                string packet = "";
                int partymemberscount = PStruct.GetPartyMembersCount(partynum);
                for (int i = 1; i <= partymemberscount; i++)
                {
                    packet = packet + PStruct.character[PStruct.partymembers[partynum, i].index, PStruct.player[PStruct.partymembers[partynum, i].index].SelectedChar].Vitality + ",";
                    packet = packet + PStruct.character[PStruct.partymembers[partynum, i].index, PStruct.player[PStruct.partymembers[partynum, i].index].SelectedChar].Spirit + ",";
                }

                SendToUser(index, String.Format("<40>{0}</40>\n", packet));
            }
        }
        public static void Send_PartyChange(int index, int user)
        {
            {
                SendToUser(user, String.Format("<41>{0}</41>\n", index));
            }
        }
        public static void Send_TradeRequest(int index, int user)
        {
            {
                SendToUser(user, String.Format("<42>{0}</42>\n", index));
            }
        }
        public static void Send_GuildRequest(int index, int user)
        {
            {
                SendToUser(user, String.Format("<68>{0}</68>\n", index));
            }
        }
        public static void Send_FriendRequest(int index, int user)
        {
            {
                SendToUser(user, String.Format("<86>{0}</86>\n", index));
            }
        }
        public static void Send_PetAttack(int index, int target, int targettype)
        {
            string packet = "";
            packet = packet + index + ";";
            packet = packet + target + ";";
            packet = packet + targettype + ";";
            SendToMap(PStruct.character[index, PStruct.player[index].SelectedChar].Map, String.Format("<85>{0}</85>\n", packet));
        }
        public static void Send_TradeOffers(int index, int user)
        {
            {
                string packet = "";
                int tradeofferscount = PStruct.GetPlayerTradeOffersCount(index);
                packet = packet + (index) + ";";
                packet = packet + tradeofferscount + ";";
                packet = packet + PStruct.tempplayer[index].TradeG + ";";
                for (int i = 1; i <= tradeofferscount ; i++)
                {
                    packet = packet + PStruct.tradeslot[index, i].item +";";
                }
                SendToUser(user, String.Format("<43>{0}</43>\n", packet));
            }
        }
        public static void Send_TradeAccept(int user, int code)
        {
            {
                SendToUser(user, String.Format("<44>{0}</44>\n", code));
            }
        }
        public static void Send_TradeRefuse(int user, int code)
        {
            {
                SendToUser(user, String.Format("<45>{0}</45>\n", code));
            }
        }
        public static void Send_TradeClose(int user)
        {
            {
                SendToUser(user, String.Format("<46></46>\n"));
            }
        }
        public static void Send_PlayerG(int user)
        {
            {
                SendToUser(user, String.Format("<47>{0}</47>\n", PStruct.character[user, PStruct.player[user].SelectedChar].Gold));
            }
        }
        public static void Send_PlayerC(int user)
        {
            {
                SendToUser(user, String.Format("<48>{0}</48>\n", PStruct.character[user, PStruct.player[user].SelectedChar].Cash));
            }
        }
        public static void Send_TradeG(int index, int user)
        {
            {
                SendToUser(user, String.Format("<49 {0}>{1}</49>\n", index, PStruct.tempplayer[index].TradeG));
            }
        }
        public static void Send_AllQuests(int index)
        {
            {
                string packet = "";
                int questcount = PStruct.GetPlayerQuestsCount(index);
                packet = packet + questcount + ";";
                for (int g = 1; g < Globals.MaxQuestGivers; g++)
                {
                    for (int q = 1; q < Globals.MaxQuestPerGiver; q++)
                    {
                        if (PStruct.queststatus[index, g, q].status != 0)
                        {
                            packet = packet + g + ";";
                            packet = packet + q + ";";
                            packet = packet + PStruct.queststatus[index, g, q].status + ";";
                            for (int k = 1; k < Globals.MaxQuestKills; k++)
                            {
                                 packet = packet + PStruct.questkills[index, g, q, k].kills + ";";
                            }
                            for (int a = 1; a < Globals.MaxQuestActions; a++)
                            {
                                string actioninfo = "0";

                                if (PStruct.questactions[index, g, q, a].actiondone == true) { actioninfo = "1"; }
                                if (PStruct.questactions[index, g, q, a].actiondone == false) { actioninfo = "0"; }

                                 packet = packet + actioninfo + ";";
                            }
                        }
                    }
                }
                SendToUser(index, String.Format("<50>{0}</50>\n", packet));
            }
        }
        public static void Send_QuestKill(int index, int g, int q, int k)
        {
            {
                SendToUser(index, String.Format("<51>{0}</51>\n", g + ";" + q + ";" + k + ";" + PStruct.questkills[index, g, q, k].kills));
            }
        }
        public static void Send_QuestAction(int index, int g, int q, int a)
        {
            {
                string actioninfo = "0";

                if (PStruct.questactions[index, g, q, a].actiondone == true) { actioninfo = "1"; }
                if (PStruct.questactions[index, g, q, a].actiondone == false) { actioninfo = "0"; }

                SendToUser(index, String.Format("<62>{0}</62>\n", g + ";" + q + ";" + a + ";" + actioninfo));
            }
        }
        public static void Send_KnockBack(int map, int type, int index, int dir, int range)
        {
            {
                SendToMap(map, String.Format("<52>{0}</52>\n", type + ";" + index + ";" + dir + ";" + range));
            }
        }
        public static void Send_Sleep(int map, int type, int index, int is_sleeping)
        {
            {
                SendToMap(map, String.Format("<53>{0}</53>\n", type + ";" + index + ";" + is_sleeping));
            }
        }
        public static void Send_Stun(int map, int type, int index, int is_stunned)
        {
            {
                SendToMap(map, String.Format("<54>{0}</54>\n", type + ";" + index + ";" + is_stunned));
            }
        }
        public static void Send_SleepToUser(int user, int type, int index, int is_sleeping)
        {
            {
                SendToMap(user, String.Format("<53>{0}</53>\n", type + ";" + index + ";" + is_sleeping));
            }
        }
        public static void Send_StunToUser(int user, int type, int index, int is_stunned)
        {
            {
                SendToUser(user, String.Format("<54>{0}</54>\n", type + ";" + index + ";" + is_stunned));
            }
        }
        public static void Send_Shop(int index, int shopnum)
        {
            {
                string packet = "";
                int item_count = ShopStruct.shop[shopnum].item_count;
                packet = packet + item_count + ";";
                for (int s = 1; s <= item_count; s++)
                {
                    packet = packet + s + ";";
                    packet = packet + ShopStruct.shopitem[shopnum, s].type + ";";
                    packet = packet + ShopStruct.shopitem[shopnum, s].num + ";";
                    packet = packet + ShopStruct.shopitem[shopnum, s].value + ";";
                    packet = packet + ShopStruct.shopitem[shopnum, s].refin + ";";
                    packet = packet + ShopStruct.shopitem[shopnum, s].price + ";";
                }
                SendToUser(index, String.Format("<55>{0}</55>\n", packet));
            }
        }
        public static void Send_Craft(int index)
        {
            {
                string packet = "";
                for (int c = 1; c < Globals.Max_Craft; c++)
                {
                    packet = packet + c + ";";
                    packet = packet + PStruct.craft[index, c].type + ";";
                    packet = packet + PStruct.craft[index, c].num + ";";
                    packet = packet + PStruct.craft[index, c].value + ";";
                    packet = packet + PStruct.craft[index, c].refin + ";";
                }
                SendToUser(index, String.Format("<56>{0}</56>\n", packet));
            }
        }
        public static void Send_Profs(int index)
        {
            {
                //PStruct.character[index, PStruct.player[index].SelectedChar].Prof_Type[1] = 2;
                //PStruct.character[index, PStruct.player[index].SelectedChar].Prof_Level[1] = 3;
                //PStruct.character[index, PStruct.player[index].SelectedChar].Prof_Exp[1] = 2;
                string packet = "";
                int prof_count = Globals.Max_Profs_Per_Char - 1;
                packet = packet + prof_count + ";";
                for (int j = 1; j < Globals.Max_Profs_Per_Char; j++)
                {
                    packet = packet + j + ";";
                    packet = packet + PStruct.character[index, PStruct.player[index].SelectedChar].Prof_Type[j] + ";";
                    packet = packet + PStruct.character[index, PStruct.player[index].SelectedChar].Prof_Level[j] + ";";
                    packet = packet + PStruct.character[index, PStruct.player[index].SelectedChar].Prof_Exp[j] + ";";
                }
                SendToUser(index, String.Format("<60>{0}</60>\n", packet));
            }
        }
        public static void Send_ProfEXP(int index, int profnum)
        {
            SendToUser(index, String.Format("<57>{0};{1}</57>\n", profnum, PStruct.character[index, PStruct.player[index].SelectedChar].Prof_Exp[profnum]));
        }
        public static void Send_ProfLEVEL(int index, int profnum)
        {
            SendToUser(index, String.Format("<58>{0};{1}</58>\n", profnum, PStruct.character[index, PStruct.player[index].SelectedChar].Prof_Level[profnum]));
        }
        public static void Send_EventGraphic(int index, int event_id, string graphic, int graphic_index, byte is_tile = 0, byte dir = 2)
        {
            SendToUser(index, String.Format("<59>{0}</59>\n", event_id + ";" + graphic + ";" + graphic_index + ";" + is_tile + ";" + dir));
        }
        public static void Send_EventGraphicToMap(int map, int event_id, string graphic, int graphic_index, byte is_tile = 0, byte dir = 2)
        {
            SendToMap(map, String.Format("<59>{0}</59>\n", event_id + ";" + graphic + ";" + graphic_index + ";" + is_tile + ";" + dir));
        }
        public static void Send_BankSlots(int index)
        {
            {
                string packet = "";
                int bank_count = Globals.Max_BankSlots - 1;
                packet = packet + bank_count + ";";
                for (int b = 1; b < Globals.Max_BankSlots; b++)
                {
                    packet = packet + b + ";";
                    packet = packet + PStruct.player[index].bankslot[b].type + ";";
                    packet = packet + PStruct.player[index].bankslot[b].num + ";";
                    packet = packet + PStruct.player[index].bankslot[b].value + ";";
                    packet = packet + PStruct.player[index].bankslot[b].refin + ";";
                    packet = packet + PStruct.player[index].bankslot[b].exp + ";";
                }
                SendToUser(index, String.Format("<61>{0}</61>\n", packet));
            }
        }
        public static void Send_PShopSlots(int shopindex, int index)
        {
            {
                string packet = "";
                int pshop_count = Globals.Max_PShops - 1;
                packet = packet + shopindex + ";";
                packet = packet + pshop_count + ";";
                for (int b = 1; b < Globals.Max_PShops; b++)
                {
                    packet = packet + b + ";";
                    packet = packet + PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[b].type + ";";
                    packet = packet + PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[b].num + ";";
                    packet = packet + PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[b].value + ";";
                    packet = packet + PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[b].refin + ";";
                    packet = packet + PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[b].exp + ";";
                    packet = packet + PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[b].price + ";";
                }
                SendToUser(index, String.Format("<81>{0}</81>\n", packet));
            }
        }
        public static void Send_PlayerShoppingTo(int user, int index)
        {
            int value = 0;
            if (PStruct.tempplayer[index].Shopping) { value = 1; }

            SendToUser(user, String.Format("<82>{0};{1}</82>\n", index, value));
           
        }
        public static void Send_PlayerShoppingToMap(int index)
        {
            int value = 0;
            if (PStruct.tempplayer[index].Shopping) { value = 1; }

            SendToMap(PStruct.character[index, PStruct.player[index].SelectedChar].Map, String.Format("<82>{0};{1}</82>\n", index, value));

        }
        public static void Send_Premmy(int index)
        {
            int result = 0;

            if (PStruct.IsPlayerPremmy(index)) { result = 1; }

            SendToUser(index, String.Format("<63>{0};{1}</63>\n", result, PStruct.player[index].Premmy));
        }

        public static void Send_WPoints(int index)
        {
            SendToUser(index, String.Format("<64>{0}</64>\n", PStruct.player[index].WPoints));
        }

        public static void Send_Recipe(int index, int recipetype, int recipenum)
        {
            {
                string packet = "";
                int recipe_count = Globals.Max_Craft - 1;
                packet = packet + recipe_count + ";";

                for (int r = 1; r < Globals.Max_Craft; r++)
                {
                    packet = packet + r + ";";
                    packet = packet + MStruct.craftrecipe[recipetype, recipenum, r].type + ";";
                    packet = packet + MStruct.craftrecipe[recipetype, recipenum, r].num + ";";
                    packet = packet + MStruct.craftrecipe[recipetype, recipenum, r].value + ";";
                    packet = packet + MStruct.craftrecipe[recipetype, recipenum, r].refin + ";";
                }
                SendToUser(index, String.Format("<65>{0}</65>\n", packet));
            }
        }

        public static void Send_GuildTo(int user, int index)
        {
            if (PStruct.character[index, PStruct.player[index].SelectedChar].Guild <= 0) { return; }
            SendToUser(user, String.Format("<66>{0}</66>\n", index + ";" + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].name + ";" + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].shield + ";" + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].hue));
        }
        public static void Send_GuildToMap(int mapnum, int index)
        {
            if (PStruct.character[index, PStruct.player[index].SelectedChar].Guild <= 0) { return; }
            SendToMap(mapnum, String.Format("<66>{0}</66>\n", index + ";" + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].name + ";" + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].shield + ";" + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].hue));
        }
        public static void Send_GuildToMapBut(int mapnum, int index)
        {
            if (PStruct.character[index, PStruct.player[index].SelectedChar].Guild <= 0) { return; }
            SendToMapBut(index, mapnum, String.Format("<66>{0}</66>\n", index + ";" + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].name + ";" + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].shield + ";" + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].hue));
        }
        public static void Send_CompleteGuild(int index)
        {
            {         
// PStruct.character[index, PStruct.player[index].SelectedChar].Guild = 1;
                if (PStruct.character[index, PStruct.player[index].SelectedChar].Guild <= 0) { return; }

                string packet = "";
                int member_count = GStruct.GetMember_Count(PStruct.character[index, PStruct.player[index].SelectedChar].Guild);

                if (member_count <= 0) { return; }

                packet = packet + member_count + ";";
                packet = packet + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].name + ";";
                packet = packet + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].level + ";";
                packet = packet + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].exp + ";";
                packet = packet + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].shield + ";";
                packet = packet + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].hue + ";";
                packet = packet + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].leader + ";";

                for (int i = 1; i <= member_count; i++)
                {
                    packet = packet + i + ";";
                    packet = packet + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].memberlist[i] + ";";
                    packet = packet + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].membersprite[i] + ";";
                    packet = packet + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].memberhue[i] + ";";
                    packet = packet + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].membersprite_index[i] + ";";
                }

                SendToUser(index, String.Format("<67>{0}</67>\n", packet));
            }
        }
        public static void Send_CompleteClearGuild(int index)
        {
            {
                // PStruct.character[index, PStruct.player[index].SelectedChar].Guild = 1;

                string packet = "";
                int member_count = 0;

                packet = packet + member_count + ";";
                packet = packet + "" + ";";
                packet = packet + 0 + ";";
                packet = packet + 0 + ";";
                packet = packet + 0 + ";";
                packet = packet + 0 + ";";
                packet = packet + 0 + ";";

                for (int i = 1; i <= member_count; i++)
                {
                    packet = packet + i + ";";
                    packet = packet + "" + ";";
                    packet = packet + "" + ";";
                    packet = packet + 0 + ";";
                    packet = packet + 0 + ";";
                }

                SendToUser(index, String.Format("<67>{0}</67>\n", packet));
            }
        }
        public static void Send_CompleteGuildToGuild(int index)
        {
            {
                if (PStruct.character[index, PStruct.player[index].SelectedChar].Guild <= 0) { return; }

                string packet = "";
                int member_count = GStruct.GetMember_Count(PStruct.character[index, PStruct.player[index].SelectedChar].Guild);

                if (member_count <= 0) { return; }

                packet = packet + member_count + ";";
                packet = packet + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].name + ";";
                packet = packet + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].level + ";";
                packet = packet + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].exp + ";";
                packet = packet + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].shield + ";";
                packet = packet + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].hue + ";";
                packet = packet + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].leader + ";";

                for (int i = 1; i <= member_count; i++)
                {
                    packet = packet + i + ";";
                    packet = packet + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].memberlist[i] + ";";
                    packet = packet + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].membersprite[i] + ";";
                    packet = packet + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].memberhue[i] + ";";
                    packet = packet + GStruct.guild[PStruct.character[index, PStruct.player[index].SelectedChar].Guild].membersprite_index[i] + ";";
                }

                SendToGuild(PStruct.character[index, PStruct.player[index].SelectedChar].Guild, String.Format("<67>{0}</67>\n", packet));
            }
        }
        public static void Send_CompleteGuildToGuildG(int guildnum)
        {
            {
                if (guildnum <= 0) { return; }

                string packet = "";
                int member_count = GStruct.GetMember_Count(guildnum);

                if (member_count <= 0) { return; }

                packet = packet + member_count + ";";
                packet = packet + GStruct.guild[guildnum].name + ";";
                packet = packet + GStruct.guild[guildnum].level + ";";
                packet = packet + GStruct.guild[guildnum].exp + ";";
                packet = packet + GStruct.guild[guildnum].shield + ";";
                packet = packet + GStruct.guild[guildnum].hue + ";";
                packet = packet + GStruct.guild[guildnum].leader + ";";

                for (int i = 1; i <= member_count; i++)
                {
                    packet = packet + i + ";";
                    packet = packet + GStruct.guild[guildnum].memberlist[i] + ";";
                    packet = packet + GStruct.guild[guildnum].membersprite[i] + ";";
                    packet = packet + GStruct.guild[guildnum].memberhue[i] + ";";
                    packet = packet + GStruct.guild[guildnum].membersprite_index[i] + ";";
                }

                SendToGuild(guildnum, String.Format("<67>{0}</67>\n", packet));
            }
        }
        public static void Send_PlayerDeathToMap(int index)
        {
            int value = 0;

            if (PStruct.tempplayer[index].isDead) { value = 1; }

            SendToMap(PStruct.character[index, PStruct.player[index].SelectedChar].Map, String.Format("<69>{0};{1}</69>\n", index, value));
        }

        public static void Send_PlayerDeathTo(int user, int index)
        {
            int value = 0;

            if (PStruct.tempplayer[index].isDead) { value = 1; }

            SendToUser(user, String.Format("<69>{0};{1}</69>\n", index, value));
        }

        public static void Send_PlayerPvpToMap(int index)
        {
            int value;
            if (PStruct.character[index, PStruct.player[index].SelectedChar].PVP) { value = 1; } else { value = 0; }
            SendToMap(PStruct.character[index, PStruct.player[index].SelectedChar].Map, String.Format("<70>{0};{1}</70>\n", index, value));
        }
        public static void Send_PlayerPvpTo(int user, int index)
        {
            int value;
            if (PStruct.character[index, PStruct.player[index].SelectedChar].PVP) { value = 1; } else { value = 0; }
            SendToUser(user, String.Format("<70>{0};{1}</70>\n", index, value));
        }
        public static void Send_PlayerPvpChangeTimer(int index)
        {
            long result = PStruct.character[index, PStruct.player[index].SelectedChar].PVPChangeTimer - Loops.TickCount.ElapsedMilliseconds;
            if (result < 0) { result = 0; }
            SendToUser(index, String.Format("<71>{0}</71>\n", result));
        }
        public static void Send_PlayerPvpBanTimer(int index)
        {
            long result = PStruct.character[index, PStruct.player[index].SelectedChar].PVPBanTimer - Loops.TickCount.ElapsedMilliseconds;
            if (result < 0) { result = 0; }
            SendToUser(index, String.Format("<72>{0}</72>\n", result));
        }
        public static void Send_PlayerSoreToMap(int index)
        {
            int value;
            if (PStruct.PlayerIsSore(index)) { value = 1; } else { value = 0; }
            SendToMap(PStruct.character[index, PStruct.player[index].SelectedChar].Map, String.Format("<73>{0};{1}</73>\n", index, value));
        }
        public static void Send_PlayerSoreTo(int user, int index)
        {
            int value;
            if (PStruct.PlayerIsSore(index)) { value = 1; } else { value = 0; }
            SendToUser(user, String.Format("<73>{0};{1}</73>\n", index, value));
        }
        public static void Send_PlayerPvpSoreTimer(int index)
        {
            long result = PStruct.character[index, PStruct.player[index].SelectedChar].PVPPenalty - Loops.TickCount.ElapsedMilliseconds;
            if (result < 0) { result = 0; }
            SendToUser(index, String.Format("<74>{0}</74>\n", result));
        }
        public static void Send_PlayerSkillCooldown(int index, int slot, int cooldown)
        {
            SendToUser(index, String.Format("<75>{0};{1}</75>\n", slot, cooldown));
        }
        public static void Send_NStatus(int index, string msg)
        {
            SendToUser(index, String.Format("<76>{0}</76>\n", msg));
        }
        public static void Send_Notice(int index)
        {
            SendToUser(index, String.Format("<77>{0}</77>\n", Globals.NOTICE));
        }
        public static void Send_BrokeSkill(int index)
        {
            SendToUser(index, String.Format("<78></78>\n"));
        }
       // public static void Send_PlayerVitality(string map, int index, int vitality)
        //{
         //   {
         //       SendToMap(map, String.Format("<25 {0}>{1}</25>\n", index, vitality));
          //  }
       // }
    }
}
