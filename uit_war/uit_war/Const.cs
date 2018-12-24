using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace uit_war
{
    class Const
    {
        public static IPAddress IP = IPAddress.Parse(Both.GetLocalIPv4_v2());
        public static int PORT = 9999;
        public static Client client=new Client();
        public static Server server=new Server();
        public static string username;
        //test render
        public static Graphics graphics;
        public static Bitmap backBuffer;
        // Bitmap dùng cho ảnh sprite
        // public static Bitmap sprite_fire;
        public static Bitmap sprite_touch;
        public static Bitmap sprite_Mario_Right, sprite_Mario_Left;
        public static Bitmap sprite_Mario_Attack_right, sprite_mario_attack_left;
        public static Bitmap sprite_Tank_Right,sprite_tank_attack_right;
        public static Bitmap sprite_megaman_left, sprite_megaman_right;
        public static Bitmap sprite_megaman_attack_left, sprite_megaman_attack_right;
        public static Bitmap sprite_hulk_left, sprite_hulk_right;
        public static Bitmap sprite_hulk_attack_left, sprite_hulk_attack_right;
        public static Bitmap sprite_knight_left, sprite_knight_right;
        public static Bitmap sprite_knight_attack_left, sprite_knight_attack_right;
        public static Bitmap spriteHP0;
        public static Bitmap spriteHP10;
        public static Bitmap spriteHP20;
        public static Bitmap spriteHP30;
        public static Bitmap spriteHP40;
        public static Bitmap spriteHP50;
        public static Bitmap spriteHP60;
        public static Bitmap spriteHP70;
        public static Bitmap spriteHP80;
        public static Bitmap spriteHP90;
        public static Bitmap spriteHP100;
        public static Bitmap spriteHP10_blue;
        public static Bitmap spriteHP20_blue;
        public static Bitmap spriteHP30_blue;
        public static Bitmap spriteHP40_blue;
        public static Bitmap spriteHP50_blue;
        public static Bitmap spriteHP60_blue;
        public static Bitmap spriteHP70_blue;
        public static Bitmap spriteHP80_blue;
        public static Bitmap spriteHP90_blue;
        public static Bitmap spriteHP100_blue;
        public static Bitmap spriteMoney0;
        public static Bitmap spriteMoney1;
        public static Bitmap spriteMoney2;
        public static Bitmap spriteMoney3;
        public static Bitmap spriteMoney4;
        public static Bitmap spriteMoney5;
        public static Bitmap spriteMoney6;
        public static Bitmap spriteMoney7;
        public static Bitmap spriteMoney8;
        public static Bitmap spriteMoney9;
        public static Bitmap spriteMoney10;
        public static Bitmap spriteAvailableMoney;
        public static Bitmap spriteHealingSpell;
        // Số thự tự của frame (16 frame ảnh)
        public static int index;
        // dòng hiện tại của frame
        public static int curFrameColumn;
        // cột hiện tại của frame
        public static int curFrameRow;
        //số lượng frames
        public static int numberOfFrames = 12;
        //số lượng sprites trên mỗi hàng, cột
        public static int imageColumns = 3;
        public static int imageRows = 4;
        // size ảnh
        public static int imageWidth = 225;
        public static int imageHeight = 300;
        //list trop
        public static List<Trop> listTrops;
        //list spell
        public static List<Spell> listSpells; 
        //current team
        // true:  left team
        // false: right team
        public static bool currentTeam=true;

        //public static int index_fire;
        //// dòng hiện tại của frame
        //public static int curFrameColumn_fire;
        //// cột hiện tại của frame
        //public static int curFrameRow_fire;
        ////số lượng frames
        //public static int numberOfFrames_fire = 64;
        ////số lượng sprites trên mỗi hàng, cột
        //public static int imageColumns_fire = 8;
        //public static int imageRows_fire = 8;
        //// size ảnh
        //public static int imageWidth_fire = 600;
        //public static int imageHeight_fire = 600;
    }
}
