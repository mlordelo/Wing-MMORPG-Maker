using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACESERVER
{
    class NStruct
    {
        public static NStruct.TempNpc[,] tempnpc = new NStruct.TempNpc[Globals.MaxMaps, 1001];
        public static NStruct.NTempSpell[,,] ntempspell = new NStruct.NTempSpell[Globals.MaxMaps, 1001, Globals.MaxNTempSpells];
        public static NStruct.NSpell[, ,] nspell = new NStruct.NSpell[Globals.MaxMaps, 1001, Globals.Max_Npc_Spells];
        public static NStruct.Npc[,] npc = new NStruct.Npc[Globals.MaxMaps, 1001];
        public static NStruct.NpcDrop[,,] npcdrop = new NStruct.NpcDrop[Globals.MaxMaps, 1001, 5];

            public struct Npc
            {
                public int Map;
                public string Name;
                public string Sprite;
                public int Index;
                public string Talk;
                public int X;
                public int Y;
                public int Attack;
                public int Defense;
                public int Agility;
                public int MagicDefense;
                public int MagicAttack;
                public int Luck;
                public int Range;
                public int Vitality;
                public int Spirit;
                public int Type;
                public int Animation;
                public int Respawn;
                public int SpeedMove;
                public int Exp;
                public int Gold;
                public bool KnockAttack;
                public int KnockRange;
            }

            public struct NpcDrop
            {
                public int ItemNum;
                public int ItemType;
                public int Chance;
                public int Value;
            }

        public struct TempNpc
        {
            public int Target;
            public int curTargetX;
            public int curTargetY;
            public long curTimer;
            public int X;
            public int Y;
            public byte Dir;
            public byte Moving;
            public long AttackTimer;
            public int curTarget;
            public int Current;
            public int Vitality;
            public int Spirit;
            public long RespawnTimer;
            public long MoveTimer;
            public bool Dead;
            public long ParalyzeTimer;
            public long Blindtimer;
            public long RegenTimer;
            public bool Stunned;
            public long StunTimer;
            public bool Sleeping;
            public long SleepTimer;
            public bool Slowed;
            public long SlowTimer;
            public double movespeed;
            public int preparingskill;
            public int preparingskillslot;
            public long skilltimer;
            public bool Blind;
            public long BlindTimer;
            public int guildnum;
            public Point[] prev_move;
            public bool isFrozen;
            public byte ReduceDamage;
        }

        public struct Point
        {
            public int x;
            public int y;
        }

        public struct NTempSpell
        {
            public bool active;
            public int attacker;
            public int spellnum;
            public long timer;
            public int repeats;
            public int anim;
            public int area_range;
            public bool is_line;
        }

        public struct NSpell
        {
            public int spellnum;
            public long cooldown; //??? askapsoksa
        }

        public static int GetOpenNTempSpell(int map, int id)
        {
            for (int i = 1; i < Globals.MaxNTempSpells; i++)
            {
                if (NStruct.ntempspell[map, id, i].active == false)
                {
                    return i;
                }
            }

            return 0;
        }
        public static int GetNpcDropCount(int map, int id)
        {
            int count = 0;

            for (int i = 0; i < Globals.MaxNpcDrops; i++)
            {
                if (NStruct.npcdrop[map, id, i].ItemNum > 0)
                {
                    count += 1;
                }
            }
            return count;
        }
        public static int GetNpcCritical(int Map, int Index)
        {
            double WaterCritical = Convert.ToDouble(NStruct.npc[Map, Index].Luck) * 1.0;
            int critical = Convert.ToInt32(WaterCritical);

            return critical;
        }
        public static int GetNpcParry(int Map, int Index)
        {
            double WindParry = Convert.ToDouble(NStruct.npc[Map, Index].Agility) * 1.0;
            int parry = Convert.ToInt32(WindParry);

            return parry;
        }
        public static void RegenNpc(int Map, int Index, bool SuperRegen = false)
        {
            if ((NStruct.tempnpc[Map, Index].Vitality <= 0) || (NStruct.tempnpc[Map, Index].Dead)) { return; }
            if ((NStruct.tempnpc[Map, Index].Vitality == NStruct.npc[Map, Index].Vitality) && (NStruct.tempnpc[Map, Index].Spirit == NStruct.npc[Map, Index].Spirit)) { return; }

            if (SuperRegen)
            {
                if (NStruct.tempnpc[Map, Index].Vitality < NStruct.npc[Map, Index].Vitality)
                {
                    NStruct.tempnpc[Map, Index].Vitality = NStruct.npc[Map, Index].Vitality;
                    return;
                }

                if (NStruct.tempnpc[Map, Index].Spirit < NStruct.npc[Map, Index].Spirit)
                {
                    NStruct.tempnpc[Map, Index].Spirit = NStruct.npc[Map, Index].Spirit;
                    return;
                }
                return;
            }

            if (NStruct.tempnpc[Map, Index].Vitality < NStruct.npc[Map, Index].Vitality)
            {
                NStruct.tempnpc[Map, Index].Vitality += (NStruct.npc[Map, Index].Vitality / 150);
                if (NStruct.tempnpc[Map, Index].Vitality > NStruct.npc[Map, Index].Vitality)
                {
                    NStruct.tempnpc[Map, Index].Vitality = NStruct.npc[Map, Index].Vitality;
                }
                SendData.Send_NpcVitality(Map, Index, NStruct.tempnpc[Map, Index].Vitality);
            }

            if (NStruct.tempnpc[Map, Index].Spirit < NStruct.npc[Map, Index].Spirit)
            {
                NStruct.tempnpc[Map, Index].Spirit += (NStruct.npc[Map, Index].Spirit / 10);
                if (NStruct.tempnpc[Map, Index].Spirit > NStruct.npc[Map, Index].Spirit)
                {
                    NStruct.tempnpc[Map, Index].Spirit = NStruct.npc[Map, Index].Spirit;
                }
            }

            NStruct.tempnpc[Map, Index].RegenTimer = Loops.TickCount.ElapsedMilliseconds + 1000;
        }
        public static void ClearTempNpc(int mapnum, int i2)
        {
            NStruct.npc[mapnum, i2].Name = "";
            NStruct.npc[mapnum, i2].Map = 0;
            NStruct.npc[mapnum, i2].X = 0;
            NStruct.npc[mapnum, i2].Y = 0;
            NStruct.npc[mapnum, i2].Vitality = 0;
            NStruct.npc[mapnum, i2].Spirit = 0;
            NStruct.tempnpc[mapnum, i2].Target = 0;
            NStruct.tempnpc[mapnum, i2].X = 0;
            NStruct.tempnpc[mapnum, i2].Y = 0;
            NStruct.tempnpc[mapnum, i2].curTargetX = 0;
            NStruct.tempnpc[mapnum, i2].curTargetY = 0;
            NStruct.tempnpc[mapnum, i2].Vitality = 0;
            NStruct.npc[mapnum, i2].Attack = 0;
            NStruct.npc[mapnum, i2].Defense = 0;
            NStruct.npc[mapnum, i2].Agility = 0;
            NStruct.npc[mapnum, i2].MagicDefense = 0;
            NStruct.npc[mapnum, i2].MagicAttack = 0;
            NStruct.npc[mapnum, i2].Luck = 0;
            NStruct.npc[mapnum, i2].Sprite = "";
            NStruct.npc[mapnum, i2].Index = 0;
            NStruct.npc[mapnum, i2].Type = 0;
            NStruct.npc[mapnum, i2].Range = 0;

            //if (notedata.Length - 1 > 11)
            //{
            //    NStruct.npc[mapnum, i2].KnockAttack = Convert.ToBoolean(notedata[12]);
            //    NStruct.npc[mapnum, i2].KnockRange = Convert.ToInt32(notedata[13]);
            //    NStruct.nspell[mapnum, i2, 1].spellnum = Convert.ToInt32(notedata[14]);
            //    NStruct.nspell[mapnum, i2, 2].spellnum = Convert.ToInt32(notedata[15]);
            //    NStruct.nspell[mapnum, i2, 3].spellnum = Convert.ToInt32(notedata[16]);
            //    NStruct.nspell[mapnum, i2, 4].spellnum = Convert.ToInt32(notedata[17]);
            //}

            NStruct.npc[mapnum, i2].Animation = 0;
            NStruct.npc[mapnum, i2].SpeedMove = 0;
            NStruct.tempnpc[mapnum, i2].movespeed = 0;
            NStruct.npc[mapnum, i2].Respawn = 0;
            NStruct.npc[mapnum, i2].Exp = 0;
            NStruct.npc[mapnum, i2].Gold = 0;
            NStruct.tempnpc[mapnum, i2].guildnum = 0;
        }
        public static void ExecuteTempSpell(int Map, int Index, int NStempSpell)
        {
            int Attacker = NStruct.ntempspell[Map, Index, NStempSpell].attacker;

            if ((UserConnection.GetIndex(Attacker) < 0) || (UserConnection.GetIndex(Attacker) >= WinsockAsync.Clients.Count()))
            {
                NStruct.ntempspell[Map, Index, NStempSpell].attacker = 0;
                NStruct.ntempspell[Map, Index, NStempSpell].timer = 0;
                NStruct.ntempspell[Map, Index, NStempSpell].spellnum = 0;
                NStruct.ntempspell[Map, Index, NStempSpell].repeats = 0;
                NStruct.ntempspell[Map, Index, NStempSpell].active = false;
                return;
            }

            //Verificar se o jogador não se desconectou no processo
            if (!WinsockAsync.Clients[(UserConnection.GetIndex(Attacker))].IsConnected)
            {
                NStruct.ntempspell[Map, Index, NStempSpell].attacker = 0;
                NStruct.ntempspell[Map, Index, NStempSpell].timer = 0;
                NStruct.ntempspell[Map, Index, NStempSpell].spellnum = 0;
                NStruct.ntempspell[Map, Index, NStempSpell].repeats = 0;
                NStruct.ntempspell[Map, Index, NStempSpell].active = false;
                return;
            }

            if (NStruct.tempnpc[Map, Index].Vitality <= 0)
            {
                NStruct.ntempspell[Map, Index, NStempSpell].attacker = 0;
                NStruct.ntempspell[Map, Index, NStempSpell].timer = 0;
                NStruct.ntempspell[Map, Index, NStempSpell].spellnum = 0;
                NStruct.ntempspell[Map, Index, NStempSpell].repeats = 0;
                NStruct.ntempspell[Map, Index, NStempSpell].active = false;
                return;
            }

            SendData.Send_Animation(Map, 2, Index, NStruct.ntempspell[Map, Index, NStempSpell].anim);
            
            if (NStruct.ntempspell[Map, Index, NStempSpell].area_range <= 0)
            {
                PStruct.PlayerAttackNpc(Attacker, Index, NStruct.ntempspell[Map, Index, NStempSpell].spellnum, Map);
            }
            else
            {
                PStruct.PlayerAttackNpc(Attacker, Index, NStruct.ntempspell[Map, Index, NStempSpell].spellnum, Map);
                for (int i = 0; i <= Globals.Player_HighIndex; i++)
                {
                    if ((PStruct.character[i, PStruct.player[i].SelectedChar].Map == Map) && (PStruct.character[Index, PStruct.player[Index].SelectedChar].PVP) && (i != Index))
                    {
                        for (int r = 1; r <= NStruct.ntempspell[Map, Index, NStempSpell].area_range; r++)
                        {
                            if ((PStruct.character[i, PStruct.player[i].SelectedChar].X - r == NStruct.tempnpc[Map, Index].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y == NStruct.tempnpc[Map, Index].Y))
                            {
                                PStruct.PlayerAttackPlayer(Attacker, i, NStruct.ntempspell[Map, Index, NStempSpell].spellnum, Map);
                            }
                            if ((PStruct.character[i, PStruct.player[i].SelectedChar].X + r == NStruct.tempnpc[Map, Index].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y == NStruct.tempnpc[Map, Index].Y))
                            {
                                PStruct.PlayerAttackPlayer(Attacker, i, NStruct.ntempspell[Map, Index, NStempSpell].spellnum, Map);
                            }
                            if ((PStruct.character[i, PStruct.player[i].SelectedChar].X == NStruct.tempnpc[Map, Index].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y - r == NStruct.tempnpc[Map, Index].Y))
                            {
                                PStruct.PlayerAttackPlayer(Attacker, i, NStruct.ntempspell[Map, Index, NStempSpell].spellnum, Map);
                            }
                            if ((PStruct.character[i, PStruct.player[i].SelectedChar].X == NStruct.tempnpc[Map, Index].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y + r == NStruct.tempnpc[Map, Index].Y))
                            {
                                PStruct.PlayerAttackPlayer(Attacker, i, NStruct.ntempspell[Map, Index, NStempSpell].spellnum, Map);
                            }


                            //Is line?
                            if (NStruct.ntempspell[Map, Index, NStempSpell].is_line)
                            {
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X - r == NStruct.tempnpc[Map, Index].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y + r == NStruct.tempnpc[Map, Index].Y))
                                {
                                    PStruct.PlayerAttackPlayer(Attacker, i, NStruct.ntempspell[Map, Index, NStempSpell].spellnum, Map);
                                }
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X + r == NStruct.tempnpc[Map, Index].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y - r == NStruct.tempnpc[Map, Index].Y))
                                {
                                    PStruct.PlayerAttackPlayer(Attacker, i, NStruct.ntempspell[Map, Index, NStempSpell].spellnum, Map);
                                }
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X + r == NStruct.tempnpc[Map, Index].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y + r == NStruct.tempnpc[Map, Index].Y))
                                {
                                    PStruct.PlayerAttackPlayer(Attacker, i, NStruct.ntempspell[Map, Index, NStempSpell].spellnum, Map);
                                }
                                if ((PStruct.character[i, PStruct.player[i].SelectedChar].X - r == NStruct.tempnpc[Map, Index].X) && (PStruct.character[i, PStruct.player[i].SelectedChar].Y - r == NStruct.tempnpc[Map, Index].Y))
                                {
                                    PStruct.PlayerAttackPlayer(Attacker, i, NStruct.ntempspell[Map, Index, NStempSpell].spellnum, Map);
                                }
                            }
                        }
                    }
                }
                
                for (int i = 0; i <= MStruct.tempmap[Map].NpcCount; i++)
                {
                    for (int r = 1; r <= NStruct.ntempspell[Map, Index, NStempSpell].area_range; r++)
                    {
                        if ((NStruct.tempnpc[Map, i].X - r == NStruct.tempnpc[Map, Index].X) && (NStruct.tempnpc[Map, i].Y == NStruct.tempnpc[Map, Index].Y))
                        {
                            PStruct.PlayerAttackNpc(Attacker, i, NStruct.ntempspell[Map, Index, NStempSpell].spellnum, Map);
                        }
                        if ((NStruct.tempnpc[Map, i].X + r == NStruct.tempnpc[Map, Index].X) && (NStruct.tempnpc[Map, i].Y == NStruct.tempnpc[Map, Index].Y))
                        {
                            PStruct.PlayerAttackNpc(Attacker, i, NStruct.ntempspell[Map, Index, NStempSpell].spellnum, Map);
                        }
                        if ((NStruct.tempnpc[Map, i].X == NStruct.tempnpc[Map, Index].X) && (NStruct.tempnpc[Map, i].Y - r == NStruct.tempnpc[Map, Index].Y))
                        {
                            PStruct.PlayerAttackNpc(Attacker, i, NStruct.ntempspell[Map, Index, NStempSpell].spellnum, Map);
                        }
                        if ((NStruct.tempnpc[Map, i].X == NStruct.tempnpc[Map, Index].X) && (NStruct.tempnpc[Map, i].Y + r == NStruct.tempnpc[Map, Index].Y))
                        {
                            PStruct.PlayerAttackNpc(Attacker, i, NStruct.ntempspell[Map, Index, NStempSpell].spellnum, Map);
                        }


                        //Is line?
                        if (NStruct.ntempspell[Map, Index, NStempSpell].is_line)
                        {
                            if ((NStruct.tempnpc[Map, i].X - r == NStruct.tempnpc[Map, Index].X) && (NStruct.tempnpc[Map, i].Y + r == NStruct.tempnpc[Map, Index].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, NStruct.ntempspell[Map, Index, NStempSpell].spellnum, Map);
                            }
                            if ((NStruct.tempnpc[Map, i].X + r == NStruct.tempnpc[Map, Index].X) && (NStruct.tempnpc[Map, i].Y - r == NStruct.tempnpc[Map, Index].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, NStruct.ntempspell[Map, Index, NStempSpell].spellnum, Map);
                            }
                            if ((NStruct.tempnpc[Map, i].X + r == NStruct.tempnpc[Map, Index].X) && (NStruct.tempnpc[Map, i].Y + r == NStruct.tempnpc[Map, Index].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, NStruct.ntempspell[Map, Index, NStempSpell].spellnum, Map);
                            }
                            if ((NStruct.tempnpc[Map, i].X - r == NStruct.tempnpc[Map, Index].X) && (NStruct.tempnpc[Map, i].Y - r == NStruct.tempnpc[Map, Index].Y))
                            {
                                PStruct.PlayerAttackNpc(Attacker, i, NStruct.ntempspell[Map, Index, NStempSpell].spellnum, Map);
                            }
                        }
                    }
                }
            }

            NStruct.ntempspell[Map, Index, NStempSpell].repeats -= 1;

            if (NStruct.ntempspell[Map, Index, NStempSpell].repeats <= 0)
            {
                if (SStruct.skill[NStruct.ntempspell[Map, Index, NStempSpell].spellnum].slow)
                {
                    NStruct.tempnpc[Map, Index].movespeed = NStruct.npc[Map, Index].SpeedMove / 64;
                    SendData.Send_MoveSpeed(2, Index, Map);
                }
                NStruct.ntempspell[Map, Index, NStempSpell].attacker = 0;
                NStruct.ntempspell[Map, Index, NStempSpell].timer = 0;
                NStruct.ntempspell[Map, Index, NStempSpell].spellnum = 0;
                NStruct.ntempspell[Map, Index, NStempSpell].repeats = 0;
                NStruct.ntempspell[Map, Index, NStempSpell].active = false;
            }

            NStruct.ntempspell[Map, Index, NStempSpell].timer = Loops.TickCount.ElapsedMilliseconds + SStruct.skill[NStruct.ntempspell[Map, Index, NStempSpell].spellnum].interval;

        }
    }
}
