using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACESERVER.Server.Network
{
    class ReceiveData
    {
        public static void SelectPacket(int Index, string data)
        {
            Loops.Last_Packet = data;
            string[] packets = data.Split('\\');
            for (int i = 0; i < packets.Length; i++)
            {
                if (packets[i] == String.Empty) { break; }
                if (PStruct.tempplayer[Index].ingame)
                {
                    //Dados ingame
                    if (packets[i].StartsWith("<10>")) { ReceivedUpdatePlayer(Index); }
                    else if (packets[i].StartsWith("<11>")) { ReceivedMove(Index, packets[i]); }
                    else if (packets[i].StartsWith("<12>")) { ReceivedMessage(Index, packets[i]); }
                    else if (packets[i].StartsWith("<15>")) { MapCheck(Index, packets[i]); }
                    else if (packets[i].StartsWith("<16>")) { UseItemCheck(Index, packets[i]); }
                    else if (packets[i].StartsWith("<17>")) { EquipItemCheck(Index, packets[i]); }
                    else if (packets[i].StartsWith("<18>")) { AttackCheck(Index, packets[i]); }
                    else if (packets[i].StartsWith("<19>")) { DirCheck(Index, packets[i]); }
                    else if (packets[i].StartsWith("<20>")) { PickItemCheck(Index); }
                    else if (packets[i].StartsWith("<21>")) { DropItemCheck(Index, packets[i]); }
                    else if (packets[i].StartsWith("<22>")) { ItemCheck(Index, packets[i]); }
                    else if (packets[i].StartsWith("<23>")) { WeaponCheck(Index, packets[i]); }
                    else if (packets[i].StartsWith("<24>")) { ArmorCheck(Index, packets[i]); }
                    else if (packets[i].StartsWith("<25>")) { SkillCheck(Index, packets[i]); }
                    else if (packets[i].StartsWith("<26>")) { HotkeyCheck(Index, packets[i]); }
                    else if (packets[i].StartsWith("<27>")) { TargetCheck(Index, packets[i]); }
                    else if (packets[i].StartsWith("<28>")) { EnemyCheck(Index, packets[i]); }
                    else if (packets[i].StartsWith("<29>")) { ReceivedSkill(Index, packets[i]); }
                    else if (packets[i].StartsWith("<30>")) { ReceivedAtr(Index, packets[i]); }
                    else if (packets[i].StartsWith("<31>")) { ReceivedUseSkillPoints(Index, packets[i]); }
                    else if (packets[i].StartsWith("<32>")) { ReceivedParty(Index); }
                    else if (packets[i].StartsWith("<33>")) { ReceivedPartyResponse(Index, packets[i]); }
                    else if (packets[i].StartsWith("<34>")) { ReceivedPartyKick(Index, packets[i]); }
                    else if (packets[i].StartsWith("<35>")) { ReceivedPartyChange(Index, packets[i]); }
                    else if (packets[i].StartsWith("<36>")) { ReceivedTrade(Index); }
                    else if (packets[i].StartsWith("<37>")) { ReceivedAddTradeOffer(Index, packets[i]); }
                    else if (packets[i].StartsWith("<38>")) { ReceivedAddTradeG(Index, packets[i]); }
                    else if (packets[i].StartsWith("<39>")) { ReceivedTradeResponse(Index, packets[i]); }
                    else if (packets[i].StartsWith("<40>")) { ReceivedTradeAccept(Index); }
                    else if (packets[i].StartsWith("<41>")) { ReceivedTradeRefuse(Index); }
                    else if (packets[i].StartsWith("<42>")) { ReceivedTradeClose(Index); }
                    else if (packets[i].StartsWith("<43>")) { ReceivedQuestAction(Index, packets[i]); }
                    else if (packets[i].StartsWith("<44>")) { ReceivedShop(Index); }
                    else if (packets[i].StartsWith("<45>")) { ReceivedShopBuy(Index, packets[i]); }
                    else if (packets[i].StartsWith("<46>")) { ReceivedShopSell(Index, packets[i]); }
                    else if (packets[i].StartsWith("<47>")) { ReceivedShopClose(Index); }
                    else if (packets[i].StartsWith("<48>")) { ReceivedCraftAdd(Index, packets[i]); }
                    else if (packets[i].StartsWith("<49>")) { ReceivedCraftWith(Index, packets[i]); }
                    else if (packets[i].StartsWith("<50>")) { ReceivedOpenCraft(Index); }
                    else if (packets[i].StartsWith("<51>")) { ReceivedCloseCraft(Index); }
                    else if (packets[i].StartsWith("<52>")) { ReceivedCraftCreate(Index); }
                    else if (packets[i].StartsWith("<53>")) { ReceivedItemCraft(Index, packets[i]); }
                    else if (packets[i].StartsWith("<54>")) { ReceivedOpenChest(Index); }
                    else if (packets[i].StartsWith("<55>")) { ReceivedOpenBank(Index); }
                    else if (packets[i].StartsWith("<56>")) { ReceivedBankPickItem(Index, packets[i]); }
                    else if (packets[i].StartsWith("<57>")) { ReceivedBankGiveItem(Index, packets[i]); }
                    else if (packets[i].StartsWith("<58>")) { ReceivedCloseBank(Index); }
                    else if (packets[i].StartsWith("<59>")) { ReceivedCompleteAction(Index, packets[i]); }
                    else if (packets[i].StartsWith("<61>")) { ReceivedCharacterSelection(Index); }
                    else if (packets[i].StartsWith("<62>")) { ReceivedGuild(Index); }
                    else if (packets[i].StartsWith("<63>")) { ReceivedGuildResponse(Index, packets[i]); }
                    else if (packets[i].StartsWith("<64>")) { ReceivedGuildCreate(Index, packets[i]); }
                    else if (packets[i].StartsWith("<65>")) { ReceivedGuildKick(Index, packets[i]); }
                    else if (packets[i].StartsWith("<66>")) { ReceivedRespawn(Index); }
                    else if (packets[i].StartsWith("<70>")) { ReceivedWarp(Index, packets[i]); }
                    else if (packets[i].StartsWith("<71>")) { ReceivedPVP(Index); }
                    else if (packets[i].StartsWith("<72>")) { ReceivedImprovement(Index, packets[i]); }
                    else if (packets[i].StartsWith("<74>")) { ReceivedPremmy(Index, packets[i]); } //mod
                    else if (packets[i].StartsWith("<75>")) { ReceivedBan(Index, packets[i]); } //mod
                    else if (packets[i].StartsWith("<76>")) { ReceivedKick(Index, packets[i]); } //mod
                    else if (packets[i].StartsWith("<77>")) { ReceivedWPoints(Index, packets[i]); } //mod
                    else if (packets[i].StartsWith("<78>")) { ReceivedSetPos(Index, packets[i]); } //mod
                    else if (packets[i].StartsWith("<79>")) { ReceivedTP(Index, packets[i]); }
                    else if (packets[i].StartsWith("<80>")) { ReceivedAddPShop(Index, packets[i]); }
                    else if (packets[i].StartsWith("<81>")) { ReceivedWithPShop(Index, packets[i]); }
                    else if (packets[i].StartsWith("<82>")) { ReceivedStartPShop(Index); }
                    else if (packets[i].StartsWith("<83>")) { ReceivedBuyPShop(Index, packets[i]); }
                    else if (packets[i].StartsWith("<84>")) { ReceivedOpenPShop(Index, packets[i]); }
                    else if (packets[i].StartsWith("<85>")) { ReceivedClosePShop(Index); }
                    else if (packets[i].StartsWith("<86>")) { ReceivedCollector(Index); }
                    else if (packets[i].StartsWith("<87>")) { ReceivedOutCollector(Index); }
                    else if (packets[i].StartsWith("<89>")) { ReceivedSavePoint(Index); }
                    else if (packets[i].StartsWith("<90>")) { ReceivedFriendAdd(Index); }
                    else if (packets[i].StartsWith("<91>")) { ReceivedFriendResponse(Index, packets[i]); }
                    else if (packets[i].StartsWith("<92>")) { ReceivedFriendDelete(Index, packets[i]); }
                }
                else
                {
                    //Dados fora do jogo
                    if (packets[i].StartsWith("<0>")) { ReceivedAuth(Index, packets[i]); }
                    else if (packets[i].StartsWith("<3>")) { ReceivedMotd(Index); }
                    else if (packets[i].StartsWith("<4>")) { ReceivedLogin(Index, packets[i]); }
                    else if (packets[i].StartsWith("<5>")) { ReceivedRegister(Index, packets[i]); }
                    else if (packets[i].StartsWith("<67>")) { ReceivedForget(Index, packets[i]); }
                    else if (packets[i].StartsWith("<68>")) { ReceivedActivation(Index, packets[i]); }
                    else if (packets[i].StartsWith("<69>")) { ReceivedEmailActivation(Index); }
                    else if (packets[i].StartsWith("<88>")) { ReceivedError(packets[i]); }
                    //Dados depois do login
                    if (PStruct.tempplayer[Index].Logged)
                    {
                        if (packets[i].StartsWith("<6>")) { ReceivedNewChar(Index, packets[i]); }
                        else if (packets[i].StartsWith("<8>")) { ReceivedIngame(Index, packets[i]); }
                        else if (packets[i].StartsWith("<60>")) { ReceivedDeleteChar(Index, packets[i]); }
                        else if (packets[i].StartsWith("<73>")) { ReceivedWBuy(Index, packets[i]); }
                    }
                }
                
                //Dados globais
                if (packets[i].StartsWith("<1>")) { ReceivedDisconnect(Index); }
                else if (packets[i].StartsWith("<14>")) { LatencyCheck(Index); }
            }
        }
        public static bool IsNumeric(string data)
        {
            int v;
            if (Int32.TryParse(data.Trim(), out v))
            {
                return true;
            }
            return false;
        }
        public static void ReceivedPVP(int index)
        {
            if (PStruct.character[index, PStruct.player[index].SelectedChar].PVPChangeTimer > Loops.TickCount.ElapsedMilliseconds) { return; }

            if (PStruct.character[index, PStruct.player[index].SelectedChar].PVP)
            {
                PStruct.character[index, PStruct.player[index].SelectedChar].PVP = false;
                PStruct.character[index, PStruct.player[index].SelectedChar].PVPChangeTimer = 60000 + Loops.TickCount.ElapsedMilliseconds;
            }
            else
            {
                PStruct.character[index, PStruct.player[index].SelectedChar].PVP = true;
                PStruct.character[index, PStruct.player[index].SelectedChar].PVPChangeTimer = 60000 + Loops.TickCount.ElapsedMilliseconds;
            }
            SendData.Send_PlayerPvpToMap(index);
            SendData.Send_PlayerPvpChangeTimer(index);
        }
        public static void ReceivedUpdatePlayer(int id)
        {
        }

        public static void ReceivedAuth(int Index, string data)
        {
            string[] packet = data.Replace("<0>", "").Split(';');
            if (packet[0] != Globals.Client_Version) { SendData.Send_NStatus(Index, "Versão inválida, por favor atualize o jogo."); WinsockAsync.ShutdownUser(UserConnection.GetIndex(Index)) ;return; }
            SendData.SendToUser(Index, String.Format("<0 {0}>1</0>\n", Index.ToString()));
        }

        public static void ReceivedMotd(int Index)
        {
            if (PStruct.tempplayer[Index].ingame) {return;}
            SendData.SendToUser(Index, String.Format("<3>{0}</3>\n", WinsockAsync.Motd));
        }

        public static void ReceivedDisconnect(int Index)
        {

        }

        public static void ReceivedSetPos(int index, string data)
        {
            if (PStruct.character[index, PStruct.player[index].SelectedChar].Access < 10) { return; }
            string[] packet = data.Replace("<78>", "").Split(';');
            if (packet.Length != 2) { return; }
            if (!IsNumeric(packet[1])) { return; }
            if (!IsNumeric(packet[0])) { return; }

            byte x = Convert.ToByte(packet[0]);
            byte  y = Convert.ToByte(packet[1]);

            if ((x < 0) || (x > Globals.MaxMapsX)) { return; }
            if ((y < 0) || (y > Globals.MaxMapsY)) { return; }

            PStruct.character[index, PStruct.player[index].SelectedChar].X = x;
            PStruct.character[index, PStruct.player[index].SelectedChar].Y = y;

            SendData.Send_PlayerXY(index);
        }


        public static void ReceivedFriendAdd(int index)
        {
            //Possíveis tentativas de hacker
            if ((PStruct.tempplayer[index].targettype != 1) || (PStruct.tempplayer[index].target <= 0) || (PStruct.tempplayer[index].InviteTimer > Loops.TickCount.ElapsedMilliseconds)) { SendData.Send_MsgToPlayer(index, "O jogador não pode receber o convite no momento.", Globals.ColorRed, Globals.Msg_Type_Server); return; }

            //Não pode convidar ele mesmo
            if (PStruct.tempplayer[index].target == index)
            {
                SendData.Send_MsgToPlayer(index, "Você não pode convidar você mesmo, está louco?", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            //O alvo é o index
            int target = PStruct.tempplayer[index].target;
            int clientindex = UserConnection.GetIndex(target);


            //Verifica se ele não se desconectou no processo
            if ((clientindex < 0) || (clientindex >= WinsockAsync.Clients.Count()))
            {
                SendData.Send_MsgToPlayer(index, "O jogador não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }
            if (!WinsockAsync.Clients[clientindex].IsConnected)
            {
                SendData.Send_MsgToPlayer(index, "O jogador não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            //Verificar se já não está na lista
            if (PStruct.FriendNameExist(index, PStruct.character[target, PStruct.player[target].SelectedChar].CharacterName))
            {
                SendData.Send_MsgToPlayer(index, "Esse jogador já está na sua lista de amigos.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            //Criar a váriaveis gerais
            PStruct.tempplayer[index].Inviting = PStruct.tempplayer[index].target;
            PStruct.tempplayer[target].Invited = index;
            PStruct.tempplayer[index].InviteTimer = Loops.TickCount.ElapsedMilliseconds + 10000;
            PStruct.tempplayer[target].InviteTimer = Loops.TickCount.ElapsedMilliseconds + 10000;

            //Envia o convite
            SendData.Send_FriendRequest(index, target);
        }

        public static void ReceivedFriendResponse(int index, string data)
        {
            string[] splited = data.Replace("<91>", "").Split(';');

            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > 2)) { return; }
            if ((Convert.ToInt32(splited[0]) < 0)) { return; }

            int response = Convert.ToInt32(splited[0]);
            int clientindex = UserConnection.GetIndex(PStruct.tempplayer[index].Invited);

            //Verificar se o jogador não se desconectou no processo
            if ((clientindex < 0) || (clientindex >= WinsockAsync.Clients.Count()))
            {
                SendData.Send_MsgToPlayer(index, "O jogador que lhe convidou não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }
            if (!WinsockAsync.Clients[clientindex].IsConnected)
            {
                SendData.Send_MsgToPlayer(index, "O jogador que lhe convidou não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            int target = PStruct.tempplayer[index].Invited;

            if (response == 0)
            {
                SendData.Send_MsgToPlayer(index, "Você tem um novo amigo!", Globals.ColorGreen, Globals.Msg_Type_Server);
                SendData.Send_MsgToPlayer(target, PStruct.character[index, PStruct.player[index].SelectedChar].CharacterName + " aceitou seu pedido de amizade.", Globals.ColorGreen, Globals.Msg_Type_Server);
                PStruct.AddFriend(index, target);
                PStruct.AddFriend(target, index);
            }
            else if (response == 1)
            {
                //Limpa os valores gerais
                PStruct.tempplayer[index].InviteTimer = 0;
                PStruct.tempplayer[PStruct.tempplayer[index].Invited].InviteTimer = 0;
                PStruct.tempplayer[PStruct.tempplayer[index].Invited].Inviting = 0;
                PStruct.tempplayer[index].Invited = 0;
                SendData.Send_MsgToPlayer(target, PStruct.character[index, PStruct.player[index].SelectedChar].CharacterName + " recusou seu pedido de amizade.", Globals.ColorRed, Globals.Msg_Type_Server);
            }
            
        }
        public static void ReceivedFriendDelete(int index, string data)
        {
            string[] splited = data.Replace("<92>", "").Split(';');

            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > 200)) { return; }
            int friendnum = Convert.ToInt32(splited[0]);

            PStruct.DeleteFriend(index, friendnum);

        }
        public static void ReceivedError(string data)
        {
            string[] packet = data.Replace("<88>", "").Split(';');
            Database.LogAdd(packet[0]);
            Console.WriteLine("Um novo erro foi registrado, verifique-o em Log.txt.");
        }

        public static void ReceivedWPoints(int index, string data)
        {
            if (PStruct.character[index, PStruct.player[index].SelectedChar].Access < 10) { return; }
            string[] packet = data.Replace("<77>", "").Split(';');
            if (packet.Length != 2) { return; }
            if (!IsNumeric(packet[1])) { return; }

            for (int i = 0; i <= Globals.Player_HighIndex; i++)
            {
                if (PStruct.player[i].Email == packet[0])
                {
                    WinsockAsync.ShutdownUser(UserConnection.GetIndex(i));
                }
            }

            if (Database.AddWPoints(packet[0], Convert.ToInt32(packet[1])))
            { SendData.Send_MsgToPlayer(index, "A conta recebeu os wpoints com sucesso.", Globals.ColorGreen, Globals.Msg_Type_Server); }
            else { SendData.Send_MsgToPlayer(index, "Falha ao entregar wpoints.", Globals.ColorGreen, Globals.Msg_Type_Server); }
        }

        public static void ReceivedKick(int index, string data)
        {
            if (PStruct.character[index, PStruct.player[index].SelectedChar].Access < 10) { return; }
            string[] packet = data.Replace("<76>", "").Split(';');
            if (packet.Length != 1) { return; }

            for (int i = 0; i <= Globals.Player_HighIndex; i++)
            {
                if (PStruct.character[i, PStruct.player[i].SelectedChar].CharacterName == packet[0])
                {
                    SendData.Send_MsgToPlayer(index, "O jogador foi retirado com sucesso.", Globals.ColorGreen, Globals.Msg_Type_Server);
                    WinsockAsync.ShutdownUser(UserConnection.GetIndex(i));
                    return;
                }
            }
            SendData.Send_MsgToPlayer(index, "Jogador não encontrado.", Globals.ColorGreen, Globals.Msg_Type_Server);
        }

        public static void ReceivedTP(int index, string data)
        {
            string[] packet = data.Replace("<79>", "").Split(';');
            if (packet.Length != 1) { return; }
            if (!IsNumeric(packet[0])) { return; }
            if (Convert.ToInt32(packet[0]) < 0) { return; }
            if (Convert.ToInt32(packet[0]) > 5) { return; }

            int id = Convert.ToInt32(packet[0]);

            for (int i = 1; i < Globals.Max_TpPoints; i++)
            {
                if (MStruct.tppoint[i].map == PStruct.character[index, PStruct.player[index].SelectedChar].Map)
                {
                    if (PStruct.character[index, PStruct.player[index].SelectedChar].Gold >= MStruct.tppoint[i].cost)
                    {
                        if (id <= MStruct.tppoint[i].count)
                        {
                            PStruct.PlayerWarp(index, MStruct.tppoint[i].tp_map[id], MStruct.tppoint[i].tp_x[id], MStruct.tppoint[i].tp_y[id]);
                            PStruct.character[index, PStruct.player[index].SelectedChar].Gold -= MStruct.tppoint[i].cost;
                            SendData.Send_PlayerG(index);
                        }
                    }
                    else
                    {
                        return; 
                    }
                }
            }
        }
        public static void ReceivedSavePoint(int index)
        {
            for (int i = 1; i < Globals.Max_SavePoints; i++)
            {
                if (MStruct.savepoint[i].map == PStruct.character[index, PStruct.player[index].SelectedChar].Map)
                {
                    Console.WriteLine(MStruct.savepoint[i].save_map);
                    PStruct.character[index, PStruct.player[index].SelectedChar].BootMap = MStruct.savepoint[i].save_map;
                    PStruct.character[index, PStruct.player[index].SelectedChar].BootX = MStruct.savepoint[i].save_x;
                    PStruct.character[index, PStruct.player[index].SelectedChar].BootY = MStruct.savepoint[i].save_y;
                    return;
                }
            }
        }

        public static void ReceivedPremmy(int index, string data)
        {
            if (PStruct.character[index, PStruct.player[index].SelectedChar].Access < 10) { return; }
            string[] packet = data.Replace("<74>", "").Split(';');
            if (packet.Length != 2) { return; }
            if (!IsNumeric(packet[1])) { return; }

            for (int i = 0; i <= Globals.Player_HighIndex; i++)
            {
                if (PStruct.player[i].Email == packet[0])
                {
                    WinsockAsync.ShutdownUser(UserConnection.GetIndex(i));
                }
            }

            if (Database.AddPremmy(packet[0], Convert.ToInt32(packet[1])))
            { SendData.Send_MsgToPlayer(index, "A conta recebeu os dias de assinatura com sucesso.", Globals.ColorGreen, Globals.Msg_Type_Server); }
            else { SendData.Send_MsgToPlayer(index, "Falha ao entregar assinatura.", Globals.ColorGreen, Globals.Msg_Type_Server); }
        }

        public static void ReceivedBan(int index, string data)
        {
            if (PStruct.character[index, PStruct.player[index].SelectedChar].Access < 10) { return; }
            string[] packet = data.Replace("<75>", "").Split(';');
            if (packet.Length != 2) { return; }
            if (!IsNumeric(packet[1])) { return; }

            for (int i = 0; i <= Globals.Player_HighIndex; i++)
            {
                if (PStruct.player[i].Email == packet[0])
                {
                    WinsockAsync.ShutdownUser(UserConnection.GetIndex(i));
                }
            }

            if (Database.AddBan(packet[0], Convert.ToInt32(packet[1])))
            { SendData.Send_MsgToPlayer(index, "A conta foi banida com sucesso.", Globals.ColorGreen, Globals.Msg_Type_Server); }
            else { SendData.Send_MsgToPlayer(index, "Falha ao banir a conta.", Globals.ColorGreen, Globals.Msg_Type_Server); }
        }

        public static void ReceivedActivation(int index, string data)
        {
            string[] packet = data.Replace("<68>", "").Split(';');

            if (packet.Length != 1) { return; }
            if (!IsNumeric(packet[0])) { return; }
            if (packet[0].Length < 4) { return; }
            if (packet[0].Length > 5) { return; }

            if (Convert.ToInt32(packet[0]) == PStruct.tempplayer[index].ActivationCode)
            {
                PStruct.player[index].Confirmed = true;
                Database.SaveAccount(index);
                if (!PStruct.tempplayer[index].Logged)
                {
                    SendData.SendToUser(index, String.Format("<5 {0};{1}>a</5>\n", PStruct.player[index].Email, PStruct.player[index].Password));
                }
                else
                {
                    SendData.SendToUser(index, String.Format("<5 {0};{1}>v</5>\n", "", ""));
                }
            }
            else
            {
                SendData.SendToUser(index, String.Format("<5 {0};{1}>f</5>\n", PStruct.player[index].Email, ""));
            }
        }
        public static void ReceivedEmailActivation(int index)
        {
            if (PStruct.tempplayer[index].ActivationCode > 0) { return; }
            Mail.Send_ActivationCode(index, PStruct.player[index].Email);
        }
        public static void ReceivedLogin(int Index, string data)
        {
            WinsockAsync.Log(String.Format("Tentativa de login..."));
            string[] login = data.Replace("<4>", "").Split(';');

            if (login.Length != 2) { return; }
            if (login[0].Length > 100) { return; }
            if (login[1].Length > 8) { return; }

            if (Database.NameIsIllegal(login[0])) { return; }
            if (Database.NameIsIllegal(login[1])) { return; }
            if ((!PStruct.tempplayer[Index].Logged) && (!String.IsNullOrEmpty(PStruct.player[Index].Email))) { Database.ClearPlayer(Index, true); }

            login[0] = login[0].ToLower();

            string response = WinsockAsync.LoginAnswer(login, Index);
            //SendData.Send_NStatus(Index, "Acesso bloqueado, o servidor está em manutenção."); return;

            SendData.SendToUser(Index, String.Format("<4 {0}>{1}</4>\n", login[0], response));
            PStruct.tempplayer[Index].ingame = false;
            if (response == "a")
            {
                if (PStruct.IsPlayerBanned(Index)) { SendData.Send_NStatus(Index, "Essa conta está banida até " + PStruct.player[Index].Banned.ToString()); return; }
                if (!PStruct.player[Index].Confirmed)
                {
                    SendData.SendToUser(Index, String.Format("<4 {0}>{1}</4>\n", "", "x"));
                }
                else
                {
                    SendData.SendToUser(Index, String.Format("<4 {0}>{1}</4>\n", "", "r"));
                }
                ReceivedLoadChar(Index, 0);
                ReceivedLoadChar(Index, 1);
                ReceivedLoadChar(Index, 2);
                SendData.Send_Premmy(Index);
                SendData.Send_WPoints(Index);
                SendData.Send_Notice(Index);
                //Carrega os itens no banco
                Database.LoadBank(Index);
                Database.LoadFriendList(Index);
                PStruct.tempplayer[Index].Logged = true;
            }
        }
        public static void ReceivedWarp(int index, string data)
        {
            string[] packet = data.Replace("<70>", "").Split(';');
            if (PStruct.character[index, PStruct.player[index].SelectedChar].Access < 3) { return; }
            PStruct.PlayerWarp(index, Convert.ToInt32(packet[0]), PStruct.character[index, PStruct.player[index].SelectedChar].X, PStruct.character[index, PStruct.player[index].SelectedChar].Y);
        }
        public static void ReceivedForget(int index, string data)
        {
            string[] packet = data.Replace("<67>", "").Split(';');
            if (packet.Length != 2) { return; }
            if (!IsNumeric(packet[0])) { return; }
            if (Convert.ToInt32(packet[0]) > 1) { return; }
            if (Convert.ToInt32(packet[0]) < 0) { return; }
            if (packet[1].Length > 100) { return; }
            if (packet[1].Length < 5) { return; }

            Mail.Send_Account(index, 1, packet[1]);
        }
        public static void ReceivedCharacterSelection(int index)
        {
            if (PStruct.tempplayer[index].ingame)
            {
                //Sai da troca
                if (PStruct.tempplayer[index].InTrade > 0)
                {
                    PStruct.GiveTrade(index);
                    PStruct.GiveTrade(PStruct.tempplayer[index].InTrade);


                    if ((UserConnection.GetIndex(PStruct.tempplayer[index].InTrade) < 0) || (UserConnection.GetIndex(PStruct.tempplayer[index].InTrade) >= WinsockAsync.Clients.Count()))
                    {
                        PStruct.ClearTempTrade(PStruct.tempplayer[index].InTrade);
                        PStruct.ClearTempTrade(index);
                        return;
                    }

                    if (WinsockAsync.Clients[(UserConnection.GetIndex(PStruct.tempplayer[index].InTrade))].IsConnected)
                    {
                        SendData.Send_PlayerG(PStruct.tempplayer[index].InTrade);
                        SendData.Send_TradeClose(PStruct.tempplayer[index].InTrade);
                        SendData.Send_InvSlots(PStruct.tempplayer[index].InTrade, PStruct.player[PStruct.tempplayer[index].InTrade].SelectedChar);
                    }

                    PStruct.ClearTempTrade(PStruct.tempplayer[index].InTrade);
                    PStruct.ClearTempTrade(index);
                }

                //Sai do Craft
                if (PStruct.tempplayer[index].InCraft)
                {
                    for (int i = 1; i < Globals.Max_Craft; i++)
                    {
                        if (PStruct.craft[index, i].num > 0)
                        {
                            PStruct.GiveItem(index, PStruct.craft[index, i].type, PStruct.craft[index, i].num, PStruct.craft[index, i].value, PStruct.craft[index, i].refin, PStruct.craft[index, i].exp);
                        }
                    }
                }

                //Salva o jogador SE PRECISAR
                if (PStruct.tempplayer[index].ingame)
                {
                    Database.SaveCharacter(index, PStruct.player[index].Email, PStruct.player[index].SelectedChar);
                    Database.SaveBank(index);
                    Database.SaveFriendList(index);
                }

                //Sai do grupo
                if (PStruct.tempplayer[index].Party > 0)
                {
                    PStruct.KickParty(index, index, true);
                }

                //Vamos avisar ao mapa que o jogador saiu
                SendData.Send_PlayerLeft(PStruct.character[index, PStruct.player[index].SelectedChar].Map, index);

                //Apagamos array do jogador
                Database.ClearPlayer(index);
                PStruct.ClearTempPlayer(index);

                //Seleção de personagem
                ReceivedLoadChar(index, 0);
                ReceivedLoadChar(index, 1);
                ReceivedLoadChar(index, 2);

                //Continua conectado
                //Ingame no!
                PStruct.tempplayer[index].ingame = false;
                PStruct.tempplayer[index].Logged = true;
            }
            else
            {
                return;
            }
        }
        public static void ReceivedRegister(int Index, string data)
        {
            string[] register = data.Replace("<5>", "").Split(';');

            if (register.Length != 3) { return; }
            if (register[0].Length > 8) { return; }
            if (register[1].Length > 8) { return; }
            if (register[2].Length > 100) { return; }

            if (Database.NameIsIllegal(register[0])) { return; }
            if (Database.NameIsIllegal(register[1])) { return; }
            if (Database.NameIsIllegal(register[2])) { return; }

            register[2] = register[2].ToLower();

            if (Database.AccountExists(register[2]))
            {
                SendData.SendToUser(Index, String.Format("<5 {0};{1}>e</5>\n", register[2], register[1]));
            }
            else
            {
                Database.RegisterNewAccount(Index, register[0], register[1], register[2]);
                Database.SaveBank(Index);
                Database.SaveFriendList(Index);
                SendData.SendToUser(Index, String.Format("<5 {0};{1}>c</5>\n", register[2], register[1]));
                Mail.Send_ActivationCode(Index, register[2]);
                WinsockAsync.Log(String.Format("Usuário {0} registrado!", register[0]));
            }
        }

        public static void ReceivedNewChar(int Index, string data)
        {
            string[] newChar = data.Replace("<6>", "").Split(';');

            if (newChar.Length != 11) { return; }
            if (!IsNumeric(newChar[1])) { return;}
            if (!IsNumeric(newChar[2])) { return; }
            if (!IsNumeric(newChar[3])) { return; }
            if (!IsNumeric(newChar[4])) { return; }
            if (!IsNumeric(newChar[5])) { return; }
            if (!IsNumeric(newChar[6])) { return; }
            if (!IsNumeric(newChar[7])) { return; }
            if (!IsNumeric(newChar[8])) { return; }
            if (!IsNumeric(newChar[9])) { return; }
            if (!IsNumeric(newChar[10])) { return; }
            if (Database.NameIsIllegal(newChar[0])) { return; }
            if (newChar[0].Length < 3) { return; }
            if (newChar[0].Length > 15) { return; }
            if (Convert.ToInt32(newChar[1]) > Globals.MaxChars - 1) { return; }
            if (Convert.ToInt32(newChar[2]) > Globals.MaxClasses) { return; }
            if (Convert.ToInt32(newChar[3]) > 12) { return; }
            if (Convert.ToInt32(newChar[4]) > 12) { return; }
            if (Convert.ToInt32(newChar[5]) > 12) { return; }
            if (Convert.ToInt32(newChar[6]) > 12) { return; }
            if (Convert.ToInt32(newChar[7]) > 12) { return; }
            if (Convert.ToInt32(newChar[8]) > 12) { return; }
            if (Convert.ToInt32(newChar[9]) > 500) { return; }
            if (Convert.ToInt32(newChar[10]) > 1) { return; }
            if (Convert.ToInt32(newChar[1]) < 0) { return; }
            if (Convert.ToInt32(newChar[2]) < 0) { return; }
            if (Convert.ToInt32(newChar[3]) < 0) { return; }
            if (Convert.ToInt32(newChar[4]) < 0) { return; }
            if (Convert.ToInt32(newChar[5]) < 0) { return; }
            if (Convert.ToInt32(newChar[6]) < 0) { return; }
            if (Convert.ToInt32(newChar[7]) < 0) { return; }
            if (Convert.ToInt32(newChar[8]) < 0) { return; }
            if (Convert.ToInt32(newChar[9]) < 0) { return; }
            if (Convert.ToInt32(newChar[10]) < 0) { return; }
            if (newChar[0].Contains(' ')) { return; }
            string name = newChar[0].Trim();
            int id = Convert.ToInt32(newChar[1]);
            int classid = Convert.ToInt32(newChar[2]);
            int fire = Convert.ToInt32(newChar[3]);
            int earth = Convert.ToInt32(newChar[4]);
            int water = Convert.ToInt32(newChar[5]);
            int wind = Convert.ToInt32(newChar[6]);
            int dark = Convert.ToInt32(newChar[7]);
            int light = Convert.ToInt32(newChar[8]);
            int hue = Convert.ToInt32(newChar[9]);
            int gender = Convert.ToInt32(newChar[10]);

            if ((!PStruct.IsPlayerPremmy(Index)) && (classid == 6)) { SendData.Send_NStatus(Index, "Raça disponível apenas para assinantes."); return; }

            try { if ((Convert.ToInt32(newChar[1]) < 0) || (Convert.ToInt32(newChar[1]) > Globals.MaxChars)) { return; } } catch { return; }
            if (Database.CharExists(newChar[0]))
            {
                SendData.SendToUser(Index, String.Format("<6 {0}>e</6>\n", newChar[0]));
            }
            else
            {
                Database.CreateNewChar(Index, PStruct.player[Index].Email, id, name, classid, fire, earth, water, wind, dark, light, hue, gender);
                SendData.SendToUser(Index, String.Format("<6 {0}>c</6>\n", newChar[0]));
                //ReceivedLoadChar(Index, 0);
                //ReceivedLoadChar(Index, 1);
                //ReceivedLoadChar(Index, 2);
                //string[] splited = data.Replace("<8>", "").Split(';');
                string data2 = "<8>" + newChar[1];
                ReceivedIngame(Index, data2);
                WinsockAsync.Log(String.Format("Novo personagem {0}" + " Slot" + "{1}", newChar[0], newChar[1]));
            }
        }

        public static void ReceivedLoadChar(int Index, int ID)
        {
            int intcharId = ID;
            if (Database.SlotExists(PStruct.player[Index].Email, ID.ToString()))
            {
                Console.WriteLine(PStruct.player[Index].Email + " slot" + ID + " TRUE");
                Database.LoadShowChar(Index, PStruct.player[Index].Email, intcharId);
                string charName = (PStruct.character[Index, intcharId].CharacterName);
                int charSpriteIndex = (PStruct.character[Index, intcharId].SpriteIndex);
                int charClass = (PStruct.character[Index, intcharId].ClassId);
                string charSprite = (PStruct.character[Index, intcharId].Sprite);
                int charLevel = (PStruct.character[Index, intcharId].Level);
                int charExp = (PStruct.character[Index, intcharId].Exp);
                int charFire = (PStruct.character[Index, intcharId].Fire);
                int charEarth = (PStruct.character[Index, intcharId].Earth);
                int charWater = (PStruct.character[Index, intcharId].Water);
                int charWind = (PStruct.character[Index, intcharId].Wind);
                int charDark = (PStruct.character[Index, intcharId].Dark);
                int charLight = (PStruct.character[Index, intcharId].Light);
                int charMap = (PStruct.character[Index, intcharId].Map);
                byte charX = (PStruct.character[Index, intcharId].X);
                byte charY = (PStruct.character[Index, intcharId].Y);
                int charHue = (PStruct.character[Index, intcharId].Hue);
                int charGender = (PStruct.character[Index, intcharId].Gender);

                int characterslot = ID;

                //WinsockAsync.Log(String.Format(charName + charGender + charClass + charLevel));
                SendData.SendToUser(Index, String.Format("<7 {0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16}>{17}</7>\n", ID, charName, charSpriteIndex, charClass, charSprite, charLevel, charExp, charFire, charEarth, charWater, charWind, charDark, charLight, charMap, charX, charY, charHue, charGender));
            }
            else
            {
                WinsockAsync.Log(String.Format("Enviando personagem nulo..."));
                SendData.SendToUser(Index, String.Format("<7 {0};e;e;e;e;e;e;e;e;e;e;e;e;e;e;e;e>e</7>\n", ID));
            }
        }
        public static void ReceivedDeleteChar(int index, string data)
        {
            //Dividimos os dados para análise
            string[] splited = data.Replace("<60>", "").Split(';');

            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }

            int charId = Convert.ToInt32(splited[0]);

            if (charId > Globals.MaxChars - 1) { return; }
            if (charId < 0) { return; }

            Database.DeleteChar(index, charId);
            ReceivedLoadChar(index, charId);
        }
        public static void ReceivedIngame(int Index, string data)
        {
            //Verifica se o jogador já não está no jogo
            if (PStruct.tempplayer[Index].ingame) { return; }
            
            //Dividimos os dados para análise
            string[] splited = data.Replace("<8>", "").Split(';');

            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }

            int charId = Convert.ToInt32(splited[0]);

            if (charId > Globals.MaxChars - 1) { return; }
            if (charId < 0) { return; }

            //Carrega TODOS os dados do personagem
            if (!Database.LoadCompleteChar(Index, PStruct.player[Index].Email, charId)) { return; }

            //Personagem selecionado(não usamos muito isso agora)
            PStruct.player[Index].SelectedChar = Convert.ToInt32(charId);

            //Relacionado a definição de vida para novos e velhos jogadores
            if (PStruct.character[Index, PStruct.player[Index].SelectedChar].Vitality > PStruct.GetPlayerMaxVitality(Index))
            {
                PStruct.character[Index, PStruct.player[Index].SelectedChar].Vitality = PStruct.GetPlayerMaxVitality(Index);
                PStruct.tempplayer[Index].Vitality = PStruct.GetPlayerMaxVitality(Index);
            }
            //else
            //{
                PStruct.tempplayer[Index].Vitality = PStruct.character[Index, PStruct.player[Index].SelectedChar].Vitality;
            //}

            //Relacionado a definição de mana para novos e velhos jogadores
            if (PStruct.character[Index, PStruct.player[Index].SelectedChar].Spirit > PStruct.GetPlayerMaxSpirit(Index))
            {
                PStruct.character[Index, PStruct.player[Index].SelectedChar].Spirit = PStruct.GetPlayerMaxSpirit(Index);
                PStruct.tempplayer[Index].Spirit = PStruct.GetPlayerMaxSpirit(Index);
            }
            //else
           // {
                PStruct.tempplayer[Index].Spirit = PStruct.character[Index, PStruct.player[Index].SelectedChar].Spirit;
           // }

            //Se o dono entrou, dar acesso(mesmo que já tenha, tanto faz)
            if (PStruct.player[Index].Email == Globals.MASTER_EMAIL) { PStruct.character[Index, PStruct.player[Index].SelectedChar].Access = 10; }

            //Valores gerais de guilda e sua limpeza e auto correção
            int guildnum = PStruct.character[Index, PStruct.player[Index].SelectedChar].Guild;
            

            if (guildnum > 0)
            {
                if (String.IsNullOrEmpty(GStruct.guild[guildnum].name)) { PStruct.character[Index, PStruct.player[Index].SelectedChar].Guild = 0; }
                bool find = true;

                for (int i = 1; i < Globals.Max_Guild_Members; i++)
                {
                    if (GStruct.guild[guildnum].memberlist[i] == PStruct.character[Index, PStruct.player[Index].SelectedChar].CharacterName)
                    {
                        find = false;
                        break;
                    }
                }

                if (find) { PStruct.character[Index, PStruct.player[Index].SelectedChar].Guild = 0; }
            }

            //O servidor agora sabe que o jogador está dentro do jogo.
            PStruct.tempplayer[Index].ingame = true;
            PStruct.tempplayer[Index].movespeed = Globals.NormalMoveSpeed;

            //Avisamos todos no mapa sobre o novo jogador.
            SendData.Send_PlayerDataToMapBut(Index, PStruct.player[Index].Username, charId);
            
            //Reset pvp values
            if (PStruct.character[Index, PStruct.player[Index].SelectedChar].PVPBanTimer > 0) { PStruct.character[Index, PStruct.player[Index].SelectedChar].PVPBanTimer += Loops.TickCount.ElapsedMilliseconds; }
            if (PStruct.character[Index, PStruct.player[Index].SelectedChar].PVPChangeTimer > 0) { PStruct.character[Index, PStruct.player[Index].SelectedChar].PVPChangeTimer += Loops.TickCount.ElapsedMilliseconds; }
            if (PStruct.character[Index, PStruct.player[Index].SelectedChar].PVPPenalty > 0) { PStruct.character[Index, PStruct.player[Index].SelectedChar].PVPPenalty += Loops.TickCount.ElapsedMilliseconds; PStruct.tempplayer[Index].SORE = true; }
            PStruct.character[Index, PStruct.player[Index].SelectedChar].Gold = 2300;
            
            //Send PVP values
            SendData.Send_PlayerPvpChangeTimer(Index);
            SendData.Send_PlayerPvpBanTimer(Index);
            SendData.Send_PlayerPvpSoreTimer(Index);

            //PShop Slots
            SendData.Send_PShopSlots(Index, Index);

            //Death
            if (PStruct.tempplayer[Index].Vitality <= 0)
            {
                PStruct.tempplayer[Index].isDead = true;
                SendData.Send_PlayerDeathToMap(Index);
            }

            //Enviamos os dados do jogador e dos que estão no mapa para que ele os veja.
            for (int i = 0; i <= Globals.Player_HighIndex; i++)
            {
                if (PStruct.character[i, PStruct.player[i].SelectedChar].Map == PStruct.character[Index, PStruct.player[Index].SelectedChar].Map)
                {
                    SendData.Send_PlayerDataTo(Index, i, PStruct.player[i].Username, charId);
                    SendData.Send_GuildTo(Index, i);
                    SendData.Send_PlayerShoppingTo(Index, i);
                    if (PStruct.tempplayer[i].Stunned) { SendData.Send_Stun(PStruct.character[Index, PStruct.player[Index].SelectedChar].Map, 1, i, 1); }
                    if (PStruct.tempplayer[i].Sleeping) { SendData.Send_Sleep(PStruct.character[Index, PStruct.player[Index].SelectedChar].Map, 1, i, 1); }
                    if (PStruct.tempplayer[i].isDead) { SendData.Send_PlayerDeathTo(Index, i); }
                    //SendData.Send_PlayerMoveSpeedTo(Index, i);
                }
            }

            for (int i = 0; i <= Globals.Max_Chests - 1; i++)
            {
                if (MStruct.chestpoint[i].map == PStruct.character[Index, PStruct.player[Index].SelectedChar].Map)
                {
                    if (PStruct.character[Index, PStruct.player[Index].SelectedChar].Chest[i])
                    {
                        SendData.Send_EventGraphic(Index, MStruct.tile[MStruct.chestpoint[i].map, MStruct.chestpoint[i].x, MStruct.chestpoint[i].y].Event_Id, MStruct.chestpoint[i].inactive_sprite, MStruct.chestpoint[i].inactive_sprite_index, 0, 8);
                    }
                }
            }

            //Ele já recebeu seus dados, agora ele pode processar as coisas (lol)
            SendData.Send_PlayerFriends(Index);
            SendData.Send_MapGuildTo(Index);
            SendData.Send_PlayerSkills(Index);
            SendData.Send_PlayerHotkeys(Index);
            SendData.Send_InvSlots(Index, PStruct.player[Index].SelectedChar);
            SendData.Send_MapNpcsTo(Index);
            SendData.Send_MapItems(Index);
            SendData.Send_PlayerVitalityToMap(PStruct.character[Index, PStruct.player[Index].SelectedChar].Map, Index, PStruct.tempplayer[Index].Vitality);
            SendData.Send_PlayerSpiritToMap(PStruct.character[Index, PStruct.player[Index].SelectedChar].Map, Index, PStruct.tempplayer[Index].Spirit);
            SendData.Send_GuildToMapBut(PStruct.character[Index, PStruct.player[Index].SelectedChar].Map, Index);
            SendData.Send_CompleteGuild(Index);
            SendData.Send_PlayerG(Index);
            SendData.Send_PlayerC(Index);
            SendData.Send_AllQuests(Index);
            SendData.Send_Profs(Index);
            SendData.Send_PlayerSkillPoints(Index);
            SendData.Send_PlayerExtraSpiritToMap(Index);
            SendData.Send_PlayerExtraVitalityToMap(Index);
            SendData.Send_PlayerPvpToMap(Index);
            SendData.Send_PlayerSoreToMap(Index);
            SendData.Send_MsgToPlayer(Index, Globals.MOTD, Globals.ColorGreen, Globals.Msg_Type_Server);
            //SendData.Send_PlayerMoveSpeedToMapBut(Index, PStruct.character[Index, PStruct.player[Index].SelectedChar].Map, Index);
        }
        public static void ReceivedMove(int Index, string data)
        {
            if ((PStruct.tempplayer[Index].InBank) || (PStruct.tempplayer[Index].InCraft) || (PStruct.tempplayer[Index].InTrade > 0) || (PStruct.tempplayer[Index].InShop > 0) || (PStruct.tempplayer[Index].Stunned) || (PStruct.tempplayer[Index].Sleeping)) { return; }
            string[] splited = data.Replace("<11>", "").Split(';');

            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > 10) || (Convert.ToInt32(splited[0]) < 0)) { return; }

            byte Dir = Convert.ToByte(splited[0]);

            if ((PStruct.CanPlayerMove(Index, Dir) == true) && (PStruct.tempplayer[Index].MoveTimer < Loops.TickCount.ElapsedMilliseconds))
            {
                PStruct.PlayerMove(Index, Dir);
                PStruct.tempplayer[Index].MoveTimer = Loops.TickCount.ElapsedMilliseconds + Convert.ToInt64((((8 + (4 - PStruct.tempplayer[Index].movespeed) - PStruct.tempplayer[Index].movespeed) * 64) - 25)); //25ms de tolerância
            }
            else
            {
                SendData.Send_PlayerXY(Index);
            }
        }
        public static void ReceivedMessage(int Index, string data)
        {
            string[] splited = data.Replace("<12>", "").Split(';');
            if (splited.Length != 1) { return; }

            string charMsg = splited[0].Trim();

            if (charMsg.Length > 150) { return; }

            string msg = "";

            try
            {
                if (charMsg.StartsWith("/w "))
                {
                    charMsg = charMsg.Remove(0, 3);
                    string[] playername = charMsg.Split(' ');
                    for (int i = 0; i <= Globals.Player_HighIndex; i++)
                    {
                        if (i != Index)
                        {
                            if ((PStruct.character[i, PStruct.player[i].SelectedChar].CharacterName == playername[0]))
                            {
                                charMsg = charMsg.Remove(0, playername[0].Length);
                                msg = PStruct.character[Index, PStruct.player[Index].SelectedChar].CharacterName + ": " + charMsg;
                                SendData.Send_MsgToPlayer(i, "[Privado] " + msg, Globals.ColorYellow, Globals.Msg_Type_Community);
                                SendData.Send_MsgToPlayer(Index, "[Privado] " + msg, Globals.ColorYellow, Globals.Msg_Type_Community);
                                break;
                            }
                        }
                    }

                    return;
                }

                if (charMsg.StartsWith("/g "))
                {
                    charMsg = charMsg.Remove(0, 3);
                    msg = PStruct.character[Index, PStruct.player[Index].SelectedChar].CharacterName + ": " + charMsg;
                    SendData.Send_MsgToGuild(Index, "[Guilda] " + msg, Globals.ColorPink, Globals.Msg_Type_Guild);
                    return;
                }

                if (charMsg.StartsWith("/p "))
                {
                    if (PStruct.tempplayer[Index].Party > 0)
                    {
                        charMsg = charMsg.Remove(0, 3);
                        msg = PStruct.character[Index, PStruct.player[Index].SelectedChar].CharacterName + ": " + charMsg;
                        SendData.Send_MsgToParty(PStruct.tempplayer[Index].Party, "[Grupo] " + msg, Globals.ColorGreen, Globals.Msg_Type_Community);
                        return;
                    }
                }

                if (charMsg.StartsWith("/t "))
                {
                    charMsg = charMsg.Remove(0, 3);
                    msg = PStruct.character[Index, PStruct.player[Index].SelectedChar].CharacterName + ": " + charMsg;
                    SendData.Send_MsgToAll("[Global] " + msg, Globals.ColorBrown, Globals.Msg_Type_Global);
                    return;
                }

                if (charMsg.StartsWith("/a "))
                {
                    if (PStruct.character[Index, PStruct.player[Index].SelectedChar].Access > 2)
                    {
                        charMsg = charMsg.Remove(0, 3);
                        msg = PStruct.character[Index, PStruct.player[Index].SelectedChar].CharacterName + ": " + charMsg;
                        SendData.Send_MsgToAll("[Admin] " + msg, Globals.ColorGreen, Globals.Msg_Type_Global);
                        return;
                    }
                }


                if (charMsg.StartsWith("/item "))
                {
                    if (PStruct.character[Index, PStruct.player[Index].SelectedChar].Access > 2)
                    {
                        charMsg = charMsg.Remove(0, 6);
                        string[] itemdata = charMsg.Split(',');
                        int itemtype = Convert.ToInt32(itemdata[0]);
                        int itemnum = Convert.ToInt32(itemdata[1]);
                        int itemvalue = Convert.ToInt32(itemdata[2]);
                        int itemrefin = Convert.ToInt32(itemdata[3]);
                        int itemexp = Convert.ToInt32(itemdata[4]);

                        PStruct.GiveItem(Index, itemtype, itemnum, itemvalue, itemrefin, itemexp);
                        return;
                    }
                }

                if (charMsg.StartsWith("/come "))
                {
                    if (PStruct.character[Index, PStruct.player[Index].SelectedChar].Access > 2)
                    {
                        charMsg = charMsg.Remove(0, 6);
                        for (int i = 0; i <= Globals.Player_HighIndex; i++)
                        {
                            if ((PStruct.character[i, PStruct.player[i].SelectedChar].CharacterName == charMsg))
                            {
                                PStruct.PlayerWarp(i, PStruct.character[Index, PStruct.player[Index].SelectedChar].Map, PStruct.character[Index, PStruct.player[Index].SelectedChar].X, PStruct.character[Index, PStruct.player[Index].SelectedChar].Y);
                                break;
                            }
                        }
                        return;
                    }
                }

                if (charMsg.StartsWith("/goto "))
                {
                    if (PStruct.character[Index, PStruct.player[Index].SelectedChar].Access > 2)
                    {
                        charMsg = charMsg.Remove(0, 6);
                        for (int i = 0; i <= Globals.Player_HighIndex; i++)
                        {
                            if ((PStruct.character[i, PStruct.player[i].SelectedChar].CharacterName == charMsg))
                            {
                                PStruct.PlayerWarp(Index, PStruct.character[i, PStruct.player[i].SelectedChar].Map, PStruct.character[i, PStruct.player[i].SelectedChar].X, PStruct.character[i, PStruct.player[i].SelectedChar].Y);
                                break;
                            }
                        }
                        return;
                    }
                }

                if (charMsg.StartsWith("/resetplayer "))
                {
                    if (PStruct.character[Index, PStruct.player[Index].SelectedChar].Access > 2)
                    {
                        charMsg = charMsg.Remove(0, 13);
                        for (int i = 0; i <= Globals.Player_HighIndex; i++)
                        {
                            if ((PStruct.character[i, PStruct.player[i].SelectedChar].CharacterName == charMsg))
                            {
                                PStruct.ResetPlayerStatus(i);
                                break;
                            }
                        }
                        return;
                    }
                }

                if (charMsg.StartsWith("/saveplayers"))
                {
                    if (PStruct.character[Index, PStruct.player[Index].SelectedChar].Access > 2)
                    {
                        for (int i = 0; i <= Globals.Player_HighIndex; i++)
                        {
                            Database.SaveCharacter(i, PStruct.player[i].Email, PStruct.player[i].SelectedChar);
                            SendData.Send_MsgToPlayer(Index, "Os jogadores foram salvos com sucesso.", Globals.ColorYellow, Globals.Msg_Type_Community);
                        }
                        return;
                    }
                }

                if (charMsg.StartsWith("/giveexp "))
                {
                    if (PStruct.character[Index, PStruct.player[Index].SelectedChar].Access > 2)
                    {
                        charMsg = charMsg.Remove(0, 9);
                        string playername = charMsg.Split(' ')[0];
                        int exp = Convert.ToInt32(charMsg.Split(' ')[1]);
                        for (int i = 0; i <= Globals.Player_HighIndex; i++)
                        {
                            if ((PStruct.character[i, PStruct.player[i].SelectedChar].CharacterName == playername))
                            {
                                PStruct.GivePlayerExp(i, exp);
                                break;
                            }
                        }
                        return;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Erro ao processar comando de chat.");
                return;
            }
            msg = PStruct.character[Index, PStruct.player[Index].SelectedChar].CharacterName + ": " + charMsg;
            SendData.Send_MsgToMap(Index, "[Mapa] " +  msg, Globals.ColorWhite, Globals.Msg_Type_Map);
        }

        static void LatencyCheck(int index)
        {
            SendData.SendToUser(index, "<13>'e'</13>\n");
        }
        static void MapCheck(int index, string data)
        {
            string[] newMap = data.Replace("<15>", "").Split(';');
            
            //variáveis simples
            int map = PStruct.character[index, PStruct.player[index].SelectedChar].Map;

            int part = Convert.ToInt32(newMap[0]);
            int startx = Convert.ToInt32(newMap[1]);
            int startxend = Convert.ToInt32(newMap[2]);
            int starty = Convert.ToInt32(newMap[3]);
            int startyend = Convert.ToInt32(newMap[4]);
            MStruct.map[Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Map)].name = newMap[5];
            
            //nosso leitor
            int reader = 6;

            //dados do mapa em geral
            MStruct.map[Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Map)].max_height = "14";
            MStruct.map[Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Map)].max_width = "19";

            //organizamos todos os dados dos tiles
            for (int x = startx; x <= startxend; x++)
                for (int y = starty; y <= startyend; y++)
                {
                    {
                        MStruct.tile[Convert.ToInt32(map), x, y].Event_Id = Convert.ToInt32(newMap[reader]);
                        reader += 1;
                        MStruct.tile[Convert.ToInt32(map), x, y].Data1 = newMap[reader];
                        reader += 1;
                        MStruct.tile[Convert.ToInt32(map), x, y].Data2 = newMap[reader];
                        reader += 1;
                        MStruct.tile[Convert.ToInt32(map), x, y].Data3 = newMap[reader];
                        reader += 1;
                        MStruct.tile[Convert.ToInt32(map), x, y].Data4 = newMap[reader];
                        reader += 1;
                        MStruct.tile[Convert.ToInt32(map), x, y].DownBlock = newMap[reader];
                        reader += 1;
                        MStruct.tile[Convert.ToInt32(map), x, y].LeftBlock = newMap[reader];
                        reader += 1;
                        MStruct.tile[Convert.ToInt32(map), x, y].RightBlock = newMap[reader];
                        reader += 1;
                        MStruct.tile[Convert.ToInt32(map), x, y].UpBlock = newMap[reader];
                        reader += 1;
                    }

                }

            //salvamos o mapa depois de juntar e organizar seus dados
            if (part == 4)
            {
                //Se já enviou todas as partes do mapa, salvar.
                Database.SaveMap(map);

                //tudo certo
                Console.WriteLine("O mapa " + map + " foi atualizado com sucesso.");
            }

        }
        static void UseItemCheck(int index, string data)
        {
            string[] splited = data.Replace("<16>", "").Split(';');
            
            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return;}

            int itemUse = Convert.ToInt32(splited[0]);

            if (itemUse > Globals.MaxInvSlot - 1) { return; }
            if (itemUse <= 0) { return; }

            string item = PStruct.invslot[index, itemUse].item;
            string[] splititem = item.Split(',');

            int itemNum = Convert.ToInt32(splititem[1]);
            int itemType = Convert.ToInt32(splititem[0]);
            int itemValue = Convert.ToInt32(splititem[2]);
            int itemRefin = Convert.ToInt32(splititem[3]);
            int itemExp = Convert.ToInt32(splititem[4]);

            string equipment = PStruct.character[index, PStruct.player[index].SelectedChar].Equipment;
            string[] equipdata = equipment.Split(',');

            string Helmet = equipdata[0].Split(';')[0];
            string Armor = equipdata[1].Split(';')[0];
            string Weapon = equipdata[2].Split(';')[0];
            string Shield = equipdata[3].Split(';')[0];
            string Pet = equipdata[4].Split(';')[0];

            string HelmetRefin = equipdata[0].Split(';')[1];
            string ArmorRefin = equipdata[1].Split(';')[1];
            string WeaponRefin = equipdata[2].Split(';')[1];
            string ShieldRefin = equipdata[3].Split(';')[1];
            string PetRefin = equipdata[4].Split(';')[1];
            string PetExp = equipdata[4].Split(';')[2];

            int map = PStruct.character[index, PStruct.player[index].SelectedChar].Map;

            bool equipped = false;

            if ((itemType == 0) || (itemType == 1))
            {
                if (IStruct.itemextra[itemNum].type == 1)
                {
                    if (Convert.ToInt32(Pet) > 0)
                    {
                        if ((Convert.ToInt32(Pet) == itemNum) && (Convert.ToInt32(PetRefin) == itemRefin) && (Convert.ToInt32(PetExp) == itemExp))
                        {
                            itemValue += 1;
                        }
                        if (!PStruct.GiveItem(index, itemType, Convert.ToInt32(Pet), 1, Convert.ToInt32(PetRefin), Convert.ToInt32(PetExp)))
                        {
                            return;
                        }
                    }
                    Pet = itemNum.ToString();
                    PetRefin = itemRefin.ToString();
                    PetExp = itemExp.ToString();
                    equipped = true;
                }
                if (itemNum == 58)
                {
                   if (PStruct.GiveSpell(index, 28))
                   {
                       SendData.Send_MsgToPlayer(index, "Você aprendeu uma nova magia!", Globals.ColorYellow, Globals.Msg_Type_Server);
                       PStruct.PickItem(index, itemType, itemNum, 1, itemRefin);
                       SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
                       SendData.Send_PlayerSkills(index);
                       return;
                   }
                }
                if (itemNum == 59)
                {
                    if (PStruct.GiveSpell(index, 29))
                    {
                        SendData.Send_MsgToPlayer(index, "Você aprendeu uma nova magia!", Globals.ColorYellow, Globals.Msg_Type_Server);
                        PStruct.PickItem(index, itemType, itemNum, 1, itemRefin);
                        SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
                        SendData.Send_PlayerSkills(index);
                        return;
                    }
                }
                if (itemNum == 60)
                {
                    if (PStruct.GiveSpell(index, 30))
                    {
                        SendData.Send_MsgToPlayer(index, "Você aprendeu uma nova magia!", Globals.ColorYellow, Globals.Msg_Type_Server);
                        PStruct.PickItem(index, itemType, itemNum, 1, itemRefin);
                        SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
                        SendData.Send_PlayerSkills(index);
                        return;
                    }
                }
                if (itemNum == 61)
                {
                    if (PStruct.GiveSpell(index, 31))
                    {
                        SendData.Send_MsgToPlayer(index, "Você aprendeu uma nova magia!", Globals.ColorYellow, Globals.Msg_Type_Server);
                        PStruct.PickItem(index, itemType, itemNum, 1, itemRefin);
                        SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
                        SendData.Send_PlayerSkills(index);
                        return;
                    }
                }
                if (itemNum == 66)
                {
                    if (PStruct.GiveSpell(index, 32))
                    {
                        SendData.Send_MsgToPlayer(index, "Você aprendeu uma nova magia!", Globals.ColorYellow, Globals.Msg_Type_Server);
                        PStruct.PickItem(index, itemType, itemNum, 1, itemRefin);
                        SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
                        SendData.Send_PlayerSkills(index);
                        return;
                    }
                }
                if (itemNum == 67)
                {
                    if (PStruct.GiveSpell(index, 34))
                    {
                        SendData.Send_MsgToPlayer(index, "Você aprendeu uma nova magia!", Globals.ColorYellow, Globals.Msg_Type_Server);
                        PStruct.PickItem(index, itemType, itemNum, 1, itemRefin);
                        SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
                        SendData.Send_PlayerSkills(index);
                        return;
                    }
                }
                if (itemNum == 69)
                {
                    PStruct.PlayerWarp(index, Globals.InitialMap, Globals.InitialX, Globals.InitialY);
                    PStruct.PickItem(index, itemType, itemNum, 1, itemRefin);
                    SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
                }
                if (itemNum == 73)
                {
                    int target = PStruct.tempplayer[index].target;
                    int targettype = PStruct.tempplayer[index].targettype;
                    if (targettype == Globals.Target_Npc) { return; }
                    //Check in
                    if (!(PStruct.character[target, PStruct.player[target].SelectedChar].Map == map) || !(target != index))
                    {
                        PStruct.tempplayer[index].preparingskill = 0;
                        PStruct.tempplayer[index].preparingskillslot = 0;
                        PStruct.tempplayer[index].movespeed = Globals.NormalMoveSpeed;
                        SendData.Send_MoveSpeed(1, index);
                        SendData.Send_MsgToPlayer(index, "Não foi possível usar o item.", Globals.ColorRed, Globals.Msg_Type_Server);
                        return;
                    }
                    if (PStruct.tempplayer[target].Vitality <= 0)
                    {
                        PStruct.tempplayer[target].isDead = false;
                        SendData.Send_PlayerDeathToMap(target);
                        PStruct.tempplayer[target].Vitality = 10;
                        SendData.Send_PlayerVitalityToMap(map, target, 10);
                        SendData.Send_Animation(map, Globals.Target_Player, target, 38);
                    }
                    PStruct.PickItem(index, itemType, itemNum, 1, itemRefin);
                    SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
                }
                if (itemNum == 74)
                {
                    if (PStruct.tempplayer[index].SORE)
                    {
                        PStruct.tempplayer[index].SORE = false;
                        PStruct.character[index, PStruct.player[index].SelectedChar].PVPPenalty = 0;
                        PStruct.character[index, PStruct.player[index].SelectedChar].PVP = false;
                        PStruct.character[index, PStruct.player[index].SelectedChar].PVPBanTimer = 0;
                        SendData.Send_PlayerPvpToMap(index);
                        SendData.Send_PlayerSoreToMap(index);
                        SendData.Send_PlayerPvpBanTimer(index);
                        SendData.Send_Animation(map, Globals.Target_Player, index, 108);
                        PStruct.PickItem(index, itemType, itemNum, 1, itemRefin);
                        SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
                    }
                }
                if (IStruct.item[itemNum].damage_type == 3)
                {
                    if (PStruct.tempplayer[index].Vitality >= PStruct.GetPlayerMaxVitality(index)) { return; }
                    if (PStruct.tempplayer[index].isDead) { return; }
                    PlayerLogic.HealPlayer(index, (PStruct.GetPlayerMaxVitality(index) / 100) * Convert.ToInt32(IStruct.item[itemNum].damage_formula));
                    PStruct.PickItem(index, itemType, itemNum, 1, itemRefin);
                    SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
                    return;
                }
                if (IStruct.item[itemNum].damage_type == 4)
                {
                    if (PStruct.tempplayer[index].Spirit >= PStruct.GetPlayerMaxSpirit(index)) { return; }
                    if (PStruct.tempplayer[index].isDead) { return; }
                    PlayerLogic.SpiritPlayer(index, (PStruct.GetPlayerMaxSpirit(index) / 100) * Convert.ToInt32(IStruct.item[itemNum].damage_formula));
                    PStruct.PickItem(index, itemType, itemNum, 1, itemRefin);
                    SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
                    return;
                }
            }
            if (itemType == 2)
            {
                if (Convert.ToInt32(Weapon) > 0)
                {
                    if ((Convert.ToInt32(Weapon) == itemNum) && (Convert.ToInt32(WeaponRefin) == itemRefin))
                    {
                        itemValue += 1;
                    }
                    if (!PStruct.GiveItem(index, itemType, Convert.ToInt32(Weapon), 1, Convert.ToInt32(WeaponRefin), Globals.NullExp))
                    {
                        return;
                    }
                }
                Weapon = itemNum.ToString();
                WeaponRefin = itemRefin.ToString();
                equipped = true;
            }
            if (itemType == 3)
            {
                if (AStruct.armor[itemNum].etype_id == 1)
                {
                    if (Convert.ToInt32(Shield) > 0)
                    {
                        if ((Convert.ToInt32(Shield) == itemNum) && (Convert.ToInt32(ShieldRefin) == itemRefin))
                        {
                            itemValue += 1;
                        }
                        if (!PStruct.GiveItem(index, itemType, Convert.ToInt32(Shield), 1, Convert.ToInt32(ShieldRefin), Globals.NullExp))
                        {
                            return;
                        }
                    }
                    Shield = itemNum.ToString();
                    ShieldRefin = itemRefin.ToString();
                    equipped = true;
                }
                if (AStruct.armor[itemNum].etype_id == 2)
                {
                    if (Convert.ToInt32(Helmet) > 0)
                    {
                        if ((Convert.ToInt32(Helmet) == itemNum) && (Convert.ToInt32(HelmetRefin) == itemRefin))
                        {
                            itemValue += 1;
                        }
                        if (!PStruct.GiveItem(index, itemType, Convert.ToInt32(Helmet), 1, Convert.ToInt32(HelmetRefin), Globals.NullExp))
                        {
                            return;
                        }
                    }
                    Helmet = itemNum.ToString();
                    HelmetRefin = itemRefin.ToString();
                    equipped = true;
                }
                if (AStruct.armor[itemNum].etype_id == 3)
                {
                    if (Convert.ToInt32(Armor) > 0)
                    {
                        if ((Convert.ToInt32(Armor) == itemNum) && (Convert.ToInt32(ArmorRefin) == itemRefin))
                        {
                            itemValue += 1;
                        }
                        if (!PStruct.GiveItem(index, itemType, Convert.ToInt32(Armor), 1, Convert.ToInt32(ArmorRefin), Globals.NullExp))
                        {
                            return;
                        }
                    }
                    Armor = itemNum.ToString();
                    ArmorRefin = itemRefin.ToString();
                    equipped = true;
                }
            }

            if (equipped == true)
            {
                if (itemValue > 1)
                {
                    PStruct.invslot[index, itemUse].item = itemType + "," + itemNum + "," + (itemValue - 1) + "," + itemRefin + "," + itemExp;
                }
                else
                {
                    PStruct.invslot[index, itemUse].item = Globals.NullItem;
                }
                PStruct.character[index, PStruct.player[index].SelectedChar].Equipment = Helmet + ";" + HelmetRefin +  "," + Armor + ";" + ArmorRefin + "," + Weapon + ";" + WeaponRefin + "," + Shield + ";" + ShieldRefin + "," + Pet + ";" + PetRefin + ";" + PetExp;
                SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
                SendData.Send_PlayerEquipmentToMap(index);
                return;
            }
            
        }
        static void EquipItemCheck(int index, string data)
        {
            string[] splited = data.Replace("<17>", "").Split(';');
            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }
            int itemUse = Convert.ToInt32(splited[0]);
            if (itemUse > 4) { return; }
            if (itemUse < 0) { return; }
            string equipment = PStruct.character[index, PStruct.player[index].SelectedChar].Equipment;
            string[] equipdata = equipment.Split(',');
            string[] equip0 = equipdata[0].Split(';');
            string[] equip1 = equipdata[1].Split(';');
            string[] equip2 = equipdata[2].Split(';');
            string[] equip3 = equipdata[3].Split(';');
            string[] equip4 = equipdata[4].Split(';');

            switch (itemUse)
            {
                case 0:
                    if (!PStruct.GiveItem(index, 3, Convert.ToInt32(equip0[0]), 1, Convert.ToInt32(equip0[1]), Globals.NullExp)) { return; }
                    equipdata[0] = "0;0";
                    break;
                case 1:
                    if (!PStruct.GiveItem(index, 3, Convert.ToInt32(equip1[0]), 1, Convert.ToInt32(equip1[1]), Globals.NullExp)) { return; }
                    equipdata[1] = "0;0";
                    break;
                case 2:
                    if (!PStruct.GiveItem(index, 2, Convert.ToInt32(equip2[0]), 1, Convert.ToInt32(equip2[1]), Globals.NullExp)) { return; }
                    equipdata[2] = "0;0";
                    break;
                case 3:
                    if (!PStruct.GiveItem(index, 3, Convert.ToInt32(equip3[0]), 1, Convert.ToInt32(equip3[1]), Globals.NullExp)) { return; }
                    equipdata[3] = "0;0";
                    break;
                case 4:
                    if (!PStruct.GiveItem(index, 1, Convert.ToInt32(equip4[0]), 1, Convert.ToInt32(equip4[1]), Convert.ToInt32(equip4[2]))) { return; }
                    equipdata[4] = "0;0;0";
                    break;
            }

            PStruct.character[index, PStruct.player[index].SelectedChar].Equipment = equipdata[0] + "," + equipdata[1] + "," + equipdata[2] + "," + equipdata[3] + "," + equipdata[4];
            SendData.Send_PlayerEquipmentToMap(index);
            SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
            
            //string msg = PStruct.character[Index, PStruct.player[Index].SelectedChar].CharacterName + ": " + charMsg;
            //SendData.Send_Msg(Index, msg);
        }
        static void AttackCheck(int index, string data)
        {
            if (PStruct.tempplayer[index].AttackTimer > Loops.TickCount.ElapsedMilliseconds ) { return; }
            if (PStruct.tempplayer[index].preparingskill > 0) { return; }

            string[] splited = data.Replace("<18>", "").Split(';');
            if (splited.Length != 2) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if (!IsNumeric(splited[1])) { return; }
            int Target = Convert.ToInt32(splited[0]);
            int TargetType = Convert.ToInt32(splited[1]);

            if (Target > 255) { return; }
            if (TargetType > 2) { return; }
            if (Target < 0) { return; }
            if (TargetType < 0) { return; }

            SendData.Send_PlayerAttack(index);
            PStruct.tempplayer[index].AttackTimer = Loops.TickCount.ElapsedMilliseconds + 1000;

            if (TargetType == 1)
            {
                //atacar jogador
                if (PStruct.CanPlayerAttackPlayer(index, Target) == true)
                {
                    PStruct.PlayerAttackPlayer(index, Target);
                    return;
                }
            }

            if (TargetType == 2)
            {
                //atacar npc
                if (PStruct.CanPlayerAttackNpc(index, Target) == true)
                {
                    PStruct.PlayerAttackNpc(index, Target);
                    return;
                }
            }

            for (int i = 1; i < Globals.Max_WorkPoints; i++)
            {
                if (MStruct.workpoint[i].map == PStruct.character[index, PStruct.player[index].SelectedChar].Map)
                {
                    switch (PStruct.character[index, PStruct.player[index].SelectedChar].Dir)
                    {
                        case 8:
                            if ((PStruct.character[index, PStruct.player[index].SelectedChar].Y - 1 == MStruct.workpoint[i].y) &&(PStruct.character[index, PStruct.player[index].SelectedChar].X == MStruct.workpoint[i].x))
                            { 
                                PStruct.PlayerAttackWorkPoint(index, i);
                                return;
                            }
                            break;
                        case 2:
                            if ((PStruct.character[index, PStruct.player[index].SelectedChar].Y + 1 == MStruct.workpoint[i].y) && (PStruct.character[index, PStruct.player[index].SelectedChar].X == MStruct.workpoint[i].x))
                            {
                                PStruct.PlayerAttackWorkPoint(index, i);
                                return;
                            }
                            break;
                        case 4:
                            if ((PStruct.character[index, PStruct.player[index].SelectedChar].Y == MStruct.workpoint[i].y) && (PStruct.character[index, PStruct.player[index].SelectedChar].X - 1 == MStruct.workpoint[i].x))
                            {
                                PStruct.PlayerAttackWorkPoint(index, i);
                                return;
                            }
                            break;
                        case 6:
                            if ((PStruct.character[index, PStruct.player[index].SelectedChar].Y == MStruct.workpoint[i].y) && (PStruct.character[index, PStruct.player[index].SelectedChar].X + 1 == MStruct.workpoint[i].x))
                            {
                                PStruct.PlayerAttackWorkPoint(index, i);
                                return;
                            }
                            break;
                        default:
                            WinsockAsync.Log(String.Format("Direção nula"));
                            break;
                    }
                }

            }
        }
        static void ReceivedOpenChest(int index)
        {
            for (int i = 1; i < Globals.Max_Chests; i++)
            {
                if (MStruct.chestpoint[i].map > 0)
                {
                    if (MStruct.chestpoint[i].map == PStruct.character[index, PStruct.player[index].SelectedChar].Map)
                    {
                        switch (PStruct.character[index, PStruct.player[index].SelectedChar].Dir)
                        {
                            case 8:
                                if ((PStruct.character[index, PStruct.player[index].SelectedChar].Y - 1 == MStruct.chestpoint[i].y) && (PStruct.character[index, PStruct.player[index].SelectedChar].X == MStruct.chestpoint[i].x))
                                {
                                    if (!PStruct.character[index, PStruct.player[index].SelectedChar].Chest[i])
                                    {
                                        if (MStruct.chestpoint[i].is_random)
                                        {
                                        }
                                        else
                                        {
                                            if (MStruct.chestpoint[i].reward_count > 0)
                                            {
                                                if (PStruct.GetNumOfInvFreeSlots(index) < MStruct.chestpoint[i].reward_count) { SendData.Send_MsgToPlayer(index, "Você não tem espaço no inventário.", Globals.ColorRed, Globals.Msg_Type_Server); return; }
                                                for (int r = 1; r <= MStruct.chestpoint[i].reward_count; r++)
                                                {
                                                    string[] dataitem = MStruct.chestpoint[i].reward[r].Split(',');
                                                    PStruct.GiveItem(index, Convert.ToInt32(dataitem[0]), Convert.ToInt32(dataitem[1]), Convert.ToInt32(dataitem[2]), Convert.ToInt32(dataitem[3]), Globals.NullExp);
                                                }
                                            }
                                        }
                                        PStruct.character[index, PStruct.player[index].SelectedChar].Chest[i] = true;
                                        SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
                                        SendData.Send_ActionMsg(index, "Encontrou um item!", Globals.ColorYellow, PStruct.character[index, PStruct.player[index].SelectedChar].X, PStruct.character[index, PStruct.player[index].SelectedChar].Y, 1, 0, PStruct.character[index, PStruct.player[index].SelectedChar].Map);
                                        SendData.Send_MsgToPlayer(index, "Você obteve novos itens!", Globals.ColorYellow, Globals.Msg_Type_Server);
                                        SendData.Send_EventGraphic(index, MStruct.tile[MStruct.chestpoint[i].map, MStruct.chestpoint[i].x, MStruct.chestpoint[i].y].Event_Id, MStruct.chestpoint[i].inactive_sprite, MStruct.chestpoint[i].inactive_sprite_index, 0, 8);
                                        return;
                                    }
                                }
                                break;
                            case 2:
                                if ((PStruct.character[index, PStruct.player[index].SelectedChar].Y + 1 == MStruct.chestpoint[i].y) && (PStruct.character[index, PStruct.player[index].SelectedChar].X == MStruct.chestpoint[i].x))
                                {
                                    if (!PStruct.character[index, PStruct.player[index].SelectedChar].Chest[i])
                                    {
                                        if (MStruct.chestpoint[i].reward_count > 0)
                                        {
                                            if (PStruct.GetNumOfInvFreeSlots(index) < MStruct.chestpoint[i].reward_count) { SendData.Send_MsgToPlayer(index, "Você não tem espaço no inventário.", Globals.ColorRed, Globals.Msg_Type_Server); return; }
                                            for (int r = 1; r <= MStruct.chestpoint[i].reward_count; r++)
                                            {
                                                string[] dataitem = MStruct.chestpoint[i].reward[r].Split(',');
                                                PStruct.GiveItem(index, Convert.ToInt32(dataitem[0]), Convert.ToInt32(dataitem[1]), Convert.ToInt32(dataitem[2]), Convert.ToInt32(dataitem[3]), Globals.NullExp);
                                            }
                                        }
                                        PStruct.character[index, PStruct.player[index].SelectedChar].Chest[i] = true;
                                        SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
                                        SendData.Send_ActionMsg(index, "Encontrou um item!", Globals.ColorYellow, PStruct.character[index, PStruct.player[index].SelectedChar].X, PStruct.character[index, PStruct.player[index].SelectedChar].Y, 1, 0, PStruct.character[index, PStruct.player[index].SelectedChar].Map);
                                        SendData.Send_MsgToPlayer(index, "Você obteve novos itens!", Globals.ColorYellow, Globals.Msg_Type_Server);
                                        SendData.Send_EventGraphic(index, MStruct.tile[MStruct.chestpoint[i].map, MStruct.chestpoint[i].x, MStruct.chestpoint[i].y].Event_Id, MStruct.chestpoint[i].inactive_sprite, MStruct.chestpoint[i].inactive_sprite_index, 0, 8);
                                        return;
                                    }
                                }
                                break;
                            case 4:
                                if ((PStruct.character[index, PStruct.player[index].SelectedChar].Y == MStruct.chestpoint[i].y) && (PStruct.character[index, PStruct.player[index].SelectedChar].X - 1 == MStruct.chestpoint[i].x))
                                {
                                    if (!PStruct.character[index, PStruct.player[index].SelectedChar].Chest[i])
                                    {
                                        if (MStruct.chestpoint[i].reward_count > 0)
                                        {
                                            if (PStruct.GetNumOfInvFreeSlots(index) < MStruct.chestpoint[i].reward_count) { SendData.Send_MsgToPlayer(index, "Você não tem espaço no inventário.", Globals.ColorRed, Globals.Msg_Type_Server); return; }
                                            for (int r = 1; r <= MStruct.chestpoint[i].reward_count; r++)
                                            {
                                                string[] dataitem = MStruct.chestpoint[i].reward[r].Split(',');
                                                PStruct.GiveItem(index, Convert.ToInt32(dataitem[0]), Convert.ToInt32(dataitem[1]), Convert.ToInt32(dataitem[2]), Convert.ToInt32(dataitem[3]), Globals.NullExp);
                                            }
                                        }
                                        PStruct.character[index, PStruct.player[index].SelectedChar].Chest[i] = true;
                                        SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
                                        SendData.Send_ActionMsg(index, "Encontrou um item!", Globals.ColorYellow, PStruct.character[index, PStruct.player[index].SelectedChar].X, PStruct.character[index, PStruct.player[index].SelectedChar].Y, 1, 0, PStruct.character[index, PStruct.player[index].SelectedChar].Map);
                                        SendData.Send_MsgToPlayer(index, "Você obteve novos itens!", Globals.ColorYellow, Globals.Msg_Type_Server);
                                        SendData.Send_EventGraphic(index, MStruct.tile[MStruct.chestpoint[i].map, MStruct.chestpoint[i].x, MStruct.chestpoint[i].y].Event_Id, MStruct.chestpoint[i].inactive_sprite, MStruct.chestpoint[i].inactive_sprite_index, 0, 8);
                                        return;
                                    }
                                }
                                break;
                            case 6:
                                if ((PStruct.character[index, PStruct.player[index].SelectedChar].Y == MStruct.chestpoint[i].y) && (PStruct.character[index, PStruct.player[index].SelectedChar].X + 1 == MStruct.chestpoint[i].x))
                                {
                                    if (!PStruct.character[index, PStruct.player[index].SelectedChar].Chest[i])
                                    {
                                        if (MStruct.chestpoint[i].reward_count > 0)
                                        {
                                            if (PStruct.GetNumOfInvFreeSlots(index) < MStruct.chestpoint[i].reward_count) { SendData.Send_MsgToPlayer(index, "Você não tem espaço no inventário.", Globals.ColorRed, Globals.Msg_Type_Server); return; }
                                            for (int r = 1; r <= MStruct.chestpoint[i].reward_count; r++)
                                            {
                                                string[] dataitem = MStruct.chestpoint[i].reward[r].Split(',');
                                                PStruct.GiveItem(index, Convert.ToInt32(dataitem[0]), Convert.ToInt32(dataitem[1]), Convert.ToInt32(dataitem[2]), Convert.ToInt32(dataitem[3]), Globals.NullExp);
                                            }
                                        }
                                        PStruct.character[index, PStruct.player[index].SelectedChar].Chest[i] = true;
                                        SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
                                        SendData.Send_ActionMsg(index, "Encontrou um item!", Globals.ColorYellow, PStruct.character[index, PStruct.player[index].SelectedChar].X, PStruct.character[index, PStruct.player[index].SelectedChar].Y, 1, 0, PStruct.character[index, PStruct.player[index].SelectedChar].Map);
                                        SendData.Send_MsgToPlayer(index, "Você obteve novos itens!", Globals.ColorYellow, Globals.Msg_Type_Server);
                                        SendData.Send_EventGraphic(index, MStruct.tile[MStruct.chestpoint[i].map, MStruct.chestpoint[i].x, MStruct.chestpoint[i].y].Event_Id, MStruct.chestpoint[i].inactive_sprite, MStruct.chestpoint[i].inactive_sprite_index, 0, 8);
                                        return;
                                    }
                                }
                                break;
                            default:
                                WinsockAsync.Log(String.Format("Direção nula"));
                                break;
                        }
                    }
                }
            }
        }
        static void DirCheck(int Index, string data)
        {
            string[] splited = data.Replace("<19>", "").Split(';');

            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > 10) || (Convert.ToInt32(splited[0]) < 0)) { return; }
            
            byte Dir = Convert.ToByte(splited[0]);

            switch (Dir)
            {
                case 8:
                    PStruct.character[Index, PStruct.player[Index].SelectedChar].Dir = Globals.DirUp;
                    break;
                case 2:
                    PStruct.character[Index, PStruct.player[Index].SelectedChar].Dir = Globals.DirDown;
                    break;
                case 4:
                    PStruct.character[Index, PStruct.player[Index].SelectedChar].Dir = Globals.DirLeft;
                    break;
                case 6:
                    PStruct.character[Index, PStruct.player[Index].SelectedChar].Dir = Globals.DirRight;
                    break;
                default:
                    WinsockAsync.Log(String.Format("Direção nula"));
                    break;
            }

            SendData.Send_PlayerDir(Index);
            SendData.Send_PlayerDir(Index, 1);
        }
        static void ReceivedOutCollector(int index)
        {
            int mapnum = PStruct.character[index, PStruct.player[index].SelectedChar].Map;
            int guildnum = PStruct.character[index, PStruct.player[index].SelectedChar].Guild;

            if (guildnum <= 0) { return; }

            if (MStruct.map[mapnum].guildnum <= 0)
            {
                SendData.Send_MsgToPlayer(index, "Este mapa não possúi um coletor para ser recolhido.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            if ((MStruct.map[mapnum].guildmember != "") && (MStruct.map[mapnum].guildmember != PStruct.character[index, PStruct.player[index].SelectedChar].CharacterName))
            {
                SendData.Send_MsgToPlayer(index, "Você não é o dono deste coletor.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }


            //Entregar o dinheiro ao jogador
            PStruct.character[index, PStruct.player[index].SelectedChar].Gold += MStruct.map[mapnum].guildgold;

            //Retirar guilda do mapa
            MStruct.map[mapnum].guildnum = 0;
            MStruct.map[mapnum].guildmember = "";
            MStruct.map[mapnum].guildgold = 0;

            //Retirar o coletor
            for (int i2 = 0; i2 <= MStruct.tempmap[mapnum].NpcCount; i2++)
            {
                if (NStruct.npc[mapnum, i2].Name == "Coletor de Guilda")
                {
                    //Avisar os clientes para apagarem o coletor do mapa
                    SendData.Send_NpcLeft(mapnum, i2);

                    //Limpar dados sobre o coletor
                    NStruct.ClearTempNpc(mapnum, i2);
                    break;
                }
            }

            //Atualizaro número de npc's no mapa
            MStruct.tempmap[mapnum].NpcCount = MStruct.GetMapNpcCount(mapnum);

            //Enviar dados para todos.
            SendData.Send_MapGuildToMap(mapnum);
            SendData.Send_MsgToGuild(guildnum, "O coletor de " + MStruct.map[mapnum].name + " foi recolhido.", Globals.ColorYellow, Globals.Msg_Type_Server);
        }
        static void ReceivedCollector(int index)
        {

            int guildnum = PStruct.character[index, PStruct.player[index].SelectedChar].Guild;

            if (guildnum <= 0)
            {
                SendData.Send_MsgToPlayer(index, "Recurso disponível apenas para membros de guildas.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            int guildlevel = GStruct.guild[guildnum].level;
            int price = guildlevel * 1000;

            if (PStruct.character[index, PStruct.player[index].SelectedChar].Gold < price)
            {
                SendData.Send_MsgToPlayer(index, "Você não tem ouro o suficiente para colocar um coletor.", Globals.ColorRed, Globals.Msg_Type_Server);
               // return;
            }

            int mapnum =  PStruct.character[index, PStruct.player[index].SelectedChar].Map;

            if (MStruct.map[mapnum].guildnum > 0)
            {
                SendData.Send_MsgToPlayer(index, "Atualmente já existe um coletor de outra guild neste mapa.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            
            int i2 = MStruct.GetMapNpcSlot(mapnum);
            if (i2 <= 1)
            {
                SendData.Send_MsgToPlayer(index, "Este mapa não está disponível para coletores.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            //Definir a nova guilda do mapa
            MStruct.map[mapnum].guildnum = guildnum;
            MStruct.map[mapnum].guildmember = PStruct.character[index, PStruct.player[index].SelectedChar].CharacterName;

            //Criar o coletor
            NStruct.npc[mapnum, i2].Name = "Coletor de Guilda";
            NStruct.npc[mapnum, i2].Map = mapnum;
            NStruct.npc[mapnum, i2].X = NStruct.npc[mapnum, 1].X;
            NStruct.npc[mapnum, i2].Y = NStruct.npc[mapnum, 1].Y;
            NStruct.npc[mapnum, i2].Vitality = (GStruct.guild[guildnum].level * 1000) + 1000;
            NStruct.npc[mapnum, i2].Spirit = (GStruct.guild[guildnum].level * 200) + 200;
            NStruct.tempnpc[mapnum, i2].Target = 0;
            NStruct.tempnpc[mapnum, i2].X = NStruct.npc[mapnum, i2].X;
            NStruct.tempnpc[mapnum, i2].Y = NStruct.npc[mapnum, i2].Y;
            NStruct.tempnpc[mapnum, i2].curTargetX = NStruct.npc[mapnum, i2].X;
            NStruct.tempnpc[mapnum, i2].curTargetY = NStruct.npc[mapnum, i2].Y;
            NStruct.tempnpc[mapnum, i2].Vitality = NStruct.npc[mapnum, i2].Vitality;
            NStruct.npc[mapnum, i2].Attack =  (GStruct.guild[guildnum].level * 34) + 34;
            NStruct.npc[mapnum, i2].Defense = (GStruct.guild[guildnum].level * 22) + 22; ;
            NStruct.npc[mapnum, i2].Agility = (GStruct.guild[guildnum].level * 4) + 4; ;
            NStruct.npc[mapnum, i2].MagicDefense = (GStruct.guild[guildnum].level * 26) + 26;
            NStruct.npc[mapnum, i2].MagicAttack = (GStruct.guild[guildnum].level * 48) + 48;
            NStruct.npc[mapnum, i2].Luck = (GStruct.guild[guildnum].level * 4) + 4;
            NStruct.npc[mapnum, i2].Sprite = "$sprite (84)";
            NStruct.npc[mapnum, i2].Index = 0;
            NStruct.npc[mapnum, i2].Type = 1;
            NStruct.npc[mapnum, i2].Range = 1;
            NStruct.npc[mapnum, i2].Animation = 2;
            NStruct.npc[mapnum, i2].SpeedMove = 256;
            NStruct.tempnpc[mapnum, i2].movespeed = NStruct.npc[mapnum, i2].SpeedMove / 64;
            NStruct.npc[mapnum, i2].Respawn = 0;
            NStruct.npc[mapnum, i2].Exp = 0;
            NStruct.npc[mapnum, i2].Gold = 0;
            NStruct.tempnpc[mapnum, i2].guildnum = guildnum;
            NStruct.tempnpc[mapnum, i2].prev_move = new NStruct.Point[7];

            //Atualizaro número de npc's no mapa
            MStruct.tempmap[mapnum].NpcCount = MStruct.GetMapNpcCount(mapnum);
            
            //Enviar dados para todos.
            SendData.Send_MapGuildToMap(mapnum);
            SendData.Send_NpcToMap(mapnum, i2);
            SendData.Send_MsgToGuild(guildnum, "Um coletor foi colocado em " + MStruct.map[mapnum].name + ".", Globals.ColorYellow, Globals.Msg_Type_Server);
        }
        static void PickItemCheck(int Index)
        {
            int map = Convert.ToInt32(PStruct.character[Index, PStruct.player[Index].SelectedChar].Map);
            int playerx = Convert.ToInt32(PStruct.character[Index, PStruct.player[Index].SelectedChar].X);
            int playery = Convert.ToInt32(PStruct.character[Index, PStruct.player[Index].SelectedChar].Y);

            for (int i = 0; i <= MStruct.GetMapItemMaxIndex(map); i++)
            {
                if ((MStruct.mapitem[map, i].X == playerx) && (MStruct.mapitem[map, i].Y == playery))
                {
                    if (PStruct.GiveItem(Index, MStruct.mapitem[map, i].ItemType, MStruct.mapitem[map, i].ItemNum, MStruct.mapitem[map, i].Value, MStruct.mapitem[map, i].Refin, MStruct.mapitem[map, i].Exp) == true)
                    {
                        if (MStruct.mapitem[map, i].ItemType == 1)
                        {
                            SendData.Send_ActionMsg(Index, IStruct.item[MStruct.mapitem[map, i].ItemNum].name + " x" + MStruct.mapitem[map, i].Value, Globals.ColorWhite, playerx, playery, 1, 0, map);
                        }
                        if (MStruct.mapitem[map, i].ItemType == 2)
                        {
                            SendData.Send_ActionMsg(Index, WStruct.weapon[MStruct.mapitem[map, i].ItemNum].name + " x" + MStruct.mapitem[map, i].Value, Globals.ColorWhite, playerx, playery, 1, 0, map);
                        }
                        if (MStruct.mapitem[map, i].ItemType == 3)
                        {
                            SendData.Send_ActionMsg(Index, AStruct.armor[MStruct.mapitem[map, i].ItemNum].name + " x" + MStruct.mapitem[map, i].Value, Globals.ColorWhite, playerx, playery, 1, 0, map);
                        }
                        SendData.Send_InvSlots(Index, PStruct.player[Index].SelectedChar);
                        MStruct.mapitem[map, i].X = 0;
                        MStruct.mapitem[map, i].Y = 0;
                        MStruct.mapitem[map, i].ItemNum = 0;
                        MStruct.mapitem[map, i].Value = 0;
                        MStruct.mapitem[map, i].Refin = 0;
                        MStruct.mapitem[map, i].Exp = 0;
                        MStruct.mapitem[map, i].Timer = 0;
                        SendData.Send_ClearMapItem(map, i);
                        break;
                    }
                }
            }
        }
        static void DropItemCheck(int Index, string data)
        {
            string[] splited = data.Replace("<21>", "").Split(';');

            if (splited.Length != 2) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if (!IsNumeric(splited[1])) { return; }
            if ((Convert.ToInt32(splited[0]) > Globals.MaxInvSlot - 1) || (Convert.ToInt32(splited[1]) > 999)) { return; }
            if ((Convert.ToInt32(splited[0]) < 0) || (Convert.ToInt32(splited[1]) < 0)) { return; }

            int Slot = Convert.ToInt32(splited[0]);
            int Value = Convert.ToInt32(splited[1]);

            int Map = Convert.ToInt32(PStruct.character[Index, PStruct.player[Index].SelectedChar].Map);
            int playerx = Convert.ToInt32(PStruct.character[Index, PStruct.player[Index].SelectedChar].X);
            int playery = Convert.ToInt32(PStruct.character[Index, PStruct.player[Index].SelectedChar].Y);
           
            string item = PStruct.invslot[Index, Convert.ToInt32(Slot)].item;
            string[] splititem = item.Split(',');

            int itemexp = Convert.ToInt32(splititem[4]);
            int itemrefin = Convert.ToInt32(splititem[3]);
            int itemvalue = Convert.ToInt32(splititem[2]);
            int itemnum = Convert.ToInt32(splititem[1]);
            int itemtype = Convert.ToInt32(splititem[0]);

            if (Value > itemvalue) { SendData.Send_MsgToPlayer(Index, "Você não tem a quantia de itens que tentou dropar.", Globals.ColorRed, Globals.Msg_Type_Server); return; }
            if (MStruct.GetNullMapItem(Map) == 0) { SendData.Send_MsgToPlayer(Index, "O mapa já tem muitos itens jogados no chão...", Globals.ColorRed, Globals.Msg_Type_Server); return; }

            if (itemvalue - Value > 0)
            {
                //Há item sobrando
                PStruct.invslot[Index, Convert.ToInt32(Slot)].item = itemtype.ToString() + "," + itemnum.ToString() + "," + (itemvalue - Value).ToString() + "," + itemrefin.ToString() + "," + itemexp.ToString();
            }
            else
            {
                PStruct.invslot[Index, Convert.ToInt32(Slot)].item = Globals.NullItem; //Não há item sobrando
            }
            //Dropar item no mapa
            int NullMapItem = MStruct.GetNullMapItem(Map);
            MStruct.mapitem[Map, NullMapItem].Value = Value;
            MStruct.mapitem[Map, NullMapItem].ItemType = itemtype;
            MStruct.mapitem[Map, NullMapItem].X = playerx;
            MStruct.mapitem[Map, NullMapItem].Y = playery;
            MStruct.mapitem[Map, NullMapItem].ItemNum = itemnum;
            MStruct.mapitem[Map, NullMapItem].Refin = itemrefin;
            MStruct.mapitem[Map, NullMapItem].Exp = itemexp;
            MStruct.mapitem[Map, NullMapItem].Timer = Loops.TickCount.ElapsedMilliseconds + 600000;
            SendData.Send_MapItem(Map, NullMapItem);

            //Mandar inventário do jogador
            SendData.Send_InvSlots(Index, PStruct.player[Index].SelectedChar);
            
        }
        static void ItemCheck(int index, string data)
        {
            string[] newItems = data.Replace("<22>", "").Split(';');

            int items_count = Convert.ToInt32(newItems[0]);

            int reader = 1;

            for (int i = 1; i <= items_count ; i++)
            {
                IStruct.item[i].name= newItems[reader];
                reader += 1;
                IStruct.item[i].price = Convert.ToInt32(newItems[reader]);
                reader += 1;
                IStruct.item[i].consumable = newItems[reader];
                reader += 1;
                IStruct.item[i].success_rate = Convert.ToInt32(newItems[reader]);
                reader += 1;
                IStruct.item[i].animation_id = Convert.ToInt32(newItems[reader]);
                reader += 1;
                IStruct.item[i].note = newItems[reader];
                reader += 1;
                IStruct.item[i].speed = Convert.ToInt32(newItems[reader]);
                reader += 1;
                IStruct.item[i].repeats = Convert.ToInt32(newItems[reader]);
                reader += 1;
                IStruct.item[i].tp_gain = Convert.ToInt32(newItems[reader]);
                reader += 1;
                IStruct.item[i].hit_type = Convert.ToInt32(newItems[reader]);
                reader += 1;
                IStruct.item[i].damage_type = Convert.ToInt32(newItems[reader]);
                reader += 1;
                IStruct.item[i].damage_formula = newItems[reader];
                reader += 1;
                IStruct.item[i].damage_element = Convert.ToInt32(newItems[reader]);
                reader += 1;
                IStruct.item[i].damage_variance = Convert.ToInt32(newItems[reader]);
                reader += 1;
                IStruct.item[i].damage_critical = newItems[reader];
                reader += 1;

                IStruct.item[i].effects_count = Convert.ToInt32(newItems[reader]);
                reader += 1;

                for (int i2 = 0; i2 <= IStruct.item[i].effects_count; i2++)
                {
                    IStruct.itemeffect[i, i2].code = Convert.ToInt32(newItems[reader]);
                    reader += 1;
                    IStruct.itemeffect[i, i2].data_id = Convert.ToInt32(newItems[reader]);
                    reader += 1;
                    IStruct.itemeffect[i, i2].value1 = Convert.ToDouble(newItems[reader]);
                    reader += 1;
                    IStruct.itemeffect[i, i2].value2 = Convert.ToDouble(newItems[reader]);
                    reader += 1;
                }
                Database.SaveItem(i.ToString());
            }
            Console.WriteLine("Items foram salvos com sucesso.");
        }
        static void WeaponCheck(int index, string data)
        {
            string[] newWeapons = data.Replace("<23>", "").Split(';');

            int weapons_count = Convert.ToInt32(newWeapons[0]);

            int reader = 1;

            for (int i = 1; i <= weapons_count; i++)
            {
                WStruct.weapon[i].name = newWeapons[reader];
                reader += 1;
                WStruct.weapon[i].price = Convert.ToInt32(newWeapons[reader]);
                reader += 1;
                WStruct.weapon[i].etype_id = Convert.ToInt32(newWeapons[reader]);
                reader += 1;
                WStruct.weapon[i].wtype_id = Convert.ToInt32(newWeapons[reader]);
                reader += 1;
                WStruct.weapon[i].animation_id = Convert.ToInt32(newWeapons[reader]);
                reader += 1;
                WStruct.weapon[i].params_size = Convert.ToInt32(newWeapons[reader]);
                reader += 1;

                for (int i2 = 0; i2 <= WStruct.weapon[i].params_size; i2++)
                {
                    WStruct.weaponparams[i, i2].value = Convert.ToInt32(newWeapons[reader]);
                    reader += 1;
                }

                WStruct.weapon[i].features_size = Convert.ToInt32(newWeapons[reader]);
                reader += 1;

                for (int i2 = 0; i2 <= WStruct.weapon[i].features_size; i2++)
                {
                    WStruct.weaponfeatures[i, i2].code = Convert.ToInt32(newWeapons[reader]);
                    reader += 1;
                    WStruct.weaponfeatures[i, i2].data_id = Convert.ToInt32(newWeapons[reader]);
                    reader += 1;
                    WStruct.weaponfeatures[i, i2].value = Convert.ToDouble(newWeapons[reader]);
                    reader += 1;
                }
                Database.SaveWeapon(i.ToString());
            }
            Console.WriteLine("Armas foram salvas com sucesso.");
        }
        static void ArmorCheck(int index, string data)
        {
            string[] newArmors = data.Replace("<24>", "").Split(';');

            int armors_count = Convert.ToInt32(newArmors[0]);

            int reader = 1;

            for (int i = 1; i <= armors_count; i++)
            {
                AStruct.armor[i].name = newArmors[reader];
                reader += 1;
                AStruct.armor[i].price = Convert.ToInt32(newArmors[reader]);
                reader += 1;
                AStruct.armor[i].etype_id = Convert.ToInt32(newArmors[reader]);
                reader += 1;
                AStruct.armor[i].atype_id = Convert.ToInt32(newArmors[reader]);
                reader += 1;
                AStruct.armor[i].params_size = Convert.ToInt32(newArmors[reader]);
                reader += 1;
                Console.WriteLine(AStruct.armor[i].params_size); 

                for (int i2 = 0; i2 <= AStruct.armor[i].params_size; i2++)
                {
                    AStruct.armorparams[i, i2].value = Convert.ToInt32(newArmors[reader]);
                    reader += 1;
                }

                AStruct.armor[i].features_size = Convert.ToInt32(newArmors[reader]);
                reader += 1;

                Console.WriteLine(AStruct.armor[i].features_size);

                for (int i2 = 0; i2 <= AStruct.armor[i].features_size; i2++)
                {
                    AStruct.armorfeatures[i, i2].code = Convert.ToInt32(newArmors[reader]);
                    reader += 1;
                    AStruct.armorfeatures[i, i2].data_id = Convert.ToInt32(newArmors[reader]);
                    reader += 1;
                    AStruct.armorfeatures[i, i2].value = Convert.ToDouble(newArmors[reader]);
                    reader += 1;
                }
                Database.SaveArmor(i.ToString());
            }
            Console.WriteLine("Armaduras foram salvas com sucesso.");
        }
        static void SkillCheck(int index, string data)
        {
            string[] newSkills = data.Replace("<25>", "").Split(';');
            int skills_count = Convert.ToInt32(newSkills[0]);

            int reader = 1;

            for (int i = 1; i <= skills_count; i++)
            {
                SStruct.skill[i].scope = Convert.ToInt32(newSkills[reader]);
                reader += 1;
                SStruct.skill[i].stype_id = Convert.ToInt32(newSkills[reader]);
                reader += 1;
                SStruct.skill[i].mp_cost = Convert.ToInt32(newSkills[reader]);
                reader += 1;
                SStruct.skill[i].tp_cost = Convert.ToInt32(newSkills[reader]);
                reader += 1;
                SStruct.skill[i].message1 = newSkills[reader];
                reader += 1;
                SStruct.skill[i].message2 = newSkills[reader];
                reader += 1;
                SStruct.skill[i].required_wtype_id1 = Convert.ToInt32(newSkills[reader]);
                reader += 1;
                SStruct.skill[i].required_wtype_id2 = Convert.ToInt32(newSkills[reader]);
                reader += 1;
                SStruct.skill[i].occasion = Convert.ToInt32(newSkills[reader]);
                reader += 1;
                SStruct.skill[i].success_rate = Convert.ToInt32(newSkills[reader]);
                reader += 1;
                SStruct.skill[i].repeats = Convert.ToInt32(newSkills[reader]);
                reader += 1;
                SStruct.skill[i].tp_gain = Convert.ToInt32(newSkills[reader]);
                reader += 1;
                SStruct.skill[i].hit_type = Convert.ToInt32(newSkills[reader]);
                reader += 1;
                SStruct.skill[i].animation_id = Convert.ToInt32(newSkills[reader]);
                reader += 1;
                SStruct.skill[i].speed = Convert.ToInt32(newSkills[reader]);
                reader += 1;
                SStruct.skill[i].note = newSkills[reader];
                reader += 1;
                SStruct.skill[i].damage_type = Convert.ToInt32(newSkills[reader]);
                reader += 1;
                SStruct.skill[i].damage_element = Convert.ToInt32(newSkills[reader]);
                reader += 1;
                SStruct.skill[i].damage_formula = newSkills[reader];
                reader += 1;
                SStruct.skill[i].damage_variance = Convert.ToInt32(newSkills[reader]);
                reader += 1;
                SStruct.skill[i].damage_critical = newSkills[reader];
                reader += 1;

                SStruct.skill[i].effects_count = Convert.ToInt32(newSkills[reader]);
                reader += 1;

                for (int i2 = 0; i2 <= SStruct.skill[i].effects_count; i2++)
                {
                    SStruct.skilleffect[i, i2].code = Convert.ToInt32(newSkills[reader]);
                    reader += 1;
                    SStruct.skilleffect[i, i2].data_id = Convert.ToInt32(newSkills[reader]);
                    reader += 1;
                    SStruct.skilleffect[i, i2].value1 = Convert.ToDouble(newSkills[reader]);
                    reader += 1;
                    SStruct.skilleffect[i, i2].value2 = Convert.ToDouble(newSkills[reader]);
                    reader += 1;
                }
                Database.SaveSkill(i.ToString());
        }
            Console.WriteLine("Skills foram salvas com sucesso.");
        }
        static void EnemyCheck(int index, string data)
        {
            string[] newEnemies = data.Replace("<28>", "").Split(';');

            int start = Convert.ToInt32(newEnemies[0]);
            int startend = Convert.ToInt32(newEnemies[1]);

            int reader = 2;

            for (int i = start; i <= startend; i++)
            {
                EStruct.enemy[i].battler_name = newEnemies[reader];
                reader += 1;
                EStruct.enemy[i].battler_hue = Convert.ToInt32(newEnemies[reader]);
                reader += 1;
                EStruct.enemy[i].exp = Convert.ToInt32(newEnemies[reader]);
                reader += 1;
                EStruct.enemy[i].gold = Convert.ToInt32(newEnemies[reader]);
                reader += 1;
                EStruct.enemy[i].note = newEnemies[reader];
                reader += 1;

                EStruct.enemy[i].params_size = Convert.ToInt32(newEnemies[reader]);
                reader += 1;

                for (int i2 = 0; i2 <= EStruct.enemy[i].params_size; i2++)
                {
                    EStruct.enemyparams[i, i2].value = Convert.ToInt32(newEnemies[reader]);
                    reader += 1;
                }

                EStruct.enemy[i].drops_size = Convert.ToInt32(newEnemies[reader]);
                reader += 1;

                for (int i2 = 0; i2 <= EStruct.enemy[i].drops_size; i2++)
                {
                    EStruct.enemydrops[i, i2].kind = Convert.ToInt32(newEnemies[reader]);
                    reader += 1;
                    EStruct.enemydrops[i, i2].data_id = Convert.ToInt32(newEnemies[reader]);
                    reader += 1;
                    EStruct.enemydrops[i, i2].denominator = Convert.ToInt32(newEnemies[reader]);
                    reader += 1;
                }

                Database.SaveEnemy(i.ToString());
            }

            if (start == 951)
            {
                Console.WriteLine("Inimigos foram salvos com sucesso.");
            }
        }
        //fim
        static void HotkeyCheck(int index, string data)
        {
            string[] splited = data.Replace("<26>", "").Split(';');

            if (splited.Length != 3) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if (!IsNumeric(splited[1])) { return; }
            if (!IsNumeric(splited[2])) { return; }
            if ((Convert.ToInt32(splited[0]) > Globals.MaxInvSlot - 1) || (Convert.ToInt32(splited[1]) > Globals.MaxHotkeys - 1) || (Convert.ToInt32(splited[2]) > 2)) { return; }
            if ((Convert.ToInt32(splited[0]) < 0) || (Convert.ToInt32(splited[1]) < 0) || (Convert.ToInt32(splited[2]) < 0)) { return; }

            int slot = Convert.ToInt32(splited[0]);
            int hotkeyslot = Convert.ToInt32(splited[1]);
            byte type = Convert.ToByte(splited[2]);

            if (type == 1)
            {
                if (slot > Globals.MaxPlayer_Skills - 1) { return; }
                if (PStruct.skill[index, slot].num > 0)
                {
                    PStruct.hotkey[index, hotkeyslot].num = slot;
                    PStruct.hotkey[index, hotkeyslot].type = type;
                    SendData.Send_PlayerHotkeys(index);
                }
            }

            else if (type == 2)
            {
                if ((Convert.ToInt32(PStruct.invslot[index, slot].item.Split(',')[0]) <= 1) && (Convert.ToInt32(PStruct.invslot[index, slot].item.Split(',')[1]) > 0))
                {
                    PStruct.hotkey[index, hotkeyslot].num = Convert.ToInt32(PStruct.invslot[index, slot].item.Split(',')[1]);
                    PStruct.hotkey[index, hotkeyslot].type = type;
                    SendData.Send_PlayerHotkeys(index);
                }  
            }

            else if (type == 0)
            {
                PStruct.hotkey[index, hotkeyslot].num = 0;
                PStruct.hotkey[index, hotkeyslot].type = type;
                SendData.Send_PlayerHotkeys(index);
            }
            
            


        }
        static void TargetCheck(int index, string data)
        {
            string[] splited = data.Replace("<27>", "").Split(';');

            if (splited.Length != 2) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if (!IsNumeric(splited[1])) { return; }
            if ((Convert.ToInt32(splited[0]) > 2) || (Convert.ToInt32(splited[1]) > 255)) { return; }
            if ((Convert.ToInt32(splited[0]) < 0) || (Convert.ToInt32(splited[1]) < 0)) { return; }

            byte targettype = Convert.ToByte(splited[0]);
            int target = Convert.ToInt32(splited[1]);

            if ((targettype > 2) || (targettype < 0)) { return; }

            if (targettype == 1)
            {
                //Verificar se o jogador não se desconectou no processo
                int clientindex = UserConnection.GetIndex(target);
                if ((clientindex < 0) || (clientindex >= WinsockAsync.Clients.Count())) { return; }
                if ((clientindex < 0) || (clientindex >= WinsockAsync.Clients.Count())) { return; }
                if (!WinsockAsync.Clients[clientindex].IsConnected) { return; }
                if ((target > Globals.Player_HighIndex) || (target < 0)) { return; }
            }

            if (targettype == 2)
            {
                if ((target > MStruct.tempmap[PStruct.character[index, PStruct.player[index].SelectedChar].Map].NpcCount) || (target < 0)) { return; }
            }

            if ((PStruct.tempplayer[index].targettype == targettype) && (PStruct.tempplayer[index].target == target)) { return; }

            PStruct.tempplayer[index].targettype = targettype;
            PStruct.tempplayer[index].target = target;

        }
        static void ReceivedSkill(int index, string data)
        {
            string[] splited = data.Replace("<29>", "").Split(';');

            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > Globals.MaxPlayer_Skills - 1)) { return; }
            if ((Convert.ToInt32(splited[0]) < 0)) { return; }

            int intslot = Convert.ToInt32(splited[0]);

            if ((intslot <= 0) && (intslot >= 6)) { return; }
            if ((PStruct.skill[index, PStruct.hotkey[index, intslot].num].num <= 0)) { return; }

            if (PStruct.hotkey[index, intslot].type != Globals.Hotkey_Type_Skill) { return; }
            if ((PStruct.skill[index, PStruct.hotkey[index, intslot].num].cooldown > Loops.TickCount.ElapsedMilliseconds)) { return; }
            if (PStruct.skill[index, PStruct.hotkey[index, intslot].num].level <= 0) { return; }
            if (SStruct.skill[PStruct.skill[index, PStruct.hotkey[index, intslot].num].num].mp_cost * PStruct.skill[index, PStruct.hotkey[index, intslot].num].level > PStruct.tempplayer[index].Spirit)
            {
                SendData.Send_MsgToPlayer(index, "Você não possúi energia para executar a magia.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            //SendData.Send_ActionMsg(index, SStruct.skill[PStruct.tempplayer[index].preparingskill].
            PStruct.tempplayer[index].preparingskillslot = intslot;
            PStruct.tempplayer[index].preparingskill = PStruct.skill[index, PStruct.hotkey[index, intslot].num].num;
            PStruct.tempplayer[index].skilltimer = Loops.TickCount.ElapsedMilliseconds + (SStruct.skill[PStruct.tempplayer[index].preparingskill].speed * 100);
            PStruct.tempplayer[index].movespeed -= 0.2;
            //CORRECT SKILL INCOMPT
            SendData.Send_MoveSpeed(1, index);
            SendData.Send_Animation(PStruct.character[index, PStruct.player[index].SelectedChar].Map, 1, index, 81);
            //PStruct.tempplayer[index].targettype;
            //PStruct.tempplayer[index].target;
           // Console.WriteLine("Novo alvo");

        }
        static void ReceivedAtr(int index, string data)
        {

            string[] splited = data.Replace("<30>", "").Split(';');
            
            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > Globals.MaxPlayer_Skills - 1)) { return; }
            if ((Convert.ToInt32(splited[0]) < 0)) { return; }

            int atr = Convert.ToInt32(splited[0]);

            if (PStruct.character[index, PStruct.player[index].SelectedChar].Points <= 0) { return; }

            PStruct.character[index, PStruct.player[index].SelectedChar].Points -= 1;

            switch (splited[0])
            {
                case "1":
                    PStruct.character[index, PStruct.player[index].SelectedChar].Fire += 1;
                    break;
                case "2":
                    PStruct.character[index, PStruct.player[index].SelectedChar].Earth += 1;
                    break;
                case "3":
                    PStruct.character[index, PStruct.player[index].SelectedChar].Water += 1;
                    break;
                case "4":
                    PStruct.character[index, PStruct.player[index].SelectedChar].Wind += 1;
                    break;
                case "5":
                    PStruct.character[index, PStruct.player[index].SelectedChar].Dark += 1;
                    break;
                case "6":
                    PStruct.character[index, PStruct.player[index].SelectedChar].Light += 1;
                    break;
                default:
                    WinsockAsync.Log(String.Format("Direção nula"));
                    break;
            }
            SendData.Send_PlayerAtrTo(index);
        }
        static void ReceivedUseSkillPoints(int index, string data)
        {

            string[] splited = data.Replace("<31>", "").Split(';');

            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > Globals.MaxPlayer_Skills - 1)) { return; }
            if ((Convert.ToInt32(splited[0]) < 0)) { return; }

            int skill = Convert.ToInt32(splited[0]);

            if (PStruct.character[index, PStruct.player[index].SelectedChar].SkillPoints <= 0) { return; }
            
            int lv_ok = 0;
            if (skill == 2) { lv_ok = 5; } 
            if (skill == 3) { lv_ok = 10; } 
            if (skill == 4) { lv_ok = 20; } 
            if (skill == 5) { lv_ok = 40; } 
            if (skill == 6) { lv_ok = 80; } 
            if (skill == 7) { lv_ok = 80; } 
            if (skill == 8) { lv_ok = 80; } 


            if (skill <= 4)
            {
                if (PStruct.character[index, PStruct.player[index].SelectedChar].Level < lv_ok)
                {
                    return;
                }
            }

            int max_level = SStruct.skill[PStruct.skill[index, skill].num].success_rate;

            if (PStruct.skill[index, skill].level >= max_level)
            {
                SendData.Send_MsgToPlayer(index, "Essa magia não pode ser aprimorada.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            PStruct.character[index, PStruct.player[index].SelectedChar].SkillPoints -= 1;
            PStruct.skill[index, skill].level += 1;

            SendData.Send_PlayerSkills(index);
            SendData.Send_PlayerSkillPoints(index);
        }
        static void ReceivedParty(int index)
        {
            //Possíveis tentativas de hacker
            if ((PStruct.tempplayer[index].targettype != 1) || (PStruct.tempplayer[index].target <= 0) || (PStruct.tempplayer[index].InviteTimer > Loops.TickCount.ElapsedMilliseconds)) { SendData.Send_MsgToPlayer(index, "O jogador não pode receber o convite no momento.", Globals.ColorRed, Globals.Msg_Type_Server); return; }

            //Não pode convidar ele mesmo
            if (PStruct.tempplayer[index].target == index) 
            {
                SendData.Send_MsgToPlayer(index, "Você não pode convidar você mesmo, está louco?", Globals.ColorRed, Globals.Msg_Type_Server);
                return; 
            }

            //O alvo é o index
            int target = PStruct.tempplayer[index].target;
            int clientindex = UserConnection.GetIndex(target);


            //Verifica se ele não se desconectou no processo
            if ((clientindex < 0) || (clientindex >= WinsockAsync.Clients.Count()))
            {
                SendData.Send_MsgToPlayer(index, "O jogador não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }
            if (!WinsockAsync.Clients[clientindex].IsConnected)
            {
                SendData.Send_MsgToPlayer(index, "O jogador não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            //Veririficar se há não tem um grupo
            if (PStruct.tempplayer[target].Party > 0) 
            {
                SendData.Send_MsgToPlayer(index, "O jogador já está em um grupo.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            //Verifica se ele pode ser convidado
            if (PStruct.IsBusy(target)) {
                SendData.Send_MsgToPlayer(index, "O jogador não pode ser convidado no momento", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            //Criar a váriaveis gerais
            PStruct.tempplayer[index].Inviting = PStruct.tempplayer[index].target;
            PStruct.tempplayer[target].Invited = index;
            PStruct.tempplayer[index].InviteTimer = Loops.TickCount.ElapsedMilliseconds + 10000;
            PStruct.tempplayer[target].InviteTimer = Loops.TickCount.ElapsedMilliseconds + 10000;

            //Envia o convite
            SendData.Send_PartyRequest(index, target);
        }
        static void ReceivedPartyResponse(int index, string data)
        {

            string[] splited = data.Replace("<33>", "").Split(';');

            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > 2)) { return; }
            if ((Convert.ToInt32(splited[0]) < 0)) { return; }

            int response = Convert.ToInt32(splited[0]);

            int partynum = 0;

            //Verificar se o jogador não se desconectou no processo
            if ((UserConnection.GetIndex(PStruct.tempplayer[index].Invited) < 0) || (UserConnection.GetIndex(PStruct.tempplayer[index].Invited) >= WinsockAsync.Clients.Count()))
            {
                SendData.Send_MsgToPlayer(index, "O jogador que lhe convidou não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }
            if (!WinsockAsync.Clients[(UserConnection.GetIndex(PStruct.tempplayer[index].Invited))].IsConnected)
            {
                SendData.Send_MsgToPlayer(index, "O jogador que lhe convidou não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            if (response == 0)
            {
                //Criação do grupo
                if (PStruct.tempplayer[PStruct.tempplayer[index].Invited].Party == 0)
                {
                    //Checa um grupo livre
                    partynum = PStruct.GetPartyFree();

                    //Definindo posições
                    PStruct.party[partynum].leader = PStruct.tempplayer[index].Invited;
                    PStruct.partymembers[partynum, 1].index = PStruct.tempplayer[index].Invited;
                    PStruct.partymembers[partynum, 2].index = index;
                    PStruct.party[partynum].active = true;
                    PStruct.tempplayer[index].Party = partynum;
                    PStruct.tempplayer[PStruct.tempplayer[index].Invited].Party = partynum;
                    
                    //Envia o grupo atualizado
                    SendData.Send_PartyDataToParty(partynum);
                    SendData.Send_PlayerExtraSpiritToParty(partynum, index);
                    SendData.Send_PlayerExtraVitalityToParty(partynum, index);
                    SendData.Send_PlayerExtraSpiritToParty(partynum, PStruct.tempplayer[index].Invited);
                    SendData.Send_PlayerExtraVitalityToParty(partynum, PStruct.tempplayer[index].Invited);
                   
                    //Limpa os valores gerais
                    PStruct.tempplayer[index].InviteTimer = 0;
                    PStruct.tempplayer[PStruct.tempplayer[index].Invited].InviteTimer = 0;
                    PStruct.tempplayer[PStruct.tempplayer[index].Invited].Inviting = 0;
                    PStruct.tempplayer[index].Invited = 0;
                    
                    //Mensagem de que o grupo foi criado
                    SendData.Send_MsgToParty(partynum, "Grupo criado.", Globals.ColorGreen, Globals.Msg_Type_Server);
                }
                else
                {
                    //Apenas adiciona o jogador no grupo
                    for (int i = 1; i < Globals.MaxPartyMembers; i++)
                    {
                        if (PStruct.partymembers[PStruct.tempplayer[PStruct.tempplayer[index].Invited].Party, i].index == 0)
                        {
                            //Posição no grupo
                            PStruct.partymembers[PStruct.tempplayer[PStruct.tempplayer[index].Invited].Party, i].index = index;
                            PStruct.tempplayer[index].Party = PStruct.tempplayer[PStruct.tempplayer[index].Invited].Party;
                            int p_index;
                            int partymemberscount = PStruct.GetPartyMembersCount(PStruct.tempplayer[index].Party);
                            for (int p = 1; p <= partymemberscount; p++)
                            {
                                p_index = PStruct.partymembers[PStruct.tempplayer[index].Party, p].index;
                                if (PStruct.character[p_index, PStruct.player[p_index].SelectedChar].Map != PStruct.character[index, PStruct.player[index].SelectedChar].Map)
                                {
                                    SendData.Send_PlayerDataTo(p_index, index, PStruct.player[index].Username, PStruct.player[index].SelectedChar);
                                    SendData.Send_PlayerDataTo(index, p_index, PStruct.player[p_index].Username, PStruct.player[p_index].SelectedChar);
                                    SendData.Send_PlayerExtraVitalityTo(p_index, index);
                                    SendData.Send_PlayerExtraSpiritTo(p_index, index);
                                    SendData.Send_PlayerExtraVitalityTo(index, p_index);
                                    SendData.Send_PlayerExtraSpiritTo(index, p_index);
                                }
                                
                            }

                            //Envia o grupo atualizado
                            SendData.Send_PartyDataToParty(PStruct.tempplayer[PStruct.tempplayer[index].Invited].Party);
                            
                            //Limpa os valores gerais
                            PStruct.tempplayer[index].InviteTimer = 0;
                            PStruct.tempplayer[PStruct.tempplayer[index].Invited].InviteTimer = 0;
                            PStruct.tempplayer[PStruct.tempplayer[index].Invited].Inviting = 0;
                            PStruct.tempplayer[index].Invited = 0;

                            //Envia mensagem ao grupo de que um novo jogador entrou
                            SendData.Send_MsgToParty(PStruct.tempplayer[index].Party, PStruct.character[index, PStruct.player[index].SelectedChar].CharacterName + " entrou no grupo.", Globals.ColorGreen, Globals.Msg_Type_Server);
                            break;
                        }
                    }
                }
            }
            else
            {
                SendData.Send_MsgToPlayer(PStruct.tempplayer[index].Invited, "O jogador recusou o convite de grupo.", Globals.ColorRed, Globals.Msg_Type_Server);
            }

            
        }
        static void ReceivedPartyKick(int index, string data)
        {
            string[] splited = data.Replace("<34>", "").Split(';');

            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > Globals.Player_HighIndex)) { return; }
            if ((Convert.ToInt32(splited[0]) < 0)) { return; }

            int kicktarget = Convert.ToInt32(splited[0]);
            
            //Será o melhor?
            PStruct.KickParty(index, kicktarget);
        }
        static void ReceivedPartyChange(int index, string data)
        {
            //string[] splited = data.Replace("<35>", "").Split(';');
        }
        static void ReceivedTrade(int index)
        {
            //Possíveis tentativas de hacker
            if ((PStruct.tempplayer[index].targettype != 1) || (PStruct.tempplayer[index].target <= 0) || (PStruct.tempplayer[index].InviteTimer > Loops.TickCount.ElapsedMilliseconds)) { SendData.Send_MsgToPlayer(index, "O jogador não pode receber o convite no momento.", Globals.ColorRed, Globals.Msg_Type_Server); return; }

            //Não pode convidar ele mesmo
            if (PStruct.tempplayer[index].target == index)
            {
                SendData.Send_MsgToPlayer(index, "Você não pode convidar você mesmo, está louco?", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            //O alvo é o index
            int target = PStruct.tempplayer[index].target;

            //Verifica se ele não se desconectou no processo
            if ((UserConnection.GetIndex(target) < 0) || (UserConnection.GetIndex(target) >= WinsockAsync.Clients.Count()))
            {
                SendData.Send_MsgToPlayer(index, "O jogador não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }
            if (!WinsockAsync.Clients[(UserConnection.GetIndex(target))].IsConnected)
            {
                SendData.Send_MsgToPlayer(index, "O jogador não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            //Veririficar se há não tem uma troca
            if (PStruct.tempplayer[target].InTrade > 0)
            {
                SendData.Send_MsgToPlayer(index, "O jogador já está em troca.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            //Verifica se ele pode ser convidado
            if (PStruct.IsBusy(target))
            {
                SendData.Send_MsgToPlayer(index, "O jogador não pode ser convidado no momento", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            //Criar a váriaveis gerais
            PStruct.tempplayer[index].Inviting = PStruct.tempplayer[index].target;
            PStruct.tempplayer[target].Invited = index;
            PStruct.tempplayer[index].InviteTimer = Loops.TickCount.ElapsedMilliseconds + 10000;
            PStruct.tempplayer[target].InviteTimer = Loops.TickCount.ElapsedMilliseconds + 10000;

            //Envia o convite
            SendData.Send_TradeRequest(index, target);
        }
        static void ReceivedGuild(int index)
        {
            //Possíveis tentativas de hacker
            if ((PStruct.tempplayer[index].targettype != 1) || (PStruct.tempplayer[index].target <= 0) || (PStruct.tempplayer[index].InviteTimer > Loops.TickCount.ElapsedMilliseconds)) { SendData.Send_MsgToPlayer(index, "O jogador não pode receber o convite no momento.", Globals.ColorRed, Globals.Msg_Type_Server); return; }

            //Não pode convidar ele mesmo
            if (PStruct.tempplayer[index].target == index)
            {
                SendData.Send_MsgToPlayer(index, "Você não pode convidar você mesmo, está louco?", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            //O alvo é o index
            int target = PStruct.tempplayer[index].target;
            int clientindex = UserConnection.GetIndex(target);

            //Verifica se ele não se desconectou no processo
            if ((clientindex < 0) || (clientindex >= WinsockAsync.Clients.Count()))
            {
                SendData.Send_MsgToPlayer(index, "O jogador não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }
            if (!WinsockAsync.Clients[clientindex].IsConnected)
            {
                SendData.Send_MsgToPlayer(index, "O jogador não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            //Veririficar se há não tem uma troca
            if (PStruct.character[index, PStruct.player[index].SelectedChar].Guild <= 0)
            {
                SendData.Send_MsgToPlayer(index, "O jogador já possúi uma Guilda.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            //Verifica se ele pode ser convidado
            if (PStruct.IsBusy(target))
            {
                SendData.Send_MsgToPlayer(index, "O jogador não pode ser convidado no momento", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            //Criar a váriaveis gerais
            PStruct.tempplayer[index].Inviting = PStruct.tempplayer[index].target;
            PStruct.tempplayer[target].Invited = index;
            PStruct.tempplayer[index].InviteTimer = Loops.TickCount.ElapsedMilliseconds + 10000;
            PStruct.tempplayer[target].InviteTimer = Loops.TickCount.ElapsedMilliseconds + 10000;

            //Envia o convite
            SendData.Send_GuildRequest(index, target);
        }
        static void ReceivedAddTradeOffer(int index, string data)
        {
            //Verifica se ele não se desconectou no processo
            if ((UserConnection.GetIndex(PStruct.tempplayer[index].InTrade) < 0) || (UserConnection.GetIndex(PStruct.tempplayer[index].InTrade) >= WinsockAsync.Clients.Count()))
            {
                SendData.Send_MsgToPlayer(index, "O jogador não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }
            if (!WinsockAsync.Clients[(UserConnection.GetIndex(PStruct.tempplayer[index].InTrade))].IsConnected)
            {
                SendData.Send_MsgToPlayer(index, "O jogador não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            string[] splited = data.Replace("<37>", "").Split(';');

            if (splited.Length != 2) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > Globals.MaxInvSlot - 1)) { return; }
            if ((Convert.ToInt32(splited[0]) < 0)) { return; }
            if ((Convert.ToInt32(splited[1]) > 999)) { return; }
            if ((Convert.ToInt32(splited[1]) < 0)) { return; }

            int slot = Convert.ToInt32(splited[0]);

            if (PStruct.invslot[index, slot].item == Globals.NullItem) { SendData.Send_MsgToPlayer(index, "Item inexistente.", Globals.ColorRed, Globals.Msg_Type_Server); return; }

            string[] splititem = PStruct.invslot[index, slot].item.Split(',');

            int value = Convert.ToInt32(splited[1]);

            int itemNum = Convert.ToInt32(splititem[1]);
            int itemType = Convert.ToInt32(splititem[0]);
            int itemValue = Convert.ToInt32(splititem[2]);
            int itemRefin = Convert.ToInt32(splititem[3]);
            int itemExp = Convert.ToInt32(splititem[4]);

            if (itemValue < value) 
            {
                SendData.Send_MsgToPlayer(index, "Você não tem a quantidade.", Globals.ColorRed, Globals.Msg_Type_Server);
                return; 
            }

            int tradeslot = PStruct.GetFreeTradeOffer(index);

            if (tradeslot == 0)
            {
                SendData.Send_MsgToPlayer(index, "Não há mais espaço.", Globals.ColorRed, Globals.Msg_Type_Server);
                return; 
            }

            if (value != itemValue)
            {
                PStruct.invslot[index, slot].item = itemType + "," + itemNum + "," + (itemValue - value) + "," + itemRefin + "," + itemExp;
                PStruct.tradeslot[index, tradeslot].item = itemType + "," + itemNum + "," + value + "," + itemRefin + "," + itemExp;
            }
            else
            {
                PStruct.invslot[index, slot].item = Globals.NullItem;
                PStruct.tradeslot[index, tradeslot].item = itemType + "," + itemNum + "," + value + "," + itemRefin + "," + itemExp;
            }

            //Envia o grupo atualizado
            SendData.Send_TradeOffers(PStruct.tempplayer[index].InTrade, PStruct.tempplayer[index].InTrade);
            SendData.Send_TradeOffers(index, PStruct.tempplayer[index].InTrade);
            SendData.Send_TradeOffers(index, index);
            SendData.Send_TradeOffers(PStruct.tempplayer[index].InTrade, index);
            SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
        }
        static void ReceivedGuildCreate(int index, string data)
        {
            string[] splited = data.Replace("<64>", "").Split(';');

            if (splited.Length != 3) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if (!IsNumeric(splited[1])) { return; }
            if ((Convert.ToInt32(splited[0]) > 999)) { return; }
            if ((Convert.ToInt32(splited[0]) < 0)) { return; }
            if ((Convert.ToInt32(splited[1]) > 360)) { return; }
            if ((Convert.ToInt32(splited[1]) < 0)) { return; }
            if ((splited[2].Length > 15)) { return; }
            if ((splited[2].Length < 3)) { return; }
            if (Database.NameIsIllegal(splited[2])) { return; }

            int shield = Convert.ToInt32(splited[0]);
            int hue = Convert.ToInt32(splited[1]);
            string name = splited[2];

            if ((shield < 17) || (shield > 31)) { return; }

            if (PStruct.character[index, PStruct.player[index].SelectedChar].Guild > 0)
            {
                SendData.Send_MsgToPlayer(index, "Você deve sair da Guilda em que está para criar uma nova.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            if (PStruct.character[index, PStruct.player[index].SelectedChar].Gold < 1000000)
            {
                //SendData.Send_MsgToPlayer(index, "Você não possúi ouro o suficiente para criar a guilda.", Globals.ColorRed, Globals.Msg_Type_Server);
                //return;
            }

            for (int i = 1; i < Globals.Max_Guilds; i++)
            {
                if (GStruct.guild[i].name == name)
                {
                    SendData.Send_MsgToPlayer(index, "Já existe uma guilda com este nome, escolha outro.", Globals.ColorRed, Globals.Msg_Type_Server);
                    return;
                }
            }

            PStruct.character[index, PStruct.player[index].SelectedChar].Gold -= 1000000;

            SendData.Send_PlayerG(index);

            int slot = GStruct.GetOpenGuildSlot();

            PStruct.character[index, PStruct.player[index].SelectedChar].Guild = slot;
            GStruct.guild[slot].name = name;
            GStruct.guild[slot].shield = shield;
            GStruct.guild[slot].hue = hue;
            GStruct.guild[slot].memberlist[1] = PStruct.character[index, PStruct.player[index].SelectedChar].CharacterName;
            GStruct.guild[slot].membersprite[1] = PStruct.character[index, PStruct.player[index].SelectedChar].Sprite;
            GStruct.guild[slot].memberhue[1] = PStruct.character[index, PStruct.player[index].SelectedChar].Hue;
            GStruct.guild[slot].membersprite_index[1] = PStruct.character[index, PStruct.player[index].SelectedChar].SpriteIndex;
            GStruct.guild[slot].leader = 1;
            GStruct.guild[slot].level = 1;
            GStruct.guild[slot].exp = 0;

            Database.SaveGuild(slot.ToString());
            SendData.Send_CompleteGuild(index);  
        }
        static void ReceivedGuildResponse(int index, string data)
        {
            string[] splited = data.Replace("<63>", "").Split(';');

            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > 1)) { return; }
            if ((Convert.ToInt32(splited[0]) < 0)) { return; }

            int response = Convert.ToInt32(splited[0]);

            //Verificar se o jogador não se desconectou no processo
            if ((UserConnection.GetIndex(PStruct.tempplayer[index].Invited) < 0) || (UserConnection.GetIndex(PStruct.tempplayer[index].Invited) >= WinsockAsync.Clients.Count()))
            {
                SendData.Send_MsgToPlayer(index, "O jogador que lhe convidou não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }
            if (!WinsockAsync.Clients[UserConnection.GetIndex(PStruct.tempplayer[index].Invited)].IsConnected)
            {
                SendData.Send_MsgToPlayer(index, "O jogador que lhe convidou não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            if (response == 0)
            {
                int guildnum = PStruct.character[PStruct.tempplayer[index].Invited, PStruct.player[PStruct.tempplayer[index].Invited].SelectedChar].Guild;
                //guildnum = 1;
                //Criação da troca
                if ((PStruct.character[index, PStruct.player[index].SelectedChar].Guild <= 0) && (guildnum > 0))
                {

                    PStruct.character[index, PStruct.player[index].SelectedChar].Guild = PStruct.character[PStruct.tempplayer[index].Invited, PStruct.player[PStruct.tempplayer[index].Invited].SelectedChar].Guild;

                    int slot = GStruct.GetOpenMemberSlot(guildnum);

                    if (slot <= 0)
                    {
                        SendData.Send_MsgToPlayer(PStruct.tempplayer[index].Invited, "Não há espaço na Guilda.", Globals.ColorRed, Globals.Msg_Type_Server);
                        SendData.Send_MsgToPlayer(index, "Não há espaço na Guilda.", Globals.ColorRed, Globals.Msg_Type_Server);
                        return;
                    }

                    GStruct.guild[guildnum].memberlist[slot] = PStruct.character[index, PStruct.player[index].SelectedChar].CharacterName;
                    GStruct.guild[guildnum].membersprite[slot] = PStruct.character[index, PStruct.player[index].SelectedChar].Sprite;
                    GStruct.guild[guildnum].memberhue[slot] = PStruct.character[index, PStruct.player[index].SelectedChar].Hue;
                    GStruct.guild[guildnum].membersprite_index[slot] = PStruct.character[index, PStruct.player[index].SelectedChar].SpriteIndex;

                    //Envia a guilda atualizada para todos online da guilda
                    SendData.Send_CompleteGuildToGuild(index);

                    //Limpa os valores gerais
                    PStruct.tempplayer[index].InviteTimer = 0;
                    PStruct.tempplayer[PStruct.tempplayer[index].Invited].InviteTimer = 0;
                    PStruct.tempplayer[PStruct.tempplayer[index].Invited].Inviting = 0;
                    PStruct.tempplayer[index].Invited = 0;

                    //Envia mensagem de congratulações
                    SendData.Send_MsgToGuild(guildnum, PStruct.character[index, PStruct.player[index].SelectedChar].CharacterName + " entrou na guilda!.", Globals.ColorYellow, Globals.Msg_Type_Server);
                    Database.SaveGuild(guildnum.ToString());
                }
                else
                {
                    //Limpa os valores gerais
                    PStruct.tempplayer[index].InviteTimer = 0;
                    PStruct.tempplayer[PStruct.tempplayer[index].Invited].InviteTimer = 0;
                    PStruct.tempplayer[PStruct.tempplayer[index].Invited].Inviting = 0;
                    PStruct.tempplayer[index].Invited = 0;

                    //Envia msg
                    SendData.Send_MsgToPlayer(PStruct.tempplayer[index].Invited, "O jogador não pode entrar na guilda no momento.", Globals.ColorRed, Globals.Msg_Type_Server);
                    SendData.Send_MsgToPlayer(index, "O jogador não pode entrar na guilda no momento.", Globals.ColorRed, Globals.Msg_Type_Server);
                }
            }
            else
            {
                //Limpa os valores gerais
                PStruct.tempplayer[index].InviteTimer = 0;
                PStruct.tempplayer[PStruct.tempplayer[index].Invited].InviteTimer = 0;
                PStruct.tempplayer[PStruct.tempplayer[index].Invited].Inviting = 0;
                PStruct.tempplayer[index].Invited = 0;

                SendData.Send_MsgToPlayer(PStruct.tempplayer[index].Invited, "O jogador recusou o convite de guilda.", Globals.ColorRed, Globals.Msg_Type_Server);
            }


        }
        static void ReceivedGuildKick(int index, string data)
        {
            string[] splited = data.Replace("<65>", "").Split(';');

            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > 20)) { return; }
            if ((Convert.ToInt32(splited[0]) < 1)) { return; }

            int slot = Convert.ToInt32(splited[0]);
           
            int guildnum = PStruct.character[index, PStruct.player[index].SelectedChar].Guild;

            if (guildnum <= 0)
            {
                SendData.Send_MsgToPlayer(index, "Você está tentando retirar quem? Você nem tem guilda.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            string member_name = GStruct.guild[guildnum].memberlist[slot];

            if (member_name != PStruct.character[index, PStruct.player[index].SelectedChar].CharacterName)
            {
                if (GStruct.guild[guildnum].memberlist[GStruct.guild[guildnum].leader] != PStruct.character[index, PStruct.player[index].SelectedChar].CharacterName)
                {
                    SendData.Send_MsgToPlayer(index, "Apenas o lider da guilda pode retirar outros membros.", Globals.ColorRed, Globals.Msg_Type_Server);
                    return;
                }
            }
 

            int count = GStruct.GetMember_Count(guildnum);

            for (int i = 1; i < Globals.MaxMaps; i++)
            {
                if (MStruct.map[i].guildmember == member_name)
                {
                    MStruct.map[i].guildmember = "";
                }
            }

            if (GStruct.guild[guildnum].memberlist[GStruct.guild[guildnum].leader] == member_name)
            {
                if (count <= 1)
                {
                    GStruct.guild[guildnum].memberlist[slot] = "";
                    GStruct.guild[guildnum].leader = 0;
                    GStruct.guild[guildnum].exp = 0;
                    GStruct.guild[guildnum].level = 0;
                    GStruct.guild[guildnum].name = "";
                    GStruct.guild[guildnum].hue = 0;
                    GStruct.guild[guildnum].membersprite[slot] = "";
                    GStruct.guild[guildnum].memberhue[slot] = 0;
                    GStruct.guild[guildnum].membersprite_index[slot] = 0;
                    PStruct.character[index, PStruct.player[index].SelectedChar].Guild = 0;
                    SendData.Send_MsgToPlayer(index, "Sua guilda foi desfeita.", Globals.ColorRed, Globals.Msg_Type_Server);
                }
            }

            for (int i = 1; i <= Globals.Player_HighIndex; i++)
            {
                if (PStruct.character[i, PStruct.player[i].SelectedChar].CharacterName == member_name)
                {
                    PStruct.character[i, PStruct.player[i].SelectedChar].Guild = 0;
                    SendData.Send_CompleteClearGuild(i);
                    break;
                }
            }

            for (int i = slot + 1; i < Globals.Max_Guild_Members; i++)
            {
                GStruct.guild[guildnum].memberlist[i - 1] = GStruct.guild[guildnum].memberlist[i];
                GStruct.guild[guildnum].membersprite[i - 1] = GStruct.guild[guildnum].membersprite[i];
                GStruct.guild[guildnum].membersprite_index[i - 1] = GStruct.guild[guildnum].membersprite_index[i];
            }


            SendData.Send_CompleteGuildToGuild(index);
            SendData.Send_MsgToGuild(guildnum, "O jogador " + member_name + " foi retirado da guilda.", Globals.ColorRed, Globals.Msg_Type_Server);
            Database.SaveGuild(guildnum.ToString());
        }
        static void ReceivedTradeResponse(int index, string data)
        {

            string[] splited = data.Replace("<39>", "").Split(';');

            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > 2)) { return; }
            if ((Convert.ToInt32(splited[0]) < 0)) { return; }

            int response = Convert.ToInt32(splited[0]);

            //Verificar se o jogador não se desconectou no processo
            if ((UserConnection.GetIndex(PStruct.tempplayer[index].Invited) < 0) || (UserConnection.GetIndex(PStruct.tempplayer[index].Invited) >= WinsockAsync.Clients.Count()))
            {
                SendData.Send_MsgToPlayer(index, "O jogador que lhe convidou não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }
            if (!WinsockAsync.Clients[(UserConnection.GetIndex(PStruct.tempplayer[index].Invited))].IsConnected)
            {
                SendData.Send_MsgToPlayer(index, "O jogador que lhe convidou não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            if (response == 0)
            {
                //Criação da troca
                if (PStruct.tempplayer[PStruct.tempplayer[index].Invited].InTrade == 0)
                {
                    //Definindo posições
                    PStruct.tempplayer[index].InTrade = PStruct.tempplayer[index].Invited;
                    PStruct.tempplayer[PStruct.tempplayer[index].Invited].InTrade = index;

                    //Envia o grupo atualizado
                    SendData.Send_TradeOffers(PStruct.tempplayer[index].Invited, PStruct.tempplayer[index].Invited);
                    SendData.Send_TradeOffers(index, PStruct.tempplayer[index].Invited);
                    SendData.Send_TradeOffers(index, index);
                    SendData.Send_TradeOffers(PStruct.tempplayer[index].Invited, index);

                    //Limpa os valores gerais
                    PStruct.tempplayer[index].InviteTimer = 0;
                    PStruct.tempplayer[PStruct.tempplayer[index].Invited].InviteTimer = 0;
                    PStruct.tempplayer[PStruct.tempplayer[index].Invited].Inviting = 0;
                    PStruct.tempplayer[index].Invited = 0;
                }
                else
                {
                    SendData.Send_MsgToPlayer(PStruct.tempplayer[index].Invited, "O jogador não pode entrar em troca no momento.", Globals.ColorRed, Globals.Msg_Type_Server);
                }
            }
            else
            {
                PStruct.ClearTempTrade(index);
                PStruct.ClearTempTrade(PStruct.tempplayer[index].Invited);
                SendData.Send_MsgToPlayer(PStruct.tempplayer[index].Invited, "O jogador recusou o convite de troca.", Globals.ColorRed, Globals.Msg_Type_Server);
            }


        }
        public static void ReceivedTradeAccept(int index)
        {
            //Verificar se o jogador não se desconectou no processo
            if ((UserConnection.GetIndex(PStruct.tempplayer[index].InTrade) < 0) || (UserConnection.GetIndex(PStruct.tempplayer[index].InTrade) >= WinsockAsync.Clients.Count()))
            {
                SendData.Send_MsgToPlayer(index, "O jogador que lhe convidou não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }
            if (!WinsockAsync.Clients[(UserConnection.GetIndex(PStruct.tempplayer[index].InTrade))].IsConnected)
            {
                SendData.Send_MsgToPlayer(index, "O jogador que lhe convidou não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            int tradetarget = PStruct.tempplayer[index].InTrade;

            PStruct.tempplayer[index].TradeStatus = 1;

            if ((PStruct.tempplayer[index].TradeStatus == 1) && (PStruct.tempplayer[tradetarget].TradeStatus == 1))
            {
                PStruct.GiveTradeTo(index, tradetarget);
                PStruct.GiveTradeTo(tradetarget, index);
                SendData.Send_InvSlots(tradetarget, PStruct.player[tradetarget].SelectedChar);
                SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
                SendData.Send_PlayerG(index);
                SendData.Send_PlayerG(tradetarget);
                SendData.Send_TradeAccept(index, 3);
                SendData.Send_TradeAccept(tradetarget, 3);
                PStruct.ClearTempTrade(index);
                PStruct.ClearTempTrade(tradetarget);
                return;
            }

            if ((PStruct.tempplayer[index].TradeStatus == 1) && (PStruct.tempplayer[tradetarget].TradeStatus == 0))
            {
                SendData.Send_TradeAccept(index, 1);
                SendData.Send_TradeAccept(tradetarget, 2);
                return;
            }

            if ((PStruct.tempplayer[index].TradeStatus == 0) && (PStruct.tempplayer[tradetarget].TradeStatus == 1))
            {
                SendData.Send_TradeAccept(tradetarget, 1);
                SendData.Send_TradeAccept(index, 2);
                return;
            }

            if ((PStruct.tempplayer[index].TradeStatus == 0) && (PStruct.tempplayer[tradetarget].TradeStatus == 0))
            {
                SendData.Send_TradeAccept(tradetarget, 0);
                SendData.Send_TradeAccept(index, 0);
                return;
            }
        }
        public static void ReceivedTradeRefuse(int index)
        {
            //Verificar se o jogador não se desconectou no processo
            if ((UserConnection.GetIndex(PStruct.tempplayer[index].InTrade) < 0) || (UserConnection.GetIndex(PStruct.tempplayer[index].InTrade) >= WinsockAsync.Clients.Count()))
            {
                SendData.Send_MsgToPlayer(index, "O jogador que lhe convidou não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }
            if (!WinsockAsync.Clients[(UserConnection.GetIndex(PStruct.tempplayer[index].InTrade))].IsConnected)
            {
                SendData.Send_MsgToPlayer(index, "O jogador que lhe convidou não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            int tradetarget = PStruct.tempplayer[index].InTrade;

            PStruct.tempplayer[index].TradeStatus = 0;

            if ((PStruct.tempplayer[index].TradeStatus == 1) && (PStruct.tempplayer[tradetarget].TradeStatus == 1))
            {
                SendData.Send_TradeRefuse(index, 3);
                SendData.Send_TradeRefuse(tradetarget, 3);
                return;
            }

            if ((PStruct.tempplayer[index].TradeStatus == 1) && (PStruct.tempplayer[tradetarget].TradeStatus == 0))
            {
                SendData.Send_TradeRefuse(index, 1);
                SendData.Send_TradeRefuse(tradetarget, 2);
                return;
            }

            if ((PStruct.tempplayer[index].TradeStatus == 0) && (PStruct.tempplayer[tradetarget].TradeStatus == 1))
            {
                SendData.Send_TradeRefuse(tradetarget, 1);
                SendData.Send_TradeRefuse(index, 2);
                return;
            }

            if ((PStruct.tempplayer[index].TradeStatus == 0) && (PStruct.tempplayer[tradetarget].TradeStatus == 0))
            {
                SendData.Send_TradeRefuse(tradetarget, 0);
                SendData.Send_TradeRefuse(index, 0);
                return;
            }
        }
        public static void ReceivedTradeClose(int index)
        {
            //Verificar se o jogador não se desconectou no processo
            if ((UserConnection.GetIndex(PStruct.tempplayer[index].InTrade) < 0) || (UserConnection.GetIndex(PStruct.tempplayer[index].InTrade) >= WinsockAsync.Clients.Count()))
            {
                SendData.Send_TradeClose(index);
                PStruct.GiveTrade(index);
                return;
            }
            if (!WinsockAsync.Clients[(UserConnection.GetIndex(PStruct.tempplayer[index].InTrade))].IsConnected)
            {
                SendData.Send_TradeClose(index);
                PStruct.GiveTrade(index);
                return;
            }

            int tradetarget = PStruct.tempplayer[index].InTrade;

            if (PStruct.tempplayer[index].TradeG > 0)
            {
                PStruct.GivePlayerGold(index, PStruct.tempplayer[index].TradeG); 
                PStruct.tempplayer[index].TradeG = 0;
            }

            if (PStruct.tempplayer[tradetarget].TradeG > 0)
            {
                PStruct.GivePlayerGold(tradetarget, PStruct.tempplayer[tradetarget].TradeG); 
                PStruct.tempplayer[tradetarget].TradeG = 0;
            }

            SendData.Send_TradeClose(index);
            SendData.Send_TradeClose(tradetarget);
            PStruct.GiveTrade(index);
            PStruct.GiveTrade(tradetarget);
            PStruct.ClearTempTrade(index);
            PStruct.ClearTempTrade(tradetarget);
        }
        public static void ReceivedAddTradeG(int index, string data)
        {
            //Verificar se o jogador não se desconectou no processo
            if ((UserConnection.GetIndex(PStruct.tempplayer[index].InTrade) < 0) || (UserConnection.GetIndex(PStruct.tempplayer[index].InTrade) >= WinsockAsync.Clients.Count()))
            {
                SendData.Send_MsgToPlayer(index, "O jogador que lhe convidou não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }
            if (!WinsockAsync.Clients[(UserConnection.GetIndex(PStruct.tempplayer[index].InTrade))].IsConnected)
            {
                SendData.Send_MsgToPlayer(index, "O jogador que lhe convidou não está conectado.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            string[] splited = data.Replace("<38>", "").Split(';');
            
            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > 99999999)) { return; }
            if ((Convert.ToInt32(splited[0]) < 0)) { return; }

            int gold = Convert.ToInt32(splited[0]);

            if (PStruct.character[index, PStruct.player[index].SelectedChar].Gold < gold)
            {
                SendData.Send_MsgToPlayer(index, "Você não tem a quantia.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            if (PStruct.tempplayer[index].TradeG > 0)
            {
                PStruct.character[index, PStruct.player[index].SelectedChar].Gold += PStruct.tempplayer[index].TradeG;
            }

            PStruct.character[index, PStruct.player[index].SelectedChar].Gold -= gold;
            PStruct.tempplayer[index].TradeG = gold;
            
            int tradetarget = PStruct.tempplayer[index].InTrade;
            
            SendData.Send_PlayerG(index);
            SendData.Send_TradeG(index, index);
            SendData.Send_TradeG(index, tradetarget);
        }
        static void ReceivedQuestAction(int index, string data)
        {
            string[] splited = data.Replace("<43>", "").Split(';');

            if (splited.Length != 1) { return; }

            if (splited[0].Split(',').Length != 2) { return; }
            if (!IsNumeric(splited[0].Split(',')[0])) { return; }
            if (!IsNumeric(splited[0].Split(',')[1])) { return; }
            if ((Convert.ToInt32(splited[0].Split(',')[0]) > Globals.MaxQuestGivers - 1)) { return; }
            if ((Convert.ToInt32(splited[0].Split(',')[0]) < 0)) { return; }
            if ((Convert.ToInt32(splited[0].Split(',')[1]) > Globals.MaxQuestActions - 1)) { return; }
            if ((Convert.ToInt32(splited[0].Split(',')[1]) < 0)) { return; }

            int questgiver = Convert.ToInt32(splited[0].Split(',')[0]);
            int action = Convert.ToInt32(splited[0].Split(',')[1]);

            //hacking attempt
            if ((action > 2) || (action < 0))
            {
                return;
            }

            if (MStruct.questgiver[questgiver].map != PStruct.character[index, PStruct.player[index].SelectedChar].Map)
            {
                return;
            }


            if ((questgiver == 10) || (questgiver == 25))
            {
                if (PStruct.GetOpenProf(index) <= 0)
                {
                    SendData.Send_MsgToPlayer(index, "Você não pode fazer uma missão de profissão pois já tem o limite de profissões", Globals.ColorRed, Globals.Msg_Type_Server);
                    return;
                }
            }

            int quest = PStruct.GetActualPlayerQuestPerGiver(index, questgiver);

            if (String.IsNullOrEmpty(MStruct.quest[questgiver, quest].type)) { PStruct.queststatus[index, questgiver, quest].status = 0; return; }

            if (action == 0 && (PStruct.queststatus[index, questgiver, quest].status == 0))
            {
                //Inicia a missão
                PStruct.queststatus[index, questgiver, quest].status = 1;
                for (int k = 1; k < Globals.MaxQuestKills; k++)
                {
                    PStruct.questkills[index, questgiver, quest, k].kills = 0;
                }
                for (int a = 1; a < Globals.MaxQuestActions; a++)
                {
                    PStruct.questactions[index, questgiver, quest, a].actiondone = false;
                }
            }

            if (action == 1 && (PStruct.queststatus[index, questgiver, quest].status == 1))
            {
                //Checar se a missão está concluída
                if (Convert.ToInt32(MStruct.quest[questgiver, quest].type.Split('|')[0]) > 0)
                {
                    for (int k = 1; k <= MStruct.quest[questgiver, quest].killvalue; k++)
                    {
                        if (PStruct.questkills[index, questgiver, quest, k].kills < MStruct.questkills[questgiver, quest, k].value)
                        {
                           // Não terminou
                           return;
                        }
                    }
                }

                if (Convert.ToInt32(MStruct.quest[questgiver, quest].type.Split('|')[1]) > 0)
                {
                    for (int a = 1; a <= MStruct.quest[questgiver, quest].actionvalue; a++)
                    {
                        if (PStruct.questactions[index, questgiver, quest, a].actiondone == false)
                        {
                            // Não terminou
                            return;
                        }
                    }
                }

                if (Convert.ToInt32(MStruct.quest[questgiver, quest].type.Split('|')[2]) > 0)
                {
                    for (int i = 1; i <= MStruct.quest[questgiver, quest].itemvalue; i++)
                    {
                        if (!PStruct.HasItem(index, MStruct.questitems[questgiver, quest, i].item))
                        {
                            //Não terminou
                            return;
                        }
                    }
                }


                if ((questgiver == 42) && (quest == 1))
                {
                    for (int i = 1; i <= 41; i++)
                    {
                        if ((i != 10) && (i != 25) && (i != 7))
                        {
                            for (int g = 1; g <= MStruct.questgiver[questgiver].quest_count; g++)
                            {
                                if (PStruct.queststatus[index, i, g].status != 2)
                                {
                                    //Não terminou
                                  //  return; 
                                }
                            }
                        }
                    }
                }


                if (MStruct.quest[questgiver, quest].rewardvalue > PStruct.GetNumOfInvFreeSlots(index))
                {
                    SendData.Send_MsgToPlayer(index, "Você não tem espaço no inventário para receber as recompensas da missão!", Globals.ColorGreen, Globals.Msg_Type_Server);
                    return;
                }

                string[] item;

                if (Convert.ToInt32(MStruct.quest[questgiver, quest].type.Split('|')[2]) > 0)
                {
                    for (int i = 1; i <= MStruct.quest[questgiver, quest].itemvalue; i++)
                    {
                        PStruct.PickItem(index, Convert.ToInt32(MStruct.questitems[questgiver, quest, i].item.Split(',')[0]), Convert.ToInt32(MStruct.questitems[questgiver, quest, i].item.Split(',')[1]), Convert.ToInt32(MStruct.questitems[questgiver, quest, i].item.Split(',')[2]), Convert.ToInt32(MStruct.questitems[questgiver, quest, i].item.Split(',')[3])); 
                    }
                }

                //Entrega as recompensas

                if (PStruct.IsQuestGiverRepeatable(questgiver))
                {
                    //Reinicia a missão
                    PStruct.queststatus[index, questgiver, quest].status = 0;
                    for (int k = 1; k < Globals.MaxQuestKills; k++)
                    {
                        PStruct.questkills[index, questgiver, quest, k].kills = 0;
                    }
                    for (int a = 1; a < Globals.MaxQuestActions; a++)
                    {
                        PStruct.questactions[index, questgiver, quest, a].actiondone = false;
                    }
                }
                else
                {
                    //Finaliza a missão
                    PStruct.queststatus[index, questgiver, quest].status = 2;
                    
                    if ((questgiver == 10) && (quest == 1))
                    {
                        int profnum = PStruct.GetOpenProf(index);
                        PStruct.character[index, PStruct.player[index].SelectedChar].Prof_Type[profnum] = Globals.Job_Miner;
                        PStruct.character[index, PStruct.player[index].SelectedChar].Prof_Level[profnum] = 1;
                        PStruct.character[index, PStruct.player[index].SelectedChar].Prof_Exp[profnum] = 0;
                        SendData.Send_MsgToPlayer(index, "Você aprendeu a profissão de Mineiro!", Globals.ColorYellow, Globals.Msg_Type_Server);
                        SendData.Send_Profs(index);
                    }
                    if ((questgiver == 25) && (quest == 1))
                    {
                        int profnum = PStruct.GetOpenProf(index);
                        PStruct.character[index, PStruct.player[index].SelectedChar].Prof_Type[profnum] = Globals.Job_Blacksmith;
                        PStruct.character[index, PStruct.player[index].SelectedChar].Prof_Level[profnum] = 1;
                        PStruct.character[index, PStruct.player[index].SelectedChar].Prof_Exp[profnum] = 0;
                        SendData.Send_MsgToPlayer(index, "Você aprendeu a profissão de Ferreiro!", Globals.ColorYellow, Globals.Msg_Type_Server);
                        SendData.Send_Profs(index);
                    }
                }

                for (int i = 1; i <= MStruct.quest[questgiver, quest].rewardvalue; i++)
                {
                    item = MStruct.questrewards[questgiver, quest, i].item.Split('/');
                    PStruct.GiveItem(index, Convert.ToInt32(item[0]), Convert.ToInt32(item[1]), Convert.ToInt32(item[2]), Convert.ToInt32(item[3]), Globals.NullExp);
                }
                PStruct.GivePlayerExp(index, MStruct.quest[questgiver, quest].exp);
                PStruct.GivePlayerGold(index, MStruct.quest[questgiver, quest].gold); 
                SendData.Send_MsgToPlayer(index, "Você completou uma missão!", Globals.ColorGreen, Globals.Msg_Type_Server);
                SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
            }

            SendData.Send_AllQuests(index);

        }
        public static void ReceivedShopBuy(int index, string data)
        {
            if (PStruct.tempplayer[index].InShop <= 0) { return; }

            string[] splited = data.Replace("<45>", "").Split(';');
            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }

            int shopnum = Convert.ToInt32(splited[0]);

            if ((shopnum <= 0) || (shopnum > ShopStruct.shop[PStruct.tempplayer[index].InShop].item_count)) { return; }

            if (PStruct.GetNumOfInvFreeSlots(index) <= 0)
            {
                SendData.Send_MsgToPlayer(index, "Você não tem espaço no inventário para efetuar a compra!", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            if (PStruct.character[index, PStruct.player[index].SelectedChar].Gold >= ShopStruct.shopitem[PStruct.tempplayer[index].InShop, shopnum].price)
            {
                PStruct.character[index, PStruct.player[index].SelectedChar].Gold -= ShopStruct.shopitem[PStruct.tempplayer[index].InShop, shopnum].price;
                PStruct.GiveItem(index, ShopStruct.shopitem[PStruct.tempplayer[index].InShop, shopnum].type, ShopStruct.shopitem[PStruct.tempplayer[index].InShop, shopnum].num, ShopStruct.shopitem[PStruct.tempplayer[index].InShop, shopnum].value, ShopStruct.shopitem[PStruct.tempplayer[index].InShop, shopnum].refin, Globals.NullExp);
                SendData.Send_MsgToPlayer(index, "Você comprou um item!", Globals.ColorGreen, Globals.Msg_Type_Server);
                SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
                SendData.Send_PlayerG(index);
            }
            else
            {
                SendData.Send_MsgToPlayer(index, "Você não tem a quantia de gold necessária!", Globals.ColorRed, Globals.Msg_Type_Server);
            }


        }
        public static void ReceivedBuyPShop(int index, string data)
        {
            if (PStruct.tempplayer[index].InPShop <= 0) { return; }
            if (PStruct.tempplayer[index].Shopping) { return; }

            string[] splited = data.Replace("<83>", "").Split(';');
            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }

            int shopnum = Convert.ToInt32(splited[0]);
            int shopindex = PStruct.tempplayer[index].InPShop;

            if ((shopnum <= 0) || (shopnum > Globals.Max_PShops - 1)) { return; }

            //Verifica se ele não se desconectou no processo
            if ((UserConnection.GetIndex(shopindex) < 0) || (UserConnection.GetIndex(shopindex) >= WinsockAsync.Clients.Count()))
            {
                SendData.Send_MsgToPlayer(index, "A loja não existe mais.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }
            if (!WinsockAsync.Clients[(UserConnection.GetIndex(shopindex))].IsConnected)
            {
                SendData.Send_MsgToPlayer(index, "A loja não existe mais.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            if (!PStruct.tempplayer[shopindex].Shopping)
            {
                SendData.Send_MsgToPlayer(index, "A loja não existe mais.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            if (PStruct.GetNumOfInvFreeSlots(index) <= 0)
            {
                SendData.Send_MsgToPlayer(index, "Você não tem espaço no inventário para efetuar a compra!", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            if (PStruct.character[index, PStruct.player[index].SelectedChar].Gold >= PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[shopnum].price)
            {
                PStruct.character[index, PStruct.player[index].SelectedChar].Gold -= PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[shopnum].price;
                PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].Gold += PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[shopnum].price;
                PStruct.GiveItem(index, PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[shopnum].type, PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[shopnum].num, PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[shopnum].value, PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[shopnum].refin, PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[shopnum].exp);
                for (int i = (shopnum + 1); i < Globals.Max_PShops; i++)
                {
                    PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[i - 1].num = PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[i].num;
                    PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[i - 1].type = PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[i].type;
                    PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[i - 1].value = PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[i].value;
                    PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[i - 1].refin = PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[i].refin;
                    PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[i - 1].price = PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[i].price;
                    PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[i].num = 0;
                    PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[i].type = 0;
                    PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[i].value = 0;
                    PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[i].refin = 0;
                    PStruct.character[shopindex, PStruct.player[shopindex].SelectedChar].pshopslot[i].price = 0;
                }
                SendData.Send_MsgToPlayer(index, "Você comprou um item!", Globals.ColorGreen, Globals.Msg_Type_Server);
                SendData.Send_MsgToPlayer(shopindex, "Você vendeu um item!", Globals.ColorGreen, Globals.Msg_Type_Server);
                SendData.Send_PShopSlots(shopindex, index);
                SendData.Send_PShopSlots(shopindex, shopindex);
                SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
                SendData.Send_PlayerG(shopindex);
                SendData.Send_PlayerG(index);
            }
            else
            {
                SendData.Send_MsgToPlayer(index, "Você não tem a quantia de ouro necessária!", Globals.ColorRed, Globals.Msg_Type_Server);
            }


        }
        public static void ReceivedShopClose(int index)
        {
            //Sair da loja, o servidor precisa saber
            PStruct.tempplayer[index].InShop = 0;
        }
        public static void ReceivedShopSell(int index, string data)
        {
            if (PStruct.tempplayer[index].InShop <= 0) { return; }

            string[] splited = data.Replace("<46>", "").Split(';');
            if (splited.Length != 2) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if (!IsNumeric(splited[1])) { return; }

            int invslot = Convert.ToInt32(splited[0]);
            int value = Convert.ToInt32(splited[1]);

            if ((invslot <= 0) || (invslot > Globals.MaxInvSlot - 1)) { return; }
            if ((value <= 0) || (value > 999)) { return; }
           
            string[] splititem = PStruct.invslot[index, invslot].item.Split(',');

            int itemNum = Convert.ToInt32(splititem[1]);
            int itemType = Convert.ToInt32(splititem[0]);
            int itemValue = Convert.ToInt32(splititem[2]);
            int itemRefin = Convert.ToInt32(splititem[3]);

            if (!PStruct.PickItem(index, itemType, itemNum, value, itemRefin)) { return; }

            int gold_value = 0;

            switch (itemType)
            {
                case 0:
                case 1:
                  gold_value = IStruct.item[itemNum].price * value;
                  break;
                case 2:
                  gold_value = WStruct.weapon[itemNum].price * value;
                  break;
                case 3:
                  gold_value = AStruct.armor[itemNum].price * value;
                  break;
                default:
                  Console.WriteLine("Recebeu um valor/tipo inválido em ReceivedShopSell: " + itemType);
                  return;
            }

            PStruct.GivePlayerGold(index, gold_value);
            SendData.Send_PlayerG(index);
            SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
            SendData.Send_MsgToPlayer(index, "Você vendeu um item", Globals.ColorGreen, Globals.Msg_Type_Server);
        }
        static void ReceivedOpenCraft(int index)
        {
            for (int i = 1; i < Globals.Max_CraftPoints; i++)
            {
                if (MStruct.craftpoint[i].map == PStruct.character[index, PStruct.player[index].SelectedChar].Map)
                {
                    int profnum = PStruct.GetPlayerProf(index, MStruct.craftpoint[i].type);

                    if (profnum <= 0)
                    {
                        SendData.Send_MsgToPlayer(index, "Você não tem o conhecimento para explorar este recurso.", Globals.ColorRed, Globals.Msg_Type_Server);
                        return;
                    }
                    if (MStruct.craftpoint[i].type == Globals.Job_Blacksmith)
                    {
                        if (PStruct.GetPlayerWeapon(index) == 31)
                        {
                            PStruct.tempplayer[index].InCraft = true;
                            PStruct.tempplayer[index].CraftType = MStruct.craftpoint[i].type;

                            //if ((PStruct.tempplayer[index].CraftType == Globals.Job_ArmorBlacksmith) || (PStruct.tempplayer[index].CraftType == Globals.Job_SwordBlacksmith)) { SendData.Send_Blacksmith(index); }
                            // if (PStruct.tempplayer[index].CraftType == Globals.Job_Alchemist) { SendData.Send_Alchemist(index); }
                            break;
                        }
                        else
                        {
                            SendData.Send_MsgToPlayer(index, "Você não tem a ferramenta necessária para explorar este recurso.", Globals.ColorRed, Globals.Msg_Type_Server);
                        }
                    }
                }
            }
        }
        static void ReceivedOpenBank(int index)
        {
            for (int i = 1; i < Globals.Max_BankPoints; i++)
            {
                if (MStruct.bankpoint[i].map == PStruct.character[index, PStruct.player[index].SelectedChar].Map)
                {
                    PStruct.tempplayer[index].InBank = true;
                    SendData.Send_BankSlots(index);
                    break;
                }
            }
        }
        static void ReceivedOpenPShop(int index, string data)
        {
            if (PStruct.tempplayer[index].InPShop > 0) { return; }
            if (PStruct.tempplayer[index].Shopping) { return; }
            string[] splited = data.Replace("<84>", "").Split(';');
            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if (Convert.ToInt32(splited[0]) < 0) { return; }
            if (Convert.ToInt32(splited[0]) > Globals.Player_HighIndex) { return; }

            //Contêm o jogador que é dono da loja
            int shopindex = Convert.ToInt32(splited[0]);

            //Se for o index, ele apenas está atualizando os dados da sua própria loja, mas como tudo, devemos sempre pensar em temporizar alguns
            //dados importantes.
            if (shopindex == index) { SendData.Send_PShopSlots(index, index); }

            //Verificar se o jogador não se desconectou no processo
            if (!PStruct.tempplayer[shopindex].Shopping) { return; }
            if ((UserConnection.GetIndex(shopindex) < 0) || (UserConnection.GetIndex(shopindex) >= WinsockAsync.Clients.Count())) { return; }
            if (!WinsockAsync.Clients[(UserConnection.GetIndex(shopindex))].IsConnected) { return; }

            //Definir a loja e enviar.
            PStruct.tempplayer[index].InPShop = shopindex;
            SendData.Send_PShopSlots(shopindex, index);
        }
        static void ReceivedStartPShop(int index)
        {
            if (PStruct.tempplayer[index].InPShop > 0) { return; }
            if (PStruct.tempplayer[index].Shopping) { return; }

            PStruct.tempplayer[index].Shopping = true;
            SendData.Send_PlayerShoppingToMap(index);
            SendData.Send_MsgToPlayer(index, "Você iniciou as vendas de sua loja!", Globals.ColorGreen, Globals.Msg_Type_Server);
        }
        static void ReceivedCloseBank(int index)
        {     
            //O servidor precisa saber quando o banco é fechado
            PStruct.tempplayer[index].InBank = false;
        }
        static void ReceivedClosePShop(int index)
        {
            //O jogador não está mais em uma loja
            PStruct.tempplayer[index].InPShop = 0;
            
            //Se era uma loja, enviar ao mapa
            if (PStruct.tempplayer[index].Shopping)
            {
                PStruct.tempplayer[index].Shopping = false;
                SendData.Send_PlayerShoppingToMap(index);
                SendData.Send_MsgToPlayer(index, "Você encerrou as vendas de sua loja!", Globals.ColorGreen, Globals.Msg_Type_Server);
            }
        }
        static void ReceivedCloseCraft(int index)
        {
            if (!PStruct.tempplayer[index].InCraft) { return; }
            //Devolve os itens

            bool need_invslot = false;

            for (int i = 1; i < Globals.Max_Craft; i++)
            {
                if (PStruct.craft[index, i].num > 0)
                {
                    PStruct.GiveItem(index, PStruct.craft[index, i].type, PStruct.craft[index, i].num, PStruct.craft[index, i].value, PStruct.craft[index, i].refin, PStruct.craft[index, i].exp);
                    need_invslot = true;
                    PStruct.craft[index, i].num = 0;
                    PStruct.craft[index, i].type = 0;
                    PStruct.craft[index, i].value = 0;
                    PStruct.craft[index, i].refin = 0;
                }
            }

            //O servidor precisa saber quando o jogador fechou o craft
            PStruct.tempplayer[index].InCraft = false;

            if (need_invslot) { SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar); SendData.Send_Craft(index); }
        }
        static void ReceivedCraftCreate(int index)
        {
            if (!PStruct.tempplayer[index].InCraft) { return; }
            if (PStruct.tempplayer[index].CraftType <= 0) { return; }
            if (PStruct.tempplayer[index].CraftItem <= 0) { return; }
            if (MStruct.craftrecipe[PStruct.tempplayer[index].CraftType, PStruct.tempplayer[index].CraftItem, 1].num <= 0) { return; }
            if (PStruct.GetNumOfInvFreeSlots(index) <= 0) { SendData.Send_MsgToPlayer(index, "Não há espaço no inventário.", Globals.ColorRed, Globals.Msg_Type_Server); return; }

            int[] craftslot = new int[Globals.Max_Craft];

            for (int i = 1; i < Globals.Max_Craft; i++)
            {
                if (MStruct.craftrecipe[PStruct.tempplayer[index].CraftType, PStruct.tempplayer[index].CraftItem, i].num > 0)
                {
                    craftslot[i] = PStruct.CraftHasItem(index, MStruct.craftrecipe[PStruct.tempplayer[index].CraftType, PStruct.tempplayer[index].CraftItem, i].type, MStruct.craftrecipe[PStruct.tempplayer[index].CraftType, PStruct.tempplayer[index].CraftItem, i].num);
                    
                    if (craftslot[i] == -1)
                    {
                        SendData.Send_MsgToPlayer(index, "Receita incorreta", Globals.ColorRed, Globals.Msg_Type_Server);
                        return;
                    }
                }
            }

                       
            for (int i = 1; i < Globals.Max_Craft; i++)
            {
                PStruct.craft[index, craftslot[i]].value -= MStruct.craftrecipe[PStruct.tempplayer[index].CraftType, PStruct.tempplayer[index].CraftItem, i].value;
                if (PStruct.craft[index, craftslot[i]].value <= 0)
                {
                    PStruct.craft[index, craftslot[i]].value = 0;
                    PStruct.craft[index, craftslot[i]].num = 0;
                    PStruct.craft[index, craftslot[i]].type = 0;
                    PStruct.craft[index, craftslot[i]].refin = 0;
                    PStruct.craft[index, craftslot[i]].exp = 0;
                }
            }


            PStruct.GiveItem(index, PStruct.tempplayer[index].CraftType, PStruct.tempplayer[index].CraftItem, 1, PStruct.GetRefinCraft(index, PStruct.tempplayer[index].CraftType), Globals.NullExp);
            SendData.Send_MsgToPlayer(index, "Você criou um novo item.", Globals.ColorGreen, Globals.Msg_Type_Server);
            SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);

           // if ((PStruct.tempplayer[index].CraftType == Globals.Job_ArmorBlacksmith) || (PStruct.tempplayer[index].CraftType == Globals.Job_SwordBlacksmith)) { PStruct.character[index, PStruct.player[index].SelectedChar].Blacksmith += 1; SendData.Send_Blacksmith(index); }
          //  if (PStruct.tempplayer[index].CraftType == Globals.Job_Alchemist) { PStruct.character[index, PStruct.player[index].SelectedChar].Alchemist += 1; SendData.Send_Alchemist(index); }

            SendData.Send_Craft(index);
        }
        static void ReceivedItemCraft(int index, string data)
        {
            if (!PStruct.tempplayer[index].InCraft) { return; }
            string[] splited = data.Replace("<53>", "").Split(';');

            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > WStruct.weapon.Length - 1)) { return; }
            if ((Convert.ToInt32(splited[0]) < 0)) { return; }

            PStruct.tempplayer[index].CraftItem = Convert.ToInt32(splited[0]);
            SendData.Send_Recipe(index, PStruct.tempplayer[index].CraftType, PStruct.tempplayer[index].CraftItem);
        }
        static void ReceivedCraftWith(int index, string data)
        {
            if (!PStruct.tempplayer[index].InCraft) { return; }
            string[] splited = data.Replace("<49>", "").Split(';');

            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > Globals.Max_Craft - 1)) { return; }
            if ((Convert.ToInt32(splited[0]) < 0)) { return; }

            int craftslot = Convert.ToInt32(splited[0]);

            if (PStruct.craft[index, craftslot].num <= 0) { return; }

            if (!PStruct.GiveItem(index, PStruct.craft[index, craftslot].type, PStruct.craft[index, craftslot].num, PStruct.craft[index, craftslot].value, PStruct.craft[index, craftslot].refin, PStruct.craft[index, craftslot].exp)) { return; }
            PStruct.craft[index, craftslot].type = 0;
            PStruct.craft[index, craftslot].num = 0;
            PStruct.craft[index, craftslot].value = 0;
            PStruct.craft[index, craftslot].refin = 0;
            PStruct.craft[index, craftslot].exp = 0;

            SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
            SendData.Send_Craft(index);
        }
        static void ReceivedImprovement(int index, string data)
        {
            string[] splited = data.Replace("<72>", "").Split(';');

            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > Globals.MaxInvSlot - 1)) { return; }
            if ((Convert.ToInt32(splited[0]) <= 0)) { return; }

            int oriunslot = PStruct.GetPlayerOriunklatex(index);

            if (oriunslot == 0) { return; }

            int itemslot = Convert.ToInt32(splited[0]);
            
            string item = PStruct.invslot[index, itemslot].item;
            string[] splititem = item.Split(',');

            int itemNum = Convert.ToInt32(splititem[1]);
            int itemType = Convert.ToInt32(splititem[0]);
            int itemValue = Convert.ToInt32(splititem[2]);
            int itemRefin = Convert.ToInt32(splititem[3]);
            int itemExp = Convert.ToInt32(splititem[4]);

            if (itemNum <= 0) { return; }
            if ((itemType == 0) || (itemType == 1)) { return; }
            
            if (PStruct.GetNumOfInvFreeSlots(index) <= 0) { SendData.Send_MsgToPlayer(index, "Não há espaço no inventário!", Globals.ColorGreen, Globals.Msg_Type_Server); return; }

            //Pegar oriun
            PStruct.PickItem(index, 1, 68, 1, 0);
            //Pegar um equipamento selecionado
            PStruct.PickItem(index, itemType, itemNum, 1, itemRefin);
            //Entregar novo equipamento
            PStruct.GiveItem(index, itemType, itemNum, 1, itemRefin + 1, itemExp);

            SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
            SendData.Send_MsgToPlayer(index, "Você aprimorou um item!", Globals.ColorGreen, Globals.Msg_Type_Server);
        }
        static void ReceivedWBuy(int index, string data)
        {
            string[] splited = data.Replace("<73>", "").Split(';');

            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > Globals.MaxItems - 1)) { return; }
            if ((Convert.ToInt32(splited[0]) <= 0)) { return; }

            int slot = Convert.ToInt32(splited[0]);

            if (ShopStruct.shopitem[Globals.Shop_W, slot].price > PStruct.player[index].WPoints) { return; }
            if (!PStruct.GiveBankItem(index, ShopStruct.shopitem[Globals.Shop_W, slot].type, ShopStruct.shopitem[Globals.Shop_W, slot].num, ShopStruct.shopitem[Globals.Shop_W, slot].value, ShopStruct.shopitem[Globals.Shop_W, slot].refin, Globals.NullExp)) { SendData.Send_NStatus(index, "Falha ao entrar o item, verifique o banco."); return; }
            PStruct.player[index].WPoints -= ShopStruct.shopitem[Globals.Shop_W, slot].price;

            SendData.Send_WPoints(index);
            SendData.Send_NStatus(index, "Compra realizada com sucesso.");
        }
        static void ReceivedBankGiveItem(int index, string data)
        {
            if (!PStruct.tempplayer[index].InBank) { return; }
            string[] splited = data.Replace("<57>", "").Split(';');

            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > Globals.Max_BankSlots - 1)) { return; }
            if ((Convert.ToInt32(splited[0]) < 0)) { return; }

            int bankslot = Convert.ToInt32(splited[0]);

            int itemNum = PStruct.player[index].bankslot[bankslot].num;
            int itemType = PStruct.player[index].bankslot[bankslot].type;
            int itemValue = PStruct.player[index].bankslot[bankslot].value;
            int itemRefin = PStruct.player[index].bankslot[bankslot].refin;
            int itemExp = PStruct.player[index].bankslot[bankslot].exp;

            if (itemNum <= 0) { return; }
            if (!PStruct.GiveItem(index, itemType, itemNum, itemValue, itemRefin, itemExp)) { return; }

            PStruct.player[index].bankslot[bankslot].type = 0;
            PStruct.player[index].bankslot[bankslot].num = 0;
            PStruct.player[index].bankslot[bankslot].value = 0;
            PStruct.player[index].bankslot[bankslot].refin = 0;
            PStruct.player[index].bankslot[bankslot].exp = 0;

            SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
            SendData.Send_BankSlots(index);
        }
        static void ReceivedWithPShop(int index, string data)
        {
            string[] splited = data.Replace("<81>", "").Split(';');

            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > Globals.Max_PShops - 1)) { return; }
            if ((Convert.ToInt32(splited[0]) < 0)) { return; }

            int pshopslot = Convert.ToInt32(splited[0]);

            int itemNum = PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[pshopslot].num;
            int itemType = PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[pshopslot].type;
            int itemValue = PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[pshopslot].value;
            int itemRefin = PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[pshopslot].refin;
            int itemExp = PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[pshopslot].exp;

            if (itemNum <= 0) { return; }
            if (!PStruct.GiveItem(index, itemType, itemNum, itemValue, itemRefin, itemExp)) { return; }

            for (int i = (pshopslot + 1); i < Globals.Max_PShops; i++)
            {
                PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i - 1].num = PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].num;
                PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i - 1].type = PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].type;
                PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i - 1].value = PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].value;
                PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i - 1].refin = PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].refin;
                PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i - 1].price = PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].price;
                PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].num = 0;
                PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].type = 0;
                PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].value = 0;
                PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].refin = 0;
                PStruct.character[index, PStruct.player[index].SelectedChar].pshopslot[i].price = 0;
            }

            SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
            SendData.Send_PShopSlots(index, index);
        }
        static void ReceivedCraftAdd(int index, string data)
        {
            if (!PStruct.tempplayer[index].InCraft) { return; }
            string[] splited = data.Replace("<48>", "").Split(';');

            if (splited.Length != 2) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > Globals.MaxInvSlot - 1)) { return; }
            if ((Convert.ToInt32(splited[0]) < 0)) { return; }
            if ((Convert.ToInt32(splited[1]) > 999)) { return; }
            if ((Convert.ToInt32(splited[1]) < 0)) { return; }

            int slot = Convert.ToInt32(splited[0]);

            if (PStruct.invslot[index, slot].item == Globals.NullItem) { SendData.Send_MsgToPlayer(index, "Item inexistente.", Globals.ColorRed, Globals.Msg_Type_Server); return; }

            string[] splititem = PStruct.invslot[index, slot].item.Split(',');

            int value = Convert.ToInt32(splited[1]);

            int itemNum = Convert.ToInt32(splititem[1]);
            int itemType = Convert.ToInt32(splititem[0]);
            int itemValue = Convert.ToInt32(splititem[2]);
            int itemRefin = Convert.ToInt32(splititem[3]);
            int itemExp = Convert.ToInt32(splititem[4]);

            if (itemValue < value)
            {
                SendData.Send_MsgToPlayer(index, "Você não tem a quantidade.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            int craftslot = PStruct.GetFreeCraft(index);

            if (craftslot == -1) { return; }

            if (value != itemValue)
            {
                PStruct.invslot[index, slot].item = itemType + "," + itemNum + "," + (itemValue - value) + "," + itemRefin + "," + itemExp;
                PStruct.craft[index, craftslot].type = itemType;
                PStruct.craft[index, craftslot].num = itemNum;
                PStruct.craft[index, craftslot].value = value;
                PStruct.craft[index, craftslot].refin = itemRefin;
                PStruct.craft[index, craftslot].exp = itemExp;
            }
            else
            {
                PStruct.invslot[index, slot].item = Globals.NullItem;
                PStruct.craft[index, craftslot].type = itemType;
                PStruct.craft[index, craftslot].num = itemNum;
                PStruct.craft[index, craftslot].value = value;
                PStruct.craft[index, craftslot].refin = itemRefin;
                PStruct.craft[index, craftslot].exp = itemExp;
            }

            SendData.Send_Craft(index);
            SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
        }
        static void ReceivedBankPickItem(int index, string data)
        {
            if (!PStruct.tempplayer[index].InBank) { return; }
            string[] splited = data.Replace("<56>", "").Split(';');

            if (splited.Length != 2) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > Globals.MaxInvSlot - 1)) { return; }
            if ((Convert.ToInt32(splited[0]) < 0)) { return; }
            if ((Convert.ToInt32(splited[1]) > 999)) { return; }
            if ((Convert.ToInt32(splited[1]) < 0)) { return; }

            int slot = Convert.ToInt32(splited[0]);

            if (PStruct.invslot[index, slot].item == Globals.NullItem) { SendData.Send_MsgToPlayer(index, "Item inexistente.", Globals.ColorRed, Globals.Msg_Type_Server); return; }

            string[] splititem = PStruct.invslot[index, slot].item.Split(',');

            int value = Convert.ToInt32(splited[1]);

            int itemNum = Convert.ToInt32(splititem[1]);
            int itemType = Convert.ToInt32(splititem[0]);
            int itemValue = Convert.ToInt32(splititem[2]);
            int itemRefin = Convert.ToInt32(splititem[3]);
            int itemExp = Convert.ToInt32(splititem[4]);

            if (itemValue < value)
            {
                SendData.Send_MsgToPlayer(index, "Você não tem a quantidade.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            if (!PStruct.GiveBankItem(index, itemType, itemNum, value, itemRefin, itemExp)) { SendData.Send_MsgToPlayer(index, "Falha ao entregar item.", Globals.ColorRed, Globals.Msg_Type_Server); return; }
            if (!PStruct.PickItem(index, itemType, itemNum, value, itemRefin)) { SendData.Send_MsgToPlayer(index, "Falha ao entregar item.", Globals.ColorRed, Globals.Msg_Type_Server); return; }

            SendData.Send_BankSlots(index);
            SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
        }
        static void ReceivedAddPShop(int index, string data)
        {
            string[] splited = data.Replace("<80>", "").Split(';');

            if (splited.Length != 3) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) > Globals.MaxInvSlot - 1)) { return; }
            if ((Convert.ToInt32(splited[0]) < 0)) { return; }
            if ((Convert.ToInt32(splited[1]) > 999)) { return; }
            if ((Convert.ToInt32(splited[1]) < 0)) { return; }
            if ((Convert.ToInt32(splited[2]) < 0)) { return; }
            if ((Convert.ToInt32(splited[2]) > 999999999)) { return; }

            int price = Convert.ToInt32(splited[2]);
            int slot = Convert.ToInt32(splited[0]);

            if (PStruct.invslot[index, slot].item == Globals.NullItem) { SendData.Send_MsgToPlayer(index, "Item inexistente.", Globals.ColorRed, Globals.Msg_Type_Server); return; }

            string[] splititem = PStruct.invslot[index, slot].item.Split(',');

            int value = Convert.ToInt32(splited[1]);

            int itemNum = Convert.ToInt32(splititem[1]);
            int itemType = Convert.ToInt32(splititem[0]);
            int itemValue = Convert.ToInt32(splititem[2]);
            int itemRefin = Convert.ToInt32(splititem[3]);
            int itemExp = Convert.ToInt32(splititem[4]);

            if (itemValue < value)
            {
                SendData.Send_MsgToPlayer(index, "Você não tem a quantidade.", Globals.ColorRed, Globals.Msg_Type_Server);
                return;
            }

            if (!PStruct.GivePShopItem(index, itemType, itemNum, value, itemRefin, price, itemExp)) { SendData.Send_MsgToPlayer(index, "Falha ao entregar item, talvez não haja espaço.", Globals.ColorRed, Globals.Msg_Type_Server); return; }
            if (!PStruct.PickItem(index, itemType, itemNum, value, itemRefin)) { SendData.Send_MsgToPlayer(index, "Falha ao entregar item, talvez não haja espaço.", Globals.ColorRed, Globals.Msg_Type_Server); return; }

            SendData.Send_PShopSlots(index, index);
            SendData.Send_InvSlots(index, PStruct.player[index].SelectedChar);
        }
        public static void ReceivedCompleteAction(int index, string data)
        {
            string[] splited = data.Replace("<59>", "").Split(';');

            if (splited.Length != 1) { return; }
            if (!IsNumeric(splited[0])) { return; }
            if ((Convert.ToInt32(splited[0]) < 0)) { return; }
            if ((Convert.ToInt32(splited[0]) > Globals.MaxQuestGivers - 1)) { return; }

            int questgiver = Convert.ToInt32(splited[0]);
            int map = PStruct.character[index, PStruct.player[index].SelectedChar].Map;
            int x = PStruct.character[index, PStruct.player[index].SelectedChar].X;
            int y = PStruct.character[index, PStruct.player[index].SelectedChar].Y;

            int quest = PStruct.GetActualPlayerQuestPerGiver(index, questgiver);

            int actionmap;
            int actionx;
            int actiony;

            if (MStruct.quest[questgiver, quest].actionvalue > 0)
            {
                for (int a = 1; a <= MStruct.quest[questgiver, quest].actionvalue; a++)
                {
                    if (MStruct.questactions[questgiver, quest, a].type == 1)
                    {
                        if (!PStruct.questactions[index, questgiver, quest, a].actiondone)
                        {
                            actionmap = Convert.ToInt32(MStruct.questactions[questgiver, quest, a].data.Split(',')[0]);

                            if (actionmap == map)
                            {
                                actionx = Convert.ToInt32(MStruct.questactions[questgiver, quest, a].data.Split(',')[1]);
                                actiony = Convert.ToInt32(MStruct.questactions[questgiver, quest, a].data.Split(',')[2]);

                                if ((PStruct.character[index, PStruct.player[index].SelectedChar].Y == actiony) && (PStruct.character[index, PStruct.player[index].SelectedChar].X == actionx))
                                {
                                    if (PStruct.queststatus[index, questgiver, quest].status == 1)
                                    {
                                        SendData.Send_ActionMsg(index, "Completou uma ação!", Globals.ColorGreen, PStruct.character[index, PStruct.player[index].SelectedChar].X, PStruct.character[index, PStruct.player[index].SelectedChar].Y, 1, 0);
                                        PStruct.questactions[index, questgiver, quest, a].actiondone = true;
                                        SendData.Send_QuestAction(index, questgiver, quest, a);
                                        return;
                                    }
                                }

                                if ((PStruct.character[index, PStruct.player[index].SelectedChar].Y == actiony) && (PStruct.character[index, PStruct.player[index].SelectedChar].X + 1 == actionx))
                                {
                                    if (PStruct.queststatus[index, questgiver, quest].status == 1)
                                    {
                                        SendData.Send_ActionMsg(index, "Completou uma ação!", Globals.ColorGreen, PStruct.character[index, PStruct.player[index].SelectedChar].X, PStruct.character[index, PStruct.player[index].SelectedChar].Y, 1, 0);
                                        PStruct.questactions[index, questgiver, quest, a].actiondone = true;
                                        SendData.Send_QuestAction(index, questgiver, quest, a);
                                        return;
                                    }
                                }

                                if ((PStruct.character[index, PStruct.player[index].SelectedChar].Y == actiony) && (PStruct.character[index, PStruct.player[index].SelectedChar].X - 1 == actionx))
                                {
                                    if (PStruct.queststatus[index, questgiver, quest].status == 1)
                                    {
                                        SendData.Send_ActionMsg(index, "Completou uma ação!", Globals.ColorGreen, PStruct.character[index, PStruct.player[index].SelectedChar].X, PStruct.character[index, PStruct.player[index].SelectedChar].Y, 1, 0);
                                        PStruct.questactions[index, questgiver, quest, a].actiondone = true;
                                        SendData.Send_QuestAction(index, questgiver, quest, a);
                                        return;
                                    }
                                }

                                if ((PStruct.character[index, PStruct.player[index].SelectedChar].Y + 1 == actiony) && (PStruct.character[index, PStruct.player[index].SelectedChar].X == actionx))
                                {
                                    if (PStruct.queststatus[index, questgiver, quest].status == 1)
                                    {
                                        SendData.Send_ActionMsg(index, "Completou uma ação!", Globals.ColorGreen, PStruct.character[index, PStruct.player[index].SelectedChar].X, PStruct.character[index, PStruct.player[index].SelectedChar].Y, 1, 0);
                                        PStruct.questactions[index, questgiver, quest, a].actiondone = true;
                                        SendData.Send_QuestAction(index, questgiver, quest, a);
                                        return;
                                    }
                                }

                                if ((PStruct.character[index, PStruct.player[index].SelectedChar].Y - 1 == actiony) && (PStruct.character[index, PStruct.player[index].SelectedChar].X == actionx))
                                {
                                    if (PStruct.queststatus[index, questgiver, quest].status == 1)
                                    {
                                        SendData.Send_ActionMsg(index, "Completou uma ação!", Globals.ColorGreen, PStruct.character[index, PStruct.player[index].SelectedChar].X, PStruct.character[index, PStruct.player[index].SelectedChar].Y, 1, 0);
                                        PStruct.questactions[index, questgiver, quest, a].actiondone = true;
                                        SendData.Send_QuestAction(index, questgiver, quest, a);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }


        }
        public static void ReceivedRespawn(int index)
        {
            if (PStruct.tempplayer[index].isDead)
            {
                PStruct.tempplayer[index].isDead = false;
                int mapnum = PStruct.character[index, PStruct.player[index].SelectedChar].Map;
                int bootmap = PStruct.character[index, PStruct.player[index].SelectedChar].BootMap;
                byte bootx = PStruct.character[index, PStruct.player[index].SelectedChar].BootX;
                byte booty = PStruct.character[index, PStruct.player[index].SelectedChar].BootY;

                PStruct.PlayerWarp(index, bootmap, bootx, booty);

                PStruct.tempplayer[index].Vitality = 1;
                if (PStruct.tempplayer[index].Party > 0)
                {
                    SendData.Send_PlayerVitalityToParty(PStruct.tempplayer[index].Party, index, PStruct.tempplayer[index].Vitality);
                }
                SendData.Send_PlayerVitalityToMap(PStruct.character[index, PStruct.player[index].SelectedChar].Map, index, PStruct.tempplayer[index].Vitality);
                SendData.Send_PlayerDeathTo(index, index);
            }
        }
        public static void ReceivedShop(int index)
        {
            for (int i = 1; i < Globals.Max_Shops; i++)
            {
                if (ShopStruct.shop[i].map == PStruct.character[index, PStruct.player[index].SelectedChar].Map)
                {
                    switch (PStruct.character[index, PStruct.player[index].SelectedChar].Dir)
                    {
                        case 8:
                            if ((ShopStruct.shop[i].y == PStruct.character[index, PStruct.player[index].SelectedChar].Y - 1) && (ShopStruct.shop[i].x == Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].X)))
                            {
                                SendData.Send_Shop(index, i);
                                PStruct.tempplayer[index].InShop = i;
                                return;
                            }
                            break;
                        case 2:
                            if ((ShopStruct.shop[i].y == Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Y) + 1) && (ShopStruct.shop[i].x == Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].X)))
                            {
                                SendData.Send_Shop(index, i);
                                PStruct.tempplayer[index].InShop = i;
                                return;
                            }
                            break;
                        case 4:
                            if ((ShopStruct.shop[i].y == Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Y)) && (ShopStruct.shop[i].x == Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].X - 1)))
                            {
                                SendData.Send_Shop(index, i);
                                PStruct.tempplayer[index].InShop = i;
                                return;
                            }
                            break;
                        case 6:
                            if ((ShopStruct.shop[i].y == Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].Y)) && (ShopStruct.shop[i].x == Convert.ToInt32(PStruct.character[index, PStruct.player[index].SelectedChar].X + 1)))
                            {
                                SendData.Send_Shop(index, i);
                                PStruct.tempplayer[index].InShop = i;
                                return;
                            }
                            break;
                        default:
                            WinsockAsync.Log(String.Format("Tentativa de abrir loja inexistente."));
                            break;
                    }

                }
            } 
        }
    }
}

