using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace uit_war
{
    public class RenderTool
    {


        // Vẽ một phần của ảnh sprite
        /// <summary>
        /// render sprite in back buffer with image and specific location
        /// </summary>
        /// <param name="sprite">image to be render</param>
        /// <param name="x">x coordinate </param>
        /// <param name="y">y coordinate</param>
        public static void Render()
        {
            // Lấy đối tượng graphics để vẽ lên back buffer
            Graphics g = Graphics.FromImage(Const.backBuffer);
            g.Clear(Color.White);
            //render background on back buffer
            g.DrawImage(Image.FromFile(Application.StartupPath + "\\Resources\\background2.jpg"), 0, 0);
            //render money bar
            g.DrawImage(Const.spriteAvailableMoney, 78, 1);
            //render list boom
            for (int i = 0; i < Const.listBooms.Count; i++)
                g.DrawImage(Const.listBooms[i].Sprite, Const.listBooms[i].CurrentLocation.X, Const.listBooms[i].CurrentLocation.Y,
                    new Rectangle(Const.curFrameColumn * Const.imageWidth / Const.imageColumns,
                Const.curFrameRow * Const.imageHeight / Const.imageRows, Const.imageWidth / Const.imageColumns, Const.imageHeight / Const.imageRows), GraphicsUnit.Pixel);


            ////render fire border
            g.DrawImage(Const.sprite_touch, 365, 0,
            new Rectangle(Const.curFrameColumn * Const.imageWidth / Const.imageColumns,
        Const.curFrameRow * Const.imageHeight / Const.imageRows, Const.imageWidth / Const.imageColumns, Const.imageHeight / Const.imageRows), GraphicsUnit.Pixel);
            g.DrawImage(Const.sprite_touch, 365, Const.sprite_touch.Height / 4,
            new Rectangle(Const.curFrameColumn * Const.imageWidth / Const.imageColumns,
        Const.curFrameRow * Const.imageHeight / Const.imageRows, Const.imageWidth / Const.imageColumns, Const.imageHeight / Const.imageRows), GraphicsUnit.Pixel);
            g.DrawImage(Const.sprite_touch, 365, 180,
            new Rectangle(Const.curFrameColumn * Const.imageWidth / Const.imageColumns,
        Const.curFrameRow * Const.imageHeight / Const.imageRows, Const.imageWidth / Const.imageColumns, Const.imageHeight / Const.imageRows), GraphicsUnit.Pixel);
            g.DrawImage(Const.sprite_touch, 365, 170 + Const.sprite_touch.Height / 4,
            new Rectangle(Const.curFrameColumn * Const.imageWidth / Const.imageColumns,
        Const.curFrameRow * Const.imageHeight / Const.imageRows, Const.imageWidth / Const.imageColumns, Const.imageHeight / Const.imageRows), GraphicsUnit.Pixel);
            g.DrawImage(Const.sprite_touch, 365, 357,
            new Rectangle(Const.curFrameColumn * Const.imageWidth / Const.imageColumns,
        Const.curFrameRow * Const.imageHeight / Const.imageRows, Const.imageWidth / Const.imageColumns, Const.imageHeight / Const.imageRows), GraphicsUnit.Pixel);
            g.DrawImage(Const.sprite_touch, 365, 340 + Const.sprite_touch.Height / 4,
            new Rectangle(Const.curFrameColumn * Const.imageWidth / Const.imageColumns,
        Const.curFrameRow * Const.imageHeight / Const.imageRows, Const.imageWidth / Const.imageColumns, Const.imageHeight / Const.imageRows), GraphicsUnit.Pixel);
            Const.curFrameColumn = Const.index % Const.imageColumns;
            Const.curFrameRow = Const.index / Const.imageRows;
            //render list spell
            for (int i = 0; i < Const.listSpells.Count; i++)
                g.DrawImage(Const.listSpells[i].Sprite, Const.listSpells[i].CurrentLocation.X, Const.listSpells[i].CurrentLocation.Y,
                    new Rectangle(Const.curFrameColumn * Const.imageWidth / Const.imageColumns,
                Const.curFrameRow * Const.imageHeight / Const.imageRows, Const.imageWidth / Const.imageColumns, Const.imageHeight / Const.imageRows), GraphicsUnit.Pixel);
            // render trops and its HP on back buffer
            for (int i = 0; i < Const.listTrops.Count; i++)
            {
                //render HP
                g.DrawImage(Const.listTrops[i].SpriteHP, Const.listTrops[i].CurrentHPLocation);
                //render trop
                g.DrawImage(Const.listTrops[i].Sprite, Const.listTrops[i].CurrentLocation.X, Const.listTrops[i].CurrentLocation.Y,
                new Rectangle(Const.curFrameColumn * Const.imageWidth / Const.imageColumns,
                Const.curFrameRow * Const.imageHeight / Const.imageRows, Const.imageWidth / Const.imageColumns, Const.imageHeight / Const.imageRows), GraphicsUnit.Pixel);
            }
            g.Dispose();

            // Tăng thứ tự frame để lấy frame tiếp theo
            Const.index++;
            if (Const.index > Const.numberOfFrames)
                Const.index = 0;
            else
                Const.index++;
            // Vẽ lên màn hình
            Const.graphics.DrawImageUnscaled(Const.backBuffer, 0, 0);
        }
    }

}