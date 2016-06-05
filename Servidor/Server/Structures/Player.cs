using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACESERVER
{
    class PStruct
    {
        public static PStruct.Player[] player = new PStruct.Player[Globals.MaxPlayers];
        public static PStruct.Character[,] character = new PStruct.Character[Globals.MaxPlayers, 3];
        public static PStruct.TempPlayer[] tempplayer = new PStruct.TempPlayer[Globals.MaxPlayers];
        public static PStruct.Skill[,] skill = new PStruct.Skill[Globals.MaxPlayers, 17];
        public static PStruct.InvSlot[,] invslot = new PStruct.InvSlot[Globals.MaxPlayers, Globals.MaxInvSlot];
        public static PStruct.Craft[,] craft = new PStruct.Craft[Globals.MaxPlayers, Globals.Max_Craft];
        public static PStruct.QuestStatus[,,] queststatus = new PStruct.QuestStatus[Globals.MaxPlayers, Globals.MaxQuestGivers, Globals.MaxQuestPerGiver];
        public static PStruct.QuestKills[,,,] questkills = new PStruct.QuestKills[Globals.MaxPlayers, Globals.MaxQuestGivers, Globals.MaxQuestPerGiver, Globals.MaxQuestKills];
        public static PStruct.QuestActions[,,,] questactions = new PStruct.QuestActions[Globals.MaxPlayers, Globals.MaxQuestGivers, Globals.MaxQuestPerGiver, Globals.MaxQuestActions];
        public static PStruct.TradeSlot[,] tradeslot = new PStruct.TradeSlot[Globals.MaxPlayers, 17];
        public static PStruct.Hotkey[,] hotkey = new PStruct.Hotkey[Globals.MaxPlayers, 11];
        public static PStruct.Party[] party = new PStruct.Party[100];
        public static PStruct.PartyMembers[,] partymembers = new PStruct.PartyMembers[100, 5];
        public static PStruct.PTempSpell[,] ptempspell = new PStruct.PTempSpell[Globals.MaxPlayers, Globals.MaxPTempSpells];
        public static PStruct.PPassiveEffect[,] ppassiveffect = new PStruct.PPassiveEffect[Globals.MaxPlayers, Globals.MaxPassiveEffects];
        public static PStruct.PSpellBuff[,] pspellbuff = new PStruct.PSpellBuff[Globals.MaxPlayers, Globals.MaxSpellBuffs];

        public struct Player
        {
            public string Email;
            public string Password;
            public string Username;
            public string Premmy;
            public bool Confirmed;
            public string Banned;
            public int SelectedChar;
            public int WPoints;
            public BankSlot[] bankslot;
            public int skin_count;
            public bool[] skin;
            public FriendList[] friend;
        }

        public struct FriendList
        {
            public string name;
            public string sprite;
            public int sprite_index;
            public int classid;
            public int level;
            public string guildname;
        }

        public struct BankSlot
        {
            public int type;
            public int num;
            public int value;
            public int refin;
            public int exp;
        }

        public struct PShopSlot
        {
            public int type;
            public int num;
            public int value;
            public int refin;
            public int price;
            public int exp;
        }

        public struct Character
        {
            public string CharacterName;
            public int SpriteIndex;
            public int ClassId;
            public string Sprite;
            public int Level;
            public int Exp;
            public int Fire;
            public int Earth;
            public int Water;
            public int Wind;
            public int Dark;
            public int Light;
            public int Points;
            public int Map;
            public byte X;
            public byte Y;
            public byte Dir;
            public string Equipment;
            public int Vitality;
            public int Spirit;
            public int Access;
            public int SkillPoints;
            public int Gold;
            public int Cash;
            public int Hue;
            public int Gender;
            public int Guild;
            public long PVPChangeTimer;
            public long PVPBanTimer;
            public long PVPPenalty;
            public bool PVP;
            public int BootMap;
            public byte BootX;
            public byte BootY;
            //Profissões
            public int[] Prof_Type;
            public int[] Prof_Level;
            public int[] Prof_Exp;
            public bool[] Chest;
            public PShopSlot[] pshopslot;
        }

        public struct Skill
        {
            public int num;
            public int level;
            public long cooldown;
        }

        public struct InvSlot
        {
            public string item;
        }

        public struct Craft
        {
            public int type;
            public int num;
            public int value;
            public int refin;
            public int exp;
        }

        public struct QuestStatus
        {
            public int status;
        }

        public struct QuestKills
        {
            public int kills;
        }

        public struct QuestActions
        {
            public bool actiondone;
        }

        public struct Hotkey
        {
            public byte type;
            public int num;
        }

        public struct TempPlayer
        {
            public bool ingame;
            public int MaxVitality;
            public int Vitality;
            public int MaxSpirit;
            public int Spirit;
            public bool Warping;
            public byte targettype;
            public int target;
            public long skilltimer;
            public int preparingskill;
            public int preparingskillslot;
            public double  movespeed;
            public long MoveTimer;
            public long InviteTimer;
            public int Inviting;
            public int Invited;
            public int Party;
            public int InTrade;
            public int TradeG;
            public int TradeStatus;
            public long RegenTimer;
            public bool Sleeping;
            public long SleepTimer;
            public bool Stunned;
            public long StunTimer;
            public bool Slowed;
            public long SlowTimer;
            public long AttackTimer;
            public int InShop;
            public bool InCraft;
            public bool InBank;
            public int CraftType;
            public int CraftItem;
            public bool Blind;
            public long BlindTimer;
            public bool Logged;
            public long DataTimer;
            public long ChatTimer;
            public int ChatExcept;
            public long AllChatTimer;
            public bool isDead;
            public int ActivationCode;
            public bool SORE;
            public bool Reflect;
            public long ReflectTimer;
            public bool Shopping;
            public int InPShop;
            public bool isFrozen;
            public byte Sheathe;
            public byte ReduceDamage;
            public long PetTimer;
            public int PetTarget;
            public int PetTargetType;
            public int LastTarget;
            public int LastTargetType;
        }

        public struct PTempSpell
        {
            public bool active;
            public int attacker;
            public int spellnum;
            public long timer;
            public int repeats;
            public int anim;
            public int area_range;
            public bool is_line;
            public bool is_heal;
            public bool fast_buff;
        }

        public struct PPassiveEffect
        {
            public bool active;
            public int type;
            public long timer;
            public int spellnum;
            public int targettype;
            public int target;
        }

        public struct PSpellBuff
        {
            public bool active;
            public int type;
            public long timer;
            public int value; //porcentagem
        }

        public struct Party
        {
            public int leader;
            public bool active;
        }
        public struct PartyMembers
        {
            public int index;
        }
        public struct TradeSlot
        {
            public string item;
        }
        public static void ResetPlayerStatus(int index)
        {
            int totalpoints = 0;

            totalpoints += PStruct.character[index, PStruct.player[index].SelectedChar].Earth - 1;
            totalpoints += PStruct.character[index, PStruct.player[index].SelectedChar].Wind - 1;
            totalpoints += PStruct.character[index, PStruct.player[index].SelectedChar].Dark - 1;
            totalpoints += PStruct.character[index, PStruct.player[index].SelectedChar].Light - 1;
            totalpoints += PStruct.character[index, PStruct.player[index].SelectedChar].Water- 1;
            totalpoints += PStruct.character[index, PStruct.player[index].SelectedChar].Fire - 1;

            PStruct.character[index, PStruct.player[index].SelectedChar].Earth = 1;
            PStruct.character[index, PStruct.player[index].SelectedChar].Wind = 1;
            PStruct.character[index, PStruct.player[index].SelectedChar].Dark = 1;
            PStruct.character[index, PStruct.player[index].SelectedChar].Light = 1;
            PStruct.character[index, PStruct.player[index].SelectedChar].Water = 1;
            PStruct.character[index, PStruct.player[index].SelectedChar].Fire = 1;

            PStruct.character[index, PStruct.player[index].SelectedChar].Points += totalpoints;
            SendData.Send_PlayerAtrToMap(index);
            SendData.Send_MsgToPlayer(index, "Seus atributos foram resetados com sucesso!", Globals.ColorGreen, Globals.Msg_Type_Server);
        }
        public static int GetFriendOpenSlot(int index)
        {
            for (int i = 1; i < Globals.Max_Friends; i++)
            {
                if (String.IsNullOrEmpty(player[index].friend[i].name))
                {
                    return i;
                }
            }
            return 0;
        }
        public static bool FriendNameExist(int index, string name)
        {
            for (int i = 1; i < Globals.Max_Friends; i++)
            {
                if (player[index].friend[i].name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool FriendIsOnline(int index, int friendnum)
        {
            for (int i = 1; i <= Globals.Player_HighIndex; i++)
            {
                if (player[index].friend[friendnum].name ==  PStruct.character[i, PStruct.player[i].SelectedChar].CharacterName)
                {
                    return true;
                }
            }
            return false;
        }
        public static int GetPlayerFriendsCount(int index)
        {
            int count = 0;
            for (int i = 1; i < Globals.Max_Friends; i++)
            {
                if (!String.IsNullOrEmpty(player[index].friend[i].name))
                {
                    count += 1;
                }
                else
                {
                    break;
                }
            }
            return count;
        }
        public static void RefreshFriends(int index)
        {
            int friendscount = GetPlayerFriendsCount(index);
            for (int i = 1; i <= friendscount; i++)
            {
                //Analisar todos os jogadores online
                for (int y = 0; y <= Globals.Player_HighIndex; y++)
                {
                    if (PStruct.player[index].friend[i].name == PStruct.character[y, PStruct.player[y].SelectedChar].CharacterName) ;
                    {
                        PStruct.player[index].friend[i].sprite = PStruct.character[y, PStruct.player[y].SelectedChar].Sprite;
                        PStruct.player[index].friend[i].sprite_index = PStruct.character[y, PStruct.player[y].SelectedChar].SpriteIndex;
                        PStruct.player[index].friend[i].classid = PStruct.character[y, PStruct.player[y].SelectedChar].ClassId;
                        PStruct.player[index].friend[i].level = PStruct.character[y, PStruct.player[y].SelectedChar].Level;
                        PStruct.player[index].friend[i].guildname = GStruct.guild[PStruct.character[y, PStruct.player[y].SelectedChar].Guild].name;
                    }
                }
            }
            SendData.Send_PlayerFriends(index);
        }
        public static bool AddFriend(int index, int friendnum)
        {
            //Valor principal
            int friendslot = GetFriendOpenSlot(index);
            if (friendslot <= 0) { return false; }

            //Verificar se já não está na lista
            if (FriendNameExist(index, PStruct.character[friendnum, PStruct.player[friendnum].SelectedChar].CharacterName))
            {
                return false;
            }

            //Tentar adicionar
            try
            {
                PStruct.player[index].friend[friendslot].name = PStruct.character[friendnum, PStruct.player[friendnum].SelectedChar].CharacterName;
                PStruct.player[index].friend[friendslot].sprite = PStruct.character[friendnum, PStruct.player[friendnum].SelectedChar].Sprite;
                PStruct.player[index].friend[friendslot].sprite_index = PStruct.character[friendnum, PStruct.player[friendnum].SelectedChar].SpriteIndex;
                PStruct.player[index].friend[friendslot].classid = PStruct.character[friendnum, PStruct.player[friendnum].SelectedChar].ClassId;
                PStruct.player[index].friend[friendslot].level = PStruct.character[friendnum, PStruct.player[friendnum].SelectedChar].Level;
                PStruct.player[index].friend[friendslot].guildname = GStruct.guild[PStruct.character[friendnum, PStruct.player[friendnum].SelectedChar].Guild].name;
                if (String.IsNullOrEmpty(PStruct.player[index].friend[friendslot].guildname)) { PStruct.player[index].friend[friendslot].guildname = ""; }
                SendData.Send_PlayerFriends(index);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool DeleteFriend(int index, int friendnum)
        {
            if (friendnum == 0) { return false; }
            try
            {
                int friendscount = GetPlayerFriendsCount(index) + 1;
                PStruct.player[index].friend[friendnum].name = "";
                PStruct.player[index].friend[friendnum].sprite = "";
                PStruct.player[index].friend[friendnum].sprite_index = 0;
                PStruct.player[index].friend[friendnum].classid = 0;
                PStruct.player[index].friend[friendnum].level = 0;
                PStruct.player[index].friend[friendnum].guildname = "";
                if (friendnum < friendscount)
                {
                    for (int i = friendnum + 1; i <= friendscount; i++)
                    {
                        PStruct.player[index].friend[i - 1].name = PStruct.player[index].friend[i].name;
                        PStruct.player[index].friend[i - 1].sprite = PStruct.player[index].friend[i].sprite;
                        PStruct.player[index].friend[i - 1].sprite_index = PStruct.player[index].friend[i].sprite_index;
                        PStruct.player[index].friend[i - 1].classid = PStruct.player[index].friend[i].classid;
                        PStruct.player[index].friend[i - 1].level = PStruct.player[index].friend[i].level;
                        PStruct.player[index].friend[i - 1].guildname = PStruct.player[index].friend[i].guildname;
                    }
                }
                SendData.Send_PlayerFriends(index);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsPlayerPremmy(int index)
        {
            DateTime myDate = DateTime.Parse(player[index].Premmy);
            int result = DateTime.Compare(myDate, DateTime.Now);
            
            if (result <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool IsPlayerBanned(int index)
        {
            DateTime myDate = DateTime.Parse(player[index].Banned);
            int result = DateTime.Compare(myDate, DateTime.Now);

            if (result <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void PlayerAddPremmy(int index)
        {
            //return;
            DateTime myDate = DateTime.Parse(player[index].Premmy);
            myDate = myDate.AddDays(30);
            player[index].Premmy = myDate.ToString();
            Console.WriteLine(player[index].Premmy);
            Database.SaveAccount(index);
        }
        public static void InitializePlayerArrays()
        {
            for (int i = 1; i < Globals.MaxPlayers; i++)
            {
                PStruct.player[i].bankslot = new BankSlot[Globals.Max_BankSlots];
                PStruct.player[i].friend = new FriendList[Globals.Max_Friends];
                for (int c = 0; c < Globals.MaxChars; c++)
                {
                    PStruct.character[i, c].Prof_Type = new int[Globals.Max_Profs_Per_Char];
                    PStruct.character[i, c].Prof_Level = new int[Globals.Max_Profs_Per_Char];
                    PStruct.character[i, c].Prof_Exp = new int[Globals.Max_Profs_Per_Char];
                    PStruct.character[i, c].Chest = new bool[Globals.Max_Chests];
                    PStruct.character[i, c].pshopslot = new PShopSlot[Globals.Max_PShops];
                }
            }
        }

        public static int GetNumOfInvFreeSlots(int index)
        {
            int count = 0;

            for (int i = 1; i < Globals.MaxInvSlot; i++)
            {
                if (PStruct.invslot[index, i].item == Globals.NullItem) { count += 1; }
            }
            return count;
        }

        public static int GetPlayerProf(int index, int type)
        {
            int prof = 0;

            for (int i = 1; i < Globals.Max_Profs_Per_Char; i++)
            {
                if (PStruct.character[index, PStruct.player[index].SelectedChar].Prof_Type[i] == type)
                {
                    prof = i;
                    break;
                }
            }

            return prof;
        }
        public static int GetActualPlayerQuestPerGiver(int index, int questgiver)
        {
            int quest = 1;

            for (int q = 1; q < Globals.MaxQuestPerGiver; q++)
            {
                if (PStruct.queststatus[index, questgiver, q].status == 2)
                {
                    quest += 1;
                }
            }

            return quest;
        }
        public static int GetPlayerQuestGiversCount(int index)
        {
            int count = 0;

            for (int g = 1; g <= Globals.MaxQuestGivers; g++)
            {
               if (PStruct.queststatus[index, g, 1].status != 0) 
               {        
                   count += 1; 
               }
            }

            return count;
        }
        public static int GetPlayerQuestsCount(int index)
        {
            int count = 0;
                             
            for (int g = 1; g < Globals.MaxQuestGivers; g++)     
            {   
                for (int q = 1; q < Globals.MaxQuestPerGiver; q++)      
                {    
                    if (PStruct.queststatus[index, g, q].status != 0)       
                    {
                        count += 1;          
                    }      
                }
            }

            return count;
        }

        public static int GetPlayerTradeOffersCount(int index)
        {
            int finalindex = 0;

            //Checa o slot que não possúi item
            for (int i = 1; i < Globals.MaxTradeOffers; i++)
            {
                if ((PStruct.tradeslot[index, i].item == Globals.NullItem) || (String.IsNullOrEmpty(PStruct.tradeslot[index, i].item)))
                {
                    finalindex = i;
                    break;
                }
            }

            if (finalindex == 0) { finalindex = 9; }

            int totalcount = finalindex - 1;

            return totalcount;
        }
        public static int GetFreeTradeOffer(int index)
        {
            int finalindex = 0;

            //Checa o slot que possúi o jogador
            for (int i = 1; i < Globals.MaxTradeOffers; i++)
            {
                if ((PStruct.tradeslot[index, i].item == Globals.NullItem) || (String.IsNullOrEmpty(PStruct.tradeslot[index, i].item)))
                {
                    finalindex = i;
                    break;
                }
            }

            return finalindex;
        }
        public static int GetFreeCraft(int index)
        {
            int finalindex = -1;

            //Checa o slot que possúi o jogador
            for (int i = 1; i < Globals.Max_Craft; i++)
            {
                if ((PStruct.craft[index, i].num == 0))
                {
                    finalindex = i;
                    break;
                }
            }

            return finalindex;
        }
        public static int GetPartyPlayerIndex(int partynum, int index)
        {
            int finalindex = 0;

            //Checa o slot que possúi o jogador
            for (int i = 1; i < Globals.MaxPartyMembers; i++)
            {
                if (PStruct.partymembers[partynum, i].index == index)
                {
                    finalindex = i;
                    break;
                }
            }

            return finalindex;
        }
        public static int GetPartyFree()
        {
            int partynum = 0;

            //Checa um grupo livre
            for (int i = 1; i < Globals.MaxParty; i++)
            {
                if (PStruct.party[i].active == false)
                {
                    partynum = i;
                    break;
                }
            }

            return partynum;
        }
        public static int GetPartyMembersCount(int partynum)
        {
            int count = 0;
            
            for (int i = 1; i < Globals.MaxPartyMembers; i++)
            {
                if (partymembers[partynum, i].index > 0) { count += 1; }
            }
            
            return count;
        }
        public static bool IsBusy(int index)
        {
            if ((tempplayer[index].Inviting <= 0) && (tempplayer[index].Invited <= 0)) { return false; }
            if (tempplayer[index].InPShop > 0) { return false; }
            if (tempplayer[index].Shopping) { return false; }
            if (tempplayer[index].InBank) { return false; }
            if (tempplayer[index].InCraft) { return false; }
            if (tempplayer[index].InShop > 0) { return false; }
            if (tempplayer[index].InTrade > 0) { return false; }
            if (tempplayer[index].isDead) { return false; }
            return true;
        }
        public static int GetPlayerHelmet(int index)
        {
            string[] splited = PStruct.character[index, PStruct.player[index].SelectedChar].Equipment.Split(',');

            int Helmet = Convert.ToInt32(splited[0].Split(';')[0]);
            return Helmet;
        }
        public static int GetPlayerArmor(int index)
        {
            string[] splited = PStruct.character[index, PStruct.player[index].SelectedChar].Equipment.Split(',');
            int Armor = Convert.ToInt32(splited[1].Split(';')[0]);
            return Armor;
        }
        public static int GetPlayerWeapon(int index)
        {
          string[] splited = PStruct.character[index, PStruct.player[index].SelectedChar].Equipment.Split(',');

          int Weapon = Convert.ToInt32(splited[2].Split(';')[0]);
          return Weapon;
        }
        public static int GetPlayerShield(int index)
        {
            string[] splited = PStruct.character[index, PStruct.player[index].SelectedChar].Equipment.Split(',');

            int Shield = Convert.ToInt32(splited[3].Split(';')[0]);
            return Shield;
        }
        public static int GetPlayerHelmetRefin(int index)
        {
            string[] splited = PStruct.character[index, PStruct.player[index].SelectedChar].Equipment.Split(',');

            int Helmet = Convert.ToInt32(splited[0].Split(';')[1]);
            return Helmet;
        }
        public static int GetPlayerArmorRefin(int index)
        {
            string[] splited = PStruct.character[index, PStruct.player[index].SelectedChar].Equipment.Split(',');
            int Armor = Convert.ToInt32(splited[1].Split(';')[1]);
            return Armor;
        }
        public static int GetPlayerWeaponRefin(int index)
        {
            string[] splited = PStruct.character[index, PStruct.player[index].SelectedChar].Equipment.Split(',');

            int Weapon = Convert.ToInt32(splited[2].Split(';')[1]);
            return Weapon;
        }
        public static int GetPlayerShieldRefin(int index)
        {
            string[] splited = PStruct.character[index, PStruct.player[index].SelectedChar].Equipment.Split(',');

            int Shield = Convert.ToInt32(splited[3].Split(';')[1]);
            return Shield;
        }
        public static int GetPetExpToNextLevel(int index, int level)
        {
            int exp = 0;
            if (level < 10)
            {
                double exptonextlevel = (level * 100) * 1.2;
                exp = Convert.ToInt32(exptonextlevel);
            }
            if ((level >= 10) && (level < 20))
            {
                double exptonextlevel = (level * 300) * 1.2;
                exp = Convert.ToInt32(exptonextlevel);
            }
            if ((level >= 20) && (level < 30))
            {
                double exptonextlevel = (level * 600) * 1.4;
                exp = Convert.ToInt32(exptonextlevel);
            }
            if ((level >= 30) && (level < 40))
            {
                double exptonextlevel = (level * 900) * 1.5;
                exp = Convert.ToInt32(exptonextlevel);
            }
            if ((level >= 40) && (level < 60))
            {
                double exptonextlevel = (level * 1700) * 1.6;
                exp = Convert.ToInt32(exptonextlevel);
            }
            if ((level >= 60) && (level < 70))
            {
                double exptonextlevel = (level * 2800) * 1.7;
                exp = Convert.ToInt32(exptonextlevel);
            }
            if ((level >= 70) && (level < 80))
            {
                double exptonextlevel = (level * 4000) * 1.8;
                exp = Convert.ToInt32(exptonextlevel);
            }
            if ((level >= 80) && (level < 90))
            {
                double exptonextlevel = (level * 7000) * 1.9;
                exp = Convert.ToInt32(exptonextlevel);
            }
            if ((level >= 90) && (level < 100))
            {
                double exptonextlevel = (level * 13000) * 1.9;
                exp = Convert.ToInt32(exptonextlevel);
            }
            if ((level >= 100))
            {
                double exptonextlevel = (level * 29000) * 1.9;
                exp = Convert.ToInt32(exptonextlevel);
            }
            return exp;
        }
        public static int GetExpToNextLevel(int index)
        {
            int level = PStruct.character[index, PStruct.player[index].SelectedChar].Level;
            int exp = 0;
            if (level < 10)
            {
                double exptonextlevel = (level * 100) * 1.2;
                exp = Convert.ToInt32(exptonextlevel);
            }
            if ((level >= 10) && (level < 20))
            {
                double exptonextlevel = (level * 300) * 1.2;
                exp = Convert.ToInt32(exptonextlevel);
            }
            if ((level >= 20) && (level < 30))
            {
                double exptonextlevel = (level * 600) * 1.4;
                exp = Convert.ToInt32(exptonextlevel);
            }
            if ((level >= 30) && (level < 40))
            {
                double exptonextlevel = (level * 900) * 1.5;
                exp = Convert.ToInt32(exptonextlevel);
            }
            if ((level >= 40) && (level < 60))
            {
                double exptonextlevel = (level * 1700) * 1.6;
                exp = Convert.ToInt32(exptonextlevel);
            }
            if ((level >= 60) && (level < 70))
            {
                double exptonextlevel = (level * 2800) * 1.7;
                exp = Convert.ToInt32(exptonextlevel);
            }
            if ((level >= 70) && (level < 80))
            {
                double exptonextlevel = (level * 4000) * 1.8;
                exp = Convert.ToInt32(exptonextlevel);
            }
            if ((level >= 80) && (level < 90))
            {
                double exptonextlevel = (level * 7000) * 1.9;
                exp = Convert.ToInt32(exptonextlevel);
            }
            if ((level >= 90) && (level < 100))
            {
                double exptonextlevel = (level * 13000) * 1.9;
                exp = Convert.ToInt32(exptonextlevel);
            }
            if ((level >= 100))
            {
                double exptonextlevel = (level * 29000) * 1.9;
                exp = Convert.ToInt32(exptonextlevel);
            }
            return exp;
        }
        public static int GetpProfExpToNextLevel(int index, int type)
        {
            int level = PStruct.character[index, PStruct.player[index].SelectedChar].Prof_Level[type];
            double exptonextlevel = (level * 10) * 1.2;
            int exp = Convert.ToInt32(exptonextlevel);
            return exp;
        }
        public static int GetOpenProf(int index)
        {
            //Limpa slot de troca
            for (int i = 1; i < Globals.Max_Profs_Per_Char; i++)
            {
                if (PStruct.character[index, PStruct.player[index].SelectedChar].Prof_Type[i] == 0)
                {
                    return i;
                }
            }

            return 0;
        }
        public static void ClearTempTrade(int index)
        {
            PStruct.tempplayer[index].InTrade = 0;
            PStruct.tempplayer[index].TradeG = 0;
            PStruct.tempplayer[index].TradeStatus = 0;
            //Limpa slot de troca
            for (int i = 1; i < Globals.MaxTradeOffers; i++)
            {
                PStruct.tradeslot[index, i].item = Globals.NullItem;
            }
        }
        public static void ClearTempPlayer(int index)
        {
            PStruct.tempplayer[index].ingame = false;
            PStruct.tempplayer[index].preparingskill = 0;
            PStruct.tempplayer[index].movespeed = 0;
            PStruct.tempplayer[index].Inviting = 0;
            PStruct.tempplayer[index].Invited = 0;
            PStruct.tempplayer[index].MaxSpirit = 0;
            PStruct.tempplayer[index].MaxVitality = 0;
            PStruct.tempplayer[index].Party = 0;
            PStruct.tempplayer[index].skilltimer = 0;
            PStruct.tempplayer[index].Spirit = 0;
            PStruct.tempplayer[index].target = 0;
            PStruct.tempplayer[index].targettype = 0;
            PStruct.tempplayer[index].Warping = false;
            PStruct.tempplayer[index].Vitality = 0;
            PStruct.tempplayer[index].preparingskillslot = 0;
            PStruct.tempplayer[index].InTrade = 0;
            PStruct.tempplayer[index].InCraft = false;
            PStruct.tempplayer[index].InBank = false;
            PStruct.tempplayer[index].Stunned = false;
            PStruct.tempplayer[index].Sleeping = false;
            PStruct.tempplayer[index].StunTimer = 0;
            PStruct.tempplayer[index].SleepTimer = 0;
            PStruct.tempplayer[index].ActivationCode = 0;
            PStruct.tempplayer[index].AttackTimer = 0;
            PStruct.tempplayer[index].InShop = 0;
            PStruct.tempplayer[index].InCraft = false;
            PStruct.tempplayer[index].InBank = false;
            PStruct.tempplayer[index].CraftType = 0;
            PStruct.tempplayer[index].CraftItem = 0;
            PStruct.tempplayer[index].Blind = false;
            PStruct.tempplayer[index].BlindTimer = 0;
            PStruct.tempplayer[index].Logged = false;
            PStruct.tempplayer[index].DataTimer = 0;
            PStruct.tempplayer[index].ChatTimer = 0;
            PStruct.tempplayer[index].ChatExcept = 0;
            PStruct.tempplayer[index].AllChatTimer = 0;
            PStruct.tempplayer[index].isDead = false;
            PStruct.tempplayer[index].ActivationCode = 0;
            PStruct.tempplayer[index].SORE = false;
            PStruct.tempplayer[index].Reflect = false;
            PStruct.tempplayer[index].ReflectTimer = 0;
            PStruct.tempplayer[index].Shopping = false;
            PStruct.tempplayer[index].InPShop = 0;
            //Limpa slot de troca
            for (int i = 1; i < Globals.MaxTradeOffers; i++)
            {
                PStruct.tradeslot[index, i].item = Globals.NullItem;
            }
        }
        public static void GiveTradeTo(int index, int intrade)
        {
            if (PStruct.tempplayer[index].TradeG > 0)
            {
                GivePlayerGold(intrade, PStruct.tempplayer[index].TradeG);
            }

            for (int i = 1; i < Globals.MaxTradeOffers; i++)
            {
                if ((PStruct.tradeslot[index, i].item != Globals.NullItem) && (!String.IsNullOrEmpty(PStruct.tradeslot[index, i].item)))
                {
                    string[] splititem = PStruct.tradeslot[index, i].item.Split(',');

                    int itemNum = Convert.ToInt32(splititem[1]);
                    int itemType = Convert.ToInt32(splititem[0]);
                    int itemValue = Convert.ToInt32(splititem[2]);
                    int itemRefin = Convert.ToInt32(splititem[3]);
                    int itemExp = Convert.ToInt32(splititem[4]);

                    GiveItem(intrade, itemType, itemNum, itemValue, itemRefin, itemExp);

                    PStruct.tradeslot[index, i].item = Globals.NullItem;
                }
            }
        }
        public static void GiveTrade(int index)
        {
            if (PStruct.tempplayer[index].TradeG > 0)
            {
                GivePlayerGold(index, PStruct.tempplayer[index].TradeG);
            }
            for (int i = 1; i < Globals.MaxTradeOffers; i++)
            {
                if ((PStruct.tradeslot[index, i].item != Globals.NullItem) && (!String.IsNullOrEmpty(PStruct.tradeslot[index, i].item)))
                {
                    string[] splititem = PStruct.tradeslot[index, i].item.Split(',');
                    
                    int itemNum = Convert.ToInt32(splititem[1]);
                    int itemType = Convert.ToInt32(splititem[0]);
                    int itemValue = Convert.ToInt32(splititem[2]);
                    int itemRefin = Convert.ToInt32(splititem[3]);
                    int itemExp = Convert.ToInt32(splititem[4]);

                    GiveItem(index, itemType, itemNum, itemValue, itemRefin, itemExp);

                    PStruct.tradeslot[index, i].item = Globals.NullItem;
                }
            }
            SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
        }
        public static bool HasItem(int index, string item)
        {
            string[] data = item.Split(',');
            string itemtype = data[0];
            string itemnum = data[1];
            int itemvalue = Convert.ToInt32(data[2]);

            string[] datainv;
            for (int i = 1; i < Globals.MaxInvSlot; i++)
            {
                datainv = PStruct.invslot[index, i].item.Split(',');
                if ((itemtype == datainv[0]) && (itemnum == datainv[1]) && (itemvalue <= Convert.ToInt32(datainv[2]))) { return true; }
            }

            return false;
        }
        public static int CraftHasItem(int index, int type, int num)
        {
            for (int i = 1; i < Globals.Max_Craft; i++)
            {
                if ((PStruct.craft[index, i].num == num) && (PStruct.craft[index, i].type == type))
                {
                    return i;
                }
            }

            return -1;
        }

        public static int GetInvItemSlot(int index, string item)
        {
            for (int i = 1; i < Globals.MaxInvSlot; i++)
            {
                if (PStruct.invslot[index, i].item == item) { return i; }
            }

            return 0;
        }
        public static bool ClearItem(int index, string item)
        {
            for (int i = 1; i < Globals.MaxInvSlot; i++)
            {
                if (PStruct.invslot[index, i].item == item) { PStruct.invslot[index, i].item = Globals.NullItem; return true; }
            }

            return false;
        }
        public static bool GiveItem(int index, int itemt, int itemn, int itemv, int itemr, int itemex)
        {
            //Não entregar itens inválidos.
            if (itemn <= 0) { return false; }

            //Já temos os item? Se sim, adicionar.
            for (int i = 1; i < Globals.MaxInvSlot; i++)
            {
                string item = PStruct.invslot[index, i].item;
                string[] splititem = item.Split(',');

                int itemNum = Convert.ToInt32(splititem[1]);
                int itemType = Convert.ToInt32(splititem[0]);
                int itemValue = Convert.ToInt32(splititem[2]);
                int itemRefin = Convert.ToInt32(splititem[3]);
                int itemExp = Convert.ToInt32(splititem[4]);

                if ((itemn == itemNum) && (itemt == itemType) && (itemr == itemRefin) && (itemex == itemExp))
                {
                    PStruct.invslot[index, i].item = itemType + "," + itemNum + "," + (itemValue + itemv) + "," + itemRefin + "," + itemex;
                    return true;
                }
            }
            if (GetInvOpenSlot(index) > 0)
            {
                PStruct.invslot[index, GetInvOpenSlot(index)].item = itemt + "," + itemn + "," + itemv + "," + itemr + "," + itemex;
                return true;
            }
            else
            {
                SendData.Send_MsgToPlayer(index, "Voce não possui espaço no inventario.", Globals.ColorRed, Globals.Msg_Type_Server);
                return false;
            }
        }
        public static bool GiveSpell(int index, int spellnum)
        {
            if (GetSkillOpenSlot(index) > 0)
            {
                int openslot = GetSkillOpenSlot(index);
                PStruct.skill[index, openslot].level = 0;
                PStruct.skill[index, openslot].cooldown = 0;
                PStruct.skill[index, openslot].num = spellnum;
                return true;
            }
            else
            {
                SendData.Send_MsgToPlayer(index, "Voce não pode aprender mais magias.", Globals.ColorRed, Globals.Msg_Type_Server);
                return false;
            }
        }
        public static bool GiveBankItem(int index, int itemt, int itemn, int itemv, int itemr, int itemex)
        {
            //Já temos os item? Se sim, adicionar.
            for (int i = 1; i < Globals.Max_BankSlots; i++)
            {

                int itemNum = PStruct.player[index].bankslot[i].num;
                int itemType = PStruct.player[index].bankslot[i].type;
                int itemValue = PStruct.player[index].bankslot[i].value;
                int itemRefin = PStruct.player[index].bankslot[i].refin;
                int itemExp = PStruct.player[index].bankslot[i].exp;

                if ((itemn == itemNum) && (itemt == itemType) && (itemr == itemRefin) && (itemex == itemExp))
                {
                    PStruct.player[index].bankslot[i].value += itemv;
                    return true;
                }
            }
            if (GetBankOpenSlot(index) > 0)
            {
                int openslot = GetBankOpenSlot(index);
                PStruct.player[index].bankslot[openslot].type = itemt;
                PStruct.player[index].bankslot[openslot].num = itemn;
                PStruct.player[index].bankslot[openslot].value = itemv;
                PStruct.player[index].bankslot[openslot].refin = itemr;
                PStruct.player[index].bankslot[openslot].exp = itemex;
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void PetAttack(int index, int target, int targettype)
        {
            PStruct.tempplayer[index].PetTarget = target;
            PStruct.tempplayer[index].PetTargetType = targettype;
            if (targettype == Globals.Target_Npc)
            {
                PlayerAttackNpc(index, target, 0, 0, false, 0, true);
            }
            else if (targettype == Globals.Target_Player)
            {
                PlayerAttackPlayer(index, target, 0, 0, false, 0, 0, true);
            }
            SendData.Send_PetAttack(index, target, targettype);
            PStruct.tempplayer[index].PetTimer = Loops.TickCount.ElapsedMilliseconds + 2000;
        }
        public static void PetMove(int index)
        {
            if (PStruct.tempplayer[index].PetTimer > Loops.TickCount.ElapsedMilliseconds) { return; }
            if (PStruct.tempplayer[index].isDead) { return; }

            string equipment = PStruct.character[index, PStruct.player[index].SelectedChar].Equipment;
            string[] equipdata = equipment.Split(',');
            string[] petdata = equipdata[4].Split(';');

            int petnum = Convert.ToInt32(petdata[0]);
            int petlvl = Convert.ToInt32(petdata[1]);
            int petexp = Convert.ToInt32(petdata[2]);
            int Map = PStruct.character[index, PStruct.player[index].SelectedChar].Map;
            int targetx = PStruct.character[index, PStruct.player[index].SelectedChar].X;
            int targety = PStruct.character[index, PStruct.player[index].SelectedChar].Y;
            int lasttarget = tempplayer[index].LastTarget;
            int lasttargettype = tempplayer[index].LastTargetType;
            int target = tempplayer[index].PetTarget;
            int targettype = tempplayer[index].PetTargetType;
            int DistanceX = 0;
            int DistanceY = 0;
            int n = 2;

            if (petnum <= 0) { return; }

          


            if ((targettype == Globals.Target_Npc))
            {
                if ((NStruct.tempnpc[Map, target].Dead) || (NStruct.tempnpc[Map, target].Vitality <= 0))
                {
                    tempplayer[index].PetTarget = 0;
                    tempplayer[index].PetTargetType = 0;
                    return;
                }
                DistanceX = NStruct.tempnpc[Map, target].X - targetx;
                DistanceY = NStruct.tempnpc[Map, target].Y - targety;

                if (DistanceX < 0) { DistanceX = DistanceX * -1; }
                if (DistanceY < 0) { DistanceY = DistanceY * -1; }

                //Verificar se está no alcance
                if ((DistanceX <= n) && (DistanceY <= n))
                {
                    PetAttack(index, target, Globals.Target_Npc);
                    return;
                }
            }

            if ((targettype == Globals.Target_Player))
            {
                //Verificar se o jogador não se desconectou no processo
                int clientindex = UserConnection.GetIndex(target);
                if ((clientindex < 0) || (clientindex >= WinsockAsync.Clients.Count())) 
                {
                    tempplayer[index].PetTarget = 0;
                    tempplayer[index].PetTargetType = 0;
                    return; }
                if ((clientindex < 0) || (clientindex >= WinsockAsync.Clients.Count())) 
                {
                    tempplayer[index].PetTarget = 0;
                    tempplayer[index].PetTargetType = 0;
                    return;}
                if (!WinsockAsync.Clients[clientindex].IsConnected) 
                {                  
                    tempplayer[index].PetTarget = 0;
                    tempplayer[index].PetTargetType = 0;
                    return; }

                //Verificar se não está morto ou sem vida
                if ((tempplayer[target].isDead) || (tempplayer[target].Vitality <= 0))
                {
                    tempplayer[index].PetTarget = 0;
                    tempplayer[index].PetTargetType = 0;
                    return;
                }
                //Condições preventivas
                if ((PStruct.character[target, PStruct.player[target].SelectedChar].Map == Map) && (target != index))
                {
                    if ((PStruct.character[target, PStruct.player[target].SelectedChar].PVP) || (PStruct.character[index, PStruct.player[index].SelectedChar].PVP))
                    {
                        DistanceX = PStruct.character[target, PStruct.player[target].SelectedChar].X - targetx;
                        DistanceY = PStruct.character[target, PStruct.player[target].SelectedChar].Y - targety;

                        if (DistanceX < 0) { DistanceX = DistanceX * -1; }
                        if (DistanceY < 0) { DistanceY = DistanceY * -1; }

                        //Verificar se está no alcance
                        if ((DistanceX <= n) && (DistanceY <= n))
                        {
                            PetAttack(index, target, Globals.Target_Player);
                            return;
                        }
                    }
                }
            }

            if ((lasttargettype == Globals.Target_Npc) && (NStruct.tempnpc[Map, lasttarget].Vitality > 0))
            {
                DistanceX = NStruct.tempnpc[Map, lasttarget].X - targetx;
                DistanceY = NStruct.tempnpc[Map, lasttarget].Y - targety;

                if (DistanceX < 0) { DistanceX = DistanceX * -1; }
                if (DistanceY < 0) { DistanceY = DistanceY * -1; }

                //Verificar se está no alcance
                if ((DistanceX <= n) && (DistanceY <= n))
                {
                    PetAttack(index, lasttarget, Globals.Target_Npc);
                    return;
                }
            }

            if ((lasttargettype == Globals.Target_Player) && (tempplayer[lasttarget].Vitality > 0))
            {
                //Condições preventivas
                if ((PStruct.character[lasttarget, PStruct.player[lasttarget].SelectedChar].Map == Map) && (lasttarget != index))
                {
                    if ((PStruct.character[lasttarget, PStruct.player[lasttarget].SelectedChar].PVP) || (PStruct.character[index, PStruct.player[index].SelectedChar].PVP))
                    {
                        DistanceX = PStruct.character[lasttarget, PStruct.player[lasttarget].SelectedChar].X - targetx;
                        DistanceY = PStruct.character[lasttarget, PStruct.player[lasttarget].SelectedChar].Y - targety;

                        if (DistanceX < 0) { DistanceX = DistanceX * -1; }
                        if (DistanceY < 0) { DistanceY = DistanceY * -1; }

                        //Verificar se está no alcance
                        if ((DistanceX <= n) && (DistanceY <= n))
                        {
                            PetAttack(index, lasttarget, Globals.Target_Player);
                            return;
                        }
                    }

                }
            }

            //Analisa todos os npcs do mapa
            for (int i = 0; i <= MStruct.tempmap[Map].NpcCount; i++)
            {
                if (NStruct.tempnpc[Map, i].Vitality > 0)
                {
                    if (NStruct.tempnpc[Map, i].Target > 0)
                    {
                        DistanceX = NStruct.tempnpc[Map, i].X - targetx;
                        DistanceY = NStruct.tempnpc[Map, i].Y - targety;

                        if (DistanceX < 0) { DistanceX = DistanceX * -1; }
                        if (DistanceY < 0) { DistanceY = DistanceY * -1; }

                        //Verificar se está no alcance
                        if ((DistanceX <= n) && (DistanceY <= n))
                        {
                            PetAttack(index, i, Globals.Target_Npc);
                            return;
                        }
                    }
                }
            }

            //Analisar todos os jogadores online
            for (int i = 0; i <= Globals.Player_HighIndex; i++)
            {
                if ((!tempplayer[i].isDead) && (tempplayer[i].Vitality > 0))
                {
                    //Condições preventivas
                    if ((PStruct.character[i, PStruct.player[i].SelectedChar].Map == Map) && (i != index))
                    {
                        if (PStruct.character[i, PStruct.player[i].SelectedChar].Guild != PStruct.character[index, PStruct.player[index].SelectedChar].Guild)
                        {
                            if (tempplayer[i].Party != tempplayer[index].Party)
                            {
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].PVP) || (PStruct.character[index, PStruct.player[index].SelectedChar].PVP))
                                {
                                    DistanceX = PStruct.character[i, PStruct.player[i].SelectedChar].X - targetx;
                                    DistanceY = PStruct.character[i, PStruct.player[i].SelectedChar].Y - targety;

                                    if (DistanceX < 0) { DistanceX = DistanceX * -1; }
                                    if (DistanceY < 0) { DistanceY = DistanceY * -1; }

                                    //Verificar se está no alcance
                                    if ((DistanceX <= n) && (DistanceY <= n))
                                    {
                                        PetAttack(index, i, Globals.Target_Player);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        
        }
        public static bool GivePShopItem(int index, int itemt, int itemn, int itemv, int itemr, int itemp, int itemex)
        {
            //Já temos os item? Se sim, adicionar.
            for (int i = 1; i < Globals.Max_PShops; i++)
            {

                int itemNum = PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].num;
                int itemType = PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].type;
                int itemValue = PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].value;
                int itemRefin = PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].refin;
                int itemExp = PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].exp;
                int itemPrice = PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].price;

                if ((itemn == itemNum) && (itemt == itemType) && (itemr == itemRefin) && (itemp == itemPrice) && (itemex == itemExp))
                {
                    PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].value += itemv;
                    return true;
                }
            }
            if (GetPShopOpenSlot(index) > 0)
            {
                int openslot = GetPShopOpenSlot(index);
                PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[openslot].type = itemt;
                PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[openslot].num = itemn;
                PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[openslot].value = itemv;
                PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[openslot].refin = itemr;
                PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[openslot].exp = itemex;
                PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[openslot].price = itemp;
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsQuestGiverRepeatable(int questgiver)
        {
            if (questgiver == 7)
            {
                return true;
            }
            return false;
        }
        public static bool PickItem(int index, int itemt, int itemn, int itemv, int itemr, int itemex = 0)
        {
            //
            for (int i = 1; i < Globals.MaxInvSlot; i++)
            {
                string item = PStruct.invslot[index, i].item;
                string[] splititem = item.Split(',');

                int itemNum = Convert.ToInt32(splititem[1]);
                int itemType = Convert.ToInt32(splititem[0]);
                int itemValue = Convert.ToInt32(splititem[2]);
                int itemRefin = Convert.ToInt32(splititem[3]);
                int itemExp = Convert.ToInt32(splititem[4]);
                
                if ((itemn == itemNum) && (itemt == itemType) && (itemr == itemRefin) && (itemv == itemValue))
                {
                    PStruct.invslot[index, i].item = Globals.NullItem;
                    return true;
                }

                if ((itemn == itemNum) && (itemt == itemType) && (itemr == itemRefin) && (itemv <= itemValue) && (itemex <= itemExp))
                {
                    PStruct.invslot[index, i].item = itemType + "," + itemNum + "," + (itemValue - itemv) + "," + itemRefin + "," + itemExp;
                    return true;
                }
            }
            return false;
        }
        public static bool PickBankItem(int index, int itemt, int itemn, int itemv, int itemr)
        {
            //
            for (int i = 1; i < Globals.Max_BankSlots; i++)
            {
                int itemNum = PStruct.player[index].bankslot[i].num;
                int itemType = PStruct.player[index].bankslot[i].type;
                int itemValue = PStruct.player[index].bankslot[i].value;
                int itemRefin = PStruct.player[index].bankslot[i].refin;

                if ((itemn == itemNum) && (itemt == itemType) && (itemr == itemRefin) && (itemv == itemValue))
                {
                    PStruct.player[index].bankslot[i].type = 0;
                    PStruct.player[index].bankslot[i].num = 0;
                    PStruct.player[index].bankslot[i].value = 0;
                    PStruct.player[index].bankslot[i].refin = 0; 
                    PStruct.player[index].bankslot[i].exp = 0;

                    return true;
                }

                if ((itemn == itemNum) && (itemt == itemType) && (itemr == itemRefin) && (itemv <= itemValue))
                {
                    PStruct.player[index].bankslot[i].type = 0;
                    PStruct.player[index].bankslot[i].num = 0;
                    PStruct.player[index].bankslot[i].value -= itemv;
                    PStruct.player[index].bankslot[i].refin = 0;
                    PStruct.player[index].bankslot[i].exp = 0;
                    return true;
                }
            }
            return false;
        }
        public static int GetInvOpenSlot(int index)
        {
            
            for (int i = 1; i < Globals.MaxInvSlot; i++)
            {
                if (PStruct.invslot[index, i].item == Globals.NullItem) { return i; }
            }

            return 0;
        }
        public static int GetSkillOpenSlot(int index)
        {

            for (int i = 9; i < Globals.MaxPlayer_Skills; i++)
            {
                if (PStruct.skill[index, i].num == 0) { return i; }
            }

            return 0;
        }
        public static int GetBankOpenSlot(int index)
        {

            for (int i = 1; i < Globals.Max_BankSlots; i++)
            {
                if (PStruct.player[index].bankslot[i].num == 0) { return i; }
            }

            return 0;
        }
        public static int GetPShopOpenSlot(int index)
        {

            for (int i = 1; i < Globals.Max_PShops; i++)
            {
                if (PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].num == 0) { return i; }
            }

            return 0;
        }
        public static int GetPlayerMaxSpirit(int Index)
        {
            int LevelVital = 0;
            if (PStruct.character[Index, PStruct.player[Index].SelectedChar].ClassId == 1) { LevelVital = PStruct.character[Index, PStruct.player[Index].SelectedChar].Level * 30; }
            else if (PStruct.character[Index, PStruct.player[Index].SelectedChar].ClassId == 2) { LevelVital = PStruct.character[Index, PStruct.player[Index].SelectedChar].Level * 22; }
            else if (PStruct.character[Index, PStruct.player[Index].SelectedChar].ClassId == 3) { LevelVital = PStruct.character[Index, PStruct.player[Index].SelectedChar].Level * 60; }
            else if (PStruct.character[Index, PStruct.player[Index].SelectedChar].ClassId == 4) { LevelVital = PStruct.character[Index, PStruct.player[Index].SelectedChar].Level * 18; }
            else if (PStruct.character[Index, PStruct.player[Index].SelectedChar].ClassId == 5) { LevelVital = PStruct.character[Index, PStruct.player[Index].SelectedChar].Level * 14; }
            else if (PStruct.character[Index, PStruct.player[Index].SelectedChar].ClassId == 6) { LevelVital = PStruct.character[Index, PStruct.player[Index].SelectedChar].Level * 40; }
            double FireVital = Convert.ToDouble(PStruct.character[Index, PStruct.player[Index].SelectedChar].Fire) * 0.5;
            double EarthVital = Convert.ToDouble(PStruct.character[Index, PStruct.player[Index].SelectedChar].Earth) * 0.8;
            double WaterVital = Convert.ToDouble(PStruct.character[Index, PStruct.player[Index].SelectedChar].Water) * 1.2;
            double WindVital = Convert.ToDouble(PStruct.character[Index, PStruct.player[Index].SelectedChar].Wind) * 1.3;
            double DarkVital = Convert.ToDouble(PStruct.character[Index, PStruct.player[Index].SelectedChar].Dark) * 2;
            double LightVital = Convert.ToDouble(PStruct.character[Index, PStruct.player[Index].SelectedChar].Light) * 1.5;
            double DVital = FireVital + EarthVital + WaterVital + WindVital + DarkVital + LightVital;
            int vital = Convert.ToInt32(DVital) + LevelVital;
            if (GetExtraSpirit(Index) > 0) { vital += (vital / 100) * GetExtraSpirit(Index); }
            if (PStruct.tempplayer[Index].SORE) { vital = vital / 2; }
            return vital;
        }
        public static int GetPlayerMaxVitality(int Index)
        {
            int LevelVital = 0;
            if (PStruct.character[Index, PStruct.player[Index].SelectedChar].ClassId == 1) { LevelVital = PStruct.character[Index, PStruct.player[Index].SelectedChar].Level * 52; }
            else if (PStruct.character[Index, PStruct.player[Index].SelectedChar].ClassId == 2) { LevelVital = PStruct.character[Index, PStruct.player[Index].SelectedChar].Level * 63; }
            else if (PStruct.character[Index, PStruct.player[Index].SelectedChar].ClassId == 3) { LevelVital = PStruct.character[Index, PStruct.player[Index].SelectedChar].Level * 34; }
            else if (PStruct.character[Index, PStruct.player[Index].SelectedChar].ClassId == 4) { LevelVital = PStruct.character[Index, PStruct.player[Index].SelectedChar].Level * 40; }
            else if (PStruct.character[Index, PStruct.player[Index].SelectedChar].ClassId == 5) { LevelVital = PStruct.character[Index, PStruct.player[Index].SelectedChar].Level * 76; }
            else if (PStruct.character[Index, PStruct.player[Index].SelectedChar].ClassId == 6) { LevelVital = PStruct.character[Index, PStruct.player[Index].SelectedChar].Level * 32; }
            //int LevelVital = PStruct.character[Index, PStruct.player[Index].SelectedChar].Level * 75;
            double FireVital = Convert.ToDouble(PStruct.character[Index, PStruct.player[Index].SelectedChar].Fire) * 2.5;
            double EarthVital = Convert.ToDouble(PStruct.character[Index, PStruct.player[Index].SelectedChar].Earth) * 4;
            double WaterVital = Convert.ToDouble(PStruct.character[Index, PStruct.player[Index].SelectedChar].Water) * 2.3;
            double WindVital = Convert.ToDouble(PStruct.character[Index, PStruct.player[Index].SelectedChar].Wind) * 2.2;
            double DarkVital = Convert.ToDouble(PStruct.character[Index, PStruct.player[Index].SelectedChar].Dark) * 1.8;
            double LightVital = Convert.ToDouble(PStruct.character[Index, PStruct.player[Index].SelectedChar].Light) * 1.5;
            double DVital = FireVital + EarthVital + WaterVital + WindVital + DarkVital + LightVital;
            int vital = Convert.ToInt32(DVital) + LevelVital;
            if (GetExtraVitality(Index) > 0) { vital += (vital / 100) * GetExtraVitality(Index); }
            if (PStruct.tempplayer[Index].SORE) { vital = vital / 2; }
            return vital;
        }
        public static int GetExtraVitality(int index)
        {
          int vital = 0;
          if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 5)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 35) && (PStruct.skill[index, i].level > 0))
                    {
                        vital = 40;
                        break;
                    }
                }
            }
          return vital;
        }
        public static int GetExtraSpirit(int index)
        {
            int vital = 0;
            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 1)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 46) && (PStruct.skill[index, i].level > 0))
                    {
                        vital = 10;
                        break;
                    }
                }
            }
            return vital;
        }
 
        public static int GetPlayerVitalityRegen(int index)
        {
            double LightRegen = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Light) * 0.6;
            int vital = 1 + Convert.ToInt32(LightRegen); //per second
            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 2)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 52) && (PStruct.skill[index, i].level > 0))
                    {
                        vital += ((GetPlayerMaxVitality(index) / 100) * PStruct.skill[index, i].level);
                        break;
                    }
                }
            }
            return vital;
        }
        public static int GetPlayerSpiritRegen(int index)
        {
            double DarkRegen = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Dark) * 0.3;
            int vital = 1 + Convert.ToInt32(DarkRegen); //per second
            return vital;
        }
        public static int GetPlayerCritical(int index)
        {
            double armorcrit = 0.0;
            double weaponcrit = 0.0;
            double shieldcrit = 0.0;
            double helmetcrit = 0.0;
            int level = 0;

            if (GetPlayerArmor(index) != 0)
            {
                level = GetPlayerArmorRefin(index);
                armorcrit = AStruct.armorparams[GetPlayerArmor(index), 7].value + ((AStruct.armorparams[GetPlayerArmor(index), 7].value / 100) * (level * 7));
            }
            if (GetPlayerWeapon(index) != 0)
            {
                level = GetPlayerWeaponRefin(index);
                weaponcrit = WStruct.weaponparams[GetPlayerWeapon(index), 7].value + ((WStruct.weaponparams[GetPlayerWeapon(index), 7].value / 100) * (level * 7));
            }
            if (GetPlayerShield(index) != 0)
            {
                level = GetPlayerShieldRefin(index);
                shieldcrit = AStruct.armorparams[GetPlayerShield(index), 7].value + ((AStruct.armorparams[GetPlayerShield(index), 7].value / 100) * (level * 7));
            }
            if (GetPlayerHelmet(index) != 0)
            {
                level = GetPlayerHelmetRefin(index);
                helmetcrit = AStruct.armorparams[GetPlayerHelmet(index), 7].value + ((AStruct.armorparams[GetPlayerHelmet(index), 7].value / 100) * (level * 7));
            }

            double totalitemcrit = armorcrit + weaponcrit + shieldcrit + helmetcrit;

            double watercrit = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Water) * 0.2;
            double dtotalcrit = totalitemcrit + watercrit;

            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 4)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 48) && (PStruct.skill[index, i].level > 0))
                    {
                        dtotalcrit += (PStruct.skill[index, i].level * 1.5);
                        break;
                    }
                }
            }

            if (PStruct.tempplayer[index].SORE) { dtotalcrit = dtotalcrit / 2; }

            int totalcrit = Convert.ToInt32(dtotalcrit);

            return totalcrit;
        }
        public static int GetPlayerParry(int index)
        {
            double armorparry = 0.0;
            double weaponparry = 0.0;
            double shieldparry = 0.0;
            double helmetparry = 0.0;
            int level = 0;

            if (GetPlayerArmor(index) != 0)
            {
                level = GetPlayerArmorRefin(index);
                armorparry = AStruct.armorparams[GetPlayerArmor(index), 6].value + ((AStruct.armorparams[GetPlayerArmor(index), 6].value / 100) * (level * 7));
            }
            if (GetPlayerWeapon(index) != 0)
            {
                level = GetPlayerWeaponRefin(index);
                weaponparry = WStruct.weaponparams[GetPlayerWeapon(index), 6].value + ((WStruct.weaponparams[GetPlayerWeapon(index), 6].value / 100) * (level * 7));
            }
            if (GetPlayerShield(index) != 0)
            {
                level = GetPlayerShieldRefin(index);
                shieldparry = AStruct.armorparams[GetPlayerShield(index), 6].value + ((AStruct.armorparams[GetPlayerShield(index), 6].value / 100) * (level * 7));
            }
            if (GetPlayerHelmet(index) != 0)
            {
                level = GetPlayerHelmetRefin(index);
                helmetparry = AStruct.armorparams[GetPlayerHelmet(index), 6].value + ((AStruct.armorparams[GetPlayerHelmet(index), 6].value / 100) * (level * 7));
            }

            double totalitemparry = armorparry + weaponparry + shieldparry + helmetparry;

            double windparry = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Wind) * 0.3;
            double dtotalparry = totalitemparry + windparry;
            if (PStruct.tempplayer[index].SORE) { dtotalparry = dtotalparry / 2; }
            int totalparry = Convert.ToInt32(dtotalparry);

            return totalparry;
        }
        public static int GetPlayerDefense(int index)
        {
            double armordef = 0.0;
            double weapondef = 0.0;
            double shielddef = 0.0;
            double helmetdef = 0.0;
            int level = 0;

            if (GetPlayerArmor(index) != 0)
            {
                level = GetPlayerArmorRefin(index);
                armordef = AStruct.armorparams[GetPlayerArmor(index), 3].value + ((AStruct.armorparams[GetPlayerArmor(index), 3].value / 100) * (level * 7));
            }
            if (GetPlayerWeapon(index) != 0)
            {
                level = GetPlayerWeaponRefin(index);
                weapondef = WStruct.weaponparams[GetPlayerWeapon(index), 3].value + ((WStruct.weaponparams[GetPlayerWeapon(index), 3].value / 100) * (level * 7));
            }
            if (GetPlayerShield(index) != 0)
            {
                level = GetPlayerShieldRefin(index);
                shielddef = AStruct.armorparams[GetPlayerShield(index), 3].value + ((AStruct.armorparams[GetPlayerShield(index), 3].value / 100) * (level * 7));
            }
            if (GetPlayerHelmet(index) != 0)
            {
                level = GetPlayerHelmetRefin(index);
                helmetdef = AStruct.armorparams[GetPlayerHelmet(index), 3].value + ((AStruct.armorparams[GetPlayerHelmet(index), 3].value / 100) * (level * 7));
            }

            double totalitemdef = armordef + weapondef + shielddef + helmetdef;

            double earthdefense = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Earth) * 0.05;
            double dtotaldefense = totalitemdef + earthdefense;
            if (PStruct.tempplayer[index].SORE) { dtotaldefense = dtotaldefense / 2; }
            int totaldefense = Convert.ToInt32(dtotaldefense);

            return totaldefense;
        }
        public static int GetPlayerMinAttack(int index)
        {
            double armoratk = 0.0;
            double weaponatk = 0.0;
            double shieldatk = 0.0;
            double helmetatk = 0.0;
            int level = 0;

            if (GetPlayerArmor(index) != 0)
            {
                level = GetPlayerArmorRefin(index);
                armoratk = AStruct.armorparams[GetPlayerArmor(index), 0].value + ((AStruct.armorparams[GetPlayerArmor(index), 0].value / 100) * (level * 7));
            }
            if (GetPlayerWeapon(index) != 0)
            {
                level = GetPlayerWeaponRefin(index);
                weaponatk = WStruct.weaponparams[GetPlayerWeapon(index), 0].value + ((WStruct.weaponparams[GetPlayerWeapon(index), 0].value / 100) * (level * 7));
            }
            if (GetPlayerShield(index) != 0)
            {
                level = GetPlayerShieldRefin(index);
                shieldatk = AStruct.armorparams[GetPlayerShield(index), 0].value + ((AStruct.armorparams[GetPlayerShield(index), 0].value / 100) * (level * 7));
            }
            if (GetPlayerHelmet(index) != 0)
            {
                level = GetPlayerHelmetRefin(index);
                helmetatk = AStruct.armorparams[GetPlayerHelmet(index), 0].value + ((AStruct.armorparams[GetPlayerHelmet(index), 0].value / 100) * (level * 7));
            }

            double totalitematk = armoratk + weaponatk + shieldatk + helmetatk;

            double earthatk = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Earth) * 0.7;
            
            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 6)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 39) && (PStruct.skill[index, i].level > 0))
                    {
                        earthatk += Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Wind) * 0.7;
                        break;
                    }
                }
            }

            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 5)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 35) && (PStruct.skill[index, i].level > 0))
                    {
                        earthatk += Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Earth) * 0.7;
                        break;
                    }
                }
            }
            
            double dtotalatk = totalitematk + earthatk;
            if (PStruct.tempplayer[index].SORE) { dtotalatk = dtotalatk / 2; }
            int totalatk = Convert.ToInt32(dtotalatk);

            return totalatk;
        }
        public static int GetPlayerMinMagic(int index)
        {
            double armoratk = 0.0;
            double weaponatk = 0.0;
            double shieldatk = 0.0;
            double helmetatk = 0.0;
            int level = 0;

            if (GetPlayerArmor(index) != 0)
            {
                level = GetPlayerArmorRefin(index);
                armoratk = AStruct.armorparams[GetPlayerArmor(index), 1].value + ((AStruct.armorparams[GetPlayerArmor(index), 1].value / 100) * (level * 7));
            }
            if (GetPlayerWeapon(index) != 0)
            {
                level = GetPlayerWeaponRefin(index);
                weaponatk = WStruct.weaponparams[GetPlayerWeapon(index), 1].value + ((WStruct.weaponparams[GetPlayerWeapon(index), 1].value / 100) * (level * 7));
            }
            if (GetPlayerShield(index) != 0)
            {
                level = GetPlayerShieldRefin(index);
                shieldatk = AStruct.armorparams[GetPlayerShield(index), 1].value + ((AStruct.armorparams[GetPlayerShield(index), 1].value / 100) * (level * 7));
            }
            if (GetPlayerHelmet(index) != 0)
            {
                level = GetPlayerHelmetRefin(index);
                helmetatk = AStruct.armorparams[GetPlayerHelmet(index), 1].value + ((AStruct.armorparams[GetPlayerHelmet(index), 1].value / 100) * (level * 7));
            }

            double totalitematk = armoratk + weaponatk + shieldatk + helmetatk;

            double earthatk = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Dark) * 0.6;

            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 6)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 39) && (PStruct.skill[index, i].level > 0))
                    {
                        earthatk += Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Wind) * 0.6;
                        break;
                    }
                }
            }

            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 5)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 35) && (PStruct.skill[index, i].level > 0))
                    {
                        earthatk += Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Earth) * 0.6;
                        break;
                    }
                }
            }

            double dtotalatk = totalitematk + earthatk;


            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 1)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 46) && (PStruct.skill[index, i].level > 0))
                    {
                        dtotalatk += ((dtotalatk / 100) * (5 * PStruct.skill[index, i].level));
                        break;
                    }
                }
            }

            if (PStruct.tempplayer[index].SORE) { dtotalatk = dtotalatk / 2; }
            int totalatk = Convert.ToInt32(dtotalatk);

            return totalatk;
        }
        public static int GetPlayerMaxMagic(int index)
        {
            double armoratk = 0.0;
            double weaponatk = 0.0;
            double shieldatk = 0.0;
            double helmetatk = 0.0;
            int level = 0;

            if (GetPlayerArmor(index) != 0)
            {
                level = GetPlayerArmorRefin(index);
                armoratk = AStruct.armorparams[GetPlayerArmor(index), 4].value + ((AStruct.armorparams[GetPlayerArmor(index), 4].value / 100) * (level * 7));
            }
            if (GetPlayerWeapon(index) != 0)
            {
                level = GetPlayerWeaponRefin(index);
                weaponatk = WStruct.weaponparams[GetPlayerWeapon(index), 4].value + ((WStruct.weaponparams[GetPlayerWeapon(index), 4].value / 100) * (level * 7));
            }
            if (GetPlayerShield(index) != 0)
            {
                level = GetPlayerShieldRefin(index);
                shieldatk = AStruct.armorparams[GetPlayerShield(index), 4].value + ((AStruct.armorparams[GetPlayerShield(index), 4].value / 100) * (level * 7));
            }
            if (GetPlayerHelmet(index) != 0)
            {
                level = GetPlayerHelmetRefin(index);
                helmetatk = AStruct.armorparams[GetPlayerHelmet(index), 4].value + ((AStruct.armorparams[GetPlayerHelmet(index), 4].value / 100) * (level * 7));
            }

            double totalitematk = armoratk + weaponatk + shieldatk + helmetatk;

            double earthatk = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Dark) * 1.5;
            
            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 6)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 39) && (PStruct.skill[index, i].level > 0))
                    {
                        earthatk += Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Wind) * 1.5;
                        break;
                    }
                }
            }

            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 5)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 35) && (PStruct.skill[index, i].level > 0))
                    {
                        earthatk += Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Earth) * 1.5;
                        break;
                    }
                }
            }

            double dtotalatk = totalitematk + earthatk;

            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 1)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 46) && (PStruct.skill[index, i].level > 0))
                    {
                        dtotalatk += ((dtotalatk / 100) * (5 * PStruct.skill[index, i].level));
                        break;
                    }
                }
            }

            if (PStruct.tempplayer[index].SORE) { dtotalatk = dtotalatk / 2; }
            int totalatk = Convert.ToInt32(dtotalatk);
            return totalatk;
        }
        public static int GetPlayerMagicDef(int index)
        {
            double armoratk = 0.0;
            double weaponatk = 0.0;
            double shieldatk = 0.0;
            double helmetatk = 0.0;
            int level = 0;

            if (GetPlayerArmor(index) != 0)
            {
                level = GetPlayerArmorRefin(index);
                armoratk = AStruct.armorparams[GetPlayerArmor(index), 5].value + ((AStruct.armorparams[GetPlayerArmor(index), 5].value / 100) * (level * 7));
            }
            if (GetPlayerWeapon(index) != 0)
            {
                level = GetPlayerWeaponRefin(index);
                weaponatk = WStruct.weaponparams[GetPlayerWeapon(index), 5].value + ((WStruct.weaponparams[GetPlayerWeapon(index), 5].value / 100) * (level * 7));
            }
            if (GetPlayerShield(index) != 0)
            {
                level = GetPlayerShieldRefin(index);
                shieldatk = AStruct.armorparams[GetPlayerShield(index), 5].value + ((AStruct.armorparams[GetPlayerShield(index), 5].value / 100) * (level * 7));
            }
            if (GetPlayerHelmet(index) != 0)
            {
                level = GetPlayerHelmetRefin(index);
                helmetatk = AStruct.armorparams[GetPlayerHelmet(index), 5].value + ((AStruct.armorparams[GetPlayerHelmet(index), 5].value / 100) * (level * 7));
            }

            double totalitematk = armoratk + weaponatk + shieldatk + helmetatk;

            double earthatk = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Light) * 0.05;
            double dtotalatk = totalitematk + earthatk;
            if (PStruct.tempplayer[index].SORE) { dtotalatk = dtotalatk / 2; }
            int totalatk = Convert.ToInt32(dtotalatk);

            return totalatk;
        }
        public static int GetPlayerMaxAttack(int index)
        {
            double armoratk = 0.0;
            double weaponatk = 0.0;
            double shieldatk = 0.0;
            double helmetatk = 0.0;
            int level = 0;

            if (GetPlayerArmor(index) != 0)
            {
                level = GetPlayerArmorRefin(index);
                armoratk = AStruct.armorparams[GetPlayerArmor(index), 2].value + ((AStruct.armorparams[GetPlayerArmor(index), 2].value / 100) * (level * 7));
            }
            if (GetPlayerWeapon(index) != 0)
            {
                level = GetPlayerWeaponRefin(index);
                weaponatk = WStruct.weaponparams[GetPlayerWeapon(index), 2].value + ((WStruct.weaponparams[GetPlayerWeapon(index), 2].value / 100) * (level * 7));
            }
            if (GetPlayerShield(index) != 0)
            {
                level = GetPlayerShieldRefin(index);
                shieldatk = AStruct.armorparams[GetPlayerShield(index), 2].value + ((AStruct.armorparams[GetPlayerShield(index), 2].value / 100) * (level * 7));
            }
            if (GetPlayerHelmet(index) != 0)
            {
                level = GetPlayerHelmetRefin(index);
                helmetatk = AStruct.armorparams[GetPlayerHelmet(index), 2].value + ((AStruct.armorparams[GetPlayerHelmet(index), 2].value / 100) * (level * 7));
            }

            double totalitematk = armoratk + weaponatk + shieldatk + helmetatk;

            double fireatk = Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Fire) * 1.8;
            
            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 6)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 39) && (PStruct.skill[index, i].level > 0))
                    {
                        fireatk += Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Wind) * 1.8;
                        break;
                    }
                }
            }

            if (PStruct.character[index, PStruct.player[index].SelectedChar].ClassId == 5)
            {
                for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                {
                    if ((PStruct.skill[index, i].num == 35) && (PStruct.skill[index, i].level > 0))
                    {
                        fireatk += Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Earth) * 1.8;
                        break;
                    }
                }
            }

            double dtotalatk = totalitematk + fireatk;
            if (PStruct.tempplayer[index].SORE) { dtotalatk = dtotalatk / 2; }
            int totalatk = Convert.ToInt32(dtotalatk);

            return totalatk;
        }
        public static bool CanPlayerMove(int Index, byte Dir, int x = 0, int y = 0)
        {
            int map = Convert.ToInt32(PStruct.character[Index, PStruct.player[Index].SelectedChar].Map);
            if (x <= 0 || y <= 0)
            {
                x = Convert.ToInt32(PStruct.character[Index, PStruct.player[Index].SelectedChar].X);
                y = Convert.ToInt32(PStruct.character[Index, PStruct.player[Index].SelectedChar].Y);
            }
                
            //Tentamos nos mover
            switch (Dir)
            {
                case 8:
                    if (y - 1 < 0)
                    {
                        return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].UpBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y - 1].DownBlock) == false) { return false; }
                    if ((MStruct.tile[map, x, y - 1].Data1 == "3") || (MStruct.tile[map, x, y - 1].Data1 == "10")) { return false; }
                    if (MStruct.tile[map, x, y - 1].Data1 == "21"){
                        if (!IsPlayerPremmy(Index))
                        {
                            PlayerMove(Index, Convert.ToByte(Convert.ToInt32(MStruct.tile[map, x, y - 1].Data2)));
                            return false;
                        }
                    }
                    break;
                case 2:
                    if (y + 1 > 14)
                    {
                        return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].DownBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y + 1].UpBlock) == false) { return false; }
                    if ((MStruct.tile[map, x, y + 1].Data1 == "3") || (MStruct.tile[map, x, y + 1].Data1 == "10")) { return false; }
                    if (MStruct.tile[map, x, y + 1].Data1 == "21")
                    {
                        if (!IsPlayerPremmy(Index))
                        {
                            PlayerMove(Index, Convert.ToByte(Convert.ToInt32(MStruct.tile[map, x, y + 1].Data2)));
                            return false;
                        }
                    }
                    break;
                case 4:
                    if (x - 1 < 0)
                    {
                        return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].LeftBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x - 1, y].RightBlock) == false) { return false; }
                    if ((MStruct.tile[map, x - 1, y].Data1 == "3") || (MStruct.tile[map, x - 1, y].Data1 == "10")) { return false; }
                    if (MStruct.tile[map, x - 1, y].Data1 == "21")
                    {
                        if (!IsPlayerPremmy(Index))
                        {
                            PlayerMove(Index, Convert.ToByte(Convert.ToInt32(MStruct.tile[map, x - 1, y].Data2)));
                            return false;
                        }
                    }
                    break;
                case 6:
                    if (x + 1 > 19)
                    {
                        return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].RightBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x + 1, y].LeftBlock) == false) { return false; }
                    if ((MStruct.tile[map, x + 1, y].Data1 == "3") || (MStruct.tile[map, x + 1, y].Data1 == "10")) { return false; }
                    if (MStruct.tile[map, x + 1, y].Data1 == "21")
                    {
                        if (!IsPlayerPremmy(Index))
                        {
                            PlayerMove(Index, Convert.ToByte(Convert.ToInt32(MStruct.tile[map, x + 1, y].Data2)));
                            return false;
                        }
                    }
                    break;
                default:
                    WinsockAsync.Log(String.Format("Direção nula"));
                    break;
            }

            return true;
        }
        public static void PlayerMove(int Index, byte Dir)
        {
            if (PStruct.tempplayer[Index].Warping) { return; }
            //Tentamos nos mover
            switch (Dir)
            {
                case 8:
                    PStruct.character[Index, PStruct.player[Index].SelectedChar].Y = Convert.ToByte(Convert.ToInt32(PStruct.character[Index, PStruct.player[Index].SelectedChar].Y) - 1);
                    PStruct.character[Index, PStruct.player[Index].SelectedChar].Dir = Globals.DirUp;
                    break;
                case 2:
                    PStruct.character[Index, PStruct.player[Index].SelectedChar].Y = Convert.ToByte(Convert.ToInt32(PStruct.character[Index, PStruct.player[Index].SelectedChar].Y) + 1);
                    PStruct.character[Index, PStruct.player[Index].SelectedChar].Dir = Globals.DirDown;
                    break;
                case 4:
                    PStruct.character[Index, PStruct.player[Index].SelectedChar].X = Convert.ToByte(Convert.ToInt32(PStruct.character[Index, PStruct.player[Index].SelectedChar].X) - 1);
                    PStruct.character[Index, PStruct.player[Index].SelectedChar].Dir = Globals.DirLeft;
                    break;
                case 6:
                    PStruct.character[Index, PStruct.player[Index].SelectedChar].X = Convert.ToByte(Convert.ToInt32(PStruct.character[Index, PStruct.player[Index].SelectedChar].X) + 1);
                    PStruct.character[Index, PStruct.player[Index].SelectedChar].Dir = Globals.DirRight;
                    break;
                default:
                    WinsockAsync.Log(String.Format("Direção nula"));
                    break;
            }

            int map = Convert.ToInt32(PStruct.character[Index, PStruct.player[Index].SelectedChar].Map);
            int x = Convert.ToInt32(PStruct.character[Index, PStruct.player[Index].SelectedChar].X);
            int y = Convert.ToInt32(PStruct.character[Index, PStruct.player[Index].SelectedChar].Y);
            //Verifica os tipos de tiles
            if (MStruct.tile[map, x, y].Data1 == "2")
            {
                PStruct.tempplayer[Index].Warping = true;
                PlayerWarp(Index, Convert.ToInt32(MStruct.tile[map, x, y].Data2), Convert.ToByte(MStruct.tile[map, x, y].Data3), Convert.ToByte(MStruct.tile[map, x, y].Data4));
                return;
            }

            //Se nenhum tile tem ação, enviar as novas coordenadas do jogador após o movimento 
            SendData.Send_PlayerXY(Index);
            SendData.Send_PlayerDir(Index, 1);
        }
        public static void PlayerWarp(int Index, int Map, byte X, byte Y)
        {
            //Salvamos o mapa antigo
            int oldmap = PStruct.character[Index, PStruct.player[Index].SelectedChar].Map;

            if (Map == oldmap)
            {
                PStruct.character[Index, PStruct.player[Index].SelectedChar].X = X;
                PStruct.character[Index, PStruct.player[Index].SelectedChar].Y = Y;
                SendData.Send_PlayerWarp(Index);
                SendData.Send_PlayerXY(Index);
                SendData.Send_PlayerDeathToMap(Index);
                return;
            }


            //Definimos as novas coordenadas do jogador
            PStruct.character[Index, PStruct.player[Index].SelectedChar].Map = Map;
            PStruct.character[Index, PStruct.player[Index].SelectedChar].X = X;
            PStruct.character[Index, PStruct.player[Index].SelectedChar].Y = Y;

            //Valores sobre magias
            if (PStruct.tempplayer[Index].preparingskill > 0)
            {
                PStruct.tempplayer[Index].preparingskill = 0;
                PStruct.tempplayer[Index].skilltimer = 0;
                PStruct.tempplayer[Index].preparingskillslot = 0;
                PStruct.tempplayer[Index].movespeed = Globals.NormalMoveSpeed;
                SendData.Send_BrokeSkill(Index);
                SendData.Send_MoveSpeed(1, Index);
            }
            
            //Enviamos o jogador ao novo mapa
            SendData.Send_PlayerWarp(Index);
            SendData.Send_PlayerDataToMapBut(Index, PStruct.player[Index].Username, PStruct.player[Index].SelectedChar);
            for (int i = 0; i <= Globals.Player_HighIndex; i++)
            {
                if (PStruct.character[i, PStruct.player[i].SelectedChar].Map == PStruct.character[Index, PStruct.player[Index].SelectedChar].Map)
                    if (i != Index)
                    {
                        {
                            SendData.Send_PlayerDataTo(Index, i, PStruct.player[i].Username, PStruct.player[i].SelectedChar);
                            SendData.Send_GuildTo(Index, i);
                            SendData.Send_PlayerSoreTo(Index, i);
                            SendData.Send_PlayerPvpTo(Index, i);
                            SendData.Send_PlayerShoppingTo(Index, i);
                            if (tempplayer[i].Stunned) { SendData.Send_Stun(PStruct.character[Index, PStruct.player[Index].SelectedChar].Map, 1, i, 1); }
                            if (tempplayer[i].Sleeping) { SendData.Send_Sleep(PStruct.character[Index, PStruct.player[Index].SelectedChar].Map, 1, i, 1); }
                            if (tempplayer[i].isDead) { SendData.Send_PlayerDeathTo(Index, i); }
                            //SendData.Send_PlayerMoveSpeedTo(Index, i);
                        }
                    }
            }

            for (int i = 0; i <= Globals.Max_WorkPoints - 1; i++)
            {
                if (MStruct.workpoint[i].map == Map)
                {
                    if ((MStruct.tempworkpoint[i].vitality <= 0))
                    {
                        SendData.Send_EventGraphicToMap(MStruct.workpoint[i].map, MStruct.tile[MStruct.workpoint[i].map, MStruct.workpoint[i].x, MStruct.workpoint[i].y].Event_Id, "", 0, Convert.ToByte(MStruct.workpoint[i].inactive_sprite));
                    }
                }
            }

            for (int i = 0; i <= Globals.Max_Chests - 1; i++)
            {
                if (MStruct.chestpoint[i].map == Map)
                {
                    if (PStruct.character[Index, PStruct.player[Index].SelectedChar].Chest[i])
                    {
                        SendData.Send_EventGraphic(Index, MStruct.tile[MStruct.chestpoint[i].map, MStruct.chestpoint[i].x, MStruct.chestpoint[i].y].Event_Id, MStruct.chestpoint[i].inactive_sprite, MStruct.chestpoint[i].inactive_sprite_index, 0, 8);
                    }
                }
            }

            //????
            SendData.Send_MapGuildTo(Index);
            SendData.Send_PlayerSkills(Index);
            SendData.Send_InvSlots(Index, PStruct.player[Index].SelectedChar);
            SendData.Send_PlayerVitalityToMap(PStruct.character[Index, PStruct.player[Index].SelectedChar].Map, Index, PStruct.tempplayer[Index].Vitality);
            SendData.Send_GuildToMapBut(PStruct.character[Index, PStruct.player[Index].SelectedChar].Map, Index);
            SendData.Send_CompleteGuild(Index);
            SendData.Send_PlayerPvpToMap(Index);
            SendData.Send_PlayerSoreToMap(Index);
            SendData.Send_PlayerExtraVitalityToMap(Index);
            SendData.Send_PlayerExtraSpiritToMap(Index);
            //SendData.Send_PlayerMoveSpeedToMapBut(Index, PStruct.character[Index, PStruct.player[Index].SelectedChar].Map, Index);

            //Enviamos os npcs do novo mapa
            SendData.Send_MapNpcsTo(Index);
            SendData.Send_MapItems(Index);

            //Avisamos aos jogadores do antigo mapa que ele saiu
            SendData.Send_PlayerLeft(oldmap, Index);

            PStruct.tempplayer[Index].Warping = false;
        }
        public static bool CanPlayerAttackNpc(int Attacker, int Victim)
        {
            int Map = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Map;
            int Dir = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir;
            int NpcX = 0;
            int NpcY = 0;
            int PlayerX = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].X;
            int PlayerY = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Y;

            if (NStruct.tempnpc[Map, Victim].Dead == true) { return false; }
            //if (NStruct.tempnpc[Map, Victim].guildnum == PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Guild) { return false; }

            switch (Dir)
            {
                case 8:
                    NpcX = NStruct.tempnpc[Map, Victim].X;
                    NpcY = NStruct.tempnpc[Map, Victim].Y + 1;
                    break;
                case 2:
                    NpcX = NStruct.tempnpc[Map, Victim].X;
                    NpcY = NStruct.tempnpc[Map, Victim].Y - 1;
                    break;
                case 4:
                    NpcX = NStruct.tempnpc[Map, Victim].X + 1;
                    NpcY = NStruct.tempnpc[Map, Victim].Y;
                    break;
                case 6:
                    NpcX = NStruct.tempnpc[Map, Victim].X - 1;
                    NpcY = NStruct.tempnpc[Map, Victim].Y;
                    break;
                default:
                    WinsockAsync.Log(String.Format("Direção nula"));
                    return false;
            }
            
            if ((NpcX == PlayerX) && (NpcY == PlayerY))
            {
                return true;
            }

            return false;
        }
        public static bool CanPlayerAttackPlayer(int Attacker, int Victim)
        {
            int Map = Convert.ToInt32(PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Map);
            int Dir = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir;
            int VictimX = PStruct.character[Victim, PStruct.player[Victim].SelectedChar].X;
            int VictimY = PStruct.character[Victim, PStruct.player[Victim].SelectedChar].Y;
            int PlayerX = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].X;
            int PlayerY = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Y;

            if (PStruct.tempplayer[Victim].isDead == true) { return false; }

            if (!MStruct.tempmap[Map].WarActive)
            {
                if (PStruct.character[Victim, PStruct.player[Victim].SelectedChar].Level < 10) { SendData.Send_MsgToPlayer(Attacker, "Apenas jogadores com nível superior a 10 podem participar do PVP.", Globals.ColorRed, Globals.Msg_Type_Server); return false; }
                if (!MStruct.MapIsPVP(Map)) { SendData.Send_MsgToPlayer(Attacker, "Você não pode atacar outros jogadores em áreas seguras.", Globals.ColorRed, Globals.Msg_Type_Server); return false; }
            }

            switch (Dir)
            {
                case 8:
                    VictimY += 1;
                    break;
                case 2:
                    VictimY -= 1;
                    break;
                case 4:
                    VictimX += 1;
                    break;
                case 6:
                    VictimX -= 1;
                    break;
                default:
                    WinsockAsync.Log(String.Format("Direção nula"));
                    return false;
            }

            if ((VictimX == PlayerX) && (VictimY == PlayerY))
            {
                return true;
            }

            return false;
        }
        public static int GetPlayerElement(int index, int element)
        {
            int quantity = 0;

            if (element == 1)
            {
                return Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Fire);
            }

            if (element == 2)
            {
                return Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Earth);
            }
            if (element == 3)
            {
                return Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Water);
            }
            if (element == 4)
            {
                return Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Wind);
            }
            if (element == 5)
            {
                return Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Dark);
            }
            if (element == 6)
            {
                return Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Light);
            }

            return quantity;
        }
        public static int GetRefinCraft(int index, int type)
        {
            //Váriaveis
            int RefinChance = GetRefinDrop();
            int Refin = RefinChance;

            //Retorna o valor de Refin
            return Refin;
        }
        public static int GetRefinDrop()
        {
            //Váriaveis
            int RefinChance = Globals.Rand(1, 100);
            int Refin = 0;


            //Verificação e definição do nível de Refin
            if ((RefinChance <= 30)  && (RefinChance >= 16))// 30% Refin 1
            {
                Refin = 1;
            }
            else if ((RefinChance <= 51) && (RefinChance >= 31)) // 20% Refin 2
            {
                Refin = 2;
            }
            else if ((RefinChance <= 67) && (RefinChance >= 52)) // 15% Refin 3
            {
                Refin = 3;
            }
            else if ((RefinChance <= 78) && (RefinChance >= 68)) // 10% Refin 4
            {
                Refin = 4;
            }
            else if ((RefinChance <= 87) && (RefinChance >= 79)) // 8% Refin 5
            {
                Refin = 5;
            }
            else if ((RefinChance <= 87) && (RefinChance >= 85)) // 5% Refin 6
            {
                Refin = 6;
            }
            else if ((RefinChance <= 90) && (RefinChance >= 88)) // 3% Refin 7
            {
                Refin = 7;
            }
            else if ((RefinChance <= 92) && (RefinChance >= 91)) // 1.x% Refin 8
            {
                Refin = 8;
            }
            else if ((RefinChance <= 94) && (RefinChance >= 93)) // 1.x% Refin 9
            {
                Refin = 9;
            }
            else if ((RefinChance <= 96) && (RefinChance >= 95)) // 1.x% Refin 10
            {
                Refin = 10;
            }
            else if ((RefinChance <= 98) && (RefinChance >= 97)) // 1.x% Refin 11
            {
                Refin = 11;
            }
            else if (RefinChance == 99) // 0.5% Refin 12
            {
                Refin = 12;
            }
            else if (RefinChance == 100) // 0.5% Refin 13
            {
                Refin = 13;
            }

            //Retorna o valor de Refin
            return Refin;
        }
        public static void DropItem(int Map, int MapItem, int x, int y, int Value, int ItemNum, int ItemType, int ItemRefin)
        {
            MStruct.mapitem[Map, MapItem].Value = Value;
            MStruct.mapitem[Map, MapItem].X = x;
            MStruct.mapitem[Map, MapItem].Y = y;
            MStruct.mapitem[Map, MapItem].ItemNum = ItemNum;
            MStruct.mapitem[Map, MapItem].ItemType = ItemType;
            MStruct.mapitem[Map, MapItem].Refin = ItemRefin;
            MStruct.mapitem[Map, MapItem].Timer = Loops.TickCount.ElapsedMilliseconds + 600000;
        }

        public static int GetPlayerSkillSlot(int Index, int SkillNum, bool by_skill_slot = false)
        {
            if (!by_skill_slot)
            {
                for (int i = 1; i < Globals.MaxHotkeys; i++)
                {
                    if (PStruct.skill[Index, PStruct.hotkey[Index, i].num].num == SkillNum)
                    {
                        return i;
                    }
                }
            }

            for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
            {
                if (PStruct.skill[Index, i].num == SkillNum)
                {
                    return i;
                }
            }

            return 0;
        }
        public static int GetOpenPassiveEffect(int index)
        {
            for (int i = 1; i < Globals.MaxPassiveEffects; i++)
            {
                if (!PStruct.ppassiveffect[index, i].active)
                {
                    return i;
                }
            }

            return 0;
        }
        public static int GetOpenSpellBuff(int index)
        {
            for (int i = 1; i < Globals.MaxSpellBuffs; i++)
            {
                if (!PStruct.pspellbuff[index, i].active)
                {
                    return i;
                }
            }

            return 0;
        }
        public static int IsActiveSpellBuff(int index)
        {
            for (int i = 1; i < Globals.MaxSpellBuffs; i++)
            {
                if (!PStruct.pspellbuff[index, i].active)
                {
                    return i;
                }
            }

            return 0;
        }
        public static void ExecutePassiveEffect(int index, int passive)
        {
            if (PStruct.ppassiveffect[index, passive].targettype == 1)
            {
                //Jogador
                if (PStruct.ppassiveffect[index, passive].type == 1) //DANO
                {
                    SendData.Send_Animation(PStruct.character[index, PStruct.player[index].SelectedChar].Map, PStruct.ppassiveffect[index, passive].targettype, PStruct.ppassiveffect[index, passive].target, SStruct.skill[PStruct.ppassiveffect[index, passive].spellnum].animation_id);
                    PlayerAttackPlayer(index, PStruct.ppassiveffect[index, passive].target, PStruct.ppassiveffect[index, passive].spellnum, PStruct.character[index, PStruct.player[index].SelectedChar].Map, true);
                    PStruct.ppassiveffect[index, passive].active = false;
                    PStruct.ppassiveffect[index, passive].type = 0;
                    PStruct.ppassiveffect[index, passive].timer = 0;
                    PStruct.ppassiveffect[index, passive].target = 0;
                    PStruct.ppassiveffect[index, passive].targettype = 0;
                    PStruct.ppassiveffect[index, passive].spellnum = 0;
                    return;
                }
            }
            if (PStruct.ppassiveffect[index, passive].targettype == 2)
            {
                //NPC
                if (PStruct.ppassiveffect[index, passive].type == 1) //DANO
                {
                    SendData.Send_Animation(PStruct.character[index, PStruct.player[index].SelectedChar].Map, PStruct.ppassiveffect[index, passive].targettype, PStruct.ppassiveffect[index, passive].target, SStruct.skill[PStruct.ppassiveffect[index, passive].spellnum].animation_id);
                    PlayerAttackNpc(index, PStruct.ppassiveffect[index, passive].target, PStruct.ppassiveffect[index, passive].spellnum, PStruct.character[index, PStruct.player[index].SelectedChar].Map, true);
                    PStruct.ppassiveffect[index, passive].active = false;
                    PStruct.ppassiveffect[index, passive].type = 0;
                    PStruct.ppassiveffect[index, passive].timer = 0;
                    PStruct.ppassiveffect[index, passive].target = 0;
                    PStruct.ppassiveffect[index, passive].targettype = 0;
                    PStruct.ppassiveffect[index, passive].spellnum = 0;
                    return;
                }
            }
            PStruct.ppassiveffect[index, passive].active = false;
            PStruct.ppassiveffect[index, passive].type = 0;
            PStruct.ppassiveffect[index, passive].timer = 0;
            PStruct.ppassiveffect[index, passive].target = 0;
            PStruct.ppassiveffect[index, passive].targettype = 0;
            PStruct.ppassiveffect[index, passive].spellnum = 0;
        }
        public static void SkillPassive(int index, int targettype, int target)
        {
            int open_passive = GetOpenPassiveEffect(index);

            if (open_passive == 0) { return; }

            for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
            {
                if (SStruct.skill[PStruct.skill[index, i].num].type == 10)
                {
                    int levelmultiplier = (SStruct.skill[PStruct.skill[index, i].num].passive_multiplier) * PStruct.skill[index, i].level;
                    int chance = SStruct.skill[PStruct.skill[index, i].num].passive_chance + levelmultiplier;


                    //Motivação Aiprah
                    if (SStruct.skill[PStruct.skill[index, i].num].passive_type == 1)
                    {
                        int passive_test = Globals.Rand(1, 100);
                        if (passive_test <= chance)
                        {
                            if (targettype == 2)
                            {
                                PStruct.ppassiveffect[index, open_passive].spellnum = PStruct.skill[index, i].num;
                                PStruct.ppassiveffect[index, open_passive].timer = Loops.TickCount.ElapsedMilliseconds + SStruct.skill[PStruct.skill[index, i].num].passive_interval;
                                PStruct.ppassiveffect[index, open_passive].target = target;
                                PStruct.ppassiveffect[index, open_passive].targettype = targettype;
                                PStruct.ppassiveffect[index, open_passive].type = 1;
                                PStruct.ppassiveffect[index, open_passive].active = true;
                            }
                            if (targettype == 1)
                            {
                                PStruct.ppassiveffect[index, open_passive].spellnum = PStruct.skill[index, i].num;
                                PStruct.ppassiveffect[index, open_passive].timer = Loops.TickCount.ElapsedMilliseconds + SStruct.skill[PStruct.skill[index, i].num].passive_interval;
                                PStruct.ppassiveffect[index, open_passive].target = target;
                                PStruct.ppassiveffect[index, open_passive].targettype = targettype;
                                PStruct.ppassiveffect[index, open_passive].type = 1;
                                PStruct.ppassiveffect[index, open_passive].active = true;
                            }
                        }
                    }

                }
            }
   
        }
        public static void PlayerAttackNpc(int Attacker, int Victim, int isSpell = 0, int Map = 0, bool isPassive = false, int skill_level = 0, bool is_pet = false)
        {
            if (Map == 0) { Map = Convert.ToInt32(PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Map); }
            int Dir = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir;
            int NpcX = NStruct.tempnpc[Map, Victim].X;
            int NpcY = NStruct.tempnpc[Map, Victim].Y;
            int PlayerX = Convert.ToInt32(PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].X);
            int PlayerY = Convert.ToInt32(PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Y);
            int Damage = 0;
            int chance = 0;
            bool is_critical = false;

            if ((!isPassive) && (isSpell == 0)) { SkillPassive(Attacker, Globals.Target_Npc, Victim); }
            if ((NStruct.tempnpc[Map, Victim].Vitality <= 0) || (NStruct.tempnpc[Map, Victim].Dead)) { return; }

            //Cálculo do dano

            //Magias
            if (isSpell > 0)
            {
                int skill_slot = 0;

                if (!isPassive) { skill_slot = GetPlayerSkillSlot(Attacker, isSpell); }
                else { skill_slot = GetPlayerSkillSlot(Attacker, isSpell, true); }

                if (skill_slot == 0) { return; }

                int extra_spellbuff = 0;

                for (int i = 1; i < Globals.MaxSpellBuffs; i++)
                {
                    if (PStruct.pspellbuff[Attacker, i].active)
                    {
                        if (PStruct.pspellbuff[Attacker, i].timer > Loops.TickCount.ElapsedMilliseconds) { extra_spellbuff += PStruct.pspellbuff[Attacker, i].value; }
                        else
                        {
                            PStruct.pspellbuff[Attacker, i].value = 0;
                            PStruct.pspellbuff[Attacker, i].type = 0;
                            PStruct.pspellbuff[Attacker, i].timer = 0;
                            PStruct.pspellbuff[Attacker, i].active = false;
                        }
                    }
                }

                //Multiplicador de dano
                double multiplier = Convert.ToDouble(SStruct.skill[isSpell].scope) / 7.2;

                //Elemento mágico multiplicado
                double min_damage = GetPlayerMinMagic(Attacker);
                double max_damage = GetPlayerMaxMagic(Attacker);

                if (PStruct.hotkey[Attacker, skill_slot].num > Globals.MaxPlayer_Skills)
                {
                    PStruct.hotkey[Attacker, skill_slot].num = 0;
                    return;
                }

                //Multiplicador de nível
                double levelmultiplier = (1.0 + multiplier) * PStruct.skill[Attacker, PStruct.hotkey[Attacker, skill_slot].num].level; //Except

                //Verificando se a skill teve algum problema e corrigindo
                if (levelmultiplier < 1.0) { levelmultiplier = 1.0; }

                //Dano total que pode ser causado
                double totaldamage = max_damage + (Convert.ToDouble(SStruct.skill[isSpell].damage_formula) * levelmultiplier);
                double totalmindamage = min_damage + (Convert.ToDouble(SStruct.skill[isSpell].damage_formula) * levelmultiplier);

                //Passamos para int para tornar o dano exato
                int MinDamage = Convert.ToInt32(totalmindamage);
                int MaxDamage = Convert.ToInt32(totaldamage) + 1;

                if (MinDamage >= MaxDamage) { MaxDamage = MinDamage; }

                //Definição geral do dano
                Damage = Globals.Rand(MinDamage, MaxDamage);
                Damage -= (Damage / 100) * PStruct.tempplayer[Attacker].ReduceDamage;
                Damage = Damage - ((Damage / 100) * NStruct.npc[Map, Victim].MagicDefense);

                if (PStruct.tempplayer[Attacker].ReduceDamage > 0)
                {
                    SendData.Send_ActionMsg(Victim, "Dano Reduzido", Globals.ColorWhite, NpcX, NpcY, 1, 0, Map);
                    PStruct.tempplayer[Attacker].ReduceDamage = 0;
                }

                if (isSpell == 36)
                {
                    Damage += ((Damage / 100) *GetPlayerDefense(Attacker));
                }

                if (PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].ClassId == 6)
                {
                    for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                    {
                        if ((PStruct.skill[Attacker, i].num == 42) && (PStruct.skill[Attacker, i].level > 0))
                        {
                            //Dano crítico?
                            int critical_t = Globals.Rand(0, 100);

                            if (critical_t <= GetPlayerCritical(Attacker))
                            {
                                Damage = Convert.ToInt32((Convert.ToDouble(Damage) * 1.5));
                                SendData.Send_Animation(Map, Globals.Target_Npc, Victim, 152);
                            }
                            //break;
                        }
                        if ((PStruct.skill[Attacker, i].num == 41) && (PStruct.skill[Attacker, i].level > 0))
                        {
                            if (isSpell == 40)
                            {
                                int open_passive = GetOpenPassiveEffect(Attacker);

                                if (open_passive == 0) { return; }

                                PStruct.ppassiveffect[Attacker, open_passive].spellnum = PStruct.skill[Attacker, i].num;
                                PStruct.ppassiveffect[Attacker, open_passive].timer = Loops.TickCount.ElapsedMilliseconds + SStruct.skill[PStruct.skill[Attacker, i].num].passive_interval;
                                PStruct.ppassiveffect[Attacker, open_passive].target = Victim;
                                PStruct.ppassiveffect[Attacker, open_passive].targettype = Globals.Target_Npc;
                                PStruct.ppassiveffect[Attacker, open_passive].type = 1;
                                PStruct.ppassiveffect[Attacker, open_passive].active = true;
                            }
                            //break;
                        }
                    }
                }

                if (Damage < 1)
                {
                    SendData.Send_ActionMsg(Attacker, "Resistiu", Globals.ColorPink, NpcX, NpcY, Globals.Action_Msg_Scroll, 0, Map);
                    return;
                }

                if (extra_spellbuff > 0)
                {
                    //BUFFF :DDDD
                    Damage += (Damage / 100) * extra_spellbuff;
                }

                int drain = SStruct.skill[isSpell].drain;

                //Drenagem de vida?
                if (drain > 0)
                {
                    double real_drain = (Convert.ToDouble(Damage) / 100) * drain;
                    PlayerLogic.HealPlayer(Attacker, Convert.ToInt32(real_drain));
                    //SendData.Send_ActionMsg(Attacker, Convert.ToInt32(real_drain).ToString(), Globals.ColorGreen, PlayerX, PlayerY, 1, 1);
                    //SendData.Send_PlayerVitalityToMap(Map, Attacker, PStruct.tempplayer[Attacker].Vitality);
                }

                NStruct.tempnpc[Map, Victim].Target = Attacker;
            }
            //Ataques básicos
            else
            {
                if (tempplayer[Attacker].Blind)
                {
                    SendData.Send_ActionMsg(Attacker, "Errou", Globals.ColorWhite, NpcX, NpcY, 1, 0, Map);
                    return;
                }

                //Desviar do golpe?
                int parry_test = Globals.Rand(0, 100);

                if (parry_test <= (NStruct.GetNpcParry(Map, Victim) - PStruct.GetPlayerCritical(Attacker)))
                {
                    SendData.Send_ActionMsg(Attacker, "Errou", Globals.ColorWhite, NpcX, NpcY, 1, 0, Map);
                    return;
                }

                //Dano comum
                int MinDamage = GetPlayerMinAttack(Attacker);
                int MaxDamage = GetPlayerMaxAttack(Attacker);

                if (is_pet)
                {
                    string equipment = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Equipment;
                    string[] equipdata = equipment.Split(',');
                    string[] petdata = equipdata[4].Split(';');

                    int petnum = Convert.ToInt32(petdata[0]);
                    int petlvl = Convert.ToInt32(petdata[1]);

                    MinDamage = (Convert.ToInt32(IStruct.item[petnum].damage_variance)) + ((petlvl / 2) * Convert.ToInt32(IStruct.item[petnum].damage_formula));
                    MaxDamage = (Convert.ToInt32(IStruct.item[petnum].damage_variance)) + ((petlvl) * Convert.ToInt32(IStruct.item[petnum].damage_formula));

                    if (MinDamage >= MaxDamage)
                    {
                        Damage = MinDamage;
                        Damage -= (Damage / 100) * PStruct.tempplayer[Attacker].ReduceDamage;
                        Damage = Damage - ((Damage / 100) * NStruct.npc[Map, Victim].Defense);
                    }
                    else
                    {
                        Damage = Globals.Rand(MinDamage, MaxDamage);
                        Damage -= (Damage / 100) * PStruct.tempplayer[Attacker].ReduceDamage;
                        Damage = Damage - ((Damage / 100) * NStruct.npc[Map, Victim].Defense);
                    }

                    SendData.Send_Animation(Map, Globals.Target_Npc, Victim, IStruct.item[petnum].animation_id);
                    SendData.Send_ActionMsg(Attacker, "-" + Damage.ToString(), Globals.ColorPurple, NpcX, NpcY, 1, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, Map);
                    goto important;
                }

                if (MinDamage >= MaxDamage) 
                {
                    Damage = MinDamage;
                    Damage -= (Damage / 100) * PStruct.tempplayer[Attacker].ReduceDamage;
                    Damage = Damage - ((Damage / 100) * NStruct.npc[Map, Victim].Defense);
                }
                else 
                { 
                    Damage = Globals.Rand(MinDamage, MaxDamage);
                    Damage -= (Damage / 100) * PStruct.tempplayer[Attacker].ReduceDamage;
                    Damage = Damage - ((Damage / 100) * NStruct.npc[Map, Victim].Defense);
                }

                if (PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].ClassId == 2)
                {
                    for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                    {
                        if ((PStruct.skill[Attacker, i].num == 52) && (PStruct.skill[Attacker, i].level > 0))
                        {
                            Damage += ((NStruct.npc[Map, Victim].Vitality / 100) * (2 + PStruct.skill[Attacker, i].level));
                        }
                    }
                }

                if (PStruct.tempplayer[Attacker].ReduceDamage > 0)
                {
                    SendData.Send_ActionMsg(Victim, "Dano Reduzido", Globals.ColorWhite, NpcX, NpcY, 1, 0, Map);
                    PStruct.tempplayer[Attacker].ReduceDamage = 0;
                }

                if (Damage <= 0)
                {
                    Damage = 1;
                }

                //Dano crítico?
                int critical_test = Globals.Rand(0, 100);

                if (critical_test <= GetPlayerCritical(Attacker))
                {
                    Damage = Convert.ToInt32((Convert.ToDouble(Damage) * 1.5));
                    is_critical = true;
                    NStruct.tempnpc[Map, Victim].Target = Attacker;
                }

                //Dano e animação
                SendData.Send_Animation(Map, 2, Victim, 7);
            }

            if (is_critical) 
            { 
                SendData.Send_ActionMsg(Attacker, "-" + Damage.ToString(), 1, NpcX, NpcY, 1, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, Map);
                int true_range = 0;
                for (int i = 1; i <= 2; i++)
                {
                    if (PStruct.CanThrowNpc(Map, Victim, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, i))
                    {
                        true_range += 1;
                    }
                    else
                    {
                        break;
                    }
                }

                if (true_range < 2)
                {
                    Damage += 2 - true_range;
                }

                if (true_range > 0)
                {
                    PStruct.ThrowNpc(Map, Victim, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, true_range);
                }
            }
            else {
                if (isSpell > 0) { SendData.Send_ActionMsg(Attacker, "-" + Damage.ToString(), Globals.ColorPink, NpcX, NpcY, Globals.Action_Msg_Scroll, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, Map); }
                else { SendData.Send_ActionMsg(Attacker, "-" + Damage.ToString(), 4, NpcX, NpcY, Globals.Action_Msg_Scroll, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, Map); }
            }

            important:
            //Nova vida do npc
            NStruct.tempnpc[Map, Victim].Vitality -= Damage;

            //O NPC é um coletor?
            if (NStruct.tempnpc[Map, Victim].guildnum > 0)
            {
                if (!MStruct.tempmap[Map].WarActive)
                {
                    MStruct.tempmap[Map].WarActive = true;
                    SendData.Send_MsgToGuild(NStruct.tempnpc[Map, Victim].guildnum, "O coletor de " + MStruct.map[Map].name + " está sendo atacado.", Globals.ColorYellow, Globals.Msg_Type_Server);
                }
                MStruct.tempmap[Map].WarTimer = Loops.TickCount.ElapsedMilliseconds + 20000;
                //Avisar a guilda sobre seu ataque
            }

            //Sleep?
            if (NStruct.tempnpc[Map, Victim].Sleeping)
            {
                NStruct.tempnpc[Map, Victim].Sleeping = false;
                NStruct.tempnpc[Map, Victim].SleepTimer = 0;
                SendData.Send_Sleep(Map, 2, Victim, 0);
            }

            //Enviamos a nova vida do npc
            SendData.Send_NpcVitality(Map, Victim, NStruct.tempnpc[Map, Victim].Vitality);

            if ((NStruct.npc[Map, Victim].Type == 1) && ( NStruct.tempnpc[Map, Victim].Target == 0)) { NStruct.tempnpc[Map, Victim].Target = Attacker; }

            if (NStruct.tempnpc[Map, Victim].Vitality <= 0)
            {
                //Npc era um coletor?
                if (NStruct.tempnpc[Map, Victim].guildnum > 0)
                {
                    SendData.Send_MsgToAll("A área " + MStruct.map[Map].name + " foi desocupada.", Globals.ColorYellow, Globals.Msg_Type_Server);
                    SendData.Send_MsgToGuild(NStruct.tempnpc[Map, Victim].guildnum, "O coletor de " + MStruct.map[Map].name + " foi destruído.", Globals.ColorYellow, Globals.Msg_Type_Server);
                    SendData.Send_MsgToPlayer(Attacker, "Você derrotou um coletor de guilda, e recolheu todo o seu ouro.", Globals.ColorYellow, Globals.Msg_Type_Server);
                    GivePlayerGold(Attacker, MStruct.map[Map].guildgold);
                    MStruct.map[Map].guildnum = 0;
                    MStruct.map[Map].guildgold = 0;
                    NStruct.ClearTempNpc(Map, Victim);
                    SendData.Send_MapGuildToMap(Map);
                    MStruct.tempmap[Map].NpcCount = MStruct.GetMapNpcCount(Map);
                    //Avisamos que o npc tem que sumir
                    SendData.Send_NpcLeft(Map, Victim);
                    return;
                }

                //O mapa possúi um coletor?
                int guildnum = MStruct.map[Map].guildnum;
                if (guildnum > 0)
                {
                    int total_exp = (NStruct.npc[Map, Victim].Exp / 100) * 10; //10%
                    if (total_exp <= 0) { total_exp = 1; }
                    int total_gold = (NStruct.npc[Map, Victim].Gold / 100) * 10; //10%
                    if (total_gold <= 0) { total_gold = 1; }
                    GStruct.guild[guildnum].exp += total_exp;
                    MStruct.map[Map].guildgold += total_gold;
                }

                //Entrega a exp para o grupo
                PartyShareExp(Attacker, Victim, Map);

                //Avisamos que o npc tem que sumir
                SendData.Send_NpcLeft(Map, Victim);

                //Morto
                NStruct.tempnpc[Map, Victim].Dead = true;

                //Drop
                for (int i = 0; i <= NStruct.GetNpcDropCount(Map, Victim); i++)
                {
                    if (NStruct.npcdrop[Map, Victim, i].Chance <= 100)
                    {
                        chance = Globals.Rand(1, 100);
                        if (chance <= NStruct.npcdrop[Map, Victim, i].Chance)
                        {
                            if (MStruct.GetNullMapItem(Map) == 0) { break; }
                            int NullMapItem = MStruct.GetNullMapItem(Map);
                            if (NStruct.npcdrop[Map, Victim, i].ItemType > 1) { DropItem(Map, NullMapItem, NpcX, NpcY, NStruct.npcdrop[Map, Victim, i].Value, NStruct.npcdrop[Map, Victim, i].ItemNum, NStruct.npcdrop[Map, Victim, i].ItemType, GetRefinDrop()); }
                            else { DropItem(Map, NullMapItem, NpcX, NpcY, NStruct.npcdrop[Map, Victim, i].Value, NStruct.npcdrop[Map, Victim, i].ItemNum, NStruct.npcdrop[Map, Victim, i].ItemType, 0); }
                            SendData.Send_MapItem(Map, NullMapItem);
                        }
                        else
                        {
                            //Tentar de novo
                            if (IsPlayerPremmy(Attacker))
                            {
                                chance = Globals.Rand(1, 100);
                                if (chance <= NStruct.npcdrop[Map, Victim, i].Chance / 2)
                                {
                                    if (MStruct.GetNullMapItem(Map) == 0) { break; }
                                    int NullMapItem = MStruct.GetNullMapItem(Map);
                                    if (NStruct.npcdrop[Map, Victim, i].ItemType > 1) { DropItem(Map, NullMapItem, NpcX, NpcY, NStruct.npcdrop[Map, Victim, i].Value, NStruct.npcdrop[Map, Victim, i].ItemNum, NStruct.npcdrop[Map, Victim, i].ItemType, GetRefinDrop()); }
                                    else { DropItem(Map, NullMapItem, NpcX, NpcY, NStruct.npcdrop[Map, Victim, i].Value, NStruct.npcdrop[Map, Victim, i].ItemNum, NStruct.npcdrop[Map, Victim, i].ItemType, 0); }
                                    SendData.Send_MapItem(Map, NullMapItem);
                                }
                            }
                        }
                    }
                    else
                    {
                        chance = Globals.Rand(1, NStruct.npcdrop[Map, Victim, i].Chance);
                        if (chance == NStruct.npcdrop[Map, Victim, i].Chance)
                        {
                            if (MStruct.GetNullMapItem(Map) == 0) { break; }
                            int NullMapItem = MStruct.GetNullMapItem(Map);
                            if (NStruct.npcdrop[Map, Victim, i].ItemType > 1) { DropItem(Map, NullMapItem, NpcX, NpcY, NStruct.npcdrop[Map, Victim, i].Value, NStruct.npcdrop[Map, Victim, i].ItemNum, NStruct.npcdrop[Map, Victim, i].ItemType, GetRefinDrop()); }
                            else { DropItem(Map, NullMapItem, NpcX, NpcY, NStruct.npcdrop[Map, Victim, i].Value, NStruct.npcdrop[Map, Victim, i].ItemNum, NStruct.npcdrop[Map, Victim, i].ItemType, 0); }
                            SendData.Send_MapItem(Map, NullMapItem);
                        }
                        else
                        {
                            //Tentar de novo
                            if (IsPlayerPremmy(Attacker))
                            {
                                chance = Globals.Rand(1, NStruct.npcdrop[Map, Victim, i].Chance * 2);
                                if (chance == NStruct.npcdrop[Map, Victim, i].Chance * 2)
                                {
                                    if (MStruct.GetNullMapItem(Map) == 0) { break; }
                                    int NullMapItem = MStruct.GetNullMapItem(Map);
                                    if (NStruct.npcdrop[Map, Victim, i].ItemType > 1) { DropItem(Map, NullMapItem, NpcX, NpcY, NStruct.npcdrop[Map, Victim, i].Value, NStruct.npcdrop[Map, Victim, i].ItemNum, NStruct.npcdrop[Map, Victim, i].ItemType, GetRefinDrop()); }
                                    else { DropItem(Map, NullMapItem, NpcX, NpcY, NStruct.npcdrop[Map, Victim, i].Value, NStruct.npcdrop[Map, Victim, i].ItemNum, NStruct.npcdrop[Map, Victim, i].ItemType, 0); }
                                    SendData.Send_MapItem(Map, NullMapItem);
                                }
                            }
                        }
                    }
                }

                //GOLD
                GivePlayerGold(Attacker, NStruct.npc[Map, Victim].Gold);

                //Limpar dados de estudo de movimento
                NpcIA.ClearPrevMove(Map, Victim);

                ///Temporizador para voltar
                NStruct.tempnpc[Map, Victim].RespawnTimer = Loops.TickCount.ElapsedMilliseconds + NStruct.npc[Map, Victim].Respawn;
            }
        }
        public static int GetMinerLevel(int index)
        {
            int exp = 0;//PStruct.character[index, PStruct.player[index].SelectedChar].Miner;

            int level = (exp / 100);

            return level;
        }
        public static void PartyShareExp(int Attacker, int Victim, int Map)
        {
            int NpcX = NStruct.tempnpc[Map, Victim].X;
            int NpcY = NStruct.tempnpc[Map, Victim].Y;
            int PlayerX = Convert.ToInt32(PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].X);
            int PlayerY = Convert.ToInt32(PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Y);

            //PARTY EXP
            int partynum = PStruct.tempplayer[Attacker].Party;

            //Damos xp ao jogador e mostramos a xp ganha
            if (partynum > 0)
            {
                int memberscount = GetPartyMembersCount(partynum);
                for (int i = 1; i <= memberscount; i++)
                {
                    int memberindex = PStruct.partymembers[partynum, i].index;
                    if (PStruct.character[memberindex, PStruct.player[memberindex].SelectedChar].Map == PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Map)
                    {
                        //Tem grupo para dividir a exp
                        //Adiciona uma kill se houver uma quest para esse npc
                        for (int g = 1; g < Globals.MaxQuestGivers; g++)
                        {
                            for (int q = 1; q < Globals.MaxQuestPerGiver; q++)
                            {
                                //Prevent
                                if ((String.IsNullOrEmpty(MStruct.quest[g, q].type)) && (PStruct.queststatus[memberindex, g, q].status > 0)) { PStruct.queststatus[memberindex, g, q].status = 0; return; }
                                
                                //Execute
                                if ((PStruct.queststatus[memberindex, g, q].status == 1) && (Convert.ToInt32(MStruct.quest[g, q].type.Split('|')[0]) > 0))
                                {
                                    for (int k = 1; k < Globals.MaxQuestKills; k++)
                                    {
                                        if (MStruct.questkills[g, q, k].monstername == NStruct.npc[Map, Victim].Name)
                                        {
                                            if (PStruct.questkills[memberindex, g, q, k].kills < MStruct.questkills[g, q, k].value)
                                            {
                                                PStruct.questkills[memberindex, g, q, k].kills += 1;
                                                SendData.Send_ActionMsg(memberindex, "Derrotar " + MStruct.questkills[g, q, k].monstername + " " + PStruct.questkills[memberindex, g, q, k].kills + "/" + MStruct.questkills[g, q, k].value, Globals.ColorGreen, NpcX, NpcY, 0, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir);
                                                SendData.Send_QuestKill(memberindex, g, q, k);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        int exp = NStruct.npc[Map, Victim].Exp;
                        if (IsPlayerPremmy(memberindex)) { exp = Convert.ToInt32(exp * 1.5); }
                        GivePlayerExp(memberindex, exp);
                    }
                }
            }
            //Não tem grupo para dividir a exp
            else
            {
                //Adiciona uma kill se houver uma quest para esse npc
                for (int g = 1; g < Globals.MaxQuestGivers; g++)
                {
                    for (int q = 1; q < Globals.MaxQuestPerGiver; q++)
                    {
                        //Prevent
                        if ((String.IsNullOrEmpty(MStruct.quest[g, q].type)) && (PStruct.queststatus[Attacker, g, q].status > 0)) { PStruct.queststatus[Attacker, g, q].status = 0; return; }
                        
                        //Execute
                        if ((PStruct.queststatus[Attacker, g, q].status == 1) && (Convert.ToInt32(MStruct.quest[g, q].type.Split('|')[0]) > 0))
                        {
                            for (int k = 1; k < Globals.MaxQuestKills; k++)
                            {
                                if (MStruct.questkills[g, q, k].monstername == NStruct.npc[Map, Victim].Name)
                                {
                                    if (PStruct.questkills[Attacker, g, q, k].kills < MStruct.questkills[g, q, k].value)
                                    {
                                        PStruct.questkills[Attacker, g, q, k].kills += 1;
                                        SendData.Send_ActionMsg(Attacker, "Derrotar " + MStruct.questkills[g, q, k].monstername + " " + PStruct.questkills[Attacker, g, q, k].kills + "/" + MStruct.questkills[g, q, k].value, Globals.ColorGreen, NpcX, NpcY, 0, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir);
                                        SendData.Send_QuestKill(Attacker, g, q, k);
                                    }
                                }
                            }
                        }
                    }
                }
                int exp = NStruct.npc[Map, Victim].Exp;
                if (IsPlayerPremmy(Attacker)) { exp = Convert.ToInt32(exp * 1.5); }
                GivePlayerExp(Attacker, exp);
            }
        }
        public static bool HaveToolToWork(int index, int type)
        {
            if (type == Globals.Job_Miner)
            {
                if (GetPlayerWeapon(index) == 28)
                {
                    return true;
                }
            }
            return false;
        }
        public static void PlayerAttackWorkPoint(int index, int workpoint)
        {
            if (MStruct.tempworkpoint[workpoint].vitality <= 0) 
            {
                SendData.Send_MsgToPlayer(index, "Recurso esgotado", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            int damage = 0;
            int profnum = 0;


            profnum = GetPlayerProf(index, MStruct.workpoint[workpoint].type);

            if (profnum <= 0)
            {
                SendData.Send_MsgToPlayer(index, "Você não tem o conhecimento para explorar este recurso.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            if (!HaveToolToWork(index, MStruct.workpoint[workpoint].type))
            {
                SendData.Send_MsgToPlayer(index, "Você precisa de uma ferramenta certa para explorar este recurso.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }
                
                damage = 1 + Convert.ToInt32(Convert.ToDouble(PStruct.character[index, PStruct.player[index].SelectedChar].Prof_Level[profnum] * 0.5));
                SendData.Send_Animation(PStruct.character[index, PStruct.player[index].SelectedChar].Map, Globals.Target_Player, index, WStruct.weapon[28].animation_id);

            if (damage == 0) { damage = 1; }

            MStruct.tempworkpoint[workpoint].vitality -= 1;
            SendData.Send_ActionMsg(index, "-" + damage, Globals.ColorWhite, MStruct.workpoint[workpoint].x, MStruct.workpoint[workpoint].y, 1, 0, MStruct.workpoint[workpoint].map);

            if (MStruct.tempworkpoint[workpoint].vitality <= 0)
            {
                GiveItem(index, 1, MStruct.workpoint[workpoint].reward, 1, 0, 0);
                MStruct.tempworkpoint[workpoint].respawn = Loops.TickCount.ElapsedMilliseconds + (MStruct.workpoint[workpoint].respawn_timer * 10000);
                character[index, PStruct.player[index].SelectedChar].Prof_Exp[profnum] += MStruct.workpoint[workpoint].exp;
                //Verificamos se ele subiu de nível
                if ((character[index, PStruct.player[index].SelectedChar].Prof_Exp[profnum] >= GetpProfExpToNextLevel(index, profnum)) && (character[index, PStruct.player[index].SelectedChar].Prof_Level[profnum] < 80))
                {
                    character[index, PStruct.player[index].SelectedChar].Prof_Exp[profnum] -= GetpProfExpToNextLevel(index, profnum);
                    character[index, PStruct.player[index].SelectedChar].Prof_Level[profnum] += 1;
                    SendData.Send_ProfLEVEL(index, profnum);
                }
                else
                {
                    //GetExpToNextLevel
                    SendData.Send_ProfEXP(index, profnum);
                   // SendData.Send_PlayerExp(memberindex);
                    //Enviamos uma animação bonitinha de exp :D
                    SendData.Send_ActionMsg(index, "+" + MStruct.workpoint[workpoint].exp + "pEXP", 0, character[index, PStruct.player[index].SelectedChar].X, character[index, PStruct.player[index].SelectedChar].Y, 1, 0, MStruct.workpoint[workpoint].map);
                }
                SendData.Send_EventGraphicToMap(MStruct.workpoint[workpoint].map, MStruct.tile[MStruct.workpoint[workpoint].map, MStruct.workpoint[workpoint].x, MStruct.workpoint[workpoint].y].Event_Id, "", 0, 49);
                SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
            }
        }
        public static void PlayerAttackPlayer(int Attacker, int Victim, int isSpell = 0, int Map = 0, bool isPassive = false, int skill_level = 0, int super_damage = 0, bool is_pet = false)
        {
            if (Map == 0) { Map = Convert.ToInt32(PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Map); }
            int Dir = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir;
            int VictimX = PStruct.character[Victim, PStruct.player[Victim].SelectedChar].X;
            int VictimY = PStruct.character[Victim, PStruct.player[Victim].SelectedChar].Y;
            int AttackerX = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].X;
            int AttackerY = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Y;
            int PlayerX = Convert.ToInt32(PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].X);
            int PlayerY = Convert.ToInt32(PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Y);
            int Damage = 0;

            bool is_critical = false;

            if (PStruct.tempplayer[Victim].isDead == true) { return; }
            if (!MStruct.tempmap[Map].WarActive) {
            if (PStruct.character[Victim, PStruct.player[Victim].SelectedChar].Level < 10) { return; }
            if (!MStruct.MapIsPVP(Map)) { return; }
            }

            if ((!isPassive) && (isSpell == 0)) { SkillPassive(Attacker, Globals.Target_Player, Victim); }
            if ((PStruct.tempplayer[Victim].Vitality <= 0) || (PStruct.tempplayer[Victim].isDead)) { return; }
            if ((!MStruct.tempmap[Map].WarActive) && (!PStruct.character[Attacker, player[Attacker].SelectedChar].PVP)) { return; }

            if (tempplayer[Victim].Reflect)
            {
                SendData.Send_Animation(Map, Globals.Target_Player, Victim, 155);
                SendData.Send_Animation(Map, Globals.Target_Player, Attacker, 156);
                PlayerAttackPlayer(Victim, Attacker, 0, 0 , false, 0, GetPlayerDefense(Victim) * 2);
                tempplayer[Victim].Reflect = false;
                tempplayer[Victim].ReflectTimer = 0;
                return;
            }

            //Cálculo do dano

            //Magias
            if (isSpell > 0)
            {
                if (PStruct.character[Victim, PStruct.player[Victim].SelectedChar].ClassId == 6)
                {
                    for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                    {
                        if ((PStruct.skill[Victim, i].num == 39) && (PStruct.skill[Victim, i].level > 0))
                        {
                            //Desviar do golpe?
                            int parry_test = Globals.Rand(0, 100);

                            if (parry_test <= (PStruct.GetPlayerParry(Victim) - PStruct.GetPlayerCritical(Attacker)))
                            {
                                SendData.Send_ActionMsg(Victim, "Errou", Globals.ColorWhite, PStruct.character[Victim, PStruct.player[Victim].SelectedChar].X, PStruct.character[Victim, PStruct.player[Victim].SelectedChar].Y, 1, 0, Map);
                                return;
                            }
                            break;
                        }
                    }
                }

                int skill_slot = 0;

                if (!isPassive) { skill_slot = GetPlayerSkillSlot(Attacker, isSpell); }
                else { skill_slot = GetPlayerSkillSlot(Attacker, isSpell, true); }

                if (skill_slot == 0) { return; }

                int extra_spellbuff = 0;

                for (int i = 1; i < Globals.MaxSpellBuffs; i++)
                {
                    if (PStruct.pspellbuff[Attacker, i].active)
                    {
                        if (PStruct.pspellbuff[Attacker, i].timer > Loops.TickCount.ElapsedMilliseconds) { extra_spellbuff += PStruct.pspellbuff[Attacker, i].value; }
                        else
                        {
                            PStruct.pspellbuff[Attacker, i].value = 0;
                            PStruct.pspellbuff[Attacker, i].type = 0;
                            PStruct.pspellbuff[Attacker, i].timer = 0;
                            PStruct.pspellbuff[Attacker, i].active = false;
                        }
                    }
                }

                //Multiplicador de dano
                double multiplier = Convert.ToDouble(SStruct.skill[isSpell].scope) / 7.2;

                //Elemento mágico multiplicado
                double min_damage = GetPlayerMinMagic(Attacker);
                double max_damage = GetPlayerMaxMagic(Attacker);


                if (PStruct.hotkey[Attacker, skill_slot].num > Globals.MaxPlayer_Skills)
                {
                    PStruct.hotkey[Attacker, skill_slot].num = 0;
                    return;
                }

                //Multiplicador de nível
                double levelmultiplier = (1.0 + multiplier) * PStruct.skill[Attacker, PStruct.hotkey[Attacker, skill_slot].num].level; //Except

                //Verificando se a skill teve algum problema e corrigindo
                if (levelmultiplier < 1.0) { levelmultiplier = 1.0; }

                //Dano total que pode ser causado
                double totaldamage = max_damage + (Convert.ToDouble(SStruct.skill[isSpell].damage_formula) * levelmultiplier);
                double totalmindamage = min_damage + (Convert.ToDouble(SStruct.skill[isSpell].damage_formula) * levelmultiplier);

                //Passamos para int para tornar o dano exato
                int MinDamage = Convert.ToInt32(totalmindamage);
                int MaxDamage = Convert.ToInt32(totaldamage) + 1;

                if (MinDamage >= MaxDamage) { MaxDamage = MinDamage; }

                //Definição geral do dano
                Damage = Globals.Rand(MinDamage, MaxDamage);
                Damage -= (Damage / 100) * PStruct.tempplayer[Attacker].ReduceDamage;
                if (PStruct.character[Victim, PStruct.player[Victim].SelectedChar].ClassId == 3)
                {
                    for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                    {
                        if ((PStruct.skill[Victim, i].num == 56) && (PStruct.skill[Victim, i].level > 0))
                        {
                            Damage -= ((Damage / 100) * (3 * PStruct.skill[Victim, i].level));
                        }
                    }
                }
                Damage -= ((Damage / 100) * GetPlayerMagicDef(Victim));

                if (PStruct.tempplayer[Attacker].ReduceDamage > 0)
                {
                    SendData.Send_ActionMsg(Victim, "Dano Reduzido", Globals.ColorWhite, VictimX, VictimY, 1, 0, Map);
                    PStruct.tempplayer[Attacker].ReduceDamage = 0;
                }

                if (isSpell == 36)
                {
                    Damage += ((Damage / 100) * GetPlayerDefense(Attacker));
                }

                if (PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].ClassId == 6)
                {

                    for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                    {
                        if ((PStruct.skill[Attacker, i].num == 42) && (PStruct.skill[Attacker, i].level > 0))
                        {
                            //Dano crítico?
                            int critical_t = Globals.Rand(0, 100);

                            if (critical_t <= GetPlayerCritical(Attacker))
                            {
                                Damage = Convert.ToInt32((Convert.ToDouble(Damage) * 1.5));
                                SendData.Send_Animation(Map, Globals.Target_Player, Victim, 152);
                            }
                            break;
                        }
                        if ((PStruct.skill[Attacker, i].num == 41) && (PStruct.skill[Attacker, i].level > 0))
                        {
                            if (isSpell == 40)
                            {
                                int open_passive = GetOpenPassiveEffect(Attacker);

                                if (open_passive == 0) { return; }

                                PStruct.ppassiveffect[Attacker, open_passive].spellnum = PStruct.skill[Attacker, i].num;
                                PStruct.ppassiveffect[Attacker, open_passive].timer = Loops.TickCount.ElapsedMilliseconds + SStruct.skill[PStruct.skill[Attacker, i].num].passive_interval;
                                PStruct.ppassiveffect[Attacker, open_passive].target = Victim;
                                PStruct.ppassiveffect[Attacker, open_passive].targettype = Globals.Target_Player;
                                PStruct.ppassiveffect[Attacker, open_passive].type = 1;
                                PStruct.ppassiveffect[Attacker, open_passive].active = true;
                            }
                            //Dano crítico?
                            int critical_t = Globals.Rand(0, 100);

                            if (critical_t <= GetPlayerCritical(Attacker))
                            {
                                Damage = Convert.ToInt32((Convert.ToDouble(Damage) * 1.5));
                                SendData.Send_Animation(Map, Globals.Target_Player, Victim, 152);
                            }
                            break;
                        }
                    }
                }

                if (Damage < 1)
                {
                    SendData.Send_ActionMsg(Victim, "Resistiu", Globals.ColorPink, VictimX, VictimY, 1, 0, Map);
                    return;
                }

                if (extra_spellbuff > 0)
                {
                    //BUFFF :DDDD
                    Damage += (Damage / 100) * extra_spellbuff;
                }

                int drain = SStruct.skill[isSpell].drain;

                //Drenagem de vida?
                if (drain > 0)
                {
                    double real_drain = (Convert.ToDouble(Damage) / 100) * drain;
                    PlayerLogic.HealPlayer(Attacker, Convert.ToInt32(real_drain));
                    //SendData.Send_ActionMsg(Attacker, Convert.ToInt32(real_drain).ToString(), Globals.ColorGreen, PlayerX, PlayerY, 1, 1);
                    //SendData.Send_PlayerVitalityToMap(Map, Attacker, PStruct.tempplayer[Attacker].Vitality);
                }
            }
            //Ataques básicos
            else
            {
                if (tempplayer[Attacker].Blind)
                {
                    SendData.Send_ActionMsg(Attacker, "Errou", Globals.ColorWhite, VictimX, VictimY, 1, 0, Map);
                    return;
                }

                //Desviar do golpe?
                int parry_test = Globals.Rand(0, 100);

                if (parry_test <= (GetPlayerParry(Victim) - GetPlayerCritical(Attacker)))
                {
                    SendData.Send_ActionMsg(Victim, "Errou", Globals.ColorWhite, VictimX, VictimY, 1, 0, Map);
                    return;
                }

                //Dano comum
                int MinDamage = GetPlayerMinAttack(Attacker);
                int MaxDamage = GetPlayerMaxAttack(Attacker);

                if (is_pet)
                {
                    string equipment = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Equipment;
                    string[] equipdata = equipment.Split(',');
                    string[] petdata = equipdata[4].Split(';');

                    int petnum = Convert.ToInt32(petdata[0]);
                    int petlvl = Convert.ToInt32(petdata[1]);

                    MinDamage = (Convert.ToInt32(IStruct.item[petnum].damage_variance)) + ((petlvl / 2) * Convert.ToInt32(IStruct.item[petnum].damage_formula));
                    MaxDamage = (Convert.ToInt32(IStruct.item[petnum].damage_variance)) + ((petlvl) * Convert.ToInt32(IStruct.item[petnum].damage_formula));

                    if (MinDamage >= MaxDamage)
                    {
                        Damage = MinDamage + super_damage;
                        Damage -= (Damage / 100) * PStruct.tempplayer[Attacker].ReduceDamage;
                        Damage -= ((Damage / 100) * GetPlayerDefense(Victim));
                    }
                    else
                    {
                        Damage = (Globals.Rand(MinDamage, MaxDamage)) + super_damage;
                        Damage -= (Damage / 100) * PStruct.tempplayer[Attacker].ReduceDamage;
                        Damage -= ((Damage / 100) * GetPlayerDefense(Victim));
                    }//

                    SendData.Send_Animation(Map, Globals.Target_Player, Victim, IStruct.item[petnum].animation_id);
                    SendData.Send_ActionMsg(Victim, "-" + Damage.ToString(), Globals.ColorPurple, VictimX, VictimY, 1, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, Map); 
                    goto important;
                }

                if (MinDamage >= MaxDamage) 
                {
                    Damage = MinDamage + super_damage;
                    Damage -= (Damage / 100) * PStruct.tempplayer[Attacker].ReduceDamage;
                    Damage -= ((Damage / 100) * GetPlayerDefense(Victim));
                }
                else 
                { 
                    Damage = (Globals.Rand(MinDamage, MaxDamage)) + super_damage;
                    Damage -= (Damage / 100) * PStruct.tempplayer[Attacker].ReduceDamage;
                    Damage -= ((Damage / 100) * GetPlayerDefense(Victim));
                }//

                if (PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].ClassId == 2)
                {
                    for (int i = 1; i < Globals.MaxPlayer_Skills; i++)
                    {
                        if ((PStruct.skill[Attacker, i].num == 52) && (PStruct.skill[Attacker, i].level > 0))
                        {
                            Damage += ((GetPlayerMaxVitality(Victim) / 100) * (2 + PStruct.skill[Attacker, i].level));
                        }
                    }
                }

                if (PStruct.tempplayer[Attacker].ReduceDamage > 0)
                {
                    SendData.Send_ActionMsg(Victim, "Dano Reduzido", Globals.ColorWhite, VictimX, VictimY, 1, 0, Map);
                    PStruct.tempplayer[Attacker].ReduceDamage = 0;
                }

                //Dano crítico?
                int critical_test = Globals.Rand(0, 100);

                if (critical_test <= GetPlayerCritical(Attacker))
                {
                    Damage = Convert.ToInt32((Convert.ToDouble(Damage) * 1.5));
                    is_critical = true;
                }

                //Dano e animação
                SendData.Send_Animation(Map, Globals.Target_Player, Victim, 7);
            }

            if (is_critical)
            {
                int true_range = 0;
                for (int i = 1; i <= 2; i++)
                {
                    if (PStruct.CanThrowPlayer(Victim, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, i))
                    {
                        true_range += 1;
                    }
                    else
                    {
                        break;
                    }
                }

                if (true_range < 2)
                {
                    Damage += 2 - true_range;
                }

                if (true_range > 0)
                {
                    PStruct.ThrowPlayer(Victim, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, true_range);
                }

                if (PStruct.tempplayer[Victim].preparingskill > 0)
                {
                    PStruct.tempplayer[Victim].preparingskill = 0;
                    PStruct.tempplayer[Victim].preparingskillslot = 0;
                    PStruct.tempplayer[Victim].skilltimer = 0;
                    SendData.Send_ActionMsg(Victim, "Conjuração quebrada!", Globals.ColorPink, VictimX, VictimY, 1, 0, Map);
                    PStruct.tempplayer[Victim].movespeed = Globals.NormalMoveSpeed;
                    SendData.Send_MoveSpeed(Globals.Target_Player, Victim);
                    SendData.Send_BrokeSkill(Victim);
                }
                SendData.Send_ActionMsg(Victim, "-" + Damage.ToString(), 1, VictimX, VictimY, 1, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, Map); 
            }
            else
            {
                if (isSpell > 0) { SendData.Send_ActionMsg(Attacker, "-" + Damage.ToString(), Globals.ColorPink, VictimX, VictimY, Globals.Action_Msg_Scroll, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, Map); }
                else { SendData.Send_ActionMsg(Attacker, "-" + Damage.ToString(), 4, VictimX, VictimY, Globals.Action_Msg_Scroll, PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Dir, Map); }
            }

            important:
            //Nova vida do jogador
            PStruct.tempplayer[Victim].Vitality -= Damage;

            //Sleep?
            if (PStruct.tempplayer[Victim].Sleeping)
            {
                PStruct.tempplayer[Victim].Sleeping = false;
                PStruct.tempplayer[Victim].SleepTimer = 0;
                SendData.Send_Sleep(Map, 2, Victim, 0);
            }

            //Enviamos a nova vida do jogador
            SendData.Send_PlayerVitalityToMap(Map, Victim, PStruct.tempplayer[Victim].Vitality);

            if (PStruct.tempplayer[Victim].Vitality <= 0)
            {
                tempplayer[Victim].PetTarget = 0;
                tempplayer[Victim].PetTargetType = 0;
                if (!MStruct.tempmap[Map].WarActive)
                {
                    if (!PStruct.tempplayer[Victim].SORE)
                    {
                        int lvd = PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Level - PStruct.character[Victim, PStruct.player[Victim].SelectedChar].Level;
                        if (lvd > 5)
                        {
                            if (!PStruct.character[Victim, PStruct.player[Victim].SelectedChar].PVP)
                            {
                                PStruct.tempplayer[Attacker].SORE = true;
                                PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].PVPPenalty = 300000 + Loops.TickCount.ElapsedMilliseconds;
                                SendData.Send_PlayerSoreToMap(Attacker);
                                SendData.Send_PlayerPvpSoreTimer(Attacker);
                                SendData.Send_Animation(Map, Globals.Target_Player, Attacker, 147);

                                //Relacionado a definição de vida para novos e velhos jogadores
                                if (PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Vitality > PStruct.GetPlayerMaxVitality(Attacker))
                                {
                                    PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Vitality = PStruct.GetPlayerMaxVitality(Attacker);
                                    PStruct.tempplayer[Attacker].Vitality = PStruct.GetPlayerMaxVitality(Attacker);
                                    SendData.Send_PlayerVitalityToMap(Map, Attacker, PStruct.tempplayer[Attacker].Vitality);
                                    if (PStruct.tempplayer[Attacker].Party > 0)
                                    {
                                        SendData.Send_PlayerVitalityToParty(PStruct.tempplayer[Attacker].Party, Attacker, PStruct.tempplayer[Attacker].Vitality);
                                    }
                                }


                                //Relacionado a definição de mana para novos e velhos jogadores
                                if (PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Spirit > PStruct.GetPlayerMaxSpirit(Attacker))
                                {
                                    PStruct.character[Attacker, PStruct.player[Attacker].SelectedChar].Spirit = PStruct.GetPlayerMaxSpirit(Attacker);
                                    PStruct.tempplayer[Attacker].Spirit = PStruct.GetPlayerMaxSpirit(Attacker);
                                    SendData.Send_PlayerSpiritToMap(Map, Attacker, PStruct.tempplayer[Attacker].Spirit);
                                    if (PStruct.tempplayer[Attacker].Party > 0)
                                    {
                                        SendData.Send_PlayerSpiritToParty(PStruct.tempplayer[Attacker].Party, Attacker, PStruct.tempplayer[Attacker].Spirit);
                                    }
                                }
                            }
                        }
                        else
                        {
                            //Matou na ordem, eai?
                        }
                    }
                }
                else
                {
                    int exp = PStruct.character[Victim, PStruct.player[Victim].SelectedChar].Exp / 2;
                    GivePlayerExp(Attacker, exp);
                    PStruct.character[Victim, PStruct.player[Victim].SelectedChar].Exp -= exp;
                    SendData.Send_PlayerExp(Victim);
                    SendData.Send_ActionMsg(Victim, "-" + exp + "Exp", 0, PlayerX, PlayerY, 1, 0, Map);
                    SendData.Send_Animation(Map, Globals.Target_Player, Attacker, 148);
                    PStruct.tempplayer[Victim].SORE = false;
                    PStruct.character[Victim, PStruct.player[Victim].SelectedChar].PVPPenalty = 0;
                    PStruct.character[Victim, PStruct.player[Victim].SelectedChar].PVP = false;
                    PStruct.character[Victim, PStruct.player[Victim].SelectedChar].PVPBanTimer = 60000 + Loops.TickCount.ElapsedMilliseconds;
                    SendData.Send_PlayerPvpToMap(Victim);
                    SendData.Send_PlayerSoreToMap(Victim);
                    SendData.Send_PlayerPvpBanTimer(Victim);
                }
              //Morte
              PStruct.tempplayer[Victim].isDead = true;
              SendData.Send_PlayerDeathToMap(Victim);
            }
        }
        public static bool CanThrowPlayer(int index, byte Dir, int range)
        {
            int map = PStruct.character[index, PStruct.player[index].SelectedChar].Map;
            int x = PStruct.character[index, PStruct.player[index].SelectedChar].X;
            int y = PStruct.character[index, PStruct.player[index].SelectedChar].Y;
            //Tentamos nos mover
            switch (Dir)
            {
                case 8:
                    if (y - range < 0)
                    {
                        return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].UpBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y - range].DownBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y - (range - 1)].UpBlock) == false) { return false; }

                    if ((MStruct.tile[map, x, y - range].Data1 == "3") || (MStruct.tile[map, x, y - range].Data1 == "10") || (MStruct.tile[map, x, y - range].Data1 == "2")) { return false; }
                    if ((MStruct.tile[map, x, y - range].Data1 == "17") || (MStruct.tile[map, x, y - range].Data1 == "18")) { return false; }                   
                    if (MStruct.tile[map, x, y - range].Data1 == "21")
                    {
                        if (!IsPlayerPremmy(index))
                        {
                            return false;
                        }
                    }
                    break;
                case 2:
                    if (y + range > 14)
                    {
                        return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].DownBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y + range].UpBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y + (range - 1)].DownBlock) == false) { return false; }
                    if ((MStruct.tile[map, x, y + range].Data1 == "3") || (MStruct.tile[map, x, y + range].Data1 == "10") || (MStruct.tile[map, x, y + range].Data1 == "2")) { return false; }
                    if ((MStruct.tile[map, x, y + range].Data1 == "17") || (MStruct.tile[map, x, y + range].Data1 == "18")) { return false; }
                    if (MStruct.tile[map, x, y + range].Data1 == "21")
                    {
                        if (!IsPlayerPremmy(index))
                        {
                            return false;
                        }
                    }
                    break;
                case 4:
                    if (x - range < 0)
                    {
                       return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].LeftBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x - range, y].RightBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x - (range - 1), y].LeftBlock) == false) { return false; }
                    if ((MStruct.tile[map, x - range, y].Data1 == "3") || (MStruct.tile[map, x - range, y].Data1 == "10") || (MStruct.tile[map, x - range, y].Data1 == "2")) { return false; }
                    if ((MStruct.tile[map, x - range, y].Data1 == "17") || (MStruct.tile[map, x - range, y].Data1 == "18")) { return false; }
                    if (MStruct.tile[map, x - range, y].Data1 == "21")
                    {
                        if (!IsPlayerPremmy(index))
                        {
                            return false;
                        }
                    }
                    break;
                case 6:
                    if (x + range > 19)
                    {
                       return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].RightBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x + range, y].LeftBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x + (range - 1), y].RightBlock) == false) { return false; }
                    if ((MStruct.tile[map, x + range, y].Data1 == "3") || (MStruct.tile[map, x + range, y].Data1 == "10") || (MStruct.tile[map, x + range, y].Data1 == "2")) { return false; }
                    if ((MStruct.tile[map, x + range, y].Data1 == "17") || (MStruct.tile[map, x + range, y].Data1 == "18")) { return false; }
                    if (MStruct.tile[map, x + range, y].Data1 == "21")
                    {
                        if (!IsPlayerPremmy(index))
                        {
                            return false;
                        }
                    }
                    break;
                default:
                    WinsockAsync.Log(String.Format("Direção nula"));
                    break;
            }


            return true;
        }
        public static void ThrowPlayer(int Index, int dir, int range)
        {
            int map = PStruct.character[Index, PStruct.player[Index].SelectedChar].Map;
            int x = PStruct.character[Index, PStruct.player[Index].SelectedChar].X;
            int y = PStruct.character[Index, PStruct.player[Index].SelectedChar].Y;

            switch (dir)
            {
                case 8:
                    PStruct.character[Index, PStruct.player[Index].SelectedChar].Y = Convert.ToByte(Convert.ToInt32(PStruct.character[Index, PStruct.player[Index].SelectedChar].Y) - range);
                    break;
                case 2:
                    PStruct.character[Index, PStruct.player[Index].SelectedChar].Y = Convert.ToByte(Convert.ToInt32(PStruct.character[Index, PStruct.player[Index].SelectedChar].Y) + range);
                    break;
                case 4:
                    PStruct.character[Index, PStruct.player[Index].SelectedChar].X = Convert.ToByte(Convert.ToInt32(PStruct.character[Index, PStruct.player[Index].SelectedChar].X) - range);
                    break;
                case 6:
                    PStruct.character[Index, PStruct.player[Index].SelectedChar].X = Convert.ToByte(Convert.ToInt32(PStruct.character[Index, PStruct.player[Index].SelectedChar].X) + range);
                    break;
                default:
                    WinsockAsync.Log(String.Format("Direção nula"));
                    break;
            }

            SendData.Send_KnockBack(map, 1, Index, dir, range);
        }
        public static bool CanThrowNpc(int map, int index, byte Dir, int range)
        {
            int x = NStruct.tempnpc[map, index].X;
            int y = NStruct.tempnpc[map, index].Y;

            //Tentamos nos mover
            switch (Dir)
            {
                case 8:
                    if (y - range < 0)
                    {
                        return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].UpBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y - range].DownBlock) == false) { return false; }
                    if ((MStruct.tile[map, x, y - range].Data1 == "3") || (MStruct.tile[map, x, y - range].Data1 == "10") || (MStruct.tile[map, x, y - range].Data1 == "2")) { return false; }
                    if ((MStruct.tile[map, x, y - range].Data1 == "17") || (MStruct.tile[map, x, y - range].Data1 == "18")) { return false; }
                    break;
                case 2:
                    if (y + range > 14)
                    {
                        return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].DownBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y + range].UpBlock) == false) { return false; }
                    if ((MStruct.tile[map, x, y + range].Data1 == "3") || (MStruct.tile[map, x, y + range].Data1 == "10") || (MStruct.tile[map, x, y + range].Data1 == "2")) { return false; }
                    if ((MStruct.tile[map, x, y + range].Data1 == "17") || (MStruct.tile[map, x, y + range].Data1 == "18")) { return false; }
                    break;
                case 4:
                    if (x - range < 0)
                    {
                        return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].LeftBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x - range, y].RightBlock) == false) { return false; }
                    if ((MStruct.tile[map, x - range, y].Data1 == "3") || (MStruct.tile[map, x - range, y].Data1 == "10") || (MStruct.tile[map, x - range, y].Data1 == "2")) { return false; }
                    if ((MStruct.tile[map, x - range, y].Data1 == "17") || (MStruct.tile[map, x - range, y].Data1 == "18")) { return false; }
                    break;
                case 6:
                    if (x + range > 19)
                    {
                        return false;
                    }
                    if (Convert.ToBoolean(MStruct.tile[map, x, y].RightBlock) == false) { return false; }
                    if (Convert.ToBoolean(MStruct.tile[map, x + range, y].LeftBlock) == false) { return false; }
                    if ((MStruct.tile[map, x + range, y].Data1 == "3") || (MStruct.tile[map, x + range, y].Data1 == "10") || (MStruct.tile[map, x + range, y].Data1 == "2")) { return false; }
                    if ((MStruct.tile[map, x + range, y].Data1 == "17") || (MStruct.tile[map, x + range, y].Data1 == "18")) { return false; }
                    break;
                default:
                    WinsockAsync.Log(String.Format("Direção nula"));
                    break;
            }


            return true;
        }
        public static void ThrowNpc(int Map, int Index, int dir, int range)
        {

            switch (dir)
            {
                case 8:
                    NStruct.tempnpc[Map, Index].Y = Convert.ToByte(NStruct.tempnpc[Map, Index].Y - range);
                    break;
                case 2:
                    NStruct.tempnpc[Map, Index].Y = Convert.ToByte(NStruct.tempnpc[Map, Index].Y + range);
                    break;
                case 4:
                    NStruct.tempnpc[Map, Index].X = Convert.ToByte(NStruct.tempnpc[Map, Index].X - range);
                    break;
                case 6:
                    NStruct.tempnpc[Map, Index].X = Convert.ToByte(NStruct.tempnpc[Map, Index].X + range);
                    break;
                default:
                    WinsockAsync.Log(String.Format("Direção nula"));
                    break;
            }

            SendData.Send_KnockBack(Map, 2, Index, dir, range);
        }
        public static int GetOpenPTempSpell(int id)
        {
            for (int i = 1; i < Globals.MaxPTempSpells; i++)
            {
                if (PStruct.ptempspell[id, i].active == false)
                {
                    return i;
                }
            }

            return 0;
        }
        public static void OnDeath(int index)
        {

        }
        public static void KickParty(int index, int kicktarget, bool order = false)
        {

            //Tentativas possíveis de hacker
            if ((PStruct.tempplayer[kicktarget].Party == 0) || (PStruct.tempplayer[kicktarget].Party != PStruct.tempplayer[index].Party)) { return; }

            if ((UserConnection.GetIndex(kicktarget) < 0) || (UserConnection.GetIndex(kicktarget) >= WinsockAsync.Clients.Count()))
            {
                SendData.Send_MsgToPlayer(index, "O jogador que você tentou retirar não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            //Verifica se ele não saiu no processo
            if (!WinsockAsync.Clients[(UserConnection.GetIndex(kicktarget))].IsConnected && (!order))
            {
                SendData.Send_MsgToPlayer(index, "O jogador que você tentou retirar não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            //Verificar se ele é lider para tirar outro jogador
            if ((PStruct.party[PStruct.tempplayer[index].Party].leader != index) && (kicktarget != index))
            {
                SendData.Send_MsgToPlayer(index, "Você não é o lider do grupo.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            //Vamos trabalhar com isso
            int partynum = PStruct.tempplayer[index].Party;
            int memberindex = 0;

            if (kicktarget == index)
            {
                //O id do jogador no grupo
                memberindex = PStruct.GetPartyPlayerIndex(partynum, index);

                //Reposicionar todos os membros no grupo se quem saiu for maior que 3
                if (memberindex <= 3)
                {
                    for (int i = (memberindex + 1); i < Globals.MaxPartyMembers; i++)
                    {
                        PStruct.partymembers[partynum, i - 1].index = PStruct.partymembers[partynum, i].index;
                        PStruct.partymembers[partynum, i].index = 0;
                    }
                }
                else
                {
                    PStruct.partymembers[partynum, 4].index = 0;
                }

                if (kicktarget == PStruct.party[partynum].leader)
                {
                    PStruct.party[partynum].leader = PStruct.partymembers[partynum, 1].index;
                }

                //Tiramos o grupo do jogador
                PStruct.tempplayer[index].Party = 0;
            }
            else
            {
                //O id do jogador no grupo
                memberindex = PStruct.GetPartyPlayerIndex(partynum, kicktarget);

                //Reposicionar todos os membros no grupo se quem saiu for maior que 3
                if (memberindex <= 3)
                {
                    for (int i = (memberindex + 1); i < Globals.MaxPartyMembers; i++)
                    {
                        PStruct.partymembers[partynum, i - 1].index = PStruct.partymembers[partynum, i].index;
                        PStruct.partymembers[partynum, i].index = 0;
                    }
                }
                else
                {
                    PStruct.partymembers[partynum, 4].index = 0;
                }

                //Tiramos o grupo do jogador
                PStruct.tempplayer[kicktarget].Party = 0;
            }


            //Algum jogador ficou sozinho?
            if (PStruct.GetPartyMembersCount(partynum) == 1)
            {
                //Jogador que ficou sozinho será sempre o 1
                int alone = PStruct.partymembers[partynum, 1].index;

                //Limpamos o grupo do jogador que ficou sozinho
                PStruct.tempplayer[alone].Party = 0;

                //Limpamos o grupo
                PStruct.party[partynum].leader = 0;
                PStruct.party[partynum].active = false;

                //Avisa ao jogador que ele não tem mais um grupo
                SendData.Send_PartyKick(alone);
                
                //Verifica se não é um kick por ordem do servidor
                if (!order)
                {
                    SendData.Send_PartyKick(kicktarget);
                }

                //Limpamos todos os membros do grupo
                for (int i = (memberindex + 1); i < Globals.MaxPartyMembers; i++)
                {
                    PStruct.partymembers[partynum, i].index = 0;
                }
                return;
            }

            //Verifica se não é um kick por ordem do servidor
            if (!order)
            {
                SendData.Send_PartyKick(kicktarget);
            }

            //Envia o grupo atualizado
            SendData.Send_PartyDataToParty(partynum);
        }
        public static void ExecuteTempSpell(int Index, int PStempSpell)
        {
            int Attacker = PStruct.ptempspell[Index, PStempSpell].attacker;
            int Map = PStruct.character[Index, PStruct.player[Index].SelectedChar].Map;

            if ((UserConnection.GetIndex(Attacker) < 0) || (UserConnection.GetIndex(Attacker) >= WinsockAsync.Clients.Count())) 
            { 
                PStruct.ptempspell[Index, PStempSpell].attacker = 0;
                PStruct.ptempspell[Index, PStempSpell].timer = 0;
                PStruct.ptempspell[Index, PStempSpell].spellnum = 0;
                PStruct.ptempspell[Index, PStempSpell].repeats = 0;
                PStruct.ptempspell[Index, PStempSpell].active = false;
                return;
            }

            //Verificar se o jogador não se desconectou no processo
            if (!WinsockAsync.Clients[(UserConnection.GetIndex(Attacker))].IsConnected)
            {
                PStruct.ptempspell[Index, PStempSpell].attacker = 0;
                PStruct.ptempspell[Index, PStempSpell].timer = 0;
                PStruct.ptempspell[Index, PStempSpell].spellnum = 0;
                PStruct.ptempspell[Index, PStempSpell].repeats = 0;
                PStruct.ptempspell[Index, PStempSpell].active = false;
                return;
            }

            if (PStruct.tempplayer[Index].Vitality <= 0)
            {
                PStruct.ptempspell[Index, PStempSpell].attacker = 0;
                PStruct.ptempspell[Index, PStempSpell].timer = 0;
                PStruct.ptempspell[Index, PStempSpell].spellnum = 0;
                PStruct.ptempspell[Index, PStempSpell].repeats = 0;
                PStruct.ptempspell[Index, PStempSpell].active = false;
                return;
            }

            SendData.Send_Animation(Map, 1, Index, PStruct.ptempspell[Index, PStempSpell].anim);

            if (PStruct.ptempspell[Index, PStempSpell].area_range <= 0)
            {
                if (!PStruct.ptempspell[Index, PStempSpell].is_heal)
                {
                    PStruct.PlayerAttackPlayer(Attacker, Index, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                }
                else
                {
                    PlayerLogic.HealPlayer(Index, PlayerLogic.HealSpellDamage(Attacker, PStruct.ptempspell[Index, PStempSpell].spellnum));
                }
            }
            else
            {
                if (!PStruct.ptempspell[Index, PStempSpell].is_heal)
                {
                    PlayerAttackPlayer(Attacker, Index, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                    for (int i = 0; i <= MStruct.tempmap[Map].NpcCount; i++)
                    {
                        for (int r = 1; r <= PStruct.ptempspell[Index, PStempSpell].area_range; r++)
                        {
                            if ((NStruct.tempnpc[Map, i].X - r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y == PStruct.character[Index, PStruct.player[Index].SelectedChar].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                            }
                            if ((NStruct.tempnpc[Map, i].X + r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y == PStruct.character[Index, PStruct.player[Index].SelectedChar].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                            }
                            if ((NStruct.tempnpc[Map, i].X == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y - r == PStruct.character[Index, PStruct.player[Index].SelectedChar].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                            }
                            if ((NStruct.tempnpc[Map, i].X == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y + r == PStruct.character[Index, PStruct.player[Index].SelectedChar].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                            }


                            //Is line?
                            if (PStruct.ptempspell[Index, PStempSpell].is_line)
                            {
                                if ((NStruct.tempnpc[Map, i].X - r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y + r == PStruct.character[Index, PStruct.player[Index].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                                }
                                if ((NStruct.tempnpc[Map, i].X + r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y - r == PStruct.character[Index, PStruct.player[Index].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                                }
                                if ((NStruct.tempnpc[Map, i].X + r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y + r == PStruct.character[Index, PStruct.player[Index].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                                }
                                if ((NStruct.tempnpc[Map, i].X - r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y - r == PStruct.character[Index, PStruct.player[Index].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                                }
                            }
                        }
                    }

                    for (int i = 0; i <= Globals.Player_HighIndex; i++)
                    {
                        if ((PStruct.character[i, PStruct.player[i].SelectedChar].Map == Map) && (PStruct.character[Index, PStruct.player[Index].SelectedChar].PVP) && (i != Index))
                        {
                            for (int r = 1; r <= PStruct.ptempspell[Index, PStempSpell].area_range; r++)
                            {
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X - r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y == PStruct.character[Index, PStruct.player[i].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackPlayer(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                                }
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X + r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y == PStruct.character[Index, PStruct.player[i].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackPlayer(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                                }
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y - r == PStruct.character[Index, PStruct.player[i].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackPlayer(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                                }
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y + r == PStruct.character[Index, PStruct.player[i].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackPlayer(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                                }


                                //Is line?
                                if (PStruct.ptempspell[Index, PStempSpell].is_line)
                                {
                                    if ((PStruct.character[i, PStruct.player[i].SelectedChar].X - r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y + r == PStruct.character[Index, PStruct.player[i].SelectedChar].Y))
                                    {
                                        PStruct.PlayerAttackPlayer(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                                    }
                                    if ((PStruct.character[i, PStruct.player[i].SelectedChar].X + r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y - r == PStruct.character[Index, PStruct.player[i].SelectedChar].Y))
                                    {
                                        PStruct.PlayerAttackPlayer(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                                    }
                                    if ((PStruct.character[i, PStruct.player[i].SelectedChar].X + r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y + r == PStruct.character[Index, PStruct.player[i].SelectedChar].Y))
                                    {
                                        PStruct.PlayerAttackPlayer(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                                    }
                                    if ((PStruct.character[i, PStruct.player[i].SelectedChar].X - r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y - r == PStruct.character[Index, PStruct.player[i].SelectedChar].Y))
                                    {
                                        PStruct.PlayerAttackPlayer(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    PlayerLogic.HealPlayer(Index, PlayerLogic.HealSpellDamage(Attacker, PStruct.ptempspell[Index, PStempSpell].spellnum));
                    PlayerAttackPlayer(Attacker, Index, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                    for (int i = 0; i <= MStruct.tempmap[Map].NpcCount; i++)
                    {
                        for (int r = 1; r <= PStruct.ptempspell[Index, PStempSpell].area_range; r++)
                        {
                            if ((NStruct.tempnpc[Map, i].X - r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y == PStruct.character[Index, PStruct.player[Index].SelectedChar].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                            }
                            if ((NStruct.tempnpc[Map, i].X + r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y == PStruct.character[Index, PStruct.player[Index].SelectedChar].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                            }
                            if ((NStruct.tempnpc[Map, i].X == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y - r == PStruct.character[Index, PStruct.player[Index].SelectedChar].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                            }
                            if ((NStruct.tempnpc[Map, i].X == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y + r == PStruct.character[Index, PStruct.player[Index].SelectedChar].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                            }


                            //Is line?
                            if (PStruct.ptempspell[Index, PStempSpell].is_line)
                            {
                                if ((NStruct.tempnpc[Map, i].X - r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y + r == PStruct.character[Index, PStruct.player[Index].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                                }
                                if ((NStruct.tempnpc[Map, i].X + r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y - r == PStruct.character[Index, PStruct.player[Index].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                                }
                                if ((NStruct.tempnpc[Map, i].X + r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y + r == PStruct.character[Index, PStruct.player[Index].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                                }
                                if ((NStruct.tempnpc[Map, i].X - r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (NStruct.tempnpc[Map, i].Y - r == PStruct.character[Index, PStruct.player[Index].SelectedChar].Y))
                                {
                                    PStruct.PlayerAttackNpc(Attacker, i, PStruct.ptempspell[Index, PStempSpell].spellnum, Map);
                                }
                            }
                        }
                    }

                    for (int i = 0; i <= Globals.Player_HighIndex; i++)
                    {
                        if ((PStruct.character[i, PStruct.player[i].SelectedChar].Map == Map) && (PStruct.character[Index, PStruct.player[Index].SelectedChar].PVP) && (i != Index))
                        {
                            for (int r = 1; r <= PStruct.ptempspell[Index, PStempSpell].area_range; r++)
                            {
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X - r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y == PStruct.character[Index, PStruct.player[i].SelectedChar].Y))
                                {
                                    PlayerLogic.HealPlayer(i, PlayerLogic.HealSpellDamage(Attacker, PStruct.ptempspell[Index, PStempSpell].spellnum));
                                }
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X + r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y == PStruct.character[Index, PStruct.player[i].SelectedChar].Y))
                                {
                                    PlayerLogic.HealPlayer(i, PlayerLogic.HealSpellDamage(Attacker, PStruct.ptempspell[Index, PStempSpell].spellnum));
                                }
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y - r == PStruct.character[Index, PStruct.player[i].SelectedChar].Y))
                                {
                                    PlayerLogic.HealPlayer(i, PlayerLogic.HealSpellDamage(Attacker, PStruct.ptempspell[Index, PStempSpell].spellnum));
                                }
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y + r == PStruct.character[Index, PStruct.player[i].SelectedChar].Y))
                                {
                                    PlayerLogic.HealPlayer(i, PlayerLogic.HealSpellDamage(Attacker, PStruct.ptempspell[Index, PStempSpell].spellnum));
                                }


                                //Is line?
                                if (PStruct.ptempspell[Index, PStempSpell].is_line)
                                {
                                    if ((PStruct.character[i, PStruct.player[i].SelectedChar].X - r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y + r == PStruct.character[Index, PStruct.player[i].SelectedChar].Y))
                                    {
                                        PlayerLogic.HealPlayer(i, PlayerLogic.HealSpellDamage(Attacker, PStruct.ptempspell[Index, PStempSpell].spellnum));
                                    }
                                    if ((PStruct.character[i, PStruct.player[i].SelectedChar].X + r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y - r == PStruct.character[Index, PStruct.player[i].SelectedChar].Y))
                                    {
                                        PlayerLogic.HealPlayer(i, PlayerLogic.HealSpellDamage(Attacker, PStruct.ptempspell[Index, PStempSpell].spellnum));
                                    }
                                    if ((PStruct.character[i, PStruct.player[i].SelectedChar].X + r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y + r == PStruct.character[Index, PStruct.player[i].SelectedChar].Y))
                                    {
                                        PlayerLogic.HealPlayer(i, PlayerLogic.HealSpellDamage(Attacker, PStruct.ptempspell[Index, PStempSpell].spellnum));
                                    }
                                    if ((PStruct.character[i, PStruct.player[i].SelectedChar].X - r == PStruct.character[Index, PStruct.player[Index].SelectedChar].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y - r == PStruct.character[Index, PStruct.player[i].SelectedChar].Y))
                                    {
                                        PlayerLogic.HealPlayer(i, PlayerLogic.HealSpellDamage(Attacker, PStruct.ptempspell[Index, PStempSpell].spellnum));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            PStruct.ptempspell[Index, PStempSpell].repeats -= 1;

            if (PStruct.ptempspell[Index, PStempSpell].repeats <= 0)
            {
                if ((SStruct.skill[PStruct.ptempspell[Index, PStempSpell].spellnum].slow) || (PStruct.ptempspell[Index, PStempSpell].fast_buff))
                {
                    PStruct.tempplayer[Index].movespeed = Globals.NormalMoveSpeed;
                    SendData.Send_MoveSpeed(1, Index);
                }
                PStruct.ptempspell[Index, PStempSpell].attacker = 0;
                PStruct.ptempspell[Index, PStempSpell].timer = 0;
                PStruct.ptempspell[Index, PStempSpell].spellnum = 0;
                PStruct.ptempspell[Index, PStempSpell].repeats = 0;
                PStruct.ptempspell[Index, PStempSpell].active = false;
            }

            PStruct.ptempspell[Index, PStempSpell].timer = Loops.TickCount.ElapsedMilliseconds + SStruct.skill[PStruct.ptempspell[Index, PStempSpell].spellnum].interval;

        }
        public static void GivePlayerGold(int index, int gold)
        {
            PStruct.character[index, PStruct.player[index].SelectedChar].Gold += gold;
            SendData.Send_PlayerG(index);
        }
        public static int GetPlayerOriunklatex(int index)
        {
            for (int i = 1; i < Globals.MaxInvSlot; i++)
            {
                string item = PStruct.invslot[index, i].item;
                string[] splititem = item.Split(',');

                int itemNum = Convert.ToInt32(splititem[1]);
                int itemValue = Convert.ToInt32(splititem[2]);
                if ((itemNum == 68) && (itemValue > 0)) { return i; }
            }

            return 0;
        }
        public static void GivePlayerExp(int index, int exp)
        {
            int PlayerX = PStruct.character[index, PStruct.player[index].SelectedChar].X;
            int PlayerY = PStruct.character[index, PStruct.player[index].SelectedChar].Y;
            int Map = PStruct.character[index, PStruct.player[index].SelectedChar].Map;
            PStruct.character[index, PStruct.player[index].SelectedChar].Exp += exp;

            string equipment = PStruct.character[index, PStruct.player[index].SelectedChar].Equipment;
            string[] equipdata = equipment.Split(',');
            string[] petdata = equipdata[4].Split(';');

            int petnum = Convert.ToInt32(petdata[0]);
            int petlvl = Convert.ToInt32(petdata[1]);
            int petexp = Convert.ToInt32(petdata[2]);

            if (petnum > 0)
            {
                petexp += exp;

                if (petexp >= GetPetExpToNextLevel(index, petlvl))
                {
                    petexp -= GetPetExpToNextLevel(index, petlvl);
                    petlvl += 1;
                    PStruct.character[index, PStruct.player[index].SelectedChar].Equipment = equipdata[0] + "," + equipdata[1] + "," + equipdata[2] + "," + equipdata[3] + "," + petnum + ";" + petlvl + ";" + petexp;
                    SendData.Send_ActionMsg(index, "Mascote Up!", 3, PStruct.character[index, PStruct.player[index].SelectedChar].X, PStruct.character[index, PStruct.player[index].SelectedChar].Y, 1, 0, Map);
                    SendData.Send_PlayerEquipmentTo(index, index);
                }
                else
                {
                    //Enviar nova exp
                    PStruct.character[index, PStruct.player[index].SelectedChar].Equipment = equipdata[0] + "," + equipdata[1] + "," + equipdata[2] + "," + equipdata[3] + "," + petnum + ";" + petlvl + ";" + petexp;
                    SendData.Send_PlayerEquipmentTo(index, index);
                }
            }

            //Verificamos se ele subiu de nível
            if ((PStruct.character[index, PStruct.player[index].SelectedChar].Exp >= GetExpToNextLevel(index)) && (PStruct.character[index, PStruct.player[index].SelectedChar].Level < 99))
            {
                PStruct.character[index, PStruct.player[index].SelectedChar].Exp -= GetExpToNextLevel(index);
                PStruct.character[index, PStruct.player[index].SelectedChar].Level += 1;
                PStruct.character[index, PStruct.player[index].SelectedChar].Points += 5;
                PStruct.character[index, PStruct.player[index].SelectedChar].SkillPoints += 1;
                SendData.Send_ActionMsg(index, "Subiu de nível!", 3, PStruct.character[index, PStruct.player[index].SelectedChar].X, PStruct.character[index, PStruct.player[index].SelectedChar].Y, 1, 0, Map);
                SendData.Send_Animation(Map, 1, index, 109);
                SendData.Send_PlayerExp(index);
                SendData.Send_PlayerLevel(index, index);
                SendData.Send_PlayerSkillPoints(index);
                SendData.Send_PlayerAtrTo(index);
            }
            else
            {
                //GetExpToNextLevel
                SendData.Send_PlayerExp(index);
                //Enviamos uma animação bonitinha de exp :D
                SendData.Send_ActionMsg(index, "+" + exp + "Exp", 0, PlayerX, PlayerY, 1, 0, Map);
            }
        }
        public static void PlayerDeath(int index)
        {
            tempplayer[index].Vitality = 1;
            tempplayer[index].Spirit = 1;

        }
        public static bool PlayerIsSore(int index)
        {
            if (PStruct.character[index, PStruct.player[index].SelectedChar].PVPPenalty > Loops.TickCount.ElapsedMilliseconds) { return true; } else { PStruct.character[index, PStruct.player[index].SelectedChar].PVPPenalty = 0; return false; }
        }
        public static void PlayerRegen(int index)
        {
            if (PStruct.tempplayer[index].isDead) { return; }
            if (PStruct.tempplayer[index].Vitality < PStruct.GetPlayerMaxVitality(index))
            {
                //Regen por segundo
                PStruct.tempplayer[index].Vitality += GetPlayerVitalityRegen(index);
                //Vida atual ficou maior que a máxima?
                if (PStruct.tempplayer[index].Vitality > GetPlayerMaxVitality(index))
                {
                    PStruct.tempplayer[index].Vitality = GetPlayerMaxVitality(index);
                }
                //Envia vida recuperada
                SendData.Send_PlayerVitalityToMap(PStruct.character[index, PStruct.player[index].SelectedChar].Map, index, PStruct.tempplayer[index].Vitality);
                //Se estiver em grupo atualiza para o grupo também
                if (PStruct.tempplayer[index].Party > 0)
                {
                    SendData.Send_PlayerVitalityToParty(PStruct.tempplayer[index].Party, index, PStruct.tempplayer[index].Vitality);
                }
            }
            if (PStruct.tempplayer[index].Spirit < PStruct.GetPlayerMaxSpirit(index))
            {
                //Regen por segundo
                PStruct.tempplayer[index].Spirit += GetPlayerSpiritRegen(index);
                //Mana atual ficou maior que a máxima?
                if (PStruct.tempplayer[index].Spirit > GetPlayerMaxSpirit(index))
                {
                    PStruct.tempplayer[index].Spirit = GetPlayerMaxSpirit(index);
                }
                //Envia vida recuperada
                SendData.Send_PlayerSpiritToMap(PStruct.character[index, PStruct.player[index].SelectedChar].Map, index, PStruct.tempplayer[index].Spirit);
                //Se estiver em grupo atualiza para o grupo também
                if (PStruct.tempplayer[index].Party > 0)
                {
                    SendData.Send_PlayerSpiritToParty(PStruct.tempplayer[index].Party, index, PStruct.tempplayer[index].Spirit);
                }
            }

            PStruct.tempplayer[index].RegenTimer = Loops.TickCount.ElapsedMilliseconds + 1000;
        }
    }

}
