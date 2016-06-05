using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACESERVER
{
    class GStruct
    {
        public static GStruct.Guild[] guild = new GStruct.Guild[Globals.Max_Guilds];

        public struct Guild
        {
            public string name;
            public int level;
            public int exp;
            public int shield;
            public int hue;
            public int leader;
            public string[] memberlist;
            public string[] membersprite;
            public int[] memberhue;
            public int[] membersprite_index;
        }

        public static void InitializeGuildArrays()
        {
            for (int i = 1; i < Globals.Max_Guilds; i++)
            {
                GStruct.guild[i].memberlist = new string[Globals.Max_Guild_Members];
                GStruct.guild[i].membersprite = new string[Globals.Max_Guild_Members];
                GStruct.guild[i].memberhue = new int[Globals.Max_Guild_Members];
                GStruct.guild[i].membersprite_index = new int[Globals.Max_Guild_Members];
            }
        }


        public static int GetOpenGuildSlot()
        {
            int count = 0;
            for (int i = 1; i < Globals.Max_Guilds; i++)
            {
                if (String.IsNullOrEmpty(GStruct.guild[i].name))
                {
                    return i;
                }
            }

            return count;
        }

        public static int GetMember_Count(int guildnum)
        {
            int count = 0;
            for (int i = 1; i < Globals.Max_Guild_Members; i++)
            {
                if (!String.IsNullOrEmpty(GStruct.guild[guildnum].memberlist[i]))
                {
                    count += 1;
                }
            }

            return count;
        }

        public static int GetOpenMemberSlot(int guildnum)
        {
            int refuse = 0;

            for (int i = 1; i < Globals.Max_Guild_Members; i++)
            {
                if (String.IsNullOrEmpty(GStruct.guild[guildnum].memberlist[i]))
                {
                    return i;
                }
            }

            return refuse;
        }
    }
}