using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace ACESERVER
{
    // State object for reading client data asynchronously
    public class StateObject
    {
        // Client  socket.
        public Socket Async {get ; set;}
        // Size of receive buffer.
        public const int BufferSize = 1202048;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
        //Client index
        public int clientid { get; set; }
        public StateObject(Socket t, int i) { Async = t; clientid = i; }
        //
        public bool IsConnected { get; set; }
        public int Index { get; set; }
    }
    class WinsockAsync
    {
        public static Socket listener;
        public static List<StateObject> Clients;
        // Thread signal.
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        public static Random rdn;
        public static string Motd = "Bem vindo a Wing Of Misadventure!";
        public static string[] connected = new string[] { };
        //public void Send(Socket sck, string message, Encoding encoding);
        static ConsoleEventDelegate event_handler;   // Keeps it from getting garbage collected
        // Pinvoke
        private delegate bool ConsoleEventDelegate(int eventType);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);

        static void Main(string[] args)
        {
           //PStruct.InitializePlayerArrays();
            //Database.ResetAndGiveExp();
            
            Log("Iniciando servidor...");
            Log("Cliente definido...");
            Log("");
            Log("Inicializando Array's dos jogadores...");
            PStruct.InitializePlayerArrays();
            Log("Inicializando Array's das guildas...");
            GStruct.InitializeGuildArrays();
            Log("Array's inicializadas.");
            Log("");
            Log("Carregando Inimigos...");
            Database.LoadEnemies();
            Log("Carregado.");
            Log("Carregando Mapas, Missões e Monstros...");
            Database.LoadMaps();
            Log("Carregado.");
            Log("Carregando Itens...");
            Database.LoadItems();
            Log("Carregado.");
            Log("Carregando Armas...");
            Database.LoadWeapons();
            Log("Carregado.");
            Log("Carregando Armaduras...");
            Database.LoadArmors();
            Log("Carregado.");
            Log("Carregando Habilidades...");
            Database.LoadSkills();
            Log("Carregado.");
            Log("Carregando Lojas...");
            Database.LoadShops();
            //Manual, no editor, sorry :/
            ShopStruct.shop[1].map = 3;
            ShopStruct.shop[1].x = 9;
            ShopStruct.shop[1].y = 7;
            ShopStruct.shop[1].item_count = 2;

            ShopStruct.shopitem[1, 1].type = 1;
            ShopStruct.shopitem[1, 1].num = 1;
            ShopStruct.shopitem[1, 1].value = 1;
            ShopStruct.shopitem[1, 1].refin = 0;
            ShopStruct.shopitem[1, 1].price = 75;

            ShopStruct.shopitem[1, 2].type = 1;
            ShopStruct.shopitem[1, 2].num = 2;
            ShopStruct.shopitem[1, 2].value = 1;
            ShopStruct.shopitem[1, 2].refin = 0;
            ShopStruct.shopitem[1, 2].price = 75;

            //Manual, no editor, sorry :/
            ShopStruct.shop[2].map = 132;
            ShopStruct.shop[2].x = 13;
            ShopStruct.shop[2].y = 7;
            ShopStruct.shop[2].item_count = 1;

            ShopStruct.shopitem[2, 1].type = 1;
            ShopStruct.shopitem[2, 1].num = 50;
            ShopStruct.shopitem[2, 1].value = 1;
            ShopStruct.shopitem[2, 1].refin = 0;
            ShopStruct.shopitem[2, 1].price = 25;

            //Manual, no editor, sorry :/
            ShopStruct.shop[3].map = 136;
            ShopStruct.shop[3].x = 12;
            ShopStruct.shop[3].y = 10;
            ShopStruct.shop[3].item_count = 1;

            ShopStruct.shopitem[3, 1].type = 2;
            ShopStruct.shopitem[3, 1].num = 28;
            ShopStruct.shopitem[3, 1].value = 1;
            ShopStruct.shopitem[3, 1].refin = 0;
            ShopStruct.shopitem[3, 1].price = 1;// 225;

            //Manual, no editor, sorry :/
            ShopStruct.shop[4].map = 77;
            ShopStruct.shop[4].x = 13;
            ShopStruct.shop[4].y = 3;
            ShopStruct.shop[4].item_count = 1;

            ShopStruct.shopitem[4, 1].type = 1;
            ShopStruct.shopitem[4, 1].num = 5;
            ShopStruct.shopitem[4, 1].value = 1;
            ShopStruct.shopitem[4, 1].refin = 0;
            ShopStruct.shopitem[4, 1].price = 100;// 225;

            //Manual, no editor, sorry :/
            ShopStruct.shop[5].map = 148;
            ShopStruct.shop[5].x = 9;
            ShopStruct.shop[5].y = 7;
            ShopStruct.shop[5].item_count = 1;

            ShopStruct.shopitem[5, 1].type = 2;
            ShopStruct.shopitem[5, 1].num = 31;
            ShopStruct.shopitem[5, 1].value = 1;
            ShopStruct.shopitem[5, 1].refin = 0;
            ShopStruct.shopitem[5, 1].price = 1;// 225;

            //Manual, no editor, sorry :/
            ShopStruct.shop[6].map = 149;
            ShopStruct.shop[6].x = 10;
            ShopStruct.shop[6].y = 6;
            ShopStruct.shop[6].item_count = 1;

            ShopStruct.shopitem[6, 1].type = 1;
            ShopStruct.shopitem[6, 1].num = 47;
            ShopStruct.shopitem[6, 1].value = 1;
            ShopStruct.shopitem[6, 1].refin = 0;
            ShopStruct.shopitem[6, 1].price = 50;// 225;

            //Manual, no editor, sorry :/
            ShopStruct.shop[7].map = 0;
            ShopStruct.shop[7].x = 0;
            ShopStruct.shop[7].y = 0;
            ShopStruct.shop[7].item_count = 3;

            ShopStruct.shopitem[7, 1].type = 1;
            ShopStruct.shopitem[7, 1].num = 68;
            ShopStruct.shopitem[7, 1].value = 1;
            ShopStruct.shopitem[7, 1].refin = 0;
            ShopStruct.shopitem[7, 1].price = 5;// 225;

            ShopStruct.shopitem[7, 2].type = 1;
            ShopStruct.shopitem[7, 2].num = 70;
            ShopStruct.shopitem[7, 2].value = 1;
            ShopStruct.shopitem[7, 2].refin = 0;
            ShopStruct.shopitem[7, 2].price = 10;// 225;

            ShopStruct.shopitem[7, 3].type = 1;
            ShopStruct.shopitem[7, 3].num = 71;
            ShopStruct.shopitem[7, 3].value = 1;
            ShopStruct.shopitem[7, 3].refin = 0;
            ShopStruct.shopitem[7, 3].price = 10;// 225;

            //Manual, no editor, sorry :/
            ShopStruct.shop[8].map = 13;
            ShopStruct.shop[8].x = 5;
            ShopStruct.shop[8].y = 7;
            ShopStruct.shop[8].item_count = 1;

            ShopStruct.shopitem[8, 1].type = 1;
            ShopStruct.shopitem[8, 1].num = 69;
            ShopStruct.shopitem[8, 1].value = 1;
            ShopStruct.shopitem[8, 1].refin = 0;
            ShopStruct.shopitem[8, 1].price = 500;// 225;

            //Manual, no editor, sorry :/
            ShopStruct.shop[9].map = 167;
            ShopStruct.shop[9].x = 11;
            ShopStruct.shop[9].y = 6;
            ShopStruct.shop[9].item_count = 11;

            ShopStruct.shopitem[9, 1].type = 2;
            ShopStruct.shopitem[9, 1].num = 2;
            ShopStruct.shopitem[9, 1].value = 1;
            ShopStruct.shopitem[9, 1].refin = 0;
            ShopStruct.shopitem[9, 1].price = 209;// 225;

            ShopStruct.shopitem[9, 2].type = 2;
            ShopStruct.shopitem[9, 2].num = 3;
            ShopStruct.shopitem[9, 2].value = 1;
            ShopStruct.shopitem[9, 2].refin = 0;
            ShopStruct.shopitem[9, 2].price = 477;// 225;

            ShopStruct.shopitem[9, 3].type = 2;
            ShopStruct.shopitem[9, 3].num = 4;
            ShopStruct.shopitem[9, 3].value = 1;
            ShopStruct.shopitem[9, 3].refin = 0;
            ShopStruct.shopitem[9, 3].price = 990;// 225;

            ShopStruct.shopitem[9, 4].type = 2;
            ShopStruct.shopitem[9, 4].num = 5;
            ShopStruct.shopitem[9, 4].value = 1;
            ShopStruct.shopitem[9, 4].refin = 0;
            ShopStruct.shopitem[9, 4].price = 1650;// 225;

            ShopStruct.shopitem[9, 5].type = 2;
            ShopStruct.shopitem[9, 5].num = 6;
            ShopStruct.shopitem[9, 5].value = 1;
            ShopStruct.shopitem[9, 5].refin = 0;
            ShopStruct.shopitem[9, 5].price = 3350;// 225;

            ShopStruct.shopitem[9, 6].type = 2;
            ShopStruct.shopitem[9, 6].num = 7;
            ShopStruct.shopitem[9, 6].value = 1;
            ShopStruct.shopitem[9, 6].refin = 0;
            ShopStruct.shopitem[9, 6].price = 5450;// 225;

            ShopStruct.shopitem[9, 7].type = 2;
            ShopStruct.shopitem[9, 7].num = 8;
            ShopStruct.shopitem[9, 7].value = 1;
            ShopStruct.shopitem[9, 7].refin = 0;
            ShopStruct.shopitem[9, 7].price = 8220;// 225;

            ShopStruct.shopitem[9, 8].type = 2;
            ShopStruct.shopitem[9, 8].num = 8;
            ShopStruct.shopitem[9, 8].value = 1;
            ShopStruct.shopitem[9, 8].refin = 0;
            ShopStruct.shopitem[9, 8].price = 10130;// 225;

            ShopStruct.shopitem[9, 9].type = 2;
            ShopStruct.shopitem[9, 9].num = 9;
            ShopStruct.shopitem[9, 9].value = 1;
            ShopStruct.shopitem[9, 9].refin = 0;
            ShopStruct.shopitem[9, 9].price = 13630;// 225;

            ShopStruct.shopitem[9, 10].type = 2;
            ShopStruct.shopitem[9, 10].num = 10;
            ShopStruct.shopitem[9, 10].value = 1;
            ShopStruct.shopitem[9, 10].refin = 0;
            ShopStruct.shopitem[9, 10].price = 17780;// 225;

            ShopStruct.shopitem[9, 11].type = 2;
            ShopStruct.shopitem[9, 11].num = 11;
            ShopStruct.shopitem[9, 11].value = 1;
            ShopStruct.shopitem[9, 11].refin = 0;
            ShopStruct.shopitem[9, 11].price = 23180;// 225;


            //Manual, no editor, sorry :/
            ShopStruct.shop[10].map = 168;
            ShopStruct.shop[10].x = 11;
            ShopStruct.shop[10].y = 6;
            ShopStruct.shop[10].item_count = 12;

            ShopStruct.shopitem[10, 1].type = 3;
            ShopStruct.shopitem[10, 1].num = 2;
            ShopStruct.shopitem[10, 1].value = 1;
            ShopStruct.shopitem[10, 1].refin = 0;
            ShopStruct.shopitem[10, 1].price = 189;// 225;

            ShopStruct.shopitem[10, 2].type = 3;
            ShopStruct.shopitem[10, 2].num = 3;
            ShopStruct.shopitem[10, 2].value = 1;
            ShopStruct.shopitem[10, 2].refin = 0;
            ShopStruct.shopitem[10, 2].price = 389;// 225;

            ShopStruct.shopitem[10, 3].type = 3;
            ShopStruct.shopitem[10, 3].num = 4;
            ShopStruct.shopitem[10, 3].value = 1;
            ShopStruct.shopitem[10, 3].refin = 0;
            ShopStruct.shopitem[10, 3].price = 756;// 225;

            ShopStruct.shopitem[10, 4].type = 3;
            ShopStruct.shopitem[10, 4].num = 5;
            ShopStruct.shopitem[10, 4].value = 1;
            ShopStruct.shopitem[10, 4].refin = 0;
            ShopStruct.shopitem[10, 4].price = 1229;// 225;

            ShopStruct.shopitem[10, 5].type = 3;
            ShopStruct.shopitem[10, 5].num = 14;
            ShopStruct.shopitem[10, 5].value = 1;
            ShopStruct.shopitem[10, 5].refin = 0;
            ShopStruct.shopitem[10, 5].price = 4663;// 225;

            ShopStruct.shopitem[10, 6].type = 3;
            ShopStruct.shopitem[10, 6].num = 15;
            ShopStruct.shopitem[10, 6].value = 1;
            ShopStruct.shopitem[10, 6].refin = 0;
            ShopStruct.shopitem[10, 6].price = 7224;// 225;

            ShopStruct.shopitem[10, 7].type = 3;
            ShopStruct.shopitem[10, 7].num = 16;
            ShopStruct.shopitem[10, 7].value = 1;
            ShopStruct.shopitem[10, 7].refin = 0;
            ShopStruct.shopitem[10, 7].price = 10101;// 225;

            ShopStruct.shopitem[10, 8].type = 3;
            ShopStruct.shopitem[10, 8].num = 17;
            ShopStruct.shopitem[10, 8].value = 1;
            ShopStruct.shopitem[10, 8].refin = 0;
            ShopStruct.shopitem[10, 8].price = 14101;// 225;

            ShopStruct.shopitem[10, 9].type = 3;
            ShopStruct.shopitem[10, 9].num = 18;
            ShopStruct.shopitem[10, 9].value = 1;
            ShopStruct.shopitem[10, 9].refin = 0;
            ShopStruct.shopitem[10, 9].price = 19243;// 225;

            ShopStruct.shopitem[10, 10].type = 3;
            ShopStruct.shopitem[10, 10].num = 22;
            ShopStruct.shopitem[10, 10].value = 1;
            ShopStruct.shopitem[10, 10].refin = 0;
            ShopStruct.shopitem[10, 10].price = 22342;// 225;

            ShopStruct.shopitem[10, 11].type = 3;
            ShopStruct.shopitem[10, 11].num = 23;
            ShopStruct.shopitem[10, 11].value = 1;
            ShopStruct.shopitem[10, 11].refin = 0;
            ShopStruct.shopitem[10, 11].price = 26347;// 225;

            ShopStruct.shopitem[10, 12].type = 3;
            ShopStruct.shopitem[10, 12].num = 24;
            ShopStruct.shopitem[10, 12].value = 1;
            ShopStruct.shopitem[10, 12].refin = 0;
            ShopStruct.shopitem[10, 12].price = 32345;// 225;

            //Manual, no editor, sorry :/
            ShopStruct.shop[11].map = 174;
            ShopStruct.shop[11].x = 11;
            ShopStruct.shop[11].y = 6;
            ShopStruct.shop[11].item_count = 6;

            ShopStruct.shopitem[11, 1].type = 2;
            ShopStruct.shopitem[11, 1].num = 34;
            ShopStruct.shopitem[11, 1].value = 1;
            ShopStruct.shopitem[11, 1].refin = 0;
            ShopStruct.shopitem[11, 1].price = 500;// 225;

            ShopStruct.shopitem[11, 2].type = 2;
            ShopStruct.shopitem[11, 2].num = 32;
            ShopStruct.shopitem[11, 2].value = 1;
            ShopStruct.shopitem[11, 2].refin = 0;
            ShopStruct.shopitem[11, 2].price = 1200;// 225;
            
            ShopStruct.shopitem[11, 3].type = 2;
            ShopStruct.shopitem[11, 3].num = 33;
            ShopStruct.shopitem[11, 3].value = 1;
            ShopStruct.shopitem[11, 3].refin = 0;
            ShopStruct.shopitem[11, 3].price = 2100;// 225;
            
            ShopStruct.shopitem[11, 4].type = 2;
            ShopStruct.shopitem[11, 4].num = 35;
            ShopStruct.shopitem[11, 4].value = 1;
            ShopStruct.shopitem[11, 4].refin = 0;
            ShopStruct.shopitem[11, 4].price = 5000;// 225;

            ShopStruct.shopitem[11, 5].type = 2;
            ShopStruct.shopitem[11, 5].num = 36;
            ShopStruct.shopitem[11, 5].value = 1;
            ShopStruct.shopitem[11, 5].refin = 0;
            ShopStruct.shopitem[11, 5].price = 8000;// 225;

            ShopStruct.shopitem[11, 6].type = 2;
            ShopStruct.shopitem[11, 6].num = 37;
            ShopStruct.shopitem[11, 6].value = 1;
            ShopStruct.shopitem[11, 6].refin = 0;
            ShopStruct.shopitem[11, 6].price = 14000; //225;

            //Manual, no editor, sorry :/
            ShopStruct.shop[12].map = 175;
            ShopStruct.shop[12].x = 11;
            ShopStruct.shop[12].y = 6;
            ShopStruct.shop[12].item_count = 11;

            ShopStruct.shopitem[12, 1].type = 3;
            ShopStruct.shopitem[12, 1].num = 7;
            ShopStruct.shopitem[12, 1].value = 1;
            ShopStruct.shopitem[12, 1].refin = 0;
            ShopStruct.shopitem[12, 1].price = 300;// 225;

            ShopStruct.shopitem[12, 2].type = 3;
            ShopStruct.shopitem[12, 2].num = 8;
            ShopStruct.shopitem[12, 2].value = 1;
            ShopStruct.shopitem[12, 2].refin = 0;
            ShopStruct.shopitem[12, 2].price = 600;// 225;

            ShopStruct.shopitem[12, 3].type = 3;
            ShopStruct.shopitem[12, 3].num = 9;
            ShopStruct.shopitem[12, 3].value = 1;
            ShopStruct.shopitem[12, 3].refin = 0;
            ShopStruct.shopitem[12, 3].price = 1100;// 225;

            ShopStruct.shopitem[12, 4].type = 3;
            ShopStruct.shopitem[12, 4].num = 10;
            ShopStruct.shopitem[12, 4].value = 1;
            ShopStruct.shopitem[12, 4].refin = 0;
            ShopStruct.shopitem[12, 4].price = 1800;// 225;

            ShopStruct.shopitem[12, 5].type = 3;
            ShopStruct.shopitem[12, 5].num = 11;
            ShopStruct.shopitem[12, 5].value = 1;
            ShopStruct.shopitem[12, 5].refin = 0;
            ShopStruct.shopitem[12, 5].price = 2500;// 225;

            ShopStruct.shopitem[12, 6].type = 3;
            ShopStruct.shopitem[12, 6].num = 12;
            ShopStruct.shopitem[12, 6].value = 1;
            ShopStruct.shopitem[12, 6].refin = 0;
            ShopStruct.shopitem[12, 6].price = 4000;// 225;

            ShopStruct.shopitem[12, 7].type = 3;
            ShopStruct.shopitem[12, 7].num = 13;
            ShopStruct.shopitem[12, 7].value = 1;
            ShopStruct.shopitem[12, 7].refin = 0;
            ShopStruct.shopitem[12, 7].price = 6200;// 225;

            ShopStruct.shopitem[12, 8].type = 3;
            ShopStruct.shopitem[12, 8].num = 25;
            ShopStruct.shopitem[12, 8].value = 1;
            ShopStruct.shopitem[12, 8].refin = 0;
            ShopStruct.shopitem[12, 8].price = 9300;// 225;

            ShopStruct.shopitem[12, 9].type = 3;
            ShopStruct.shopitem[12, 9].num = 26;
            ShopStruct.shopitem[12, 9].value = 1;
            ShopStruct.shopitem[12, 9].refin = 0;
            ShopStruct.shopitem[12, 9].price = 13800;// 225;

            ShopStruct.shopitem[12, 10].type = 3;
            ShopStruct.shopitem[12, 10].num = 27;
            ShopStruct.shopitem[12, 10].value = 1;
            ShopStruct.shopitem[12, 10].refin = 0;
            ShopStruct.shopitem[12, 10].price = 17100;// 225;

            ShopStruct.shopitem[12, 11].type = 3;
            ShopStruct.shopitem[12, 11].num = 30;
            ShopStruct.shopitem[12, 11].value = 1;
            ShopStruct.shopitem[12, 11].refin = 0;
            ShopStruct.shopitem[12, 11].price = 22400;// 225;

            //Manual, no editor, sorry :/
            ShopStruct.shop[13].map = 170;
            ShopStruct.shop[13].x = 11;
            ShopStruct.shop[13].y = 6;
            ShopStruct.shop[13].item_count = 7;

            ShopStruct.shopitem[13, 1].type = 1;
            ShopStruct.shopitem[13, 1].num = 1;
            ShopStruct.shopitem[13, 1].value = 1;
            ShopStruct.shopitem[13, 1].refin = 0;
            ShopStruct.shopitem[13, 1].price = 75;// 225;

            ShopStruct.shopitem[13, 2].type = 1;
            ShopStruct.shopitem[13, 2].num = 2;
            ShopStruct.shopitem[13, 2].value = 1;
            ShopStruct.shopitem[13, 2].refin = 0;
            ShopStruct.shopitem[13, 2].price = 75;// 225;

            ShopStruct.shopitem[13, 3].type = 1;
            ShopStruct.shopitem[13, 3].num = 69;
            ShopStruct.shopitem[13, 3].value = 1;
            ShopStruct.shopitem[13, 3].refin = 0;
            ShopStruct.shopitem[13, 3].price = 500;// 225;

            ShopStruct.shopitem[13, 4].type = 1;
            ShopStruct.shopitem[13, 4].num = 73;
            ShopStruct.shopitem[13, 4].value = 1;
            ShopStruct.shopitem[13, 4].refin = 0;
            ShopStruct.shopitem[13, 4].price = 200;// 225;

            ShopStruct.shopitem[13, 5].type = 1;
            ShopStruct.shopitem[13, 5].num = 72;
            ShopStruct.shopitem[13, 5].value = 1;
            ShopStruct.shopitem[13, 5].refin = 0;
            ShopStruct.shopitem[13, 5].price = 700;// 225;

            ShopStruct.shopitem[13, 6].type = 1;
            ShopStruct.shopitem[13, 6].num = 74;
            ShopStruct.shopitem[13, 6].value = 1;
            ShopStruct.shopitem[13, 6].refin = 0;
            ShopStruct.shopitem[13, 6].price = 500;// 225;

            ShopStruct.shopitem[13, 7].type = 1;
            ShopStruct.shopitem[13, 7].num = 75;
            ShopStruct.shopitem[13, 7].value = 1;
            ShopStruct.shopitem[13, 7].refin = 0;
            ShopStruct.shopitem[13, 7].price = 1000;// 225;

            //Manual, no editor, sorry :/
            ShopStruct.shop[14].map = 169;
            ShopStruct.shop[14].x = 11;
            ShopStruct.shop[14].y = 6;
            ShopStruct.shop[14].item_count = 1;

            ShopStruct.shopitem[14, 1].type = 1;
            ShopStruct.shopitem[14, 1].num = 68;
            ShopStruct.shopitem[14, 1].value = 1;
            ShopStruct.shopitem[14, 1].refin = 0;
            ShopStruct.shopitem[14, 1].price = 100000;// 225;


            //Manual, no editor, sorry :/
            ShopStruct.shop[15].map = 219;
            ShopStruct.shop[15].x = 11;
            ShopStruct.shop[15].y = 6;
            ShopStruct.shop[15].item_count = 11;

            ShopStruct.shopitem[15, 1].type = 3;
            ShopStruct.shopitem[15, 1].num = 7;
            ShopStruct.shopitem[15, 1].value = 1;
            ShopStruct.shopitem[15, 1].refin = 0;
            ShopStruct.shopitem[15, 1].price = 300;// 225;

            ShopStruct.shopitem[15, 2].type = 3;
            ShopStruct.shopitem[15, 2].num = 8;
            ShopStruct.shopitem[15, 2].value = 1;
            ShopStruct.shopitem[15, 2].refin = 0;
            ShopStruct.shopitem[15, 2].price = 600;// 225;

            ShopStruct.shopitem[15, 3].type = 3;
            ShopStruct.shopitem[15, 3].num = 9;
            ShopStruct.shopitem[15, 3].value = 1;
            ShopStruct.shopitem[15, 3].refin = 0;
            ShopStruct.shopitem[15, 3].price = 1100;// 225;

            ShopStruct.shopitem[15, 4].type = 3;
            ShopStruct.shopitem[15, 4].num = 10;
            ShopStruct.shopitem[15, 4].value = 1;
            ShopStruct.shopitem[15, 4].refin = 0;
            ShopStruct.shopitem[15, 4].price = 1800;// 225;

            ShopStruct.shopitem[15, 5].type = 3;
            ShopStruct.shopitem[15, 5].num = 11;
            ShopStruct.shopitem[15, 5].value = 1;
            ShopStruct.shopitem[15, 5].refin = 0;
            ShopStruct.shopitem[15, 5].price = 2500;// 225;

            ShopStruct.shopitem[15, 6].type = 3;
            ShopStruct.shopitem[15, 6].num = 12;
            ShopStruct.shopitem[15, 6].value = 1;
            ShopStruct.shopitem[15, 6].refin = 0;
            ShopStruct.shopitem[15, 6].price = 4000;// 225;

            ShopStruct.shopitem[15, 7].type = 3;
            ShopStruct.shopitem[15, 7].num = 13;
            ShopStruct.shopitem[15, 7].value = 1;
            ShopStruct.shopitem[15, 7].refin = 0;
            ShopStruct.shopitem[15, 7].price = 6200;// 225;

            ShopStruct.shopitem[15, 8].type = 3;
            ShopStruct.shopitem[15, 8].num = 25;
            ShopStruct.shopitem[15, 8].value = 1;
            ShopStruct.shopitem[15, 8].refin = 0;
            ShopStruct.shopitem[15, 8].price = 9300;// 225;

            ShopStruct.shopitem[15, 9].type = 3;
            ShopStruct.shopitem[15, 9].num = 26;
            ShopStruct.shopitem[15, 9].value = 1;
            ShopStruct.shopitem[15, 9].refin = 0;
            ShopStruct.shopitem[15, 9].price = 13800;// 225;

            ShopStruct.shopitem[15, 10].type = 3;
            ShopStruct.shopitem[15, 10].num = 27;
            ShopStruct.shopitem[15, 10].value = 1;
            ShopStruct.shopitem[15, 10].refin = 0;
            ShopStruct.shopitem[15, 10].price = 17100;// 225;

            ShopStruct.shopitem[15, 11].type = 3;
            ShopStruct.shopitem[15, 11].num = 30;
            ShopStruct.shopitem[15, 11].value = 1;
            ShopStruct.shopitem[15, 11].refin = 0;
            ShopStruct.shopitem[15, 11].price = 22400;// 225;

            //Manual, no editor, sorry :/
            ShopStruct.shop[16].map = 220;
            ShopStruct.shop[16].x = 11;
            ShopStruct.shop[16].y = 6;
            ShopStruct.shop[16].item_count = 7;

            ShopStruct.shopitem[16, 1].type = 1;
            ShopStruct.shopitem[16, 1].num = 1;
            ShopStruct.shopitem[16, 1].value = 1;
            ShopStruct.shopitem[16, 1].refin = 0;
            ShopStruct.shopitem[16, 1].price = 75;// 225;

            ShopStruct.shopitem[16, 2].type = 1;
            ShopStruct.shopitem[16, 2].num = 2;
            ShopStruct.shopitem[16, 2].value = 1;
            ShopStruct.shopitem[16, 2].refin = 0;
            ShopStruct.shopitem[16, 2].price = 75;// 225;

            ShopStruct.shopitem[16, 3].type = 1;
            ShopStruct.shopitem[16, 3].num = 69;
            ShopStruct.shopitem[16, 3].value = 1;
            ShopStruct.shopitem[16, 3].refin = 0;
            ShopStruct.shopitem[16, 3].price = 500;// 225;

            ShopStruct.shopitem[16, 4].type = 1;
            ShopStruct.shopitem[16, 4].num = 73;
            ShopStruct.shopitem[16, 4].value = 1;
            ShopStruct.shopitem[16, 4].refin = 0;
            ShopStruct.shopitem[16, 4].price = 200;// 225;

            ShopStruct.shopitem[16, 5].type = 1;
            ShopStruct.shopitem[16, 5].num = 72;
            ShopStruct.shopitem[16, 5].value = 1;
            ShopStruct.shopitem[16, 5].refin = 0;
            ShopStruct.shopitem[16, 5].price = 700;// 225;

            ShopStruct.shopitem[16, 6].type = 1;
            ShopStruct.shopitem[16, 6].num = 74;
            ShopStruct.shopitem[16, 6].value = 1;
            ShopStruct.shopitem[16, 6].refin = 0;
            ShopStruct.shopitem[16, 6].price = 500;// 225;

            ShopStruct.shopitem[16, 7].type = 1;
            ShopStruct.shopitem[16, 7].num = 75;
            ShopStruct.shopitem[16, 7].value = 1;
            ShopStruct.shopitem[16, 7].refin = 0;
            ShopStruct.shopitem[16, 7].price = 1000;// 225;

            Log("Carregado.");
            Log("Carregando Receitas...");
            Database.LoadRecipes();
            Log("Carregado.");
            Log("Carregando Guildas...");
            Database.LoadGuilds();
            Log("Carregado.");
            Log("");
            Log("Definingo váriaveis...");
            rdn = new Random();
            Log("OK.");
            Log("");
            Log("Iniciando Loop do servidor...");
            Log("Iniciando conexão TCP/IP...");

            //Lidar com fechamento
            event_handler = new ConsoleEventDelegate(ConsoleEventCallback);
            SetConsoleCtrlHandler(event_handler, true);

            //Clientes
            Clients = new List<StateObject>(100);

            // Create the thread object, passing in the Alpha.Beta method
            // via a ThreadStart delegate. This does not start the thread.
            Thread sThread = new Thread(new ThreadStart(Loops.BetaLoop));

            // Start the thread
            sThread.Start();

            //Iniciar conexão
            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.
            // The DNS name of the computer
            // running the listener is "host.contoso.com".
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = IPAddress.Any;//ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 8000);

            // Create a TCP/IP socket.
            listener = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(100);
            listener.NoDelay = true;

            // Create the thread object, passing in the Alpha.Beta method
            // via a ThreadStart delegate. This does not start the thread.
            Thread lThread = new Thread(new ThreadStart(Listen));

            // Start the thread
            lThread.Start();

            //Loop principal
            Loops.AlphaLoop();
        }
        static bool ConsoleEventCallback(int eventType)
        {
            if (eventType == 2)
            {
                for (int i = 0; i <= WinsockAsync.Clients.Count; i++)
                {
                    WinsockAsync.DisconnectUser(i);
                }
            }
            return false;
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
        public static void Listen()
        {
            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                while (true)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    // Wait until a connection is made before continuing.
                    allDone.WaitOne();

                    Thread.Sleep(10);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            //Temporizador
            Loops.Accept_Timer = Loops.TickCount.ElapsedMilliseconds;

            // Signal the main thread to continue.
            allDone.Set();

            // Socket \o/.
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            //Adicionamos ele na lista
            Clients.Add(new StateObject(handler, Clients.Count - 1));
            Clients[Clients.Count - 1].Async.NoDelay = true;
            Clients[Clients.Count - 1].IsConnected = true;
            
            //Vamos analisar qual index está disponível para o jogador
            for (int i = 0; i < 100; i++)
            {
                if (UserConnection.CheckIndex(i))
                {
                    Clients[(Clients.Count() - 1)].Index = i;
                    break;
                }
            }

            //Ele não está logado, pois se conectou agora
            PStruct.tempplayer[WinsockAsync.Clients[(WinsockAsync.Clients.Count() - 1)].Index].Logged = false;

            //Ele não está no jogo pois se conectou agora
            PStruct.tempplayer[WinsockAsync.Clients[(WinsockAsync.Clients.Count() - 1)].Index].ingame = false;

            //Zerar o Player_HighIndex pra evitar problemas
            Globals.Player_HighIndex = 0;


            //Vamos atualizar o Player_HighIndex sem frescura
            for (int i = 0; i < WinsockAsync.Clients.Count(); i++)
            {
                if (WinsockAsync.Clients[i].Index > Globals.Player_HighIndex)
                {
                    Globals.Player_HighIndex = WinsockAsync.Clients[i].Index;
                }
            }

            //Vamos atualizar o Player_HighIndex para todos os jogadores
            SendData.Send_UpdatePlayerHighIndex();

            //WinsockAnsyc.Clients[Clients.Count() - 1].ListIndex = Clients.Count() - 1;
            Log(String.Format("Cliente conectado: {0}", Clients.Count() - 1));

            // Create the state object.
            Clients[Clients.Count - 1].Async.BeginReceive(Clients[Clients.Count - 1].buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), Clients[Clients.Count - 1]);
        }
        // FIONREAD is also available as the "Available" property.
        public const int FIONREAD = 0x4004667F;

        public static int GetPendingByteCount(Socket s)
        {
            try
            {
                byte[] outValue = BitConverter.GetBytes(0);

                // Check how many bytes have been received.
                s.IOControl(FIONREAD, null, outValue);

                int bytesAvailable = BitConverter.ToInt32(outValue, 0);
                //Console.WriteLine("server has {0} bytes pending. Available property says {1}.",
                //  bytesAvailable, s.Available);

                return bytesAvailable;
            }
            catch
            {
                return 0;
            }
        }
        public static void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;
            // state = clients[i].
            // handler = clients[i].async
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.Async;


            if (handler == null) { return; }; if (!handler.Connected) { return; }
            if (state.Index < 0) { return; }

            int clientid = UserConnection.GetIndex(state.Index);

            //Se ultrapassar os limites, fechar conexão.
            if ((clientid < 0) || (clientid > Clients.Count - 1))
            {
                return;
            }

            int index = Clients[clientid].Index;
            // Clients[Clients.Count - 1].Ansyc.EndReceive(ar)

            //Obtenção da informação
            int buffersize = GetPendingByteCount(handler);

            if (buffersize > 1000)
            {
                if (PStruct.character[index, PStruct.player[index].SelectedChar].Access < 1)
                {
                    Console.WriteLine("Limite de dados por conexão excedido, jogador desconectado.");
                    return;
                }
            }
            // Ler informações do cliente
            try
            {
                //Finalizar o recebimento para começar a ler
                int bytesRead = handler.EndReceive(ar);

                //Se tiver dados para ler.
                if (bytesRead > 0)
                {
                    //Tem dados, então vamos processa-los
                    state.sb.Append(Encoding.UTF8.GetString(
                        state.buffer, 0, bytesRead));

                    // Passamos tudo para uma váriavel ler.
                    content = state.sb.ToString();

                    //Enviamos os dados para o SelectPacket
                    Server.Network.ReceiveData.SelectPacket(index, content);

                    //Limpar a stream de dados pois já foram processados.
                    state.sb.Clear();
                }

                //Voltamos a receber os dados.
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
            }
            catch (SocketException e)
            {
                if (e.ErrorCode == 10054)
                {
                    //A conexão será fechada logo pela outra thread, então apenas aguardar.
                    return;
                }
                Console.WriteLine("Houve um erro crítico em uma conexão, confira o log.");
                Database.LogError(e);
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine("Houve um erro crítico em um jogador, confira o log.");
                Database.LogError(e);
                return;
            }
        }
        public static void Send(int clientid, string data)
        {
            try
            {
                //Conectado?
                if (Clients[clientid].IsConnected)
                {
                    // Convert the string data to byte data using ASCII encoding.
                    byte[] byteData = Encoding.UTF8.GetBytes(data);

                    // Begin sending the data to the remote device.
                    Clients[clientid].Async.BeginSend(byteData, 0, byteData.Length, 0,
                        new AsyncCallback(SendCallback), Clients[clientid].Async);
                }
            }
            catch
            {
                //NO!
                Log(String.Format("Uma conexão foi forçadamente fechada"));
            }
        }
        public static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public static void ShutdownUser(int clientid)
        {
            if ((Clients.Count <= 0) || (clientid > Clients.Count - 1)) { return; }
            //Consequentemente deve ser desconectado.
            Clients[clientid].Async.Shutdown(SocketShutdown.Both);
        }

        public static void DisconnectUser(int clientid)
        {
            {
                //LOL
                if ((Clients.Count <= 0) || (clientid > Clients.Count - 1)) { return; }
                //Se estiver morto, resetar posição
                //PStruct.tempplayer[Clients[clientid].Index].isDead = false;
                
                //Sai da troca
                if (PStruct.tempplayer[Clients[clientid].Index].InTrade > 0)
                {
                    PStruct.GiveTrade(Clients[clientid].Index);
                    PStruct.GiveTrade(PStruct.tempplayer[Clients[clientid].Index].InTrade);

                    //Verificar se o jogador não se desconectou no processo
                    if (Clients[(UserConnection.GetIndex(PStruct.tempplayer[Clients[clientid].Index].InTrade))].IsConnected)
                    {
                        SendData.Send_PlayerG(PStruct.tempplayer[Clients[clientid].Index].InTrade);
                        SendData.Send_TradeClose(PStruct.tempplayer[Clients[clientid].Index].InTrade);
                        SendData.Send_InvSlots(PStruct.tempplayer[Clients[clientid].Index].InTrade, PStruct.player[PStruct.tempplayer[Clients[clientid].Index].InTrade].SelectedChar);
                    }

                    PStruct.ClearTempTrade(PStruct.tempplayer[Clients[clientid].Index].InTrade);
                    PStruct.ClearTempTrade(Clients[clientid].Index);
                }

                //Sai do Craft
                if (PStruct.tempplayer[Clients[clientid].Index].InCraft)
                {
                    for (int i = 1; i < Globals.Max_Craft; i++)
                    {
                        if (PStruct.craft[Clients[clientid].Index, i].num > 0)
                        {
                            PStruct.GiveItem(Clients[clientid].Index, PStruct.craft[Clients[clientid].Index, i].type, PStruct.craft[Clients[clientid].Index, i].num, PStruct.craft[Clients[clientid].Index, i].value, PStruct.craft[Clients[clientid].Index, i].refin, PStruct.craft[Clients[clientid].Index, i].exp);
                        }
                    }
                }

                //Salva o jogador SE PRECISAR
                if (PStruct.tempplayer[Clients[clientid].Index].ingame)
                {
                    Database.SaveCharacter(Clients[clientid].Index, PStruct.player[Clients[clientid].Index].Email, PStruct.player[Clients[clientid].Index].SelectedChar);
                    Database.SaveBank(Clients[clientid].Index);
                    Database.SaveFriendList(Clients[clientid].Index);
                }

                //Sai do grupo
                if (PStruct.tempplayer[Clients[clientid].Index].Party > 0)
                {
                    PStruct.KickParty(Clients[clientid].Index, Clients[clientid].Index, true);
                }

                //Vamos avisar ao mapa que o jogador saiu
                SendData.Send_PlayerLeft(PStruct.character[Clients[clientid].Index, PStruct.player[Clients[clientid].Index].SelectedChar].Map, Clients[clientid].Index);

                //Apagamos o banco
                Database.ClearBank(Clients[clientid].Index);

                Console.WriteLine("Jogador apagado" + clientid + Clients[clientid].Index);

                //Fecha a conexão
                Clients[clientid].Async.Close();

                //Limpa dados sobre o jogador
                Clients[clientid].Async = null;
  
                //Limpa dados temporários sobre o jogador
                Database.ClearPlayer(Clients[clientid].Index, true);
                PStruct.ClearTempPlayer(Clients[clientid].Index);

                //Limpa informações gerais da conexão
                Clients[clientid].Index = -1;

                //Remova da lista de clientes do servidor
                Clients.RemoveAt(clientid);

                //Zerar o Player_HighIndex pra evitar problemas
                Globals.Player_HighIndex = 0;

                //Vamos atualizar o Player_HighIndex sem frescura
                for (int i = 0; i < WinsockAsync.Clients.Count(); i++)
                {
                    if (Clients[i].Index > Globals.Player_HighIndex)
                    {
                        Globals.Player_HighIndex = Clients[i].Index;
                    }
                }

                //Vamos atualizar o Player_HighIndex para todos os jogadores
                SendData.Send_UpdatePlayerHighIndex();

                Log(String.Format("Cliente desconectado: {0}", clientid));
            }
        }

        public static string LoginAnswer(string[] data, int index)
        {
            string password = data[1];
            Console.WriteLine("Login:" + data[0]);
            Console.WriteLine("Senha:" + password);
            if(Database.TryLogin(index, data[0], password))
            {

                if (PlayerLogic.isPlayerConnected(data[0]) == true)
                {
                    return "c";
                }
                else
                {
                    PStruct.player[index].Email = data[0];
                    Log(String.Format("Jogador autenticado: {0} / Pass: {1}", data[0], password));
                    return "a";
                }
            }
            else { return "p"; }
        }

        public static void Log(string data, ConsoleColor c = ConsoleColor.Gray)
        {
            Console.ForegroundColor = c;
            Console.WriteLine(data);
        }

        

    }
        
}


